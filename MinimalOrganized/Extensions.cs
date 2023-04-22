using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

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

    public static IEndpointConventionBuilder ValidateRequest<T>(this RouteHandlerBuilder builder)
    {
        builder.AddEndpointFilterFactory((context, next) =>
        {
            if (!context.MethodInfo.GetParameters()
                    .Any(t => t.GetCustomAttributes().Any(a => a.GetType() == typeof(FromBodyAttribute)))) return next;
            
            var filter = new ValidatorFilter<T>();
            return invocationContext => filter.InvokeAsync(invocationContext, next);
        });

        return builder;
    }
}