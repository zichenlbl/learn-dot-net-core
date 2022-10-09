using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace SwaggerDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {//API 信息和说明
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "An ASP.NET Core Web API for managing ToDo items", //描述
                    TermsOfService = new Uri("https://example.com/terms"), //服务条款
                    Contact = new OpenApiContact
                    {//联系
                        Name = "Example Contact",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {//许可证
                        Name = "Example License",
                        Url = new Uri("https://example.com/license")
                    }
                });
                //XML 注释 启用：<PropertyGroup><GenerateDocumentationFile>true</GenerateDocumentationFile></PropertyGroup>
                // using System.Reflection;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; //获取程序集的简单名称。
                // 基于XML注释文件为操作、参数和模式注入人性化的描述
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename)); //将多个字符串组合成一个路径。
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //Swagger
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"); //IIS或反向代理
                    options.RoutePrefix = "api"; //string.Empty; //要在应用的根 (https://localhost:<port>/) 处提供 Swagger UI，请将 RoutePrefix 属性设置为空字符串（string.Empty）
                    //options.InjectStylesheet("/swagger-ui/custom.css"); //自定义 UI 样式文件
                    //options.InjectJavascript("/swagger-ui/zh_CN.js"); // 加载中文包
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
