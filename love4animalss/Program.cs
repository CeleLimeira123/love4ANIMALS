using love4animalss.Interfaces;
using love4animalss.Repositories;
using love4animalss.Services;
using Scalar.AspNetCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.OpenApi; 
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<ICampaignRepository, CampaignRepository>(); 
builder.Services.AddSingleton<IPostRepository, PostRepository>(); 
builder.Services.AddSingleton<ICommentRepository, CommentRepository>();
builder.Services.AddSingleton<IDonationRepository, DonationRepository>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers()
    .AddJsonOptions(options => 
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddOpenApi("v1", options => {
    options.AddDocumentTransformer((document, context, cancellationToken) => {
        document.Info.Title = "Love4Animals - Dashboard de Gestión";
        document.Info.Version = "v1";
        document.Info.Description = "API para la gestión de donaciones, campañas y rescate animal.";

        foreach (var path in document.Paths)
        {
            foreach (var operation in path.Value.Operations)
            {
                if (!string.IsNullOrEmpty(operation.Value.Summary))
                {
                    operation.Value.OperationId = operation.Value.Summary.Replace(" ", "");
                }
            }
        }
        return Task.CompletedTask;
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); 

    app.MapScalarApiReference(options => 
    {
        options.WithTitle("Love4Animals - API Docs")
               .WithTheme(ScalarTheme.Moon)
               .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
               // Nota: WithSidebar(true) ya no es necesario, es el comportamiento por defecto
    });

    Console.WriteLine("\n" + new string('=', 55));
    Console.WriteLine("  LOVE4ANIMALS BACKEND - ¡SISTEMA INICIADO!");
    Console.WriteLine("  URL SCALAR: http://localhost:5228/scalar/v1");
    Console.WriteLine(new string('=', 55) + "\n");
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();