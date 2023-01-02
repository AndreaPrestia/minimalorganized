namespace MinimalOrganized.ExampleApis.Routers;

public class TestApiRouter : ApiRouter
{
    public override void Init(WebApplication app)
    {
        app.MapGet("/api/v1/router/test", () => "ApiRouter is working properly :)");
    }
}