using CWProject.Data;
using CWProject.Data.Repositories;
using CWProject.Data.Repositories.Interfaces;
using CWProject.Data.SeedData;
using CWProject.Services;
using CWProject.Services.Interfaces;
using DinkToPdf.Contracts;
using DinkToPdf;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//DBConnection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//Authorization
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standart Authorization header using the Bearer scheme(\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

//Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opsions =>{
        opsions.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

// services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IVillasService, VillasService>();
builder.Services.AddScoped<IAmenitiesService, AmenitiesService>();
builder.Services.AddScoped<ILocationTypeService, LocationTypeService>();
builder.Services.AddScoped<IVillaAmenitiesService, VillaAmenitiesService>();

// repositories
builder.Services.AddScoped<IVillasRepository, VillasRepository>();
builder.Services.AddScoped<IAmenitiesRepository, AmenitiesRepository>();
builder.Services.AddScoped<ILocationTypeRepository, LocationTypeRepository>();
builder.Services.AddScoped<IVillaAmenitiesRepository, VillaAmenitiesRepository>();

//AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

//PDF
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
builder.Services.AddScoped<IPDFReport, PDFReport>();

var app = builder.Build();

//SeedData
using (var scope = app.Services.CreateScope())
{
    DbInitializer.Seed(scope.ServiceProvider.GetRequiredService<AppDbContext>());
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
    