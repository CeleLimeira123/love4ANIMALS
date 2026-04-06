using love4animalss.Interfaces;
using love4animalss.Repositories;
using love4animalss.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<ICampaignRepository, CampaignRepository>(); 
builder.Services.AddSingleton<IPostRepository, PostRepository>(); 

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
    Console.WriteLine("***************************************************");
    Console.WriteLine(" PROYECTO LOVE4ANIMALS CORRIENDO");
    Console.WriteLine(" Usuarios:  http://localhost:5228/v1/users");
    Console.WriteLine(" Campañas:  http://localhost:5228/v1/campaigns");
    Console.WriteLine(" Posts:     http://localhost:5228/v1/users/profile"); 
    Console.WriteLine("***************************************************");
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();