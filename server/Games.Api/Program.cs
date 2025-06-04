using Games.Api.Middlewear;
using Games.Core;
using Games.Core.data;
using Games.Core.service;
using Games.Data;
using Games.Data.data;
using Games.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    option.JsonSerializerOptions.WriteIndented = true;
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//הרחבת השימוש ב swagger
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

builder.Services.AddScoped<ICategoryDeta, CategoryDeta>();
builder.Services.AddScoped<ICategoryService, CategoryService>();


builder.Services.AddScoped<IProductData,ProductData>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IUserData, UserData>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IOrderData, OrderData>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddDbContext<DataContext>();


//הזרקת jwt
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "https://localhost:7211",
        ValidAudience = "https://localhost:7211",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SomeLongKeyToGenerateMyJwtTokenAAAAAAAAAAAAAAAAAA"))
    };
});
builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy",
                  builder => builder.WithOrigins("http://localhost:4200")
                             .AllowAnyHeader()
                             .AllowAnyMethod()
                             .AllowCredentials()
                             //.AllowAnyOrigin()
                             );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

//ניהול זהות 
app.UseAuthentication();
// מתן הרשאות בהתאם לזהות
app.UseAuthorization();


//בדיקהת קוד קטגוריה עבור פונקציית הוספת מוצר
app.ValidCategory();

app.MapControllers();

app.Run();

