using InfraStructure;
using Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<PlantContext>().AddDefaultTokenProviders();
builder.Services.AddDbContext<PlantContext>(c => { c.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                       .UseLazyLoadingProxies(); },ServiceLifetime.Scoped);

builder.Services.AddControllers();

//Add Your Manager 
builder.Services.AddScoped<CartManager>();
builder.Services.AddScoped<CartProductManager>();
builder.Services.AddScoped<CategoryManager>();
builder.Services.AddScoped<DelivaryDetailsManager>();
builder.Services.AddScoped<OrderedProductManager>();
builder.Services.AddScoped<OrderManager>();
builder.Services.AddScoped<PhoneNumberManager>();
builder.Services.AddScoped<ProductManager>();
builder.Services.AddScoped<ReviewManager>();
builder.Services.AddScoped<TokenManager>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); //need configuration to swagger 


//jwttttt


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
