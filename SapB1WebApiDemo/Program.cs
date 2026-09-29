
using B1SLayer;
using SapB1WebApiDemo.Services;

namespace SapB1WebApiDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<SLConnection>(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();

                var serviceLayerUrl = configuration["SapB1:ServiceLayerUrl"] ?? throw new InvalidOperationException("SapB1:ServiceLayerUrl is missing.");

                var companyDB = configuration["SapB1:CompanyDb"] ?? throw new InvalidOperationException("SapB1:CompanyDb is missing.");

                var username = configuration["SapB1:Username"] ?? throw new InvalidOperationException("SapB1:Username is missing.");

                var password = configuration["SapB1:Password"] ?? throw new InvalidOperationException("SapB1:Password is missing.");

                return new SLConnection(serviceLayerUrl, companyDB, username, password);
            });

            builder.Services.AddScoped<IBusinessPartnertService, BusinessPartnerService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
