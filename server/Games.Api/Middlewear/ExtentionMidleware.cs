namespace Games.Api.Middlewear
{
    public static class ExtentionMidleware
    {
        //מימוש middleware 
        public static IApplicationBuilder ValidCategory(this IApplicationBuilder app)
        {
           return app.UseMiddleware< ValidCategory>();
        }
    }
}
