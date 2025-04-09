
using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shipping.BL.Mappers;
using Shipping.BL.Services;
using Shipping.DAL.Entities.Identity;
using Shipping.DAL.Persistent.Data.Context;

using Shipping.DAL.Persistent.UnitOfWork;


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
                    builder.Services.AddAutoMapper(typeof(MapConfig));
                    builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

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


            #endregion
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ShippingContext>()
    .AddDefaultTokenProviders();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                ShippingContextSeed.Initialize(serviceProvider, userManager);
               
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(op => op.SwaggerEndpoint("/openapi/v1.json", "v1"));
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);

            app.MapControllers();

            app.Run();
        }
    }
}
