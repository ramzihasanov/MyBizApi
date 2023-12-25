using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using MyBiz.DAL;
using MyBiz.DTOs.Position;
using MyBiz.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddFluentValidation(opt =>
{
    opt.RegisterValidatorsFromAssembly(typeof(PositionGetDto).Assembly);
});
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MapProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt => {
    opt.UseSqlServer("Server=;Database=MyBizApi;Trusted_Connection=True;TrustServerCertificate=true");

});
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
