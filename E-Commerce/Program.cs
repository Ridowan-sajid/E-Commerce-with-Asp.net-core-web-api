using ECommerce.DAL.Repository;
using ECommerce.DAL.Repository.IRepository;
using ECommerce.Models.EntityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Db Added
builder.Services.AddDbContext<ApplicationDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Add DI  
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddDbContext<ApplicationDbContext>();

//Add Identity services
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    //options.SignIn.RequireConfirmedAccount = true;
    options.Tokens.EmailConfirmationTokenProvider = "E-Commerce";
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>("E-Commerce")
    .AddDefaultTokenProviders();




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
