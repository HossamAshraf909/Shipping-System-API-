
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shipping.BL.Mappers;
using Shipping.BL.Services;
using Shipping.DAL.Persistent.Data.Context;

using Shipping.DAL.Persistent.UnitOfWork;


namespace Shipping.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            
            builder.Services.AddOpenApi();
            
            
            #region Add Services

                    builder.Services.AddDbContext<ShippingContext>(options =>
                        options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                        );
                    builder.Services.AddScoped<UnitOfWork>();
                    builder.Services.AddAutoMapper(typeof(MapConfig));

                    builder.Services.AddScoped<ProductService>();
                    builder.Services.AddScoped<OrderProductService>();
                    builder.Services.AddScoped<ShippingTypeService>();

            
            #endregion


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(op => op.SwaggerEndpoint("/openapi/v1.json", "v1"));
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
