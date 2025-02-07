using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using TaskManagementAPI.Data;
using TaskManagementAPI.Services; // UserService ve IUserService için gerekli
using TaskManagementAPI.Hubs;
using Microsoft.AspNetCore.SignalR;


var builder = WebApplication.CreateBuilder(args);

var jwtSettings = builder.Configuration.GetSection("Jwt");
var secretKey = jwtSettings["Key"];

if (string.IsNullOrEmpty(secretKey))
{
    throw new ArgumentNullException("JWT Key is missing in appsettings.json");
}

// JWT kimlik doðrulama ayarlarýný yapýyoruz
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

// Baðlantý dizesini ekliyoruz
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Servisleri ekliyoruz

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Swagger'ý ekliyoruz
builder.Services.AddScoped<TaskManagementAPI.Services.IUserService, TaskManagementAPI.Services.UserService>();
builder.Services.AddScoped<YourService>();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication();
builder.Services.AddSignalR();



var app = builder.Build();

{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();  // Authentication middleware'ini ekliyoruz
app.UseAuthorization();   // Authorization middleware'ini ekliyoruz

app.MapControllers();
app.Run();
