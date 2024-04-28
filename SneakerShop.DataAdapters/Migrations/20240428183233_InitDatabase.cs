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
                    { new Guid("5e615cd3-1ba7-4110-81fd-8fa4c0abb5e9"), null, "Admin", "ADMIN" },
                    { new Guid("7783ba08-532a-4061-8cdc-69fe1bc96301"), null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("2f9b0ad3-00d0-45be-b5fd-b49b9093a1a7"), 0, "afbf1e0b-5573-4484-9ff4-060a13ea76c7", "sneakershop@mail.ru", true, "Admin", "Admin", false, null, null, null, "AQAAAAIAAYagAAAAEO7B2CUOgbgiKGx+2YkjFD27PKcmLSI7LA6AJOPchq2nTFLZj8xpGnjp8VTMbNjOEA==", null, false, null, false, "Admin" });

            migrationBuilder.InsertData(
                table: "DiscountTypes",
                columns: new[] { "Id", "CreateDate", "CreatedUserId", "DeleteDate", "DeletedUserId", "Description", "IsActual", "Name", "Percent", "UpdateDate", "UpdatedUserId" },
                values: new object[,]
                {
                    { new Guid("1351dae0-b8d2-48cf-a13d-a4cd67856629"), new DateTime(2024, 4, 28, 21, 32, 33, 81, DateTimeKind.Local).AddTicks(461), null, null, null, "Обычная летняя скидка", true, "Летняя скидка", 5, null, null },
                    { new Guid("73d85971-227e-4a77-8b2d-cca587857d13"), new DateTime(2024, 4, 28, 21, 32, 33, 81, DateTimeKind.Local).AddTicks(466), null, null, null, "Обычная зимняя скидка", true, "Зимняя скидка", 10, null, null },
                    { new Guid("d4822de1-9340-4fc8-a5a4-13cb8c417261"), new DateTime(2024, 4, 28, 21, 32, 33, 81, DateTimeKind.Local).AddTicks(467), null, null, null, "Особая скидка", true, "Особая скидка", 50, null, null }
                });

            migrationBuilder.InsertData(
                table: "GoodTypes",
                columns: new[] { "Id", "CreateDate", "CreatedUserId", "DeleteDate", "DeletedUserId", "IsActual", "Name", "UpdateDate", "UpdatedUserId" },
                values: new object[,]
                {
                    { new Guid("39234702-29d2-4abb-976e-a0bc8a8f4836"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(4970), null, null, null, true, "Обувь", null, null },
                    { new Guid("5fbdc75d-be80-431e-979d-1e5e02b1ce5c"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(4971), null, null, null, true, "Аксессуары", null, null },
                    { new Guid("8dcf657e-a3b2-497e-a6de-d2cc6687b2e8"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(4968), null, null, null, true, "Нижняя одежда", null, null },
                    { new Guid("be06f6e5-66a3-4bf3-8217-8a8433daaf57"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(4950), null, null, null, true, "Верхняя одежда", null, null }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CreateDate", "CreatedUserId", "DeleteDate", "DeletedUserId", "Description", "IsActual", "Name", "UpdateDate", "UpdatedUserId" },
                values: new object[,]
                {
                    { new Guid("15052e27-e29c-4ef6-a99a-d379812b5d53"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(7389), null, null, null, "Адики .......", true, "Adidas", null, null },
                    { new Guid("431ef5bf-2da3-4426-af11-ccb776773e09"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(7397), null, null, null, "Томми ..........", true, "Tommy Hilfiger", null, null },
                    { new Guid("dea7b10c-8b02-4af8-b587-737f11914062"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(7396), null, null, null, "Гучи ..........", true, "Gucci", null, null },
                    { new Guid("e55eaea7-ef90-42fb-954e-ae74251cf961"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(7395), null, null, null, "Найки ..........", true, "Nke", null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("5e615cd3-1ba7-4110-81fd-8fa4c0abb5e9"), new Guid("2f9b0ad3-00d0-45be-b5fd-b49b9093a1a7") },
                    { new Guid("7783ba08-532a-4061-8cdc-69fe1bc96301"), new Guid("2f9b0ad3-00d0-45be-b5fd-b49b9093a1a7") }
                });

            migrationBuilder.InsertData(
                table: "GoodSubtypes",
                columns: new[] { "Id", "CreateDate", "CreatedUserId", "DeleteDate", "DeletedUserId", "GoodTypeId", "IsActual", "Name", "UpdateDate", "UpdatedUserId" },
                values: new object[,]
                {
                    { new Guid("010e9af5-1d47-453c-8bf4-ca2acedf9f9f"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(4998), null, null, null, new Guid("be06f6e5-66a3-4bf3-8217-8a8433daaf57"), true, "Куртки", null, null },
                    { new Guid("11a22f6f-8043-46cf-9d37-d2bf58b0ec95"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(5026), null, null, null, new Guid("39234702-29d2-4abb-976e-a0bc8a8f4836"), true, "Кроссовки", null, null },
                    { new Guid("24d97687-937a-4b70-951c-0f75338445d7"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(5023), null, null, null, new Guid("8dcf657e-a3b2-497e-a6de-d2cc6687b2e8"), true, "Подштанники", null, null },
                    { new Guid("50d2dc32-0ef7-43f0-81ed-ead8c237dfb9"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(5029), null, null, null, new Guid("39234702-29d2-4abb-976e-a0bc8a8f4836"), true, "Каблуки", null, null },
                    { new Guid("76d27d28-25bb-44d0-8846-71bd288982c1"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(5018), null, null, null, new Guid("be06f6e5-66a3-4bf3-8217-8a8433daaf57"), true, "Кофты", null, null },
                    { new Guid("8d1315ef-d51b-4c28-8d87-214892b562fc"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(5027), null, null, null, new Guid("39234702-29d2-4abb-976e-a0bc8a8f4836"), true, "Кеды", null, null },
                    { new Guid("a194eb2f-8842-4e51-856a-f2093bba0c3a"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(5021), null, null, null, new Guid("be06f6e5-66a3-4bf3-8217-8a8433daaf57"), true, "Юбки", null, null },
                    { new Guid("a43686cd-3835-4a6f-a4ea-ae801cf5196d"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(5028), null, null, null, new Guid("39234702-29d2-4abb-976e-a0bc8a8f4836"), true, "Туфли", null, null },
                    { new Guid("aaa82db2-f368-43e6-bfcf-472a9c125936"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(5022), null, null, null, new Guid("be06f6e5-66a3-4bf3-8217-8a8433daaf57"), true, "Легинсы", null, null },
                    { new Guid("ad5f2ad3-68b2-404f-ac8d-92501f59a3e7"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(5017), null, null, null, new Guid("be06f6e5-66a3-4bf3-8217-8a8433daaf57"), true, "Майки", null, null },
                    { new Guid("b70270fe-52ac-47d7-8ea0-d6b2a8c0a036"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(5030), null, null, null, new Guid("5fbdc75d-be80-431e-979d-1e5e02b1ce5c"), true, "Сумки", null, null },
                    { new Guid("b7672fd5-bd97-4caf-876f-7454e0022317"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(5020), null, null, null, new Guid("be06f6e5-66a3-4bf3-8217-8a8433daaf57"), true, "Брюки", null, null },
                    { new Guid("c4d14640-e6b3-44a7-ae99-f88f2b097b65"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(5019), null, null, null, new Guid("be06f6e5-66a3-4bf3-8217-8a8433daaf57"), true, "Джинсы", null, null },
                    { new Guid("c6b8fe5a-f555-4290-8d61-cb862829d062"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(5031), null, null, null, new Guid("5fbdc75d-be80-431e-979d-1e5e02b1ce5c"), true, "Барсетки", null, null },
                    { new Guid("cce6bc71-3e60-4e0a-bc5e-fe3bbf2eea03"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(5025), null, null, null, new Guid("8dcf657e-a3b2-497e-a6de-d2cc6687b2e8"), true, "Трусы", null, null },
                    { new Guid("ce9e4965-f0ae-4c69-9aaa-fe9642c85a32"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(5035), null, null, null, new Guid("5fbdc75d-be80-431e-979d-1e5e02b1ce5c"), true, "Браслеты", null, null },
                    { new Guid("d023cf9a-7b27-4bc4-b481-6fdff24d1faa"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(5016), null, null, null, new Guid("be06f6e5-66a3-4bf3-8217-8a8433daaf57"), true, "Футболки", null, null },
                    { new Guid("ddcea7c9-521a-4b4d-8dc9-dbafda0342fa"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(5036), null, null, null, new Guid("5fbdc75d-be80-431e-979d-1e5e02b1ce5c"), true, "Перчатки", null, null },
                    { new Guid("e29440b7-f4c4-4b36-b144-3f2c4d681b51"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(5029), null, null, null, new Guid("5fbdc75d-be80-431e-979d-1e5e02b1ce5c"), true, "Рюкзаки", null, null },
                    { new Guid("efb5e640-9c7d-4a2b-a442-3064962f3a73"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(5034), null, null, null, new Guid("5fbdc75d-be80-431e-979d-1e5e02b1ce5c"), true, "Кольца", null, null }
                });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "CreateDate", "CreatedUserId", "DeleteDate", "DeletedUserId", "Description", "GoodSubtypeId", "ImageURL", "IsActual", "ManufacturerId", "Name", "Price", "UpdateDate", "UpdatedUserId" },
                values: new object[,]
                {
                    { new Guid("08660589-ac5a-4c6f-8704-d99f20d2658d"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(9440), null, null, null, "Рюкзак nike белые ....", new Guid("e29440b7-f4c4-4b36-b144-3f2c4d681b51"), "https://freepngimg.com/thumb/backpack/9-2-backpack-png-hd.png", true, new Guid("e55eaea7-ef90-42fb-954e-ae74251cf961"), "Рюкзаак nike", 5000m, null, null },
                    { new Guid("2fd0f100-5d72-434a-98eb-6a3065ebe39f"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(9441), null, null, null, "Футболка adidas синяя ....", new Guid("d023cf9a-7b27-4bc4-b481-6fdff24d1faa"), "https://c1.klipartz.com/pngpicture/301/681/sticker-png-tshirt-tshirt-clothing-dress-fashion-jacket-playera-laundry-aline.png", true, new Guid("15052e27-e29c-4ef6-a99a-d379812b5d53"), "Футболка adidas", 5000m, null, null },
                    { new Guid("acb2055a-4ee4-48aa-9469-c9899db1e818"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(9438), null, null, null, "Кроссовки nike белые ....", new Guid("11a22f6f-8043-46cf-9d37-d2bf58b0ec95"), "https://i.pinimg.com/originals/58/7d/82/587d82a229ceba80432497d594206c06.png", true, new Guid("e55eaea7-ef90-42fb-954e-ae74251cf961"), "Кроссовки nike", 2500m, null, null },
                    { new Guid("d5459aa8-575d-4bb6-b2c4-de3c9e1590eb"), new DateTime(2024, 4, 28, 21, 32, 33, 80, DateTimeKind.Local).AddTicks(9425), null, null, null, "Куртка адидас чёрная ....", new Guid("010e9af5-1d47-453c-8bf4-ca2acedf9f9f"), "https://fullsourcemedia.s3.amazonaws.com/images/items/e/raw/J331_black_form_front.jpg", true, new Guid("15052e27-e29c-4ef6-a99a-d379812b5d53"), "Куртка адидас", 500m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "CreateDate", "CreatedUserId", "DeleteDate", "DeletedUserId", "GoodSubtypeId", "IsActual", "Name", "UpdateDate", "UpdatedUserId" },
                values: new object[,]
                {
                    { new Guid("09abec63-1553-406e-82eb-134aac905f48"), new DateTime(2024, 4, 28, 21, 32, 33, 81, DateTimeKind.Local).AddTicks(295), null, null, null, new Guid("e29440b7-f4c4-4b36-b144-3f2c4d681b51"), true, "XL", null, null },
                    { new Guid("1a22db0b-4c71-41f7-ab8e-5a4c6ec73352"), new DateTime(2024, 4, 28, 21, 32, 33, 81, DateTimeKind.Local).AddTicks(287), null, null, null, new Guid("11a22f6f-8043-46cf-9d37-d2bf58b0ec95"), true, "L", null, null },
                    { new Guid("1d083484-10f9-481a-9285-a04048b87024"), new DateTime(2024, 4, 28, 21, 32, 33, 81, DateTimeKind.Local).AddTicks(291), null, null, null, new Guid("11a22f6f-8043-46cf-9d37-d2bf58b0ec95"), true, "XS", null, null },
                    { new Guid("2f59ee82-7737-4457-aec2-538fc071f10a"), new DateTime(2024, 4, 28, 21, 32, 33, 81, DateTimeKind.Local).AddTicks(286), null, null, null, new Guid("11a22f6f-8043-46cf-9d37-d2bf58b0ec95"), true, "XL", null, null },
                    { new Guid("2fbefbcb-6fad-4c92-b86e-b00d5b0f40b8"), new DateTime(2024, 4, 28, 21, 32, 33, 81, DateTimeKind.Local).AddTicks(306), null, null, null, new Guid("d023cf9a-7b27-4bc4-b481-6fdff24d1faa"), true, "XS", null, null },
                    { new Guid("4bdc91da-1aa0-4247-bf10-0e28cb1e3d5b"), new DateTime(2024, 4, 28, 21, 32, 33, 81, DateTimeKind.Local).AddTicks(289), null, null, null, new Guid("11a22f6f-8043-46cf-9d37-d2bf58b0ec95"), true, "M", null, null },
                    { new Guid("511aaf50-d268-4989-b341-61653a170088"), new DateTime(2024, 4, 28, 21, 32, 33, 81, DateTimeKind.Local).AddTicks(298), null, null, null, new Guid("d023cf9a-7b27-4bc4-b481-6fdff24d1faa"), true, "XXL", null, null },
                    { new Guid("5ec65441-21e5-4245-909d-6372eb2f6cad"), new DateTime(2024, 4, 28, 21, 32, 33, 81, DateTimeKind.Local).AddTicks(276), null, null, null, new Guid("010e9af5-1d47-453c-8bf4-ca2acedf9f9f"), true, "M", null, null },
                    { new Guid("6727e37f-8289-4c4c-a4ae-fd88f9607a8d"), new DateTime(2024, 4, 28, 21, 32, 33, 81, DateTimeKind.Local).AddTicks(249), null, null, null, new Guid("010e9af5-1d47-453c-8bf4-ca2acedf9f9f"), true, "L", null, null },
                    { new Guid("67bd71ef-e889-4402-b58e-c79b718732a9"), new DateTime(2024, 4, 28, 21, 32, 33, 81, DateTimeKind.Local).AddTicks(296), null, null, null, new Guid("e29440b7-f4c4-4b36-b144-3f2c4d681b51"), true, "M", null, null },
                    { new Guid("756a9ffd-8c08-4585-ae11-4c605e903b17"), new DateTime(2024, 4, 28, 21, 32, 33, 81, DateTimeKind.Local).AddTicks(292), null, null, null, new Guid("e29440b7-f4c4-4b36-b144-3f2c4d681b51"), true, "XXL", null, null },
                    { new Guid("843f6d8d-f0c5-4b6b-9e2c-e8a39e14142d"), new DateTime(2024, 4, 28, 21, 32, 33, 81, DateTimeKind.Local).AddTicks(297), null, null, null, new Guid("e29440b7-f4c4-4b36-b144-3f2c4d681b51"), true, "S", null, null },
                    { new Guid("a7d01673-acf2-454d-8071-4cc5e6f7b269"), new DateTime(2024, 4, 28, 21, 32, 33, 81, DateTimeKind.Local).AddTicks(301), null, null, null, new Guid("d023cf9a-7b27-4bc4-b481-6fdff24d1faa"), true, "L", null, null },
                    { new Guid("ab74a4e2-728b-4dfe-bc7a-e6c119d895b0"), new DateTime(2024, 4, 28, 21, 32, 33, 81, DateTimeKind.Local).AddTicks(248), null, null, null, new Guid("010e9af5-1d47-453c-8bf4-ca2acedf9f9f"), true, "XL", null, null },
                    { new Guid("b8a79dc2-e0dd-4a2f-9bc8-0fb05bc0919d"), new DateTime(2024, 4, 28, 21, 32, 33, 81, DateTimeKind.Local).AddTicks(302), null, null, null, new Guid("d023cf9a-7b27-4bc4-b481-6fdff24d1faa"), true, "M", null, null },
                    { new Guid("c8180835-6942-4e2b-99a4-7a602092685e"), new DateTime(2024, 4, 28, 21, 32, 33, 81, DateTimeKind.Local).AddTicks(241), null, null, null, new Guid("010e9af5-1d47-453c-8bf4-ca2acedf9f9f"), true, "XXL", null, null },
                    { new Guid("c8fdfbd8-dcaa-4bc2-b6ad-1953f71f331d"), new DateTime(2024, 4, 28, 21, 32, 33, 81, DateTimeKind.Local).AddTicks(300), null, null, null, new Guid("d023cf9a-7b27-4bc4-b481-6fdff24d1faa"), true, "XL", null, null },
                    { new Guid("cd2b66d4-6921-4248-975b-9142149946a9"), new DateTime(2024, 4, 28, 21, 32, 33, 81, DateTimeKind.Local).AddTicks(278), null, null, null, new Guid("010e9af5-1d47-453c-8bf4-ca2acedf9f9f"), true, "S", null, null },
                    { new Guid("e102460c-a053-40ac-b4c2-a45aa36051aa"), new DateTime(2024, 4, 28, 21, 32, 33, 81, DateTimeKind.Local).AddTicks(284), null, null, null, new Guid("010e9af5-1d47-453c-8bf4-ca2acedf9f9f"), true, "XS", null, null },
                    { new Guid("e6a4bcfa-e81b-425e-bd08-ab347fac28c7"), new DateTime(2024, 4, 28, 21, 32, 33, 81, DateTimeKind.Local).AddTicks(290), null, null, null, new Guid("11a22f6f-8043-46cf-9d37-d2bf58b0ec95"), true, "S", null, null },
                    { new Guid("e9b1d35a-d658-4995-86f3-422f47d0eea0"), new DateTime(2024, 4, 28, 21, 32, 33, 81, DateTimeKind.Local).AddTicks(285), null, null, null, new Guid("11a22f6f-8043-46cf-9d37-d2bf58b0ec95"), true, "XXL", null, null },
                    { new Guid("ed24337d-59ae-4e4d-a2ca-417325ac6e33"), new DateTime(2024, 4, 28, 21, 32, 33, 81, DateTimeKind.Local).AddTicks(303), null, null, null, new Guid("d023cf9a-7b27-4bc4-b481-6fdff24d1faa"), true, "S", null, null }
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
