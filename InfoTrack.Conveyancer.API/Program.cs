using InfoTrack.Conveyancer.API.Middlewares;
using InfoTrack.Conveyancer.Domain;
using InfoTrack.Conveyancer.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISettlementRepository, SettlementRepository>();

builder.Services.AddDomainServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<UserExceptionHandlerMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();