using Autofac;
using Autofac.Extensions.DependencyInjection;
using demoSqlSaveJson.Infraestructure.AutofacModule;
using demoSqlSaveJson.Infraestructure.NativeInjector;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace demoSqlSaveJson
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration) => _configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc(options =>
            {
                //options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.DescribeAllEnumsAsStrings();
                c.SwaggerDoc("v1", new Info { Title = "Service Demo", Version = "V1" });
            });

            services.AddSingleton(_configuration);
            services.AddOptions();

            RegisterServices(services);

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule(new QueriesModule(_configuration["ConnectionString"]));

            var container = builder.Build();

            return container.Resolve<IServiceProvider>();
        }

        private static void RegisterServices(IServiceCollection services) => BootStrapper.RegisterServices(services);

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
                      .AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader());

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api/v1/swagger.json", "Service");
                c.RoutePrefix = "api/swagger";
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
