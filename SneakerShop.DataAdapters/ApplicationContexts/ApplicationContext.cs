using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SneakerShop.DataAdapters.Models.Entities;
using SneakerShop.Core.ApplicationContext;

namespace SneakerShop.DataAdapters.ApplicationContexts;

/// <summary>
/// Здесь хранятся все данные БД
/// </summary>
public class ApplicationContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
{

    public IConfiguration Configuration { get; set; }

    public DbSet<BasketElement> Basket { get; set; }

    public DbSet<DiscountType> DiscountTypes { get; set; }

    public DbSet<Discount> Discounts { get; set; }

    public DbSet<Good> Goods { get; set; }

    public DbSet<Manufacturer> Manufacturers { get; set; }

    public DbSet<GoodType> GoodTypes { get; set; }

    public DbSet<GoodSubtype> GoodSubtypes { get; set; }

    public DbSet<Size> Sizes { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderedGood> OrderedGoods { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
        // апдейт энтити фремворка
        // dotnet tool update --global dotnet-ef

        // dotnet ef migrations add (название миграции, например, init) -c ApplicationContext --output-dir Migrations

        // dotnet ef migrations add InitDatabase -c ApplicationContext --project ..\SneakerShop.DataAdapters --output-dir ..\SneakerShop.DataAdapters\Migrations

        // как применить миграцию
        // dotnet ef database update -c ApplicationContext
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var adminRole = new IdentityRole<Guid>()
        {
            Id = Guid.NewGuid(),
            Name = Constants.AdminUserRoleName,
            NormalizedName = Constants.AdminUserRoleName.ToUpperInvariant()
        };
        var customerRole = new IdentityRole<Guid>()
        {
            Id = Guid.NewGuid(),
            Name = Constants.CustomerUserRoleName,
            NormalizedName = Constants.CustomerUserRoleName.ToUpperInvariant()
        };
        builder.Entity<IdentityRole<Guid>>().HasData(adminRole, customerRole);

        #region GoodType

        var topClothes = new GoodType("Верхняя одежда");
        var bottomClothes = new GoodType("Нижняя одежда");
        var shoes = new GoodType("Обувь");
        var accessories = new GoodType("Аксессуары");
        builder.Entity<GoodType>().HasData(new List<GoodType>()
        {
            topClothes, bottomClothes, shoes, accessories
        });

        #endregion

        #region GoodSubtype

        var jacket = new GoodSubtype("Куртки", topClothes.Id);
        var tshirt = new GoodSubtype("Футболки", topClothes.Id);
        var singlet = new GoodSubtype("Майки", topClothes.Id);
        var sweater = new GoodSubtype("Кофты", topClothes.Id);
        var jeans = new GoodSubtype("Джинсы", topClothes.Id);
        var pants = new GoodSubtype("Брюки", topClothes.Id);
        var skirts = new GoodSubtype("Юбки", topClothes.Id);
        var leggings = new GoodSubtype("Легинсы", topClothes.Id);

        var underPants = new GoodSubtype("Подштанники", bottomClothes.Id);
        var panties = new GoodSubtype("Трусы", bottomClothes.Id);

        var runShoes = new GoodSubtype("Кроссовки", shoes.Id);
        var sneakers = new GoodSubtype("Кеды", shoes.Id);
        var shoesSubtype = new GoodSubtype("Туфли", shoes.Id);
        var heels = new GoodSubtype("Каблуки", shoes.Id);

        var backpacks = new GoodSubtype("Рюкзаки", accessories.Id);
        var bags = new GoodSubtype("Сумки", accessories.Id);
        var badgers = new GoodSubtype("Барсетки", accessories.Id);
        var rings = new GoodSubtype("Кольца", accessories.Id);
        var bracelets = new GoodSubtype("Браслеты", accessories.Id);
        var gloves = new GoodSubtype("Перчатки", accessories.Id);

        builder.Entity<GoodSubtype>(entity =>
        {
            entity.HasOne(e => e.GoodType)
                .WithMany(e => e.GoodSubtypes)
                .HasForeignKey(e => e.GoodTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasData(new List<GoodSubtype>()
            {
                jacket, tshirt, singlet, sweater, jeans, pants, skirts, leggings,
                underPants, panties,
                runShoes, sneakers, shoesSubtype, heels,
                backpacks, bags, badgers, rings, bracelets, gloves
            });
        });

        #endregion

        #region Manufacturers

        var adidas = new Manufacturer("Adidas", "Адики .......");
        var nike = new Manufacturer("Nke", "Найки ..........");
        var gucci = new Manufacturer("Gucci", "Гучи ..........");
        var tommyHilfiger = new Manufacturer("Tommy Hilfiger", "Томми ..........");

        builder.Entity<Manufacturer>().HasData(new List<Manufacturer>()
        {
            adidas, nike, gucci, tommyHilfiger
        });

        #endregion

        #region Good

        builder.Entity<Good>(entity => 
        {
            entity.HasOne(e => e._GoodSubtype)
                .WithMany(e => e.Goods)
                .HasForeignKey(e => e.GoodSubtypeId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e._Manufacturer)
                .WithMany(e => e.Goods)
                .HasForeignKey(e => e.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasData(new List<Good>()
            {
                new Good(jacket.Id, adidas.Id, "Куртка адидас", 500, "Куртка адидас чёрная ....", "https://fullsourcemedia.s3.amazonaws.com/images/items/e/raw/J331_black_form_front.jpg"),
                new Good(runShoes.Id, nike.Id, "Кроссовки nike", 2500, "Кроссовки nike белые ....", "https://i.pinimg.com/originals/58/7d/82/587d82a229ceba80432497d594206c06.png"),
                new Good(backpacks.Id, nike.Id, "Рюкзаак nike", 5000, "Рюкзак nike белые ....", "https://freepngimg.com/thumb/backpack/9-2-backpack-png-hd.png"),
                new Good(tshirt.Id, adidas.Id, "Футболка adidas", 5000, "Футболка adidas синяя ....", "https://c1.klipartz.com/pngpicture/301/681/sticker-png-tshirt-tshirt-clothing-dress-fashion-jacket-playera-laundry-aline.png"),
            });
        });

        #endregion

        #region Size

        builder.Entity<Size>(entity =>
        {
            entity.HasOne(e => e._GoodSubtype)
                .WithMany(e => e.Sizes)
                .HasForeignKey(e => e.GoodSubtypeId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasData(new List<Size>()
            {
                new Size(jacket.Id, "XXL"), new Size(jacket.Id, "XL"), new Size(jacket.Id, "L"), new Size(jacket.Id, "M"), new Size(jacket.Id, "S"), new Size(jacket.Id, "XS"),
                new Size(runShoes.Id, "XXL"), new Size(runShoes.Id, "XL"), new Size(runShoes.Id, "L"), new Size(runShoes.Id, "M"), new Size(runShoes.Id, "S"), new Size(runShoes.Id, "XS"),
                new Size(backpacks.Id, "XXL"), new Size(backpacks.Id, "XL"), new Size(backpacks.Id, "M"), new Size(backpacks.Id, "S"),
                new Size(tshirt.Id, "XXL"), new Size(tshirt.Id, "XL"), new Size(tshirt.Id, "L"), new Size(tshirt.Id, "M"), new Size(tshirt.Id, "S"), new Size(tshirt.Id, "XS")
            });
        });

        #endregion

        #region DiscountType

        builder.Entity<DiscountType>().HasData(new List<DiscountType>()
        {
            new DiscountType("Летняя скидка", "Обычная летняя скидка", 5),
            new DiscountType("Зимняя скидка", "Обычная зимняя скидка", 10),
            new DiscountType("Особая скидка", "Особая скидка", 50)
        });

        #endregion

        #region Discount

        builder.Entity<Discount>(entity => 
        {
            entity.HasOne(e => e._DiscountType)
                .WithMany(e => e.Discounts)
                .HasForeignKey(e => e.DiscountTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e._Good)
                .WithMany(e => e.Discounts)
                .HasForeignKey(e => e.GoodId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        #endregion

        #region Order

        builder.Entity<Order>(entity =>
        {
            entity.HasOne(e => e._User)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        #endregion

        #region OrderedGood

        builder.Entity<OrderedGood>(entity =>
        {
            entity.HasOne(e => e._Order)
                .WithMany(e => e.OrderedGoods)
                .HasForeignKey(e => e.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e._Good)
                .WithMany(e => e.OrderedGoods)
                .HasForeignKey(e => e.GoodId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e._Size)
                .WithMany(e => e.OrderedGoods)
                .HasForeignKey(e => e.SizeId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e._Discount)
                .WithMany(e => e.OrderedGoods)
                .HasForeignKey(e => e.DiscountId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        #endregion

        #region BasketElement

        builder.Entity<BasketElement>(entity =>
        {
            entity.HasOne(e => e._Good)
                .WithMany(e => e.BasketElements)
                .HasForeignKey(e => e.GoodId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e._Size)
                .WithMany(e => e.BasketElements)
                .HasForeignKey(e => e.GoodId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e._User)
                .WithMany(e => e.Basket)
                .HasForeignKey(e => e.SizeId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e._Discount)
                .WithMany(e => e.BasketElements)
                .HasForeignKey(e => e.DiscountId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        #endregion
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Configuration.GetConnectionString("PGDatabaseConnectionString"));
    }

}