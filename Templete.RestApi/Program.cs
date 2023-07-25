using Templete.Persistanse.EF;
using Microsoft.EntityFrameworkCore;
using Templete.Services.Contracts;
using Templete.Services.Complexes.Contracts;
using Templete.Persistanse.EF.Complexes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EFDataContext>(_ =>
    _.UseSqlServer("Server=.;Database=ComplexManagementFinal1;Trusted_Connection=True;"));
builder.Services.AddScoped<UnitOfWork, EFUnitOfWork>();
builder.Services.AddScoped<ComplexService,ComplexAppService>();
builder.Services.AddScoped<ComplexRepository,EFComplexRepository>();



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