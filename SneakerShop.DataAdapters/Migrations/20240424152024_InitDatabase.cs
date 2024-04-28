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
                    { new Guid("2503ca1f-4de2-43ef-8749-73b91b9c4b8c"), null, "Customer", "CUSTOMER" },
                    { new Guid("ac6c10fd-58cd-4f2e-a69d-27ca572db6b2"), null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("3f049b98-849e-4d08-ab8a-5b8f2537d54f"), 0, "2b22cac6-209c-44e0-9718-fcb71d1dcc53", "sneakershop@mail.ru", true, "Admin", "Admin", false, null, null, null, "AQAAAAIAAYagAAAAENpjyE56KJSxrIVed2r0E4DbY6JOGT9JlwJ6ykVMFgau3p/B2dDccELy0XVFVeGIRg==", null, false, null, false, "Admin" });

            migrationBuilder.InsertData(
                table: "DiscountTypes",
                columns: new[] { "Id", "CreateDate", "CreatedUserId", "DeleteDate", "DeletedUserId", "Description", "IsActual", "Name", "Percent", "UpdateDate", "UpdatedUserId" },
                values: new object[,]
                {
                    { new Guid("0e21665e-3aeb-48f5-ad21-8564bcafb3b2"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(9496), null, null, null, "Обычная зимняя скидка", true, "Зимняя скидка", 10, null, null },
                    { new Guid("279847e2-08f0-4082-a2e0-1f62a8f6fd79"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(9497), null, null, null, "Особая скидка", true, "Особая скидка", 50, null, null },
                    { new Guid("d2c41197-f68e-4c92-bf29-a6e68b61a70f"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(9492), null, null, null, "Обычная летняя скидка", true, "Летняя скидка", 5, null, null }
                });

            migrationBuilder.InsertData(
                table: "GoodTypes",
                columns: new[] { "Id", "CreateDate", "CreatedUserId", "DeleteDate", "DeletedUserId", "IsActual", "Name", "UpdateDate", "UpdatedUserId" },
                values: new object[,]
                {
                    { new Guid("5b297472-63c5-4329-afd8-dda647b953dd"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(3591), null, null, null, true, "Аксессуары", null, null },
                    { new Guid("98f424e2-9ffb-458f-84d4-e8cff5f6585f"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(3589), null, null, null, true, "Нижняя одежда", null, null },
                    { new Guid("ccb924ac-bae7-4d6a-b606-c578e903be91"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(3564), null, null, null, true, "Верхняя одежда", null, null },
                    { new Guid("efe665a4-2531-44da-a040-b7bb4da8ed22"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(3590), null, null, null, true, "Обувь", null, null }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CreateDate", "CreatedUserId", "DeleteDate", "DeletedUserId", "Description", "IsActual", "Name", "UpdateDate", "UpdatedUserId" },
                values: new object[,]
                {
                    { new Guid("8f623ecb-f2dc-4d04-b344-fe4a0abed041"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(6341), null, null, null, "Томми ..........", true, "Tommy Hilfiger", null, null },
                    { new Guid("c673879d-cb67-48c8-852b-cce9b7056e0c"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(6340), null, null, null, "Гучи ..........", true, "Gucci", null, null },
                    { new Guid("dfe8ec89-4a13-4bbe-8285-935017f8ce23"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(6290), null, null, null, "Адики .......", true, "Adidas", null, null },
                    { new Guid("f7e37f02-86bc-4892-951d-c9e6c9f0a7ce"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(6338), null, null, null, "Найки ..........", true, "Nke", null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("ac6c10fd-58cd-4f2e-a69d-27ca572db6b2"), new Guid("3f049b98-849e-4d08-ab8a-5b8f2537d54f") });

            migrationBuilder.InsertData(
                table: "GoodSubtypes",
                columns: new[] { "Id", "CreateDate", "CreatedUserId", "DeleteDate", "DeletedUserId", "GoodTypeId", "IsActual", "Name", "UpdateDate", "UpdatedUserId" },
                values: new object[,]
                {
                    { new Guid("0a8a7aac-5217-47ca-b635-448dd5603522"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(3636), null, null, null, new Guid("ccb924ac-bae7-4d6a-b606-c578e903be91"), true, "Куртки", null, null },
                    { new Guid("0afd27db-05c4-48ab-a612-d16192b40503"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(3653), null, null, null, new Guid("efe665a4-2531-44da-a040-b7bb4da8ed22"), true, "Кроссовки", null, null },
                    { new Guid("0d81af64-d21d-4758-adbc-dd2ef836a866"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(3661), null, null, null, new Guid("5b297472-63c5-4329-afd8-dda647b953dd"), true, "Сумки", null, null },
                    { new Guid("1690e16c-509c-4b3f-a6fa-e4d5129a970f"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(3663), null, null, null, new Guid("5b297472-63c5-4329-afd8-dda647b953dd"), true, "Кольца", null, null },
                    { new Guid("1e074d7f-ee5d-473c-8518-adf5656ea64a"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(3647), null, null, null, new Guid("ccb924ac-bae7-4d6a-b606-c578e903be91"), true, "Брюки", null, null },
                    { new Guid("644f7f44-2b50-4e96-9219-1292ac0f64d2"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(3654), null, null, null, new Guid("efe665a4-2531-44da-a040-b7bb4da8ed22"), true, "Кеды", null, null },
                    { new Guid("66b8b3b2-6f2a-4e07-b092-bb60bd9263b9"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(3656), null, null, null, new Guid("efe665a4-2531-44da-a040-b7bb4da8ed22"), true, "Туфли", null, null },
                    { new Guid("70c088d2-7d32-401b-894c-c62f7f8457f9"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(3651), null, null, null, new Guid("98f424e2-9ffb-458f-84d4-e8cff5f6585f"), true, "Подштанники", null, null },
                    { new Guid("7f259ec8-b615-4245-b761-95888bbfadd1"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(3665), null, null, null, new Guid("5b297472-63c5-4329-afd8-dda647b953dd"), true, "Перчатки", null, null },
                    { new Guid("a4a48d37-dcb1-40f0-86bd-f961e089a554"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(3662), null, null, null, new Guid("5b297472-63c5-4329-afd8-dda647b953dd"), true, "Барсетки", null, null },
                    { new Guid("a5375bc2-ca16-4c01-9c12-f175a22f4419"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(3638), null, null, null, new Guid("ccb924ac-bae7-4d6a-b606-c578e903be91"), true, "Футболки", null, null },
                    { new Guid("c2a82456-2e98-4d85-8c9a-8a7c04196bc4"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(3664), null, null, null, new Guid("5b297472-63c5-4329-afd8-dda647b953dd"), true, "Браслеты", null, null },
                    { new Guid("c4c4f563-c53b-4928-9f80-806c943d7b25"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(3642), null, null, null, new Guid("ccb924ac-bae7-4d6a-b606-c578e903be91"), true, "Кофты", null, null },
                    { new Guid("ca079622-ee8e-414a-9193-1997c4176291"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(3640), null, null, null, new Guid("ccb924ac-bae7-4d6a-b606-c578e903be91"), true, "Майки", null, null },
                    { new Guid("d1a9cb6b-b268-4e09-992e-eafd04ec4d2c"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(3659), null, null, null, new Guid("efe665a4-2531-44da-a040-b7bb4da8ed22"), true, "Каблуки", null, null },
                    { new Guid("df52a8fc-3741-4bbb-9010-dba4f02475d3"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(3660), null, null, null, new Guid("5b297472-63c5-4329-afd8-dda647b953dd"), true, "Рюкзаки", null, null },
                    { new Guid("df7dbffe-12c5-499e-b4f6-3bac85dcb10f"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(3652), null, null, null, new Guid("98f424e2-9ffb-458f-84d4-e8cff5f6585f"), true, "Трусы", null, null },
                    { new Guid("e6158c8e-2741-4f2e-bcca-f9597c72276c"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(3644), null, null, null, new Guid("ccb924ac-bae7-4d6a-b606-c578e903be91"), true, "Джинсы", null, null },
                    { new Guid("e68004d9-3187-4aba-934b-8728e53e6ef3"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(3648), null, null, null, new Guid("ccb924ac-bae7-4d6a-b606-c578e903be91"), true, "Юбки", null, null },
                    { new Guid("fdccc078-04a0-432a-a2bb-db61f9e355ad"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(3649), null, null, null, new Guid("ccb924ac-bae7-4d6a-b606-c578e903be91"), true, "Легинсы", null, null }
                });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "CreateDate", "CreatedUserId", "DeleteDate", "DeletedUserId", "Description", "GoodSubtypeId", "ImageURL", "IsActual", "ManufacturerId", "Name", "Price", "UpdateDate", "UpdatedUserId" },
                values: new object[,]
                {
                    { new Guid("3f219746-6957-44af-ad60-6703b6e1c7d8"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(8372), null, null, null, "Куртка адидас чёрная ....", new Guid("0a8a7aac-5217-47ca-b635-448dd5603522"), "https://fullsourcemedia.s3.amazonaws.com/images/items/e/raw/J331_black_form_front.jpg", true, new Guid("dfe8ec89-4a13-4bbe-8285-935017f8ce23"), "Куртка адидас", 500m, null, null },
                    { new Guid("78e274be-042c-4d5d-b2cc-00d0cae437ce"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(8380), null, null, null, "Кроссовки nike белые ....", new Guid("0afd27db-05c4-48ab-a612-d16192b40503"), "https://i.pinimg.com/originals/58/7d/82/587d82a229ceba80432497d594206c06.png", true, new Guid("f7e37f02-86bc-4892-951d-c9e6c9f0a7ce"), "Кроссовки nike", 2500m, null, null },
                    { new Guid("7afca5f6-7163-477c-bf1d-3f09036ac42b"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(8382), null, null, null, "Рюкзак nike белые ....", new Guid("df52a8fc-3741-4bbb-9010-dba4f02475d3"), "https://freepngimg.com/thumb/backpack/9-2-backpack-png-hd.png", true, new Guid("f7e37f02-86bc-4892-951d-c9e6c9f0a7ce"), "Рюкзаак nike", 5000m, null, null },
                    { new Guid("999dccb8-e1e9-4847-aa38-3735813816c6"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(8383), null, null, null, "Футболка adidas синяя ....", new Guid("a5375bc2-ca16-4c01-9c12-f175a22f4419"), "https://c1.klipartz.com/pngpicture/301/681/sticker-png-tshirt-tshirt-clothing-dress-fashion-jacket-playera-laundry-aline.png", true, new Guid("dfe8ec89-4a13-4bbe-8285-935017f8ce23"), "Футболка adidas", 5000m, null, null }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "CreateDate", "CreatedUserId", "DeleteDate", "DeletedUserId", "GoodSubtypeId", "IsActual", "Name", "UpdateDate", "UpdatedUserId" },
                values: new object[,]
                {
                    { new Guid("020845de-8b18-4177-afe5-a2f10e5b5aa1"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(9297), null, null, null, new Guid("0afd27db-05c4-48ab-a612-d16192b40503"), true, "XL", null, null },
                    { new Guid("021d2911-cd32-45af-a907-18025b2f1506"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(9306), null, null, null, new Guid("df52a8fc-3741-4bbb-9010-dba4f02475d3"), true, "XL", null, null },
                    { new Guid("2ce462aa-17f2-46fa-bf2a-2b18bd7c0355"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(9315), null, null, null, new Guid("a5375bc2-ca16-4c01-9c12-f175a22f4419"), true, "M", null, null },
                    { new Guid("2d57ef16-d1b2-4a90-be58-63cc342d6f99"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(9317), null, null, null, new Guid("a5375bc2-ca16-4c01-9c12-f175a22f4419"), true, "XS", null, null },
                    { new Guid("37d47ba1-145f-4980-8258-e937adc11298"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(9265), null, null, null, new Guid("0a8a7aac-5217-47ca-b635-448dd5603522"), true, "M", null, null },
                    { new Guid("3f91763f-2ad9-4cd9-a838-2f91375f309e"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(9305), null, null, null, new Guid("df52a8fc-3741-4bbb-9010-dba4f02475d3"), true, "XXL", null, null },
                    { new Guid("506b1374-8e93-4602-aad2-9a3f5c1e1bac"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(9261), null, null, null, new Guid("0a8a7aac-5217-47ca-b635-448dd5603522"), true, "XL", null, null },
                    { new Guid("589bc477-bc8d-4800-b5f5-372b34804633"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(9296), null, null, null, new Guid("0afd27db-05c4-48ab-a612-d16192b40503"), true, "XXL", null, null },
                    { new Guid("71891871-80ee-4324-9eb2-a705f5f763c0"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(9303), null, null, null, new Guid("0afd27db-05c4-48ab-a612-d16192b40503"), true, "S", null, null },
                    { new Guid("75fa43a5-87ed-40a0-bcfe-87288ce17236"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(9267), null, null, null, new Guid("0a8a7aac-5217-47ca-b635-448dd5603522"), true, "S", null, null },
                    { new Guid("785121e7-ead3-49d9-ade7-64e6905e387d"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(9298), null, null, null, new Guid("0afd27db-05c4-48ab-a612-d16192b40503"), true, "L", null, null },
                    { new Guid("9337aca7-0120-4385-900f-e782f65a500e"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(9314), null, null, null, new Guid("a5375bc2-ca16-4c01-9c12-f175a22f4419"), true, "L", null, null },
                    { new Guid("a6d26dd5-90cc-4b1f-aa0e-9cafe6baaa89"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(9316), null, null, null, new Guid("a5375bc2-ca16-4c01-9c12-f175a22f4419"), true, "S", null, null },
                    { new Guid("ae2641d8-fe7c-4864-84a9-d513d22033d7"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(9251), null, null, null, new Guid("0a8a7aac-5217-47ca-b635-448dd5603522"), true, "XXL", null, null },
                    { new Guid("b191bb3e-67b2-42d8-ad4f-5ec2d3c7274f"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(9264), null, null, null, new Guid("0a8a7aac-5217-47ca-b635-448dd5603522"), true, "L", null, null },
                    { new Guid("b220d50e-b38e-4b98-ae8e-24051472ce20"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(9313), null, null, null, new Guid("a5375bc2-ca16-4c01-9c12-f175a22f4419"), true, "XL", null, null },
                    { new Guid("ba3500df-7773-4b0c-a5f8-41217f7f149f"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(9308), null, null, null, new Guid("df52a8fc-3741-4bbb-9010-dba4f02475d3"), true, "S", null, null },
                    { new Guid("de6e51c7-f9ed-4f97-81de-f2037ad0cab7"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(9295), null, null, null, new Guid("0a8a7aac-5217-47ca-b635-448dd5603522"), true, "XS", null, null },
                    { new Guid("e11f758c-2ebc-4f86-b2f6-086d39c2603c"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(9304), null, null, null, new Guid("0afd27db-05c4-48ab-a612-d16192b40503"), true, "XS", null, null },
                    { new Guid("ea0babb6-ab69-4579-9a6c-40bb38eaa5ea"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(9307), null, null, null, new Guid("df52a8fc-3741-4bbb-9010-dba4f02475d3"), true, "M", null, null },
                    { new Guid("f25f2964-756a-43a1-9131-e4aaca1b9ba2"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(9309), null, null, null, new Guid("a5375bc2-ca16-4c01-9c12-f175a22f4419"), true, "XXL", null, null },
                    { new Guid("f820fb80-7c7c-4c93-bc2c-a2df2e956e68"), new DateTime(2024, 4, 24, 18, 20, 24, 626, DateTimeKind.Local).AddTicks(9302), null, null, null, new Guid("0afd27db-05c4-48ab-a612-d16192b40503"), true, "M", null, null }
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
