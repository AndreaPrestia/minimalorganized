using Microsoft.AspNetCore.Builder;

namespace MinimalOrganized;

public abstract class ApiRouter
{
    
    /// <summary>
    /// Init routers
    /// </summary>
    /// <param name="app"></param>
    public abstract void Init(WebApplication app);
}