using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogisticsCommon;
using LogisticsDAL;
using LogisticsIDAL;
using LogisticsLogin;
using LogisticsModel;
using System.Reflection;
using System.IO;
using Autofac;

namespace LogisticsUI
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
            //数据库连接
            Lianjie.LianjieString = Configuration.GetConnectionString("default");
            //注入
            //services.AddTransient<ILogin,Login>();//登录
            //services.AddTransient<IRoleFen, RoloFen>();//分配权限
            //services.AddTransient<IjurisdictionS, jurisdictionS>();//权限
            services.AddTransient<Loginlogin>();//登录
            services.AddTransient<Allocation>();//分配权限 
            services.AddTransient<JurisdictionJ>();//权限
            services.AddTransient<Cars>();//车辆管理
            //跨域
            services.AddControllers();

            services.AddCors(options => options.AddPolicy("cor",
            builder =>
            {
                builder.AllowAnyMethod()
                  .AllowAnyHeader()
                  .SetIsOriginAllowed(_ => true) // =AllowAnyOrigin()
                  .AllowCredentials();
            }));

            //验证及配置
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSwaggerGen(c =>
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LogisticsUI", Version = "v1", Description = "LogisticsUI" });
                });

                // 为 Swagger 设置xml文档注释路径
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // 添加控制器层注释，true表示显示控制器注释
                c.IncludeXmlComments(xmlPath, true);

            });
            
            services.AddSession();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseSession();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LogisticsUI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            //配置Cors跨域
            app.UseCors("cor");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        //Startup类中添加
         public void ConfigureContainer(ContainerBuilder build)
        {
            var bllFilePath = System.IO.Path.Combine(AppContext.BaseDirectory, "LogisticsDAL.dll"); //DDal.dll是依赖注入的层
            build.RegisterAssemblyTypes(Assembly.LoadFile(bllFilePath)).AsImplementedInterfaces();
        }

    }
}
