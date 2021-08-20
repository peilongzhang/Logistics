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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Swashbuckle.AspNetCore.Filters;

namespace LogisticsUI
{
    public class JwtConfig
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string SigningKey { get; set; }
    }
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
            //���ݿ�����
            Lianjie.LianjieString = Configuration.GetConnectionString("default");
            //ע��
            //services.AddTransient<ILogin,Login>();//��¼
            //services.AddTransient<IRoleFen, RoloFen>();//����Ȩ��
            //services.AddTransient<IjurisdictionS, jurisdictionS>();//Ȩ��
            services.AddTransient<Loginlogin>();//��¼
            services.AddTransient<Allocation>();//����Ȩ�� 
            services.AddTransient<JurisdictionJ>();//Ȩ��
            services.AddTransient<Cars>();//��������
            services.AddTransient<Owners>();//��������
            // ����
            services.AddControllers();

            services.AddCors(options => options.AddPolicy("cor",
            builder =>
            {
                builder.AllowAnyMethod()
                  .AllowAnyHeader()
                  .SetIsOriginAllowed(_ => true) // =AllowAnyOrigin()
                  .AllowCredentials();
            }));

            //jwt
            var jwtconfig = Configuration.GetSection("Jwt").Get<JwtConfig>();
            // JWT�����֤
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(option =>
            {
                option.RequireHttpsMetadata = false;
                option.SaveToken = true;
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    ValidIssuer = jwtconfig.Issuer,
                    ValidAudience = jwtconfig.Audience,
                    ValidateIssuer = false,
                    ValidateLifetime = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtconfig.SigningKey)),
                    // �������ʱ�䣬�ܵ���Чʱ��������ʱ�����jwt�Ĺ���ʱ�䣬��������ã�Ĭ����5����
                    ClockSkew = TimeSpan.FromSeconds(10)
                };
            });

            services.AddOptions().Configure<JwtConfig>(Configuration.GetSection("Jwt"));

            //��֤������
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LogisticsManagementSystem_API", Version = "v1" });
                //#region swagger��JWT��֤
                //����Ȩ��С��
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                //��header�����token�����ݵ���̨
                c.OperationFilter<SecurityRequirementsOperationFilter>();
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���)ֱ���������������Bearer {token}(ע������֮����һ���ո�) \"",
                    Name = "Authorization",//jwtĬ�ϵĲ�������
                    In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
                    Type = SecuritySchemeType.ApiKey
                });
                // #endregion
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
            //����Cors����
            app.UseCors("cor");

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
           
        }


        //Startup�������
         public void ConfigureContainer(ContainerBuilder build)
        {
            var bllFilePath = System.IO.Path.Combine(AppContext.BaseDirectory, "LogisticsDAL.dll"); //DDal.dll������ע��Ĳ�
            build.RegisterAssemblyTypes(Assembly.LoadFile(bllFilePath)).AsImplementedInterfaces();
        }

    }
}
