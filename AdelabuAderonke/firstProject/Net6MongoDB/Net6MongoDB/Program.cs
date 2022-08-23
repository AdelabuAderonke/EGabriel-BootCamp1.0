using MongoDB.Driver;
using MongoDB.Entities;
using Net6MongoDB.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
await DB.InitAsync("UserManagement",
    MongoClientSettings.FromConnectionString(
        "mongodb+srv://Aderonke:Abdulsalam123@cluster0.aognqfs.mongodb.net/?retryWrites=true&w=majority"));

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
