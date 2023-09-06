using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Connection.Interface;
using Connection.Repositories;
using Connection.Settings;

namespace API
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
            services.AddControllers();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<JwtService>();
            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<IStampsRepository, StampsRepository>();
            services.AddScoped<ILakuEmasRepository, LakuEmasRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStockInventoryRepository, StockInventoryRepository>();
            services.AddScoped<IPackagingRepository, PackagingRepository>();
            services.AddScoped<ISouvenirRepository, SouvenirRepository>();
            services.AddScoped<IDataAdminSalesRepository, DataAdminSalesRepository>();
            services.AddScoped<IDataSalesRepository, DataSalesRepository>();
            services.AddScoped<ISalesOrderRepository, SalesOrderRepository>();
            services.AddScoped<IDataCustomerRepository, DataCustomerRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IResellRepository, ResellRepository>();
            services.AddScoped<IParcelRepository, ParcelRepository>();
            services.AddScoped<IStockOutgoingRepository, StockOutgoingRepository>();
            services.AddScoped<IPromoRepository, PromoRepository>();
            services.AddScoped<IDocQCRepository, DocQCRepository>();
            services.AddScoped<IStockIncomingRepository, StockIncomingRepository>();
            services.AddScoped<IRepairRepository, RepairRepository>();
            services.AddScoped<ITitipanRepository, TitipanRepository>();
            services.AddScoped<ICetakanRepository, CetakanRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IAccountingRepository, AccountingRepository>();
            services.AddScoped<IStoneRepository, StoneRepository>();

            services.AddCors();
            services.AddSwaggerGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(o => o.WithOrigins("http://localhost:3000", "https://james.cmk.co.id")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            );

            app.UseAuthorization();

            app.UseSwagger();

            // This middleware serves the Swagger documentation UI
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "JAWS API");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
