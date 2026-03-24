using love4animalss.Interfaces;
using love4animalss.Repositories;
using love4animalss.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddScoped<ICampaignRepository, CampaignRepository>(); 

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

if (app.Environment.IsDevelopment())
{
    Console.WriteLine("***************************************************");
    Console.WriteLine(" PROYECTO LOVE4ANIMALS CORRIENDO");
    Console.WriteLine(" Perfil de Usuario: http://localhost:5228/v1/users/profile");
    Console.WriteLine(" Lista de Campañas: http://localhost:5228/v1/campaigns");
    Console.WriteLine("***************************************************");
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();