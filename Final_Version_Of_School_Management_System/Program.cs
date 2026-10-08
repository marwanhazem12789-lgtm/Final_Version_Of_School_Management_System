using Final_Version_Of_School_Management_System.GenaricRepos;
using Final_Version_Of_School_Management_System.Models;
using Final_Version_Of_School_Management_System.Unit_Of_Work;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Final_Version_Of_School_Management_System.AllCustoms;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; 
    options.SaveToken = true; 
    options.TokenValidationParameters = new TokenValidationParameters 
    {
        ValidateIssuerSigningKey = true, 
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true, 
        ValidIssuer = builder.Configuration["Jwt:Issuer"], 
        ValidateAudience = true, 
        ValidAudience = builder.Configuration["Jwt:Audience"], 
        ClockSkew = TimeSpan.Zero 
    };
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>(i => i.UseSqlServer(builder.Configuration.GetConnectionString("C")));
builder.Services.AddScoped<IUnitOfWork , UnitOfWork>();
builder.Services.AddScoped(typeof(IGenaricRepo<>) ,typeof(GenaricRepo<>));
builder.Services.AddScoped<IAuthRepo ,  AuthRepo>();
builder.Services.AddAutoMapper(typeof(Program));

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
