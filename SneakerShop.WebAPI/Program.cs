using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SneakerShop.Core.ApplicationContext;
using SneakerShop.Core.Models.Entities;
using SneakerShop.Core.Repositories.Intf;
using SneakerShop.Core.Services;
using SneakerShop.Core.Services.Entities;
using SneakerShop.Core.Services.Entities.Impl;
using SneakerShop.Core.Services.Impl;
using SneakerShop.Core.Services.Users;
using SneakerShop.Core.Services.Users.Impl;
using SneakerShop.DAL.ApplicationContexts;
using SneakerShop.DAL.Map.Profiles;
using SneakerShop.DAL.Repositories.Impl;
using SneakerShop.WebAPI.Infrastructure.ModelBinderProviders;
using SneakerShop.WebAPI.Services.Impl;
using System.Globalization;

SetDefaultCulture();

var builder = WebApplication.CreateBuilder(args);

RegisterControllersWithServices(builder);

var app = builder.Build();
// ������� �� XSS ���������� !!!
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

    builder.Services.AddDbContext<ApplicationContext>(opts =>
    {
        opts.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        opts.UseNpgsql(connString, options =>
        {
            options.SetPostgresVersion(new Version(14, 11, 0));
            options.MigrationsAssembly("SneakerShop.DAL");
        });
    });

    builder.Services.AddIdentity<SneakerShop.DAL.Models.Entities.AppUser, IdentityRole<Guid>>(opts =>
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

    builder.Services.ConfigureApplicationCookie(opts =>
    {
        opts.Cookie.Name = "SneakerShop.Identity.Cookie";
        opts.Cookie.HttpOnly = true;
        opts.ExpireTimeSpan = TimeSpan.FromMinutes(5);

        opts.LoginPath = "/Account/Login";
        opts.AccessDeniedPath = "/Account/AccessDenied";
        opts.SlidingExpiration = true;
    });

    builder.Services.AddAuthorization(opts =>
    {
        opts.AddPolicy(Constants.CustomerUserRoleName, policy => policy.RequireClaim(Constants.CustomerUserRoleName));
        opts.AddPolicy(Constants.AdminUserRoleName, policy => policy.RequireClaim(Constants.AdminUserRoleName));
    });

    #region Repositories

    builder.Services.AddScoped<IDbEntitiesRepository<BasketElement>, BasketElementsRepository>();
    builder.Services.AddScoped<IDbEntitiesRepository<Discount>, DiscountsRepository>();
    builder.Services.AddScoped<IDbEntitiesRepository<DiscountType>, DiscountTypesRepository>();
    builder.Services.AddScoped<IDbEntitiesRepository<Good>, GoodsRepository>();
    builder.Services.AddScoped<IDbEntitiesRepository<GoodSubtype>, GoodSubtypesRepository>();
    builder.Services.AddScoped<IDbEntitiesRepository<GoodType>, GoodTypesRepository>();
    builder.Services.AddScoped<IDbEntitiesRepository<Manufacturer>, ManufacturersRepository>();
    builder.Services.AddScoped<IDbEntitiesRepository<Order>, OrdersRepository>();
    builder.Services.AddScoped<IDbEntitiesRepository<OrderedGood>, OrderedGoodsRepository>();
    builder.Services.AddScoped<IDbEntitiesRepository<Size>, SizesRepository>();

    #endregion

    builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
    builder.Services.AddTransient<IRolesService, RolesService>();

    #region Entity services

    builder.Services.AddTransient<IBasketService, BasketService>();
    builder.Services.AddTransient<IDiscountsService, DiscountsService>();
    builder.Services.AddTransient<IDiscountTypesService, DiscountTypesService>();
    builder.Services.AddTransient<IGoodsService, GoodsService>();
    builder.Services.AddTransient<IGoodSubtypesService, GoodSubtypesService>();
    builder.Services.AddTransient<IGoodTypesService, GoodTypesService>();
    builder.Services.AddTransient<IManufacturersService, ManufacturersService>();
    builder.Services.AddTransient<IOrdersService, OrdersService>();
    builder.Services.AddTransient<IOrderedGoodsService, OrderedGoodsService>();
    builder.Services.AddTransient<ISizesService, SizesService>();

    #endregion

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