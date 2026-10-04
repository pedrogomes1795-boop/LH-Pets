var builder = WebApplication.CreateBuilder(args);

// Adiciona os controladores
builder.Services.AddControllers();

// Adiciona os serviços do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura o pipeline para o ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Gera o endpoint /swagger/v1/swagger.json
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "LHPets v1");
        c.RoutePrefix = "swagger"; // Mantém o Swagger acessível na raiz /swagger
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();