using InfraStructure;
using Managers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<PlantContext>().AddDefaultTokenProviders();
builder.Services.AddDbContext<PlantContext>(c => { c.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                       .UseLazyLoadingProxies(); },ServiceLifetime.Scoped);

builder.Services.AddControllers();

//Add Your Manager 
builder.Services.AddScoped<CartManager>();
builder.Services.AddScoped<CartProductManager>();
builder.Services.AddScoped<DelivaryDetailsManager>();
builder.Services.AddScoped<OrderedProductManager>();
builder.Services.AddScoped<OrderManager>();
builder.Services.AddScoped<PhoneNumberManager>();
builder.Services.AddScoped<ProductManager>();
builder.Services.AddScoped<ReviewManager>();
builder.Services.AddScoped<TokenManager>();
builder.Services.AddScoped<AccountManager>();
builder.Services.AddScoped<PlantGrowthMangaer>();
builder.Services.AddScoped<PhoneNumberManager>();
builder.Services.AddScoped<PlantUsageManager>();
builder.Services.AddScoped<ToolUsageManager>();






// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JWTToken_Auth_API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
}); // configuration to swagger 


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = false,
        ValidateActor = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JwtSettings:Key"]))
    };
    
});

builder.WebHost.UseUrls("http://localhost:5161", "https://localhost:7161");
var app = builder.Build();

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
