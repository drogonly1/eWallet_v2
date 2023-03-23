using eWallet.Data.EF;
using eWallet.Data.Entities;
using eWallet.Services;
using eWallet.Services.Catalog.Buyers;
using eWallet.Services.Catalog.Buyers.Services;
using eWallet.Services.Catalog.ConfirmOrderRequests;
using eWallet.Services.Catalog.OrderRequests;
using eWallet.Services.Catalog.System.Users;
using eWallet.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddCors();
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000", "http://localhost:4200")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
        });
        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Add Db
        builder.Services.AddDbContext<EWalletDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("eWalletDb"));
        });

        //
        builder.Services.AddIdentity<AppUser, AppRole>()
            .AddEntityFrameworkStores<EWalletDbContext>()
            .AddDefaultTokenProviders();


        // Get key, Issuer
        string issuer = builder.Configuration.GetValue<string>("Tokens:Issuer");
        string signingKey = builder.Configuration.GetValue<string>("Tokens:Key");
        byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);

        builder.Services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = issuer,
                ValidateAudience = true,
                ValidAudience = issuer,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = System.TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
            };
        });

        // DI from eWallet.Service
        builder.Services.AddTransient<IServiceHandle, ServiceHandle>();
        builder.Services.AddTransient<ICryptoService, CryptoService>();


        builder.Services.AddTransient<IManageBuyerService, ManageBuyerService>();
        builder.Services.AddTransient<IOrderRequestService, OrderRequestService>();
        builder.Services.AddTransient<IConfirmOrderRequestService, ConfirmOrderRequestService>();
        builder.Services.AddTransient<IUserService, UserService>();

        // TEST SERVICE DI
        builder.Services.AddTransient<ITestUserService, TestUserService>();

        builder.Services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
        builder.Services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();

        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"Hello",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement(){
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                             Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });
        });
           
        var app = builder.Build();

        app.UseCors(builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI v1"));
        }

 


        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseRouting();

        app.UseCors();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}