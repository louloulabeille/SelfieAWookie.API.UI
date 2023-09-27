using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Application.Repository;
using SelfieAWookie.Core.Selfies.Infrastructure.DataBase;
using SelfieAWookie.Core.Selfies.Infrastructure.DataLayers;
using SelfieAWookie.Core.Selfies.Interface.Infrastructure;
using SelfieAWookie.Core.Selfies.Interface.Repository;
using SelfieAWookie.API.UI.ExtensionMethod;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

string? stringConnection = builder.Configuration.GetConnectionString("AuthentificationSelfieContextConnection")
    ?? throw new InvalidOperationException("Connection string 'AuthentificationUserContextConnection' not found."); ;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// appel des options de CROS
builder.Services.GetAddCorsOption(builder.Configuration);

#region DbContext
builder.Services.AddDbContext<SelfieDbContext>(options =>
{
    options.UseSqlServer(stringConnection);
});
builder.Services.AddDbContext<IdentitySelfieDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityContext"));
});
#endregion
#region Injection
/*builder.Services.AddScoped<ISelfieDataLayer, SqlServerSelfieDataLayer>();
builder.Services.AddScoped<ISelfieRepository, SelfieRepository>();

builder.Services.AddScoped<IWookieDataLayer, SqlServerWookieDataLayer>();
builder.Services.AddScoped<IWookieRepository, WookieRepository>();*/
builder.Services.PrepareInjectionData();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseStatusCodePagesWithRedirects("api/v1/ErrorsController/{0}"); //-- gestion des erreurs -- faire le controller error pour retourné un object error

app.UseHttpsRedirection();
app.UseStaticFiles(); // pour mettre en place le répertoire wwwroot s'il n'existe pas - il faut le créer- possible de changer le répetoire du root de l'application en applicant des options
app.UseCors(SecurityCROSMethod.Policy2);

app.UseAuthorization();

app.MapControllers();

app.Run();
