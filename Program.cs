var builder = WebApplication.CreateBuilder(args);
var NuevasReglasCors = "ReglasCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: NuevasReglasCors,
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();

                      });
});
//builder.SetIsOriginAllowed(x => true)


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(NuevasReglasCors);

app.UseAuthorization();

app.MapControllers();

app.Run();
