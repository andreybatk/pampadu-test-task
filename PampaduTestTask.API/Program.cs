using Npgsql;
using PampaduTestTask.API.Services;
using PampaduTestTask.DB;
using PampaduTestTask.DB.Repositories;
using System.Data;

namespace PampaduTestTask.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpClient();
            builder.Services.AddHostedService<PriceBackgroundService>();
            builder.Services.AddScoped<IDbConnection>(s => new NpgsqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IPriceRepository, PriceRepository>();
            builder.Services.AddScoped<EnsureData>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var ensureData = scope.ServiceProvider.GetRequiredService<EnsureData>();
                ensureData.CreateTables();
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.MapControllers();
            app.Run();
        }
    }
}