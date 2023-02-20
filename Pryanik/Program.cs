using Pryanik;
using Pryanik.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.ConfigureNpgsqlContext(builder.Configuration); postgres
builder.Services.ConfigureUseInMemoryDatabase();

builder.Services.ConfigureRepositories();
builder.Services.ConfigureServices();

builder.Services.ConfigureMapper();

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
