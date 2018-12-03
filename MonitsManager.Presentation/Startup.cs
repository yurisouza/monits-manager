using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using MonitsManager.Core.Mapper;
using MonitsManager.IoC;
using Swashbuckle.AspNetCore.Examples;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using System.Reflection;

namespace MonitsManager.Presentation
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureSwaggerService(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            AutoMapperConfig.RegisterMappings();
            StartupIoC.RegisterIoC(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ConfigureSwagger(app, env);
            app.UseMvc();
        }

        private void ConfigureSwaggerService(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                string basePath = PlatformServices.Default.Application.ApplicationBasePath;
                string moduleName = GetType().GetTypeInfo().Module.Name.Replace(".dll", ".xml");
                string filePath = Path.Combine(basePath, moduleName);
                //string readme = File.ReadAllText(Path.Combine(basePath, "README.md"));

                //var scheme = Configuration.GetSection("ApiKeyScheme").Get<ApiKeyScheme>();
                //options.AddSecurityDefinition("Authentication", scheme);

                Info info = Configuration.GetSection("Info").Get<Info>();
                //info.Description = readme;
                options.SwaggerDoc(info.Version, info);

                options.IncludeXmlComments(filePath);
                options.IncludeXmlComments(Path.Combine(basePath, "MonitsManager.Models.xml"));
                options.DescribeAllEnumsAsStrings();
                options.OperationFilter<ExamplesOperationFilter>();

            });
        }

        private void ConfigureSwagger(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs"));
            }

            app.UseSwagger(c => c.PreSerializeFilters.Add((swagger, httpReq) => swagger.Host = httpReq.Host.Value));
        }
    }
}
