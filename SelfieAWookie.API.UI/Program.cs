using SelfieAWookie.API.UI.ExtensionMethod;

var builder = WebApplication.CreateBuilder(args);

//string? stringConnection = builder.Configuration.GetConnectionString("AuthentificationSelfieContextConnection")
//    ?? throw new InvalidOperationException("Connection string 'AuthentificationUserContextConnection' not found."); ;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// appel des options de CROS
builder.Services.AddCORSSecurity(builder.Configuration);

#region DbContext
builder.Services.AddAllContext(builder.Configuration);  // ajout dans une instand méthode des 2 contexts 
/*builder.Services.AddDbContext<SelfieDbContext>(options =>
{
    options.UseSqlServer(stringConnection);
});
builder.Services.AddDbContext<IdentitySelfieDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityContext"));
});*/
#endregion
#region Injection
/*builder.Services.AddScoped<ISelfieDataLayer, SqlServerSelfieDataLayer>();
builder.Services.AddScoped<ISelfieRepository, SelfieRepository>();

builder.Services.AddScoped<IWookieDataLayer, SqlServerWookieDataLayer>();
builder.Services.AddScoped<IWookieRepository, WookieRepository>();*/
builder.Services.PrepareInjectionData();
#endregion

var app = builder.Build();

// attention avec les middleswares ils ont un ordre d'appel très important voir documentation de Microsoft 
//https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-7.0

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
