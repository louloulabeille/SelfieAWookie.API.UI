using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Application.Repository;
using SelfieAWookie.Core.Selfies.Infrastructure.DataBase;
using SelfieAWookie.Core.Selfies.Infrastructure.DataLayers;
using SelfieAWookie.Core.Selfies.Interface.Infrastructure;
using SelfieAWookie.Core.Selfies.Interface.Repository;

var builder = WebApplication.CreateBuilder(args);

string? stringConnection = builder.Configuration.GetConnectionString("AuthentificationSelfieContextConnection")
    ?? throw new InvalidOperationException("Connection string 'AuthentificationUserContextConnection' not found."); ;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DbContext
builder.Services.AddDbContext<SelfieDbContext>(options =>
{
    options.UseSqlServer("Server=localhost;Database=Selfie-Dev;User Id=sa;Password=ieupn486jadF&;TrustServerCertificate=true;");
});
#endregion
#region Injection
builder.Services.AddScoped<ISelfieDataLayer, SqlServerSelfieDataLayer>();
builder.Services.AddScoped<ISelfieRepository, SelfieRepository>();

builder.Services.AddScoped<IWookieDataLayer, SqlServerWookieDataLayer>();
builder.Services.AddScoped<IWookieRepository, WookieRepository>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseStatusCodePagesWithRedirects("api/v1/ErrorsController/Error{0}"); //-- gestion des erreurs -- faire le controller error pour retourné un object error

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
