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

        var jackets = new GoodSubtype("Куртки", topClothes.Id);
        var tshirts = new GoodSubtype("Футболки", topClothes.Id);
        var singlets = new GoodSubtype("Майки", topClothes.Id);
        var sweaters = new GoodSubtype("Кофты", topClothes.Id);
        var jeans = new GoodSubtype("Джинсы", topClothes.Id);
        var pants = new GoodSubtype("Брюки", topClothes.Id);
        var skirts = new GoodSubtype("Юбки", topClothes.Id);
        var leggings = new GoodSubtype("Легинсы", topClothes.Id);
        var caps = new GoodSubtype("Кепки", topClothes.Id);
        var hats = new GoodSubtype("Шапки", topClothes.Id);

        var underPants = new GoodSubtype("Подштанники", bottomClothes.Id);

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
            entity.HasOne(e => e._GoodType)
                .WithMany(e => e.GoodSubtypes)
                .HasForeignKey(e => e.GoodTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasData(new List<GoodSubtype>()
            {
                jackets, tshirts, singlets, sweaters, jeans, pants, skirts, leggings, caps, hats,
                underPants,
                runShoes, sneakers, shoesSubtype, heels,
                backpacks, bags, badgers, rings, bracelets, gloves
            });
        });

        #endregion

        #region Manufacturers

        var adidas = new Manufacturer("Adidas", "Немецкая транснациональная компания по производству спортивной одежды, обуви и аксессуаров", "https://flomaster.top/uploads/posts/2023-10/1697227433_flomaster-top-p-adidas-risunok-instagram-1.jpg");
        var nike = new Manufacturer("Nike", "Американская транснациональная компания, специализирующаяся на спортивной одежде и обуви", "https://gas-kvas.com/grafic/uploads/posts/2024-01/gas-kvas-com-p-naik-logotip-na-prozrachnom-fone-7.png");
        var puma = new Manufacturer("Puma", "Промышленная компания Германии, специализирующаяся на выпуске спортивной обуви, одежды и инвентаря под торговой маркой Puma", "https://chelsfieldlakes.co.uk/wp-content/uploads/2017/08/puma-logo-black.png");
        var gucci = new Manufacturer("Gucci", "Итальянский дом моды, производитель одежды, парфюмерии и галантереи", "https://decalfly.com/cdn/shop/products/gucci-brand-decal-logo-sticker_1024x1024.jpg?v=1590520355");
        var tommyHilfiger = new Manufacturer("Tommy Hilfiger", "Американский бренд одежды премиум-класса, выпускающий одежду, обувь, аксессуары, ароматы и товары для дома", "https://ideacdn.net/idea/jj/63/myassets/brands/188/Tommy-Hilfiger-Amblem.jpg?revision=1661341987");
        var guess = new Manufacturer("Guess", "Американская розничная компания и одноимённый бренд мужской и женской одежды и аксессуаров, а также часов, ювелирных изделий, духов и обуви.", "https://upload.wikimedia.org/wikipedia/commons/7/75/Logo_Guess.jpg");

        builder.Entity<Manufacturer>().HasData(new List<Manufacturer>()
        {
            adidas, nike, puma, gucci, tommyHilfiger, guess
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
                new Size(jackets.Id, "XXL"), new Size(jackets.Id, "XL"), new Size(jackets.Id, "L"), new Size(jackets.Id, "M"), new Size(jackets.Id, "S"), new Size(jackets.Id, "XS"),
                new Size(runShoes.Id, "XXL"), new Size(runShoes.Id, "XL"), new Size(runShoes.Id, "L"), new Size(runShoes.Id, "M"), new Size(runShoes.Id, "S"), new Size(runShoes.Id, "XS"),
                new Size(backpacks.Id, "XXL"), new Size(backpacks.Id, "XL"), new Size(backpacks.Id, "M"), new Size(backpacks.Id, "S"),
                new Size(tshirts.Id, "XXL"), new Size(tshirts.Id, "XL"), new Size(tshirts.Id, "L"), new Size(tshirts.Id, "M"), new Size(tshirts.Id, "S"), new Size(tshirts.Id, "XS"),
                new Size(singlets.Id, "M"),
                new Size(sweaters.Id, "M"),
                new Size(jeans.Id, "M"),
                new Size(pants.Id, "M"),
                new Size(skirts.Id, "M"),
                new Size(leggings.Id, "M"),
                new Size(caps.Id, "M"),
                new Size(hats.Id, "M"),
                new Size(underPants.Id, "M"),
                new Size(sneakers.Id, "M"),
                new Size(shoesSubtype.Id, "M"),
                new Size(heels.Id, "M"),
                new Size(bags.Id, "M"),
                new Size(badgers.Id, "M"),
                new Size(rings.Id, "M"),
                new Size(bracelets.Id, "M"),
                new Size(gloves.Id, "M")
            });
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
                new Good(jackets.Id, puma.Id, "Ветровка ACTIVE Jacket Puma Black", 6999, "Ветровка выполнена из гладкого текстиля. Модель прямого силуэта. Детали: воротник-стойка, застежка на молнии, боковые карманы, удлиненная спинка.", "https://a.lmcdn.ru/product/R/T/RTLACJ839401_19495431_5_v1_2x.jpg"),
                new Good(jackets.Id, adidas.Id, "Куртка утепленная ESS INS HYB JKT", 12999, "Куртка выполнена из водо и ветрозащитного текстиля. Детали: капюшон, застежка на молнии с защитой подбородка, два внешних кармана, тонкий слой утеплителя.", "https://a.lmcdn.ru/product/R/T/RTLACX655501_21520428_4_v1_2x.jpg"),
                new Good(backpacks.Id, adidas.Id, "Рюкзак MH BP", 7499, "Рюкзак выполнен из прочной ткани CORDURA® и декорирован лентой adidas. В нем найдется место для твоих повседневных вещей, а также внутренний карман для ноутбука и передний карман на молнии для ценных вещей - она создана как для напряженных дней, так и для небольших приключений. Модель минимум на 40% состоит из переработанных материалов и представляет одно из наших решений по сокращению пластиковых отходов.", "https://a.lmcdn.ru/product/R/T/RTLACY475501_21648496_1_v1.jpg"),
                new Good(badgers.Id, adidas.Id, "Сумка LINEAR ORG", 1699, "Сумка выполнена из прочного текстиля. Детали: застежка на молнии, один внешний карман и один внутренний, подкладка из текстиля.", "https://a.lmcdn.ru/product/R/T/RTLACZ076602_22799653_1_v1.jpg"),
                new Good(caps.Id, adidas.Id, "Бейсболка TECH 3P CAP R.R", 4399, "Товар как минимум на 50% состоит из переработанных материалов, а значит, на его создание потребовалось меньше природных ресурсов. Ткань получена путем переработки пластика или текстильных остатков. Выбирая этот товар, вы вносите свой вклад в сохранение окружающей среды.", "https://a.lmcdn.ru/product/R/T/RTLACY114001_21699686_1_v1.jpg"),
                new Good(hats.Id, adidas.Id, "Шапка COLD.RDY BEANIE", 3999, "Товар как минимум на 50% состоит из переработанных материалов, а значит, на его создание потребовалось меньше природных ресурсов. Ткань получена путем переработки пластика или текстильных остатков. Выбирая этот товар, вы вносите свой вклад в сохранение окружающей среды.", "https://a.lmcdn.ru/product/R/T/RTLACY063901_21670176_1_v1.jpg"),
                new Good(gloves.Id, adidas.Id, "Перчатки для фитнеса TRAINING", 4499, "Товар как минимум на 50% состоит из переработанных материалов, а значит, на его создание потребовалось меньше природных ресурсов. Ткань получена путем переработки пластика или текстильных остатков. Выбирая этот товар, вы вносите свой вклад в сохранение окружающей среды.", "https://a.lmcdn.ru/product/R/T/RTLACV074501_21321718_1_v1.jpg"),
                new Good(jackets.Id, nike.Id, "Куртка утепленная M NK CLUB PUFFER JKT", 38390, "Утепленная куртка выполнена из стеганого текстиля с толстым слоем искусственного утеплителя. Модель прямого кроя. Детали: застежка на молнии, внутренняя ветрозащитная планка, воротник-стойка, 2 кармана на молнии.", "https://a.lmcdn.ru/product/R/T/RTLADH300501_22798637_5_v1_2x.jpg"),
                new Good(jackets.Id, nike.Id, "Худи M NSW CLUB HOODIE PO FT", 11690, "", "https://a.lmcdn.ru/product/R/T/RTLADF178902_22904293_5_v1_2x.jpg"),
                new Good(pants.Id, nike.Id, "Брюки спортивные M NK DF PHENOM ELITE KNIT PANT", 16390, "Брюки спортивные выполнены из эластичной ткани. Технология Dri-FIT помогает отводить влагу и обеспечивает комфорт. Детали: эластичный пояс с фиксирующим шнурком, боковые карманы обеспечивают хранение мелких предметов, задний карман имеет пароизоляцию для защиты от пота, манжеты, светоотражающие элементы.", "https://a.lmcdn.ru/product/R/T/RTLADI750701_22922904_4_v1_2x.jpg"),
                new Good(runShoes.Id, nike.Id, "Кроссовки Nike Venture Runner", 13590, "Кроссовки выполнены из натуральной кожи и текстиля. Сетка и замша на верху придают вентиляцию и прочность. Резиновая подошва, вдохновленная вафлями, обеспечивает превосходное сцепление с дорогой и долговечность, кивая на стиль наследия. Зажим для пятки способствует стабильности. Детали: шнуровка.", "https://a.lmcdn.ru/product/R/T/RTLACR843402_23116771_1_v1.jpg"),
                new Good(sneakers.Id, tommyHilfiger.Id, "Кеды", 9490, "", "https://a.lmcdn.ru/product/R/T/RTLACN213702_23428269_3_v1.jpg"),
                new Good(bracelets.Id, guess.Id, "Браслет", 8399, "", "https://a.lmcdn.ru/product/R/T/RTLABP198301_17558030_1_v1.jpg"),
                new Good(rings.Id, guess.Id, "Кольцо", 4699, "", "https://a.lmcdn.ru/product/R/T/RTLABP201301_17556292_1_v1.jpg"),
                new Good(jackets.Id, adidas.Id, "Куртка адидас", 9399, "Куртка адидас чёрная ....", "https://fullsourcemedia.s3.amazonaws.com/images/items/e/raw/J331_black_form_front.jpg"),
                new Good(runShoes.Id, nike.Id, "Кроссовки nike", 7675, "Кроссовки nike белые ....", "https://i.pinimg.com/originals/58/7d/82/587d82a229ceba80432497d594206c06.png"),
                new Good(backpacks.Id, nike.Id, "Рюкзак nike", 7675, "Рюкзак nike белые ....", "https://freepngimg.com/thumb/backpack/9-2-backpack-png-hd.png"),
                new Good(tshirts.Id, adidas.Id, "Футболка adidas", 10250, "Футболка adidas синяя ....", "https://c1.klipartz.com/pngpicture/301/681/sticker-png-tshirt-tshirt-clothing-dress-fashion-jacket-playera-laundry-aline.png"),
                new Good(bags.Id, gucci.Id, "Сумка 1", 9000, "", "/empty_good.png"),
                new Good(bags.Id, gucci.Id, "Сумка 2", 20000, "", "/empty_good.png"),
                new Good(bags.Id, gucci.Id, "Сумка 3", 15349, "", "/empty_good.png"),
                new Good(bags.Id, gucci.Id, "Сумка 4", 3053, "", "/empty_good.png"),
                new Good(underPants.Id, adidas.Id, "Подштанники 1", 7908, "", "/empty_good.png"),
                new Good(underPants.Id, nike.Id, "Подштанники 2", 5789, "", "/empty_good.png"),
                new Good(leggings.Id, tommyHilfiger.Id, "Легинсы 1", 7000, "", "/empty_good.png"),
                new Good(leggings.Id, tommyHilfiger.Id, "Легинсы 2", 7896, "", "/empty_good.png"),
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