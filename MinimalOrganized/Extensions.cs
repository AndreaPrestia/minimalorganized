using Microsoft.AspNetCore.Builder;

namespace MinimalOrganized;

public static class Extensions
{
    public static void UseApiRouters(this WebApplication app)
    {
        AppDomain.CurrentDomain.GetAssemblies().First(x => x.GetName().Name == AppDomain.CurrentDomain.FriendlyName)
            .GetTypes().Where(t =>
                t.IsSubclassOf(typeof(ApiRouter)) && !t.IsInterface
                                                  && !t.IsAbstract && !t.IsInterface).ToList().ForEach(t =>
            {
                var instance = (ApiRouter)Activator.CreateInstance(t)!;

                if (instance == null!)
                {
                    throw new ApplicationException($"Cannot create an instance of {t.Name}");
                }

                instance.Init(app);
            });
    }
}