namespace CrudProductManagement.Configurations
{
    internal static class CorsConfig
    {
        internal static IServiceCollection AddCorsDocumentation(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("MastersPolicy", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            return services;
        }

        internal static IApplicationBuilder UseCorsDocumentation(this IApplicationBuilder app)
        {
            app.UseCors("MastersPolicy");
            return app;
        }
    }
}
