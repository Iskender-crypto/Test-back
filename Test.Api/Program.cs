
using Microsoft.EntityFrameworkCore;
using Test.Infrastructure.Ef;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql("Host=localhost;Port=5432;Database=Test;Username=root;Password=Iskndr-2003;Include Error Detail=true");
});
 
//
// builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
//     {
//         options.Password.RequireDigit = true;
//         options.Password.RequireLowercase = true;
//         options.Password.RequiredLength = 5;
//     })
//     .AddEntityFrameworkStores<DataContext>()
//     .AddDefaultTokenProviders();
//         
//
//         
// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
// }).AddJwtBearer(options =>
// {
//     options.SaveToken = true;
//     options.RequireHttpsMetadata = false;
//     options.TokenValidationParameters = new TokenValidationParameters()
//     {
//         ValidateIssuer = true,
//         ValidateAudience = true,
//         ValidIssuer = "issuer",
//         ValidAudience = "audience",
//         IssuerSigningKey = new SymmetricSecurityKey("JWTAuthenticationHIGHsecuredPasswordVVVp1OH7Xzyr"u8.ToArray())
//     };
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(builder =>
    {
        builder.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();