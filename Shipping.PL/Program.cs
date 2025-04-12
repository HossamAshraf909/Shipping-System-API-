
using System.Text;
using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shipping.BL.Mappers;
using Shipping.BL.Services;
using Shipping.BL.Services.Imodel;
using Shipping.BL.Services.Shipping.BL.Services;
using Shipping.DAL.Entities.Identity;
using Shipping.DAL.Persistent.Data.Context;

using Shipping.DAL.Persistent.UnitOfWork;
using Shipping.PL.Helpers;


namespace Shipping.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                     .AddJsonOptions(options =>
                     {
                         options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                     });
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

            builder.Services.AddOpenApi();
       
        

            #region Add Services
            //allow cors
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });
            builder.Services.AddDbContext<ShippingContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                );
            // Add Identity
            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
               .AddEntityFrameworkStores<ShippingContext>()
               .AddDefaultTokenProviders();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(options =>
              {
                      options.RequireHttpsMetadata = false;
                      options.SaveToken = true;
                  
                      options.TokenValidationParameters = new TokenValidationParameters
                      {
                          ValidateIssuer = true,
                          ValidateAudience = true,
                          ValidateLifetime = true,
                          ValidateIssuerSigningKey = true,
                          ValidIssuer = builder.Configuration["JWT:Issuer"],
                          ValidAudience = builder.Configuration["JWT:Audience"],
                          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                      };
              });


            builder.Services.AddAutoMapper(typeof(MapConfig));

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<OrderProductService>();
            builder.Services.AddScoped<ShippingTypeService>();
            builder.Services.AddScoped<BranchService>();
            builder.Services.AddScoped<GovernorateService>();
            builder.Services.AddScoped<CityService>();
            builder.Services.AddScoped<WeightPriceService>();
            builder.Services.AddScoped<OrderService>();
            builder.Services.AddScoped<OrderReportService>();
            builder.Services.AddScoped<VillageDeliveryService>();
            builder.Services.AddScoped<DeliveryService>();
            builder.Services.AddScoped<EmployeeService>();
            builder.Services.AddScoped<MerchantService>();
            builder.Services.AddScoped<ITokenGeneration, TokenGeneration>();
            builder.Services.AddScoped<DashboardServices>();


            builder.Services.AddScoped<AuthService>();



            #endregion

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                ShippingContextSeed.Initialize(serviceProvider, userManager);
                PermissionSeeder.SeedRolesAndPermissions(serviceProvider);

            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(op => op.SwaggerEndpoint("/openapi/v1.json", "v1"));
            }

            app.UseHttpsRedirection();
            
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);

            app.MapControllers();

            app.Run();
        }
    }
}
