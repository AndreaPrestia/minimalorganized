namespace MinimalOrganized.ExampleApis.Routers;

public class TestApiRouter : ApiRouter
{
    public override void Init(WebApplication app)
    {
        app.MapGet("/api/v1/router/test", () => "ApiRouter is working properly :)");

        app.MapPost("/api/v1/router/test", (TestRequestModel request) => "ApiRouter is working properly :)").ValidateRequest<TestRequestModel>();
    }
}