using System;
using ExamApp.Extensions;
using ExamApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ExamApp;

public class Program
{
    public static void Main(string[] args)
    {
        CreateApp(args).Run();
    }

    public static WebApplication CreateApp(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddTransient<IStudentsService, StudentsService>();
        builder.Services.AddTransient<ILogging, Logging>();

        //app.UseKestrel((options) =>
        //{
        //    // Do not add the Server HTTP header.
        //    options.AddServerHeader = false;
        //});
        builder.Services.AddHsts(options =>
        {
            options.IncludeSubDomains = true;
            options.MaxAge = TimeSpan.FromDays(365);
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        /* Adding global Exception handling instead of writing try catch block for all the methods */
        app.ConfigureExceptionHandler();

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        app.Map("languages", (LanguageService service) => service.GetLanguages());

        /* Security Headers */

        app.UseReferrerPolicy(options => options.NoReferrer());
        app.UseXContentTypeOptions();
        app.UseXXssProtection(options => options.EnabledWithBlockMode());
        app.UseXfo(options => options.Deny());
        app.UseCsp(options => options
                            .BlockAllMixedContent()
                            .DefaultSources(s => s.Self())
                            .ScriptSources(s => s.Self().UnsafeInline().CustomSources("https://ajax.aspnetcdn.com"))
                            .StyleSources(s => s.Self())
                            .StyleSources(s => s.UnsafeInline())
                            .StyleSources(s => s.CustomSources("https://fonts.googleapis.com"))
                            .FontSources(s => s.Self())
                            .FontSources(s => s.CustomSources("https://fonts.gstatic.com"))
                        );


        return app;
    }
}
