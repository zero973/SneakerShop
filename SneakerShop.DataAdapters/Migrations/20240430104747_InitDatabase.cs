using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SneakerShop.DataAdapters.Migrations
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
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GoodSubtypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    GoodId = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Sizes_Goods_GoodId",
                        column: x => x.GoodId,
                        principalTable: "Goods",
                        principalColumn: "Id");
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
                        name: "FK_Baskets_AspNetUsers_SizeId",
                        column: x => x.SizeId,
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
                        name: "FK_Baskets_Sizes_GoodId",
                        column: x => x.GoodId,
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
                    { new Guid("b3ab81bd-47e0-4bf6-b10e-ac8541edf01b"), null, "Customer", "CUSTOMER" },
                    { new Guid("b67e9fcb-6557-4e8f-90e8-a8be52178a59"), null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "DiscountTypes",
                columns: new[] { "Id", "CreateDate", "CreatedUserId", "DeleteDate", "DeletedUserId", "Description", "IsActual", "Name", "Percent", "UpdateDate", "UpdatedUserId" },
                values: new object[,]
                {
                    { new Guid("8cbb7f04-ce8c-4aa9-915e-cdfc2c4e86d2"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2225), null, null, null, "Особая скидка", true, "Особая скидка", 50, null, null },
                    { new Guid("987727c2-5944-448d-8c5f-308ec9b4cebb"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2221), null, null, null, "Обычная летняя скидка", true, "Летняя скидка", 5, null, null },
                    { new Guid("fac3cf56-7b39-4510-a8a3-92d1f6c2fdc2"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2224), null, null, null, "Обычная зимняя скидка", true, "Зимняя скидка", 10, null, null }
                });

            migrationBuilder.InsertData(
                table: "GoodTypes",
                columns: new[] { "Id", "CreateDate", "CreatedUserId", "DeleteDate", "DeletedUserId", "IsActual", "Name", "UpdateDate", "UpdatedUserId" },
                values: new object[,]
                {
                    { new Guid("25e7355a-8498-4932-ae8a-0f3ff24e2a07"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(7268), null, null, null, true, "Верхняя одежда", null, null },
                    { new Guid("72a866ec-28f4-4e6b-bcac-e46bcfe99d06"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(7287), null, null, null, true, "Нижняя одежда", null, null },
                    { new Guid("c1f91914-4d24-4982-ba91-3f185e1f207f"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(7288), null, null, null, true, "Аксессуары", null, null },
                    { new Guid("e3654c33-052e-40ea-b4d0-7a1f6d7daadd"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(7288), null, null, null, true, "Обувь", null, null }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CreateDate", "CreatedUserId", "DeleteDate", "DeletedUserId", "Description", "ImageURL", "IsActual", "Name", "UpdateDate", "UpdatedUserId" },
                values: new object[,]
                {
                    { new Guid("12681a95-2bf8-4fb1-8024-983551b729a2"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(8893), null, null, null, "Американская розничная компания и одноимённый бренд мужской и женской одежды и аксессуаров, а также часов, ювелирных изделий, духов и обуви.", "https://upload.wikimedia.org/wikipedia/commons/7/75/Logo_Guess.jpg", true, "Guess", null, null },
                    { new Guid("1ce68f8b-7671-4648-9789-0bc05cf94dcb"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(8886), null, null, null, "Американская транснациональная компания, специализирующаяся на спортивной одежде и обуви", "https://gas-kvas.com/grafic/uploads/posts/2024-01/gas-kvas-com-p-naik-logotip-na-prozrachnom-fone-7.png", true, "Nike", null, null },
                    { new Guid("2c8124cf-ae5f-4558-87f3-db04592b3096"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(8888), null, null, null, "Американский бренд одежды премиум-класса, выпускающий одежду, обувь, аксессуары, ароматы и товары для дома", "https://ideacdn.net/idea/jj/63/myassets/brands/188/Tommy-Hilfiger-Amblem.jpg?revision=1661341987", true, "Tommy Hilfiger", null, null },
                    { new Guid("6ecb47ee-7598-47ff-8049-d477ef24a638"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(8888), null, null, null, "Итальянский дом моды, производитель одежды, парфюмерии и галантереи", "https://decalfly.com/cdn/shop/products/gucci-brand-decal-logo-sticker_1024x1024.jpg?v=1590520355", true, "Gucci", null, null },
                    { new Guid("7f258dd1-fe8a-4f46-abb9-51d9071d63ed"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(8879), null, null, null, "Немецкая транснациональная компания по производству спортивной одежды, обуви и аксессуаров", "https://flomaster.top/uploads/posts/2023-10/1697227433_flomaster-top-p-adidas-risunok-instagram-1.jpg", true, "Adidas", null, null },
                    { new Guid("ed45032c-5a81-424c-a844-c6f889927726"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(8887), null, null, null, "Промышленная компания Германии, специализирующаяся на выпуске спортивной обуви, одежды и инвентаря под торговой маркой Puma", "https://chelsfieldlakes.co.uk/wp-content/uploads/2017/08/puma-logo-black.png", true, "Puma", null, null }
                });

            migrationBuilder.InsertData(
                table: "GoodSubtypes",
                columns: new[] { "Id", "CreateDate", "CreatedUserId", "DeleteDate", "DeletedUserId", "GoodTypeId", "IsActual", "Name", "UpdateDate", "UpdatedUserId" },
                values: new object[,]
                {
                    { new Guid("17b46bfe-3314-419e-8d71-5c0cca954318"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(7358), null, null, null, new Guid("25e7355a-8498-4932-ae8a-0f3ff24e2a07"), true, "Брюки", null, null },
                    { new Guid("1c5ac0c8-3909-47bf-aa4b-1d8563575ea9"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(7365), null, null, null, new Guid("72a866ec-28f4-4e6b-bcac-e46bcfe99d06"), true, "Подштанники", null, null },
                    { new Guid("1ed5e931-5ca5-4e73-bf83-fe19de727ece"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(7356), null, null, null, new Guid("25e7355a-8498-4932-ae8a-0f3ff24e2a07"), true, "Кофты", null, null },
                    { new Guid("2279add4-ec69-4507-bad3-521205ea64d2"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(7372), null, null, null, new Guid("c1f91914-4d24-4982-ba91-3f185e1f207f"), true, "Рюкзаки", null, null },
                    { new Guid("25b8b8fe-86f8-480c-8c98-748d9ecd8017"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(7373), null, null, null, new Guid("c1f91914-4d24-4982-ba91-3f185e1f207f"), true, "Сумки", null, null },
                    { new Guid("2ceb7274-2231-4517-8dd6-657b7d6611bc"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(7352), null, null, null, new Guid("25e7355a-8498-4932-ae8a-0f3ff24e2a07"), true, "Футболки", null, null },
                    { new Guid("36239051-db81-47f6-875c-f104b22c8a77"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(7370), null, null, null, new Guid("e3654c33-052e-40ea-b4d0-7a1f6d7daadd"), true, "Каблуки", null, null },
                    { new Guid("370d25fc-7f5d-449d-8d3d-0f5169e232d9"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(7378), null, null, null, new Guid("c1f91914-4d24-4982-ba91-3f185e1f207f"), true, "Перчатки", null, null },
                    { new Guid("42eefe0a-5034-4eeb-9607-f6cd42fd0398"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(7369), null, null, null, new Guid("e3654c33-052e-40ea-b4d0-7a1f6d7daadd"), true, "Туфли", null, null },
                    { new Guid("502e46d3-3c5f-4ddf-8150-880bb9974540"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(7377), null, null, null, new Guid("c1f91914-4d24-4982-ba91-3f185e1f207f"), true, "Браслеты", null, null },
                    { new Guid("639b7a20-2f7d-429d-810d-0105a827692a"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(7368), null, null, null, new Guid("e3654c33-052e-40ea-b4d0-7a1f6d7daadd"), true, "Кеды", null, null },
                    { new Guid("6ae8af06-7953-40fe-9286-37475ddb478e"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(7348), null, null, null, new Guid("25e7355a-8498-4932-ae8a-0f3ff24e2a07"), true, "Куртки", null, null },
                    { new Guid("6c54139d-2fc6-4d95-b328-578b559546bb"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(7367), null, null, null, new Guid("e3654c33-052e-40ea-b4d0-7a1f6d7daadd"), true, "Кроссовки", null, null },
                    { new Guid("6c95e96f-3362-496e-92c1-81bce67ea5d9"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(7373), null, null, null, new Guid("c1f91914-4d24-4982-ba91-3f185e1f207f"), true, "Барсетки", null, null },
                    { new Guid("80ba63df-b404-4b40-bacc-9b9aba951ff2"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(7359), null, null, null, new Guid("25e7355a-8498-4932-ae8a-0f3ff24e2a07"), true, "Юбки", null, null },
                    { new Guid("b0fd53a6-9be5-45bc-ad2c-fd9653647e18"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(7357), null, null, null, new Guid("25e7355a-8498-4932-ae8a-0f3ff24e2a07"), true, "Джинсы", null, null },
                    { new Guid("b737c1cb-82a8-4840-b1f8-2ea9ba165992"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(7376), null, null, null, new Guid("c1f91914-4d24-4982-ba91-3f185e1f207f"), true, "Кольца", null, null },
                    { new Guid("b9f6f184-9a03-46a1-a06d-d050a50df07c"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(7360), null, null, null, new Guid("25e7355a-8498-4932-ae8a-0f3ff24e2a07"), true, "Легинсы", null, null },
                    { new Guid("c4b7d871-ac98-4f6a-9ad5-05251bdac362"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(7361), null, null, null, new Guid("25e7355a-8498-4932-ae8a-0f3ff24e2a07"), true, "Кепки", null, null },
                    { new Guid("d5dae8df-c017-4881-a916-089fc035b551"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(7355), null, null, null, new Guid("25e7355a-8498-4932-ae8a-0f3ff24e2a07"), true, "Майки", null, null },
                    { new Guid("f3172816-ce7e-4d7d-8dba-7ac45519eeea"), new DateTime(2024, 4, 30, 13, 47, 47, 422, DateTimeKind.Local).AddTicks(7362), null, null, null, new Guid("25e7355a-8498-4932-ae8a-0f3ff24e2a07"), true, "Шапки", null, null }
                });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "CreateDate", "CreatedUserId", "DeleteDate", "DeletedUserId", "Description", "GoodSubtypeId", "ImageURL", "IsActual", "ManufacturerId", "Name", "Price", "UpdateDate", "UpdatedUserId" },
                values: new object[,]
                {
                    { new Guid("1120ced9-a6a3-4475-82ac-cb0235503b57"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2137), null, null, null, "", new Guid("25b8b8fe-86f8-480c-8c98-748d9ecd8017"), "/empty_good.png", true, new Guid("6ecb47ee-7598-47ff-8049-d477ef24a638"), "Сумка 1", 9000m, null, null },
                    { new Guid("1dbbc996-2de9-4ce4-b55f-94866bf2919c"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2127), null, null, null, "", new Guid("502e46d3-3c5f-4ddf-8150-880bb9974540"), "https://a.lmcdn.ru/product/R/T/RTLABP198301_17558030_1_v1.jpg", true, new Guid("12681a95-2bf8-4fb1-8024-983551b729a2"), "Браслет", 8399m, null, null },
                    { new Guid("22b841d8-a432-45b3-9a1d-c6586ceb6c86"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2164), null, null, null, "", new Guid("1c5ac0c8-3909-47bf-aa4b-1d8563575ea9"), "/empty_good.png", true, new Guid("7f258dd1-fe8a-4f46-abb9-51d9071d63ed"), "Подштанники 1", 7908m, null, null },
                    { new Guid("253037cf-c06d-4cbf-bfa7-23a88113288a"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2170), null, null, null, "", new Guid("b9f6f184-9a03-46a1-a06d-d050a50df07c"), "/empty_good.png", true, new Guid("2c8124cf-ae5f-4558-87f3-db04592b3096"), "Легинсы 2", 7896m, null, null },
                    { new Guid("276bc343-2985-4cfe-a496-c77fa26bab5f"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2131), null, null, null, "Кроссовки nike белые ....", new Guid("6c54139d-2fc6-4d95-b328-578b559546bb"), "https://i.pinimg.com/originals/58/7d/82/587d82a229ceba80432497d594206c06.png", true, new Guid("1ce68f8b-7671-4648-9789-0bc05cf94dcb"), "Кроссовки nike", 7675m, null, null },
                    { new Guid("2b7e075b-3c2f-481b-823b-770217f59723"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2108), null, null, null, "Рюкзак выполнен из прочной ткани CORDURA® и декорирован лентой adidas. В нем найдется место для твоих повседневных вещей, а также внутренний карман для ноутбука и передний карман на молнии для ценных вещей - она создана как для напряженных дней, так и для небольших приключений. Модель минимум на 40% состоит из переработанных материалов и представляет одно из наших решений по сокращению пластиковых отходов.", new Guid("2279add4-ec69-4507-bad3-521205ea64d2"), "https://a.lmcdn.ru/product/R/T/RTLACY475501_21648496_1_v1.jpg", true, new Guid("7f258dd1-fe8a-4f46-abb9-51d9071d63ed"), "Рюкзак MH BP", 7499m, null, null },
                    { new Guid("2c3b93dd-cd94-46f3-b774-0e92f930ad34"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2165), null, null, null, "", new Guid("1c5ac0c8-3909-47bf-aa4b-1d8563575ea9"), "/empty_good.png", true, new Guid("1ce68f8b-7671-4648-9789-0bc05cf94dcb"), "Подштанники 2", 5789m, null, null },
                    { new Guid("415ec5e1-2f59-4a07-af66-ccf2cbc03dde"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2168), null, null, null, "", new Guid("b9f6f184-9a03-46a1-a06d-d050a50df07c"), "/empty_good.png", true, new Guid("2c8124cf-ae5f-4558-87f3-db04592b3096"), "Легинсы 1", 7000m, null, null },
                    { new Guid("43f1d6a4-b395-4539-a003-a9ed89667bc2"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2130), null, null, null, "Куртка адидас чёрная ....", new Guid("6ae8af06-7953-40fe-9286-37475ddb478e"), "https://fullsourcemedia.s3.amazonaws.com/images/items/e/raw/J331_black_form_front.jpg", true, new Guid("7f258dd1-fe8a-4f46-abb9-51d9071d63ed"), "Куртка адидас", 9399m, null, null },
                    { new Guid("4c5864eb-abe6-478a-be7b-3abc674f55bd"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2161), null, null, null, "", new Guid("25b8b8fe-86f8-480c-8c98-748d9ecd8017"), "/empty_good.png", true, new Guid("6ecb47ee-7598-47ff-8049-d477ef24a638"), "Сумка 3", 15349m, null, null },
                    { new Guid("573cfac6-5915-4ad4-a7a5-0c19bdbdf794"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2106), null, null, null, "Куртка выполнена из водо и ветрозащитного текстиля. Детали: капюшон, застежка на молнии с защитой подбородка, два внешних кармана, тонкий слой утеплителя.", new Guid("6ae8af06-7953-40fe-9286-37475ddb478e"), "https://a.lmcdn.ru/product/R/T/RTLACX655501_21520428_4_v1_2x.jpg", true, new Guid("7f258dd1-fe8a-4f46-abb9-51d9071d63ed"), "Куртка утепленная ESS INS HYB JKT", 12999m, null, null },
                    { new Guid("5c085c2d-943b-49e3-bdf0-f9f11cd4b7d4"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2120), null, null, null, "", new Guid("6ae8af06-7953-40fe-9286-37475ddb478e"), "https://a.lmcdn.ru/product/R/T/RTLADF178902_22904293_5_v1_2x.jpg", true, new Guid("1ce68f8b-7671-4648-9789-0bc05cf94dcb"), "Худи M NSW CLUB HOODIE PO FT", 11690m, null, null },
                    { new Guid("73ab4311-ac16-409d-b46c-297ee9293c2e"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2123), null, null, null, "Брюки спортивные выполнены из эластичной ткани. Технология Dri-FIT помогает отводить влагу и обеспечивает комфорт. Детали: эластичный пояс с фиксирующим шнурком, боковые карманы обеспечивают хранение мелких предметов, задний карман имеет пароизоляцию для защиты от пота, манжеты, светоотражающие элементы.", new Guid("17b46bfe-3314-419e-8d71-5c0cca954318"), "https://a.lmcdn.ru/product/R/T/RTLADI750701_22922904_4_v1_2x.jpg", true, new Guid("1ce68f8b-7671-4648-9789-0bc05cf94dcb"), "Брюки спортивные M NK DF PHENOM ELITE KNIT PANT", 16390m, null, null },
                    { new Guid("853e32c7-c698-4a7f-8efb-c73a74208a57"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2099), null, null, null, "Ветровка выполнена из гладкого текстиля. Модель прямого силуэта. Детали: воротник-стойка, застежка на молнии, боковые карманы, удлиненная спинка.", new Guid("6ae8af06-7953-40fe-9286-37475ddb478e"), "https://a.lmcdn.ru/product/R/T/RTLACJ839401_19495431_5_v1_2x.jpg", true, new Guid("ed45032c-5a81-424c-a844-c6f889927726"), "Ветровка ACTIVE Jacket Puma Black", 6999m, null, null },
                    { new Guid("91636e4e-f07f-46d9-847e-d438537b78aa"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2160), null, null, null, "", new Guid("25b8b8fe-86f8-480c-8c98-748d9ecd8017"), "/empty_good.png", true, new Guid("6ecb47ee-7598-47ff-8049-d477ef24a638"), "Сумка 2", 20000m, null, null },
                    { new Guid("99de7ad3-7b43-4a29-901d-deeb2c53ea9e"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2113), null, null, null, "Товар как минимум на 50% состоит из переработанных материалов, а значит, на его создание потребовалось меньше природных ресурсов. Ткань получена путем переработки пластика или текстильных остатков. Выбирая этот товар, вы вносите свой вклад в сохранение окружающей среды.", new Guid("f3172816-ce7e-4d7d-8dba-7ac45519eeea"), "https://a.lmcdn.ru/product/R/T/RTLACY063901_21670176_1_v1.jpg", true, new Guid("7f258dd1-fe8a-4f46-abb9-51d9071d63ed"), "Шапка COLD.RDY BEANIE", 3999m, null, null },
                    { new Guid("9c402325-ff38-4bff-a60b-2e35e51fc984"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2134), null, null, null, "Рюкзак nike белые ....", new Guid("2279add4-ec69-4507-bad3-521205ea64d2"), "https://freepngimg.com/thumb/backpack/9-2-backpack-png-hd.png", true, new Guid("1ce68f8b-7671-4648-9789-0bc05cf94dcb"), "Рюкзак nike", 7675m, null, null },
                    { new Guid("a01a0f29-f250-4c22-b959-b2371a867855"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2126), null, null, null, "", new Guid("639b7a20-2f7d-429d-810d-0105a827692a"), "https://a.lmcdn.ru/product/R/T/RTLACN213702_23428269_3_v1.jpg", true, new Guid("2c8124cf-ae5f-4558-87f3-db04592b3096"), "Кеды", 9490m, null, null },
                    { new Guid("a88d39b1-8417-40be-8e82-f349228660f1"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2114), null, null, null, "Товар как минимум на 50% состоит из переработанных материалов, а значит, на его создание потребовалось меньше природных ресурсов. Ткань получена путем переработки пластика или текстильных остатков. Выбирая этот товар, вы вносите свой вклад в сохранение окружающей среды.", new Guid("370d25fc-7f5d-449d-8d3d-0f5169e232d9"), "https://a.lmcdn.ru/product/R/T/RTLACV074501_21321718_1_v1.jpg", true, new Guid("7f258dd1-fe8a-4f46-abb9-51d9071d63ed"), "Перчатки для фитнеса TRAINING", 4499m, null, null },
                    { new Guid("a8d21ce4-896e-445f-a3c8-89aba27eb742"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2163), null, null, null, "", new Guid("25b8b8fe-86f8-480c-8c98-748d9ecd8017"), "/empty_good.png", true, new Guid("6ecb47ee-7598-47ff-8049-d477ef24a638"), "Сумка 4", 3053m, null, null },
                    { new Guid("aa0aea04-d278-46d8-9271-fd0dc0ee2eb5"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2111), null, null, null, "Товар как минимум на 50% состоит из переработанных материалов, а значит, на его создание потребовалось меньше природных ресурсов. Ткань получена путем переработки пластика или текстильных остатков. Выбирая этот товар, вы вносите свой вклад в сохранение окружающей среды.", new Guid("c4b7d871-ac98-4f6a-9ad5-05251bdac362"), "https://a.lmcdn.ru/product/R/T/RTLACY114001_21699686_1_v1.jpg", true, new Guid("7f258dd1-fe8a-4f46-abb9-51d9071d63ed"), "Бейсболка TECH 3P CAP R.R", 4399m, null, null },
                    { new Guid("b757ffaa-3d95-4727-8479-36f2b1155168"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2135), null, null, null, "Футболка adidas синяя ....", new Guid("2ceb7274-2231-4517-8dd6-657b7d6611bc"), "https://c1.klipartz.com/pngpicture/301/681/sticker-png-tshirt-tshirt-clothing-dress-fashion-jacket-playera-laundry-aline.png", true, new Guid("7f258dd1-fe8a-4f46-abb9-51d9071d63ed"), "Футболка adidas", 10250m, null, null },
                    { new Guid("bfe29506-0603-4e77-9b1e-58b8bcb49947"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2124), null, null, null, "Кроссовки выполнены из натуральной кожи и текстиля. Сетка и замша на верху придают вентиляцию и прочность. Резиновая подошва, вдохновленная вафлями, обеспечивает превосходное сцепление с дорогой и долговечность, кивая на стиль наследия. Зажим для пятки способствует стабильности. Детали: шнуровка.", new Guid("6c54139d-2fc6-4d95-b328-578b559546bb"), "https://a.lmcdn.ru/product/R/T/RTLACR843402_23116771_1_v1.jpg", true, new Guid("1ce68f8b-7671-4648-9789-0bc05cf94dcb"), "Кроссовки Nike Venture Runner", 13590m, null, null },
                    { new Guid("d9b3d38d-12a0-4bf7-ae36-1f0273a47143"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2117), null, null, null, "Утепленная куртка выполнена из стеганого текстиля с толстым слоем искусственного утеплителя. Модель прямого кроя. Детали: застежка на молнии, внутренняя ветрозащитная планка, воротник-стойка, 2 кармана на молнии.", new Guid("6ae8af06-7953-40fe-9286-37475ddb478e"), "https://a.lmcdn.ru/product/R/T/RTLADH300501_22798637_5_v1_2x.jpg", true, new Guid("1ce68f8b-7671-4648-9789-0bc05cf94dcb"), "Куртка утепленная M NK CLUB PUFFER JKT", 38390m, null, null },
                    { new Guid("e06dd243-7a4c-4ed7-bb15-defce34a5f6a"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2109), null, null, null, "Сумка выполнена из прочного текстиля. Детали: застежка на молнии, один внешний карман и один внутренний, подкладка из текстиля.", new Guid("6c95e96f-3362-496e-92c1-81bce67ea5d9"), "https://a.lmcdn.ru/product/R/T/RTLACZ076602_22799653_1_v1.jpg", true, new Guid("7f258dd1-fe8a-4f46-abb9-51d9071d63ed"), "Сумка LINEAR ORG", 1699m, null, null },
                    { new Guid("eb45068b-ae98-48e1-a6c4-861673928abe"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(2128), null, null, null, "", new Guid("b737c1cb-82a8-4840-b1f8-2ea9ba165992"), "https://a.lmcdn.ru/product/R/T/RTLABP201301_17556292_1_v1.jpg", true, new Guid("12681a95-2bf8-4fb1-8024-983551b729a2"), "Кольцо", 4699m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "CreateDate", "CreatedUserId", "DeleteDate", "DeletedUserId", "GoodId", "GoodSubtypeId", "IsActual", "Name", "UpdateDate", "UpdatedUserId" },
                values: new object[,]
                {
                    { new Guid("02b47b1e-5809-4092-851d-2bbfb5ecd074"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(107), null, null, null, null, new Guid("370d25fc-7f5d-449d-8d3d-0f5169e232d9"), true, "M", null, null },
                    { new Guid("0b7f7e8f-4326-4431-97ad-c506cec9ff18"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(93), null, null, null, null, new Guid("80ba63df-b404-4b40-bacc-9b9aba951ff2"), true, "M", null, null },
                    { new Guid("0f7ca2f3-bd34-41b2-aed4-70665839152d"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(38), null, null, null, null, new Guid("6c54139d-2fc6-4d95-b328-578b559546bb"), true, "XXL", null, null },
                    { new Guid("17ccac0f-b979-4d34-8b95-65c0a2bdbd29"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(27), null, null, null, null, new Guid("6ae8af06-7953-40fe-9286-37475ddb478e"), true, "XL", null, null },
                    { new Guid("1acf4df6-6458-4466-8fca-512f1e1579a4"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(103), null, null, null, null, new Guid("25b8b8fe-86f8-480c-8c98-748d9ecd8017"), true, "M", null, null },
                    { new Guid("272d1fb7-5844-4837-820a-baac3fa718bf"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(45), null, null, null, null, new Guid("6c54139d-2fc6-4d95-b328-578b559546bb"), true, "XL", null, null },
                    { new Guid("32feb6c2-6c0e-49f8-86b9-c6cce8bf8808"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(95), null, null, null, null, new Guid("c4b7d871-ac98-4f6a-9ad5-05251bdac362"), true, "M", null, null },
                    { new Guid("480c04ab-a120-4a3a-8299-0802413f6d89"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(104), null, null, null, null, new Guid("6c95e96f-3362-496e-92c1-81bce67ea5d9"), true, "M", null, null },
                    { new Guid("502cf27d-961d-4b98-a9f1-70f15aa78a99"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(100), null, null, null, null, new Guid("639b7a20-2f7d-429d-810d-0105a827692a"), true, "M", null, null },
                    { new Guid("57093945-1aed-45ca-ad73-6baa723c5d1d"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(101), null, null, null, null, new Guid("42eefe0a-5034-4eeb-9607-f6cd42fd0398"), true, "M", null, null },
                    { new Guid("5ad74ee6-1c7f-4849-844a-043436f48290"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(36), null, null, null, null, new Guid("6ae8af06-7953-40fe-9286-37475ddb478e"), true, "XS", null, null },
                    { new Guid("62e52fe2-b2c8-4ff3-82f9-00c6a8425fc2"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(31), null, null, null, null, new Guid("6ae8af06-7953-40fe-9286-37475ddb478e"), true, "M", null, null },
                    { new Guid("66d0fd66-c149-437f-96cd-e33d648779fa"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(105), null, null, null, null, new Guid("b737c1cb-82a8-4840-b1f8-2ea9ba165992"), true, "M", null, null },
                    { new Guid("6bf2864e-8881-45b8-95b3-2d0a231d32e4"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(51), null, null, null, null, new Guid("6c54139d-2fc6-4d95-b328-578b559546bb"), true, "XS", null, null },
                    { new Guid("7989bcff-0566-445a-a2c9-2364439968a1"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(49), null, null, null, null, new Guid("6c54139d-2fc6-4d95-b328-578b559546bb"), true, "M", null, null },
                    { new Guid("89ed75ce-ceff-42e9-85f6-b5980af65a13"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(81), null, null, null, null, new Guid("2ceb7274-2231-4517-8dd6-657b7d6611bc"), true, "XXL", null, null },
                    { new Guid("91850c5d-39de-429f-901a-8c5a77ee9184"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(30), null, null, null, null, new Guid("6ae8af06-7953-40fe-9286-37475ddb478e"), true, "L", null, null },
                    { new Guid("95f382c7-3742-4d9a-953d-7c9e7fdced14"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(90), null, null, null, null, new Guid("1ed5e931-5ca5-4e73-bf83-fe19de727ece"), true, "M", null, null },
                    { new Guid("9abcfb01-96e7-4380-b586-b8c7ba267b1a"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(85), null, null, null, null, new Guid("2ceb7274-2231-4517-8dd6-657b7d6611bc"), true, "M", null, null },
                    { new Guid("9ee64b59-bdbd-4912-856b-1cd344920a78"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(54), null, null, null, null, new Guid("2279add4-ec69-4507-bad3-521205ea64d2"), true, "M", null, null },
                    { new Guid("9eecc7a6-49e4-46b1-ae2a-1eb6bdd5f025"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(50), null, null, null, null, new Guid("6c54139d-2fc6-4d95-b328-578b559546bb"), true, "S", null, null },
                    { new Guid("a541c7d6-1558-4f53-9da6-fd9bf6972885"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(83), null, null, null, null, new Guid("2ceb7274-2231-4517-8dd6-657b7d6611bc"), true, "XL", null, null },
                    { new Guid("ab364987-0a14-4a1d-9976-b27a51b61c83"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(47), null, null, null, null, new Guid("6c54139d-2fc6-4d95-b328-578b559546bb"), true, "L", null, null },
                    { new Guid("b415c0af-1666-48b4-9e32-febb46b3ff98"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(97), null, null, null, null, new Guid("1c5ac0c8-3909-47bf-aa4b-1d8563575ea9"), true, "M", null, null },
                    { new Guid("b68a8120-2fec-4684-9b25-1c5ed1da58bc"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(21), null, null, null, null, new Guid("6ae8af06-7953-40fe-9286-37475ddb478e"), true, "XXL", null, null },
                    { new Guid("bd8b3109-2ea9-4dac-9d50-e0f16c6a2c15"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(33), null, null, null, null, new Guid("6ae8af06-7953-40fe-9286-37475ddb478e"), true, "S", null, null },
                    { new Guid("c1b508b1-2852-4f91-836d-cdda7d25b6d0"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(84), null, null, null, null, new Guid("2ceb7274-2231-4517-8dd6-657b7d6611bc"), true, "L", null, null },
                    { new Guid("c30fea84-9ba4-43c1-aecd-fad13190d260"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(88), null, null, null, null, new Guid("d5dae8df-c017-4881-a916-089fc035b551"), true, "M", null, null },
                    { new Guid("cf9deb8d-b553-436d-ac36-be613adcdc7b"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(102), null, null, null, null, new Guid("36239051-db81-47f6-875c-f104b22c8a77"), true, "M", null, null },
                    { new Guid("d39518d8-b221-49a0-a016-dec71758d5c4"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(86), null, null, null, null, new Guid("2ceb7274-2231-4517-8dd6-657b7d6611bc"), true, "S", null, null },
                    { new Guid("d58dce14-0db6-4b16-8afc-2c916ecb0e1f"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(91), null, null, null, null, new Guid("b0fd53a6-9be5-45bc-ad2c-fd9653647e18"), true, "M", null, null },
                    { new Guid("de5d0ecc-78c3-41f5-8596-627033b58c37"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(106), null, null, null, null, new Guid("502e46d3-3c5f-4ddf-8150-880bb9974540"), true, "M", null, null },
                    { new Guid("e3328c1e-6bbb-4609-9081-6d9e1c6cf641"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(53), null, null, null, null, new Guid("2279add4-ec69-4507-bad3-521205ea64d2"), true, "XL", null, null },
                    { new Guid("e836fde6-df40-4d5f-80db-8b817982ca5e"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(92), null, null, null, null, new Guid("17b46bfe-3314-419e-8d71-5c0cca954318"), true, "M", null, null },
                    { new Guid("e8c2d00e-1612-4965-8a47-d890222a666d"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(87), null, null, null, null, new Guid("2ceb7274-2231-4517-8dd6-657b7d6611bc"), true, "XS", null, null },
                    { new Guid("f23a06b2-18b3-41aa-9445-d4289d4212d7"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(56), null, null, null, null, new Guid("2279add4-ec69-4507-bad3-521205ea64d2"), true, "S", null, null },
                    { new Guid("f2b5a071-8431-44dd-8992-acad8ee7d5e9"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(52), null, null, null, null, new Guid("2279add4-ec69-4507-bad3-521205ea64d2"), true, "XXL", null, null },
                    { new Guid("f56bc98b-6c76-4ef3-bd4c-9f4e928ea811"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(96), null, null, null, null, new Guid("f3172816-ce7e-4d7d-8dba-7ac45519eeea"), true, "M", null, null },
                    { new Guid("fad80224-db9c-4e0f-aeac-02cc5c3eb6e0"), new DateTime(2024, 4, 30, 13, 47, 47, 423, DateTimeKind.Local).AddTicks(94), null, null, null, null, new Guid("b9f6f184-9a03-46a1-a06d-d050a50df07c"), true, "M", null, null }
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
                name: "IX_Sizes_GoodId",
                table: "Sizes",
                column: "GoodId");

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
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "GoodSubtypes");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "GoodTypes");
        }
    }
}
