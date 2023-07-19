using ComplexManagement1.Persistance.EF;
using ComplexManagement1.Persistance.EF.Complexes;
using ComplexManagement1.Services.Complexes;
using ComplexManagement1.Services.Complexes.Contracts;
using ComplexManagement1.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ComplexManagement1.RestApi
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
            builder.Services.AddDbContext<EFDataContext>(option => option.UseSqlServer("Server=.;Database=ComplexManagement1;Trusted_Connection=True;"));
            builder.Services.AddScoped<ComplexService,ComplexAppService>();
            builder.Services.AddScoped<ComplexRepository, EFComplexRepository>();
            builder.Services.AddScoped<UnitOfWork,EFUnitOfWork>();

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