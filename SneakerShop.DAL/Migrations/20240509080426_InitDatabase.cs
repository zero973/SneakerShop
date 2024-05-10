using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SneakerShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Percent = table.Column<int>(type: "integer", nullable: false),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoodTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ImageURL = table.Column<string>(type: "text", nullable: false),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GoodSubtypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    GoodTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodSubtypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodSubtypes_GoodTypes_GoodTypeId",
                        column: x => x.GoodTypeId,
                        principalTable: "GoodTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GoodSubtypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ManufacturerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ImageURL = table.Column<string>(type: "text", nullable: false),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goods_GoodSubtypes_GoodSubtypeId",
                        column: x => x.GoodSubtypeId,
                        principalTable: "GoodSubtypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Goods_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GoodSubtypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sizes_GoodSubtypes_GoodSubtypeId",
                        column: x => x.GoodSubtypeId,
                        principalTable: "GoodSubtypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GoodId = table.Column<Guid>(type: "uuid", nullable: false),
                    DiscountTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discounts_DiscountTypes_DiscountTypeId",
                        column: x => x.DiscountTypeId,
                        principalTable: "DiscountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Discounts_Goods_GoodId",
                        column: x => x.GoodId,
                        principalTable: "Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GoodId = table.Column<Guid>(type: "uuid", nullable: false),
                    SizeId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    DiscountId = table.Column<Guid>(type: "uuid", nullable: true),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baskets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Baskets_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Baskets_Goods_GoodId",
                        column: x => x.GoodId,
                        principalTable: "Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Baskets_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderedGoods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    GoodId = table.Column<Guid>(type: "uuid", nullable: false),
                    SizeId = table.Column<Guid>(type: "uuid", nullable: false),
                    DiscountId = table.Column<Guid>(type: "uuid", nullable: true),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedGoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderedGoods_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderedGoods_Goods_GoodId",
                        column: x => x.GoodId,
                        principalTable: "Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderedGoods_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderedGoods_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("7e7a3229-7eff-49e8-a139-81449e67d951"), null, "Admin", "ADMIN" },
                    { new Guid("bb952c11-5eb0-45a1-ae6e-c06b78c60e19"), null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "DiscountTypes",
                columns: new[] { "Id", "CreateDate", "CreatedUserId", "DeleteDate", "DeletedUserId", "Description", "IsActual", "Name", "Percent", "UpdateDate", "UpdatedUserId" },
                values: new object[,]
                {
                    { new Guid("446f36fe-238b-4d7c-9ae0-b3c1eb8e1d21"), new DateTime(2024, 5, 9, 11, 4, 26, 569, DateTimeKind.Local).AddTicks(116), null, null, null, "Обычная летняя скидка", true, "Летняя скидка", 5, null, null },
                    { new Guid("61e489fa-3877-4d20-a4fc-dad6f31c01cf"), new DateTime(2024, 5, 9, 11, 4, 26, 569, DateTimeKind.Local).AddTicks(122), null, null, null, "Особая скидка", true, "Особая скидка", 50, null, null },
                    { new Guid("b08f07c3-4610-46ac-913e-b31f2d864dfb"), new DateTime(2024, 5, 9, 11, 4, 26, 569, DateTimeKind.Local).AddTicks(121), null, null, null, "Обычная зимняя скидка", true, "Зимняя скидка", 10, null, null }
                });

            migrationBuilder.InsertData(
                table: "GoodTypes",
                columns: new[] { "Id", "CreateDate", "CreatedUserId", "DeleteDate", "DeletedUserId", "IsActual", "Name", "UpdateDate", "UpdatedUserId" },
                values: new object[,]
                {
                    { new Guid("2e28edc1-fa24-4b88-80dd-a884ef5e2a41"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(6039), null, null, null, true, "Обувь", null, null },
                    { new Guid("3571b362-3c07-4113-ac2c-905b88be1b40"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(6038), null, null, null, true, "Нижняя одежда", null, null },
                    { new Guid("b0410692-712a-4f98-8a72-7859b3594a98"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(6040), null, null, null, true, "Аксессуары", null, null },
                    { new Guid("fd096c13-10e7-48c6-976a-4ddb522ee6e0"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(6025), null, null, null, true, "Верхняя одежда", null, null }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CreateDate", "CreatedUserId", "DeleteDate", "DeletedUserId", "Description", "ImageURL", "IsActual", "Name", "UpdateDate", "UpdatedUserId" },
                values: new object[,]
                {
                    { new Guid("0335ae7c-4fc3-4d3b-a9cb-9e0692a555d4"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(7401), null, null, null, "Американская транснациональная компания, специализирующаяся на спортивной одежде и обуви", "https://gas-kvas.com/grafic/uploads/posts/2024-01/gas-kvas-com-p-naik-logotip-na-prozrachnom-fone-7.png", true, "Nike", null, null },
                    { new Guid("085bd07b-1b7f-43f1-a678-80750e479bd7"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(7395), null, null, null, "Немецкая транснациональная компания по производству спортивной одежды, обуви и аксессуаров", "https://flomaster.top/uploads/posts/2023-10/1697227433_flomaster-top-p-adidas-risunok-instagram-1.jpg", true, "Adidas", null, null },
                    { new Guid("1580cfa7-f859-4ea8-9e58-7c5f28daa940"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(7409), null, null, null, "Американская розничная компания и одноимённый бренд мужской и женской одежды и аксессуаров, а также часов, ювелирных изделий, духов и обуви.", "https://upload.wikimedia.org/wikipedia/commons/7/75/Logo_Guess.jpg", true, "Guess", null, null },
                    { new Guid("20dbcf43-c4b5-4bb6-ba4f-3b4088cbc8ed"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(7403), null, null, null, "Итальянский дом моды, производитель одежды, парфюмерии и галантереи", "https://decalfly.com/cdn/shop/products/gucci-brand-decal-logo-sticker_1024x1024.jpg?v=1590520355", true, "Gucci", null, null },
                    { new Guid("7f0e715b-2612-4c10-923f-23fcd0343d5b"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(7404), null, null, null, "Американский бренд одежды премиум-класса, выпускающий одежду, обувь, аксессуары, ароматы и товары для дома", "https://ideacdn.net/idea/jj/63/myassets/brands/188/Tommy-Hilfiger-Amblem.jpg?revision=1661341987", true, "Tommy Hilfiger", null, null },
                    { new Guid("c600135f-dfd8-4a23-ad1f-738965f953d4"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(7402), null, null, null, "Промышленная компания Германии, специализирующаяся на выпуске спортивной обуви, одежды и инвентаря под торговой маркой Puma", "https://chelsfieldlakes.co.uk/wp-content/uploads/2017/08/puma-logo-black.png", true, "Puma", null, null }
                });

            migrationBuilder.InsertData(
                table: "GoodSubtypes",
                columns: new[] { "Id", "CreateDate", "CreatedUserId", "DeleteDate", "DeletedUserId", "GoodTypeId", "IsActual", "Name", "UpdateDate", "UpdatedUserId" },
                values: new object[,]
                {
                    { new Guid("2b9d7a55-a1b9-4ded-960e-548b878ec410"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(6107), null, null, null, new Guid("2e28edc1-fa24-4b88-80dd-a884ef5e2a41"), true, "Кроссовки", null, null },
                    { new Guid("3cb59275-53ac-46e9-b7cd-ab3a5c839d27"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(6108), null, null, null, new Guid("2e28edc1-fa24-4b88-80dd-a884ef5e2a41"), true, "Туфли", null, null },
                    { new Guid("4c3a1fab-f569-41c3-beca-d56629c87d58"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(6111), null, null, null, new Guid("b0410692-712a-4f98-8a72-7859b3594a98"), true, "Сумки", null, null },
                    { new Guid("4f05b48c-f3e3-4f50-b8f0-dce83fe065b9"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(6110), null, null, null, new Guid("b0410692-712a-4f98-8a72-7859b3594a98"), true, "Рюкзаки", null, null },
                    { new Guid("630fb955-f9d3-4a82-9c1a-e2466f758842"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(6091), null, null, null, new Guid("fd096c13-10e7-48c6-976a-4ddb522ee6e0"), true, "Майки", null, null },
                    { new Guid("65475dc7-95c2-46de-a4da-60efdf5bb1f1"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(6116), null, null, null, new Guid("b0410692-712a-4f98-8a72-7859b3594a98"), true, "Перчатки", null, null },
                    { new Guid("80faa5d3-7c8d-4559-9221-c570d6196b84"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(6103), null, null, null, new Guid("fd096c13-10e7-48c6-976a-4ddb522ee6e0"), true, "Шапки", null, null },
                    { new Guid("8acd0563-e18e-4771-aa9d-99a35470c95c"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(6085), null, null, null, new Guid("fd096c13-10e7-48c6-976a-4ddb522ee6e0"), true, "Куртки", null, null },
                    { new Guid("964ba25b-7341-47e9-a3bc-a48586d28c29"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(6095), null, null, null, new Guid("fd096c13-10e7-48c6-976a-4ddb522ee6e0"), true, "Брюки", null, null },
                    { new Guid("9a753fcf-48a6-4c69-b4ad-7a56b45fba9a"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(6109), null, null, null, new Guid("2e28edc1-fa24-4b88-80dd-a884ef5e2a41"), true, "Каблуки", null, null },
                    { new Guid("a06e411e-bd5e-4e3d-b7f2-251c9320a78d"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(6101), null, null, null, new Guid("fd096c13-10e7-48c6-976a-4ddb522ee6e0"), true, "Юбки", null, null },
                    { new Guid("a24e3678-2362-48cb-8f67-8ad37f4b2108"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(6112), null, null, null, new Guid("b0410692-712a-4f98-8a72-7859b3594a98"), true, "Барсетки", null, null },
                    { new Guid("a52f0b4f-e30e-423c-be11-e7c8570db9fe"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(6106), null, null, null, new Guid("3571b362-3c07-4113-ac2c-905b88be1b40"), true, "Подштанники", null, null },
                    { new Guid("a5ecd126-c79c-4f2f-84e4-6fa48b304a74"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(6102), null, null, null, new Guid("fd096c13-10e7-48c6-976a-4ddb522ee6e0"), true, "Кепки", null, null },
                    { new Guid("a9d20359-a3fd-41ee-bddc-29ea25f767e5"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(6094), null, null, null, new Guid("fd096c13-10e7-48c6-976a-4ddb522ee6e0"), true, "Джинсы", null, null },
                    { new Guid("ae8d21f0-4a3c-4a72-b32b-a09ee129dd21"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(6108), null, null, null, new Guid("2e28edc1-fa24-4b88-80dd-a884ef5e2a41"), true, "Кеды", null, null },
                    { new Guid("d1df6dad-f860-41f3-abd7-7493cd2d4d0a"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(6115), null, null, null, new Guid("b0410692-712a-4f98-8a72-7859b3594a98"), true, "Кольца", null, null },
                    { new Guid("dc87c20f-6e9c-4ae9-b764-805758d01f9f"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(6115), null, null, null, new Guid("b0410692-712a-4f98-8a72-7859b3594a98"), true, "Браслеты", null, null },
                    { new Guid("e7470efb-bd90-40a9-9ca2-8e344e8d4f45"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(6102), null, null, null, new Guid("fd096c13-10e7-48c6-976a-4ddb522ee6e0"), true, "Легинсы", null, null },
                    { new Guid("ec89f8a9-bf47-415b-b3f8-644933f4739a"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(6093), null, null, null, new Guid("fd096c13-10e7-48c6-976a-4ddb522ee6e0"), true, "Кофты", null, null },
                    { new Guid("f7d01dc8-589b-43ad-98d5-46127e32a05d"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(6088), null, null, null, new Guid("fd096c13-10e7-48c6-976a-4ddb522ee6e0"), true, "Футболки", null, null }
                });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "CreateDate", "CreatedUserId", "DeleteDate", "DeletedUserId", "Description", "GoodSubtypeId", "ImageURL", "IsActual", "ManufacturerId", "Name", "Price", "UpdateDate", "UpdatedUserId" },
                values: new object[,]
                {
                    { new Guid("005c91e1-884b-43a7-817e-ef63fe1f1dff"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(9972), null, null, null, "Рюкзак выполнен из прочной ткани CORDURA® и декорирован лентой adidas. В нем найдется место для твоих повседневных вещей, а также внутренний карман для ноутбука и передний карман на молнии для ценных вещей - она создана как для напряженных дней, так и для небольших приключений. Модель минимум на 40% состоит из переработанных материалов и представляет одно из наших решений по сокращению пластиковых отходов.", new Guid("4f05b48c-f3e3-4f50-b8f0-dce83fe065b9"), "https://a.lmcdn.ru/product/R/T/RTLACY475501_21648496_1_v1.jpg", true, new Guid("085bd07b-1b7f-43f1-a678-80750e479bd7"), "Рюкзак MH BP", 7499m, null, null },
                    { new Guid("0265f3b0-cfc6-4698-a3de-733aea5a561d"), new DateTime(2024, 5, 9, 11, 4, 26, 569, DateTimeKind.Local).AddTicks(55), null, null, null, "", new Guid("4c3a1fab-f569-41c3-beca-d56629c87d58"), "/empty_good.png", true, new Guid("20dbcf43-c4b5-4bb6-ba4f-3b4088cbc8ed"), "Сумка 2", 20000m, null, null },
                    { new Guid("02742a65-bc00-430d-9d21-eb42a08b1ea6"), new DateTime(2024, 5, 9, 11, 4, 26, 569, DateTimeKind.Local).AddTicks(50), null, null, null, "Рюкзак nike белые ....", new Guid("4f05b48c-f3e3-4f50-b8f0-dce83fe065b9"), "https://freepngimg.com/thumb/backpack/9-2-backpack-png-hd.png", true, new Guid("0335ae7c-4fc3-4d3b-a9cb-9e0692a555d4"), "Рюкзак nike", 7675m, null, null },
                    { new Guid("054cfb9a-02dc-4a79-bf4f-b15623f5a17c"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(9970), null, null, null, "Куртка выполнена из водо и ветрозащитного текстиля. Детали: капюшон, застежка на молнии с защитой подбородка, два внешних кармана, тонкий слой утеплителя.", new Guid("8acd0563-e18e-4771-aa9d-99a35470c95c"), "https://a.lmcdn.ru/product/R/T/RTLACX655501_21520428_4_v1_2x.jpg", true, new Guid("085bd07b-1b7f-43f1-a678-80750e479bd7"), "Куртка утепленная ESS INS HYB JKT", 12999m, null, null },
                    { new Guid("09a358dd-5d56-4b03-951d-e0d5e57e4577"), new DateTime(2024, 5, 9, 11, 4, 26, 569, DateTimeKind.Local).AddTicks(56), null, null, null, "", new Guid("4c3a1fab-f569-41c3-beca-d56629c87d58"), "/empty_good.png", true, new Guid("20dbcf43-c4b5-4bb6-ba4f-3b4088cbc8ed"), "Сумка 3", 15349m, null, null },
                    { new Guid("0bbb6b30-8193-4e2a-abd0-9b5e7dbecc88"), new DateTime(2024, 5, 9, 11, 4, 26, 569, DateTimeKind.Local).AddTicks(64), null, null, null, "", new Guid("e7470efb-bd90-40a9-9ca2-8e344e8d4f45"), "/empty_good.png", true, new Guid("7f0e715b-2612-4c10-923f-23fcd0343d5b"), "Легинсы 1", 7000m, null, null },
                    { new Guid("262fad09-d329-4a24-a4ae-dcfb817177d6"), new DateTime(2024, 5, 9, 11, 4, 26, 569, DateTimeKind.Local).AddTicks(31), null, null, null, "Товар как минимум на 50% состоит из переработанных материалов, а значит, на его создание потребовалось меньше природных ресурсов. Ткань получена путем переработки пластика или текстильных остатков. Выбирая этот товар, вы вносите свой вклад в сохранение окружающей среды.", new Guid("65475dc7-95c2-46de-a4da-60efdf5bb1f1"), "https://a.lmcdn.ru/product/R/T/RTLACV074501_21321718_1_v1.jpg", true, new Guid("085bd07b-1b7f-43f1-a678-80750e479bd7"), "Перчатки для фитнеса TRAINING", 4499m, null, null },
                    { new Guid("3999de2d-17c0-45cb-928d-1c2b1967d94c"), new DateTime(2024, 5, 9, 11, 4, 26, 569, DateTimeKind.Local).AddTicks(43), null, null, null, "", new Guid("dc87c20f-6e9c-4ae9-b764-805758d01f9f"), "https://a.lmcdn.ru/product/R/T/RTLABP198301_17558030_1_v1.jpg", true, new Guid("1580cfa7-f859-4ea8-9e58-7c5f28daa940"), "Браслет", 8399m, null, null },
                    { new Guid("39bbcadf-8ab3-409f-8a46-3479c3f63d09"), new DateTime(2024, 5, 9, 11, 4, 26, 569, DateTimeKind.Local).AddTicks(30), null, null, null, "Товар как минимум на 50% состоит из переработанных материалов, а значит, на его создание потребовалось меньше природных ресурсов. Ткань получена путем переработки пластика или текстильных остатков. Выбирая этот товар, вы вносите свой вклад в сохранение окружающей среды.", new Guid("80faa5d3-7c8d-4559-9221-c570d6196b84"), "https://a.lmcdn.ru/product/R/T/RTLACY063901_21670176_1_v1.jpg", true, new Guid("085bd07b-1b7f-43f1-a678-80750e479bd7"), "Шапка COLD.RDY BEANIE", 3999m, null, null },
                    { new Guid("3a1bcccb-3400-4590-aeca-4d18b2b19941"), new DateTime(2024, 5, 9, 11, 4, 26, 569, DateTimeKind.Local).AddTicks(66), null, null, null, "", new Guid("e7470efb-bd90-40a9-9ca2-8e344e8d4f45"), "/empty_good.png", true, new Guid("7f0e715b-2612-4c10-923f-23fcd0343d5b"), "Легинсы 2", 7896m, null, null },
                    { new Guid("49da924b-37c4-4195-a76d-a306b45f1f11"), new DateTime(2024, 5, 9, 11, 4, 26, 569, DateTimeKind.Local).AddTicks(39), null, null, null, "Брюки спортивные выполнены из эластичной ткани. Технология Dri-FIT помогает отводить влагу и обеспечивает комфорт. Детали: эластичный пояс с фиксирующим шнурком, боковые карманы обеспечивают хранение мелких предметов, задний карман имеет пароизоляцию для защиты от пота, манжеты, светоотражающие элементы.", new Guid("964ba25b-7341-47e9-a3bc-a48586d28c29"), "https://a.lmcdn.ru/product/R/T/RTLADI750701_22922904_4_v1_2x.jpg", true, new Guid("0335ae7c-4fc3-4d3b-a9cb-9e0692a555d4"), "Брюки спортивные M NK DF PHENOM ELITE KNIT PANT", 16390m, null, null },
                    { new Guid("4bad078f-209c-4c0b-9027-96b70a8dc009"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(9960), null, null, null, "Ветровка выполнена из гладкого текстиля. Модель прямого силуэта. Детали: воротник-стойка, застежка на молнии, боковые карманы, удлиненная спинка.", new Guid("8acd0563-e18e-4771-aa9d-99a35470c95c"), "https://a.lmcdn.ru/product/R/T/RTLACJ839401_19495431_5_v1_2x.jpg", true, new Guid("c600135f-dfd8-4a23-ad1f-738965f953d4"), "Ветровка ACTIVE Jacket Puma Black", 6999m, null, null },
                    { new Guid("50a71ba9-c29c-47fd-834b-0e3279a9e69f"), new DateTime(2024, 5, 9, 11, 4, 26, 569, DateTimeKind.Local).AddTicks(37), null, null, null, "", new Guid("8acd0563-e18e-4771-aa9d-99a35470c95c"), "https://a.lmcdn.ru/product/R/T/RTLADF178902_22904293_5_v1_2x.jpg", true, new Guid("0335ae7c-4fc3-4d3b-a9cb-9e0692a555d4"), "Худи M NSW CLUB HOODIE PO FT", 11690m, null, null },
                    { new Guid("6c5ab98d-0d85-4d8e-badd-6103ed34f8b3"), new DateTime(2024, 5, 9, 11, 4, 26, 569, DateTimeKind.Local).AddTicks(45), null, null, null, "", new Guid("d1df6dad-f860-41f3-abd7-7493cd2d4d0a"), "https://a.lmcdn.ru/product/R/T/RTLABP201301_17556292_1_v1.jpg", true, new Guid("1580cfa7-f859-4ea8-9e58-7c5f28daa940"), "Кольцо", 4699m, null, null },
                    { new Guid("720b4243-42b4-4ef7-a316-abbd825da0fd"), new DateTime(2024, 5, 9, 11, 4, 26, 569, DateTimeKind.Local).AddTicks(53), null, null, null, "", new Guid("4c3a1fab-f569-41c3-beca-d56629c87d58"), "/empty_good.png", true, new Guid("20dbcf43-c4b5-4bb6-ba4f-3b4088cbc8ed"), "Сумка 1", 9000m, null, null },
                    { new Guid("8be0ca28-3157-44c8-97d7-c17da8e00dba"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(9978), null, null, null, "Товар как минимум на 50% состоит из переработанных материалов, а значит, на его создание потребовалось меньше природных ресурсов. Ткань получена путем переработки пластика или текстильных остатков. Выбирая этот товар, вы вносите свой вклад в сохранение окружающей среды.", new Guid("a5ecd126-c79c-4f2f-84e4-6fa48b304a74"), "https://a.lmcdn.ru/product/R/T/RTLACY114001_21699686_1_v1.jpg", true, new Guid("085bd07b-1b7f-43f1-a678-80750e479bd7"), "Бейсболка TECH 3P CAP R.R", 4399m, null, null },
                    { new Guid("8c1c2ec7-7166-4587-9bdf-5616157d8adf"), new DateTime(2024, 5, 9, 11, 4, 26, 569, DateTimeKind.Local).AddTicks(57), null, null, null, "", new Guid("4c3a1fab-f569-41c3-beca-d56629c87d58"), "/empty_good.png", true, new Guid("20dbcf43-c4b5-4bb6-ba4f-3b4088cbc8ed"), "Сумка 4", 3053m, null, null },
                    { new Guid("8e3db1f0-5b21-4d02-b2bd-cc418cf7697b"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(9976), null, null, null, "Сумка выполнена из прочного текстиля. Детали: застежка на молнии, один внешний карман и один внутренний, подкладка из текстиля.", new Guid("a24e3678-2362-48cb-8f67-8ad37f4b2108"), "https://a.lmcdn.ru/product/R/T/RTLACZ076602_22799653_1_v1.jpg", true, new Guid("085bd07b-1b7f-43f1-a678-80750e479bd7"), "Сумка LINEAR ORG", 1699m, null, null },
                    { new Guid("92345f5c-1ca3-474f-856e-b8eb4fc3abb2"), new DateTime(2024, 5, 9, 11, 4, 26, 569, DateTimeKind.Local).AddTicks(42), null, null, null, "", new Guid("ae8d21f0-4a3c-4a72-b32b-a09ee129dd21"), "https://a.lmcdn.ru/product/R/T/RTLACN213702_23428269_3_v1.jpg", true, new Guid("7f0e715b-2612-4c10-923f-23fcd0343d5b"), "Кеды", 9490m, null, null },
                    { new Guid("96c7d37a-dba5-440c-8d42-0ef196b6c644"), new DateTime(2024, 5, 9, 11, 4, 26, 569, DateTimeKind.Local).AddTicks(52), null, null, null, "Футболка adidas синяя ....", new Guid("f7d01dc8-589b-43ad-98d5-46127e32a05d"), "https://c1.klipartz.com/pngpicture/301/681/sticker-png-tshirt-tshirt-clothing-dress-fashion-jacket-playera-laundry-aline.png", true, new Guid("085bd07b-1b7f-43f1-a678-80750e479bd7"), "Футболка adidas", 10250m, null, null },
                    { new Guid("979b7d24-f89a-438b-89e8-f9d21f86b299"), new DateTime(2024, 5, 9, 11, 4, 26, 569, DateTimeKind.Local).AddTicks(33), null, null, null, "Утепленная куртка выполнена из стеганого текстиля с толстым слоем искусственного утеплителя. Модель прямого кроя. Детали: застежка на молнии, внутренняя ветрозащитная планка, воротник-стойка, 2 кармана на молнии.", new Guid("8acd0563-e18e-4771-aa9d-99a35470c95c"), "https://a.lmcdn.ru/product/R/T/RTLADH300501_22798637_5_v1_2x.jpg", true, new Guid("0335ae7c-4fc3-4d3b-a9cb-9e0692a555d4"), "Куртка утепленная M NK CLUB PUFFER JKT", 38390m, null, null },
                    { new Guid("a2b1b629-e93d-4fcf-96d0-bd974d27196d"), new DateTime(2024, 5, 9, 11, 4, 26, 569, DateTimeKind.Local).AddTicks(58), null, null, null, "", new Guid("a52f0b4f-e30e-423c-be11-e7c8570db9fe"), "/empty_good.png", true, new Guid("085bd07b-1b7f-43f1-a678-80750e479bd7"), "Подштанники 1", 7908m, null, null },
                    { new Guid("b895fe55-d207-4843-af0c-4a5538fef899"), new DateTime(2024, 5, 9, 11, 4, 26, 569, DateTimeKind.Local).AddTicks(60), null, null, null, "", new Guid("a52f0b4f-e30e-423c-be11-e7c8570db9fe"), "/empty_good.png", true, new Guid("0335ae7c-4fc3-4d3b-a9cb-9e0692a555d4"), "Подштанники 2", 5789m, null, null },
                    { new Guid("c8370084-cbdf-4279-bd15-7ad754e6fbc7"), new DateTime(2024, 5, 9, 11, 4, 26, 569, DateTimeKind.Local).AddTicks(40), null, null, null, "Кроссовки выполнены из натуральной кожи и текстиля. Сетка и замша на верху придают вентиляцию и прочность. Резиновая подошва, вдохновленная вафлями, обеспечивает превосходное сцепление с дорогой и долговечность, кивая на стиль наследия. Зажим для пятки способствует стабильности. Детали: шнуровка.", new Guid("2b9d7a55-a1b9-4ded-960e-548b878ec410"), "https://a.lmcdn.ru/product/R/T/RTLACR843402_23116771_1_v1.jpg", true, new Guid("0335ae7c-4fc3-4d3b-a9cb-9e0692a555d4"), "Кроссовки Nike Venture Runner", 13590m, null, null },
                    { new Guid("d06c7e25-b4df-490d-9bfe-1961ba631b94"), new DateTime(2024, 5, 9, 11, 4, 26, 569, DateTimeKind.Local).AddTicks(46), null, null, null, "Куртка адидас чёрная ....", new Guid("8acd0563-e18e-4771-aa9d-99a35470c95c"), "https://fullsourcemedia.s3.amazonaws.com/images/items/e/raw/J331_black_form_front.jpg", true, new Guid("085bd07b-1b7f-43f1-a678-80750e479bd7"), "Куртка адидас", 9399m, null, null },
                    { new Guid("dd05de80-0908-4311-9e21-872206b1afee"), new DateTime(2024, 5, 9, 11, 4, 26, 569, DateTimeKind.Local).AddTicks(47), null, null, null, "Кроссовки nike белые ....", new Guid("2b9d7a55-a1b9-4ded-960e-548b878ec410"), "https://i.pinimg.com/originals/58/7d/82/587d82a229ceba80432497d594206c06.png", true, new Guid("0335ae7c-4fc3-4d3b-a9cb-9e0692a555d4"), "Кроссовки nike", 7675m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "CreateDate", "CreatedUserId", "DeleteDate", "DeletedUserId", "GoodSubtypeId", "IsActual", "Name", "UpdateDate", "UpdatedUserId" },
                values: new object[,]
                {
                    { new Guid("0188f128-9295-44f2-8926-9ba81fceb787"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8247), null, null, null, new Guid("a06e411e-bd5e-4e3d-b7f2-251c9320a78d"), true, "M", null, null },
                    { new Guid("0620119e-6bbb-4a99-ab3f-c36842ba3748"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8223), null, null, null, new Guid("2b9d7a55-a1b9-4ded-960e-548b878ec410"), true, "L", null, null },
                    { new Guid("07f8419b-bbc2-488f-8350-74e7ee183cb2"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8204), null, null, null, new Guid("8acd0563-e18e-4771-aa9d-99a35470c95c"), true, "XL", null, null },
                    { new Guid("194dcd11-5cea-4f1f-a991-7951ff6df92f"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8231), null, null, null, new Guid("4f05b48c-f3e3-4f50-b8f0-dce83fe065b9"), true, "M", null, null },
                    { new Guid("1eeb4b46-cf20-4e82-afd7-6d025ccdc392"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8217), null, null, null, new Guid("2b9d7a55-a1b9-4ded-960e-548b878ec410"), true, "XXL", null, null },
                    { new Guid("206d6101-db9f-4684-8eed-249f7682f935"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8278), null, null, null, new Guid("9a753fcf-48a6-4c69-b4ad-7a56b45fba9a"), true, "M", null, null },
                    { new Guid("4902ba7e-42d5-4b42-880c-3f2604c634be"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8275), null, null, null, new Guid("ae8d21f0-4a3c-4a72-b32b-a09ee129dd21"), true, "M", null, null },
                    { new Guid("4f4d1749-c42b-4b22-848d-d914ef9c37b6"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8206), null, null, null, new Guid("8acd0563-e18e-4771-aa9d-99a35470c95c"), true, "L", null, null },
                    { new Guid("5289cee8-c137-4b5b-b128-ea8817339e13"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8271), null, null, null, new Guid("80faa5d3-7c8d-4559-9221-c570d6196b84"), true, "M", null, null },
                    { new Guid("54a53749-7c76-4d01-bf08-143b4760f5f1"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8234), null, null, null, new Guid("4f05b48c-f3e3-4f50-b8f0-dce83fe065b9"), true, "S", null, null },
                    { new Guid("59d8f908-9940-4102-8246-ac344e9ae6ea"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8196), null, null, null, new Guid("8acd0563-e18e-4771-aa9d-99a35470c95c"), true, "XXL", null, null },
                    { new Guid("5fb70383-3e3c-4bb8-9667-54682167c52f"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8230), null, null, null, new Guid("4f05b48c-f3e3-4f50-b8f0-dce83fe065b9"), true, "XL", null, null },
                    { new Guid("62622cc2-2a7b-4cd2-985a-7b38579ff310"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8241), null, null, null, new Guid("f7d01dc8-589b-43ad-98d5-46127e32a05d"), true, "XS", null, null },
                    { new Guid("7007f608-6e14-4fb5-93b6-afe3634fd7c5"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8239), null, null, null, new Guid("f7d01dc8-589b-43ad-98d5-46127e32a05d"), true, "M", null, null },
                    { new Guid("71839bc2-37b9-4a53-9844-d9d2828f46c3"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8282), null, null, null, new Guid("dc87c20f-6e9c-4ae9-b764-805758d01f9f"), true, "M", null, null },
                    { new Guid("7840bbf9-6430-4df9-9953-1a5756b12a1b"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8272), null, null, null, new Guid("a52f0b4f-e30e-423c-be11-e7c8570db9fe"), true, "M", null, null },
                    { new Guid("79c2d304-cc18-4761-8494-4f3f4e3df1cc"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8242), null, null, null, new Guid("630fb955-f9d3-4a82-9c1a-e2466f758842"), true, "M", null, null },
                    { new Guid("7e9e50b7-a211-4108-b968-e3ae49db3bec"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8244), null, null, null, new Guid("ec89f8a9-bf47-415b-b3f8-644933f4739a"), true, "M", null, null },
                    { new Guid("81d09c57-dc23-4927-acdc-17b076137dde"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8240), null, null, null, new Guid("f7d01dc8-589b-43ad-98d5-46127e32a05d"), true, "S", null, null },
                    { new Guid("8562ebc1-7201-42a3-9913-10f8c4d8e943"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8280), null, null, null, new Guid("a24e3678-2362-48cb-8f67-8ad37f4b2108"), true, "M", null, null },
                    { new Guid("925c58e0-b097-4a70-bd3a-464bdd815692"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8281), null, null, null, new Guid("d1df6dad-f860-41f3-abd7-7493cd2d4d0a"), true, "M", null, null },
                    { new Guid("9f091c7b-fd71-4dde-9083-41a26e1e173b"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8235), null, null, null, new Guid("f7d01dc8-589b-43ad-98d5-46127e32a05d"), true, "XXL", null, null },
                    { new Guid("a8815a59-3f46-4ab8-b863-a7f9889879c8"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8212), null, null, null, new Guid("8acd0563-e18e-4771-aa9d-99a35470c95c"), true, "M", null, null },
                    { new Guid("acee8efa-ca20-45c1-8c65-f4978fe71111"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8276), null, null, null, new Guid("3cb59275-53ac-46e9-b7cd-ab3a5c839d27"), true, "M", null, null },
                    { new Guid("af874d12-b847-4349-8189-8f7af1a88c40"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8270), null, null, null, new Guid("a5ecd126-c79c-4f2f-84e4-6fa48b304a74"), true, "M", null, null },
                    { new Guid("b6f481cc-1782-4798-9e3e-e89c5c1b0be7"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8237), null, null, null, new Guid("f7d01dc8-589b-43ad-98d5-46127e32a05d"), true, "XL", null, null },
                    { new Guid("b6fdd6be-b33e-4a30-b3be-1fe8429f6eae"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8246), null, null, null, new Guid("964ba25b-7341-47e9-a3bc-a48586d28c29"), true, "M", null, null },
                    { new Guid("ba62e2aa-0aab-4dca-8351-cdb85a85d926"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8225), null, null, null, new Guid("2b9d7a55-a1b9-4ded-960e-548b878ec410"), true, "M", null, null },
                    { new Guid("c0f41440-f3bb-4042-a592-4b5a1e0a81e2"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8222), null, null, null, new Guid("2b9d7a55-a1b9-4ded-960e-548b878ec410"), true, "XL", null, null },
                    { new Guid("c10f3e0c-0d0b-471e-aef6-4556c14838ed"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8213), null, null, null, new Guid("8acd0563-e18e-4771-aa9d-99a35470c95c"), true, "S", null, null },
                    { new Guid("c7c14374-d27a-4110-92f4-64086b5d7604"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8216), null, null, null, new Guid("8acd0563-e18e-4771-aa9d-99a35470c95c"), true, "XS", null, null },
                    { new Guid("c815cd07-e72b-442b-81c6-d08f4993031c"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8245), null, null, null, new Guid("a9d20359-a3fd-41ee-bddc-29ea25f767e5"), true, "M", null, null },
                    { new Guid("d7e46b26-9d4f-44d1-a46e-e5e0f96bd08a"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8228), null, null, null, new Guid("4f05b48c-f3e3-4f50-b8f0-dce83fe065b9"), true, "XXL", null, null },
                    { new Guid("d7f9e064-34e2-40f1-a39b-0e9dc6b91f23"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8227), null, null, null, new Guid("2b9d7a55-a1b9-4ded-960e-548b878ec410"), true, "XS", null, null },
                    { new Guid("da42dedf-4f56-498f-b0be-385618d5b5a5"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8248), null, null, null, new Guid("e7470efb-bd90-40a9-9ca2-8e344e8d4f45"), true, "M", null, null },
                    { new Guid("f014693a-c251-45dd-b769-f988eabb247f"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8226), null, null, null, new Guid("2b9d7a55-a1b9-4ded-960e-548b878ec410"), true, "S", null, null },
                    { new Guid("f1e308d7-fb33-44b2-84b7-f6535c06e251"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8283), null, null, null, new Guid("65475dc7-95c2-46de-a4da-60efdf5bb1f1"), true, "M", null, null },
                    { new Guid("f3ea2da8-1522-444c-9cff-f5c9e2f9091b"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8238), null, null, null, new Guid("f7d01dc8-589b-43ad-98d5-46127e32a05d"), true, "L", null, null },
                    { new Guid("f71e95b8-2c78-4404-a2b3-0d056e8eaf00"), new DateTime(2024, 5, 9, 11, 4, 26, 568, DateTimeKind.Local).AddTicks(8279), null, null, null, new Guid("4c3a1fab-f569-41c3-beca-d56629c87d58"), true, "M", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_DiscountId",
                table: "Baskets",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_GoodId",
                table: "Baskets",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_SizeId",
                table: "Baskets",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_UserId",
                table: "Baskets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_DiscountTypeId",
                table: "Discounts",
                column: "DiscountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_GoodId",
                table: "Discounts",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Goods_GoodSubtypeId",
                table: "Goods",
                column: "GoodSubtypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Goods_ManufacturerId",
                table: "Goods",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodSubtypes_GoodTypeId",
                table: "GoodSubtypes",
                column: "GoodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedGoods_DiscountId",
                table: "OrderedGoods",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedGoods_GoodId",
                table: "OrderedGoods",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedGoods_OrderId",
                table: "OrderedGoods",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedGoods_SizeId",
                table: "OrderedGoods",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_GoodSubtypeId",
                table: "Sizes",
                column: "GoodSubtypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "OrderedGoods");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "DiscountTypes");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "GoodSubtypes");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "GoodTypes");
        }
    }
}
