using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SneakerShop.Core.Models.Auth;
using SneakerShop.Core.Services;
using SneakerShop.Core.Services.Entities;
using SneakerShop.Core.Services.Entities.Impl;
using SneakerShop.Core.Services.Impl;
using SneakerShop.Core.Services.Users;
using SneakerShop.DataAdapters.ApplicationContexts;
using SneakerShop.DataAdapters.Contracts.Repositories.Intf;
using SneakerShop.DataAdapters.Map.Profiles;
using SneakerShop.DataAdapters.Repositories.Impl;
using SneakerShop.WebAPI.Infrastructure.ModelBinderProviders;
using SneakerShop.WebAPI.Services.Impl;
using System.Globalization;

SetDefaultCulture();

var builder = WebApplication.CreateBuilder(args);

RegisterControllersWithServices(builder);

var app = builder.Build();
// ×ÅÊÍÓÒÜ ÍÀ XSS ÓßÇÂÈÌÎÑÒÜ !!!
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();


void RegisterControllersWithServices(WebApplicationBuilder builder)
{
    builder.Services.AddSwaggerGen(x =>
    {
        x.SwaggerDoc("v1", new OpenApiInfo { Title = "SneakerShop API", Version = "v1" });
    });

    builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

    var connString = builder.Configuration.GetConnectionString("PGDatabaseConnectionString");

    builder.Services.AddDbContext<ApplicationContext>(options =>
        options.UseNpgsql(connString,
            options =>
            {
                options.SetPostgresVersion(new Version(14, 9, 0));
                options.MigrationsAssembly("SneakerShop.DataAdapters");
            }));

    builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>(opts =>
    {
        opts.User.RequireUniqueEmail = true;
        opts.Password.RequiredLength = 4;
        opts.Password.RequireNonAlphanumeric = false;
        opts.Password.RequireLowercase = false;
        opts.Password.RequireUppercase = false;
        opts.Password.RequireDigit = false;

        opts.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        opts.Lockout.MaxFailedAccessAttempts = 5;
        opts.Lockout.AllowedForNewUsers = true;
    }).AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

    builder.Services.ConfigureApplicationCookie(options =>
    {
        options.Cookie.Name = "SneakerShop.Identity.Cookie";
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.SlidingExpiration = true;
    });

    builder.Services.AddScoped<IDbEntitiesRepository, DbEntitiesRepository>();

    builder.Services.AddTransient<IAutificationService, AutificationService>();
    builder.Services.AddTransient<IGoodTypesService, GoodTypesService>();
    builder.Services.AddTransient<IGoodSubtypesService, GoodSubtypesService>();
    builder.Services.AddTransient<IDiscountTypesService, DiscountTypesService>();
    builder.Services.AddTransient<IGoodsService, GoodsService>();
    builder.Services.AddTransient<IBasketService, BasketService>();
    builder.Services.AddTransient<IOrderedGoodsService, OrderedGoodsService>();
    builder.Services.AddTransient<IOrdersService, OrdersService>();

    builder.Services.AddControllers(opts => opts.ModelBinderProviders.Insert(0, new BaseListParamsModelBinderProvider()));
    builder.Services.AddEndpointsApiExplorer();
}

void SetDefaultCulture()
{
    var culture = new CultureInfo("ru-RU")
    {
        NumberFormat = { NumberDecimalSeparator = "." },
        DateTimeFormat = { ShortDatePattern = "dd.MM.yyyy", ShortTimePattern = "HH:mm:ss" }
    };

    CultureInfo.DefaultThreadCurrentCulture = culture;
    CultureInfo.DefaultThreadCurrentUICulture = culture;
}