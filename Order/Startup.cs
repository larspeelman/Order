using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Order_Services.Users;
using Order_Api.Helpers;
using Order_Domain.Users;
using Microsoft.AspNetCore.Authentication;
using Order_Api.Helper;
using Order_Services.items;
using Order_Domain.items;
using Order_Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Order.Data;
using System.Security.Claims;

namespace Order
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Order_Api", Version = "v1" });
            });
            services.AddAuthentication("BasicAuthentication")
               .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
            services.AddCors();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IitemService, itemService>();

            services.AddSingleton<IUserMapper, UserMapper>();
            services.AddSingleton<IItemMapper, ItemMapper>();
            services.AddSingleton<IItemGroupMapper, ItemGroupMapper>();
            services.AddSingleton<IOrderMapper, OrderMapper>();

            services.AddDbContext<OrderDbContext>(options =>
                options
                .UseSqlServer(Configuration.GetConnectionString("OrderDb")));

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                    policy.RequireClaim(ClaimTypes.Role, "1", "2"));
                options.AddPolicy("Customer", policy =>
                    policy.RequireClaim(ClaimTypes.Role, "2"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
            app.Run(async context =>
            {
                context.Response.Redirect("/swagger");
            });
        }
    }
}
