# minimalorganized
This repo contains a way to organize the .NET minimal api in a clean manner, keeping the Program.cs light. 
This approach is used on a production environment.

The usage is very simple, as shown in the project **MinimalOrganized.ExampleApis**.

**How to use it?**

The configuration is very simple and straight-forward. It's only a line of code in **Program.cs** (or where you init your app).

**Program.cs**

In Program.cs just add this line of code:

```
app.UseApiRouters()
```
it maps the ApiRouter implementations that will contain the endpoints divided by entity, domain, etc..

**Examples**

In Routers directory there is an ApiRouter example. It contains an Init method that takes into account a WebApplication object that will provide the endpoints to map.

Here the complete example:

```
namespace MinimalOrganized.ExampleApis.Routers;

public class TestApiRouter : ApiRouter
{
    public override void Init(WebApplication app)
    {
        app.MapGet("/api/v1/router/test", () => "ApiRouter is working properly :)");
    }
}
```

Thats it! 

I have implemented this kind of approach in a production environment that needed a lot of endpoints. I hated to bloat my Program.cs with regions containing the endpoints :D 
