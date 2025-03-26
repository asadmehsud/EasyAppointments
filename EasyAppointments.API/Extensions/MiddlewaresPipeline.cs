namespace EasyAppointments.API.Extensions
{
    public static class MiddlewaresPipeline
    {
        public static WebApplication AddMiddlewares(this WebApplication app)
        {
           
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(option =>
                {
                    option.SwaggerEndpoint("swagger/v1/swagger.json", "EasyAppointments V1");
                    option.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();
            app.UseCookiePolicy();
            app.UseCors("AllowRazorUI");
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            return app;
        }
    }
}
