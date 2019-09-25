using System;
using VueCliMiddleware;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.Extensions.DependencyInjection;
using CodeBattle.PointWar.Server.Models;
using CodeBattle.PointWar.Server.Services;
using CodeBattle.PointWar.Server.Interfaces;
using Microsoft.AspNetCore.HttpOverrides;

namespace CodeBattle.PointWar.Server
{
  public class Startup
  {

    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.Configure<PlayersDatabaseSettings>(
        Configuration.GetSection(nameof(PlayersDatabaseSettings)));

      services.AddSingleton<IPlayersDatabaseSettings>(sp =>
        sp.GetRequiredService<IOptions<PlayersDatabaseSettings>>().Value);
      
      services.AddSingleton<PlayerService>();

      services.Configure<BotsDatabaseSettings>(
        Configuration.GetSection(nameof(BotsDatabaseSettings)));

      services.AddSingleton<IBotsDatabaseSettings>(sp =>
        sp.GetRequiredService<IOptions<BotsDatabaseSettings>>().Value);

      services.AddSingleton<BotService>();

            services.AddMvc()
        .AddJsonOptions(options => options.UseMemberCasing())
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

      // In production, the files will be served from this directory
      services.AddSpaStaticFiles(configuration =>
      {
        configuration.RootPath = "wwwroot/dist";
      });

      services.Configure<CookiePolicyOptions>(options =>
      {
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });

      services.AddCors(options => options.AddPolicy("CorsPolicy",
        builder =>
        {
          builder.AllowAnyMethod().AllowAnyHeader()
                      .WithOrigins("http://localhost:80")
                      .AllowCredentials();
        }));

      // Инициализация сервиса SignalR
      services.AddSignalR(hubOptions =>
      {
              // Возвращает клиенту детальное описание возникшей ошибки 
              //(при ее возникновении)
              hubOptions.EnableDetailedErrors = true;
      });

      services.AddScoped<ICodeBattle<Map>, MapService>();
      services.AddScoped<ICodeBattle<User>, RegService>();
      services.AddDistributedMemoryCache();
      services.AddSession(options =>
      {
        options.CookieName = ".CodeBattle.Session";
        options.IdleTimeout = TimeSpan.FromSeconds(3600);
      });
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
        //app.UseHttpsRedirection();
      }

      app.UseStaticFiles();
      app.UseSpaStaticFiles();      
      app.UseCookiePolicy();
      app.UseCors("CorsPolicy");

      app.UseMvc(routes =>
      {
        routes.MapRoute(
            name: "default",
            template: "{controller}/{action=Index}/{id?}"
        );
      });

      app.UseSignalR(routes =>
      {
        routes.MapHub<BotCommands>("/command",
                  options =>
              {
                      // Настраивает транспорт WebSocket.
                      options.Transports = HttpTransportType.LongPolling | HttpTransportType.WebSockets;
              });
      });

      //спецаильно, чтобы работало с обратным прокси под nginx
      app.UseForwardedHeaders(new ForwardedHeadersOptions
      {
          ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
      });

      app.UseSpa(spa =>
      {
        spa.Options.SourcePath = "wwwroot";
#if DEBUG
        if (env.IsDevelopment())
        {
          spa.UseVueCli(npmScript: "serve", port: 8080, regex: "Compiled ");
          spa.UseProxyToSpaDevelopmentServer("http://localhost:8080");
        }
#endif
      });
    }
  }
}
