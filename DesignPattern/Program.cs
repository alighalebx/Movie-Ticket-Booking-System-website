using DesignPattern;
//using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors();

builder.Services.AddSwaggerGen();

//    var emailConfig = Configuration
//            .GetSection("EmailConfiguration")
//            .Get<EmailConfiguration>();
//    builder.Services.AddSingleton(emailConfig);


//Services.Configure<EmailConfiguration>(Configuration.GetSection("MailSettings"));


builder.Services.AddControllers();
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MovieTicketSystemContext>(Options=>Options.UseSqlServer(connection));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();



