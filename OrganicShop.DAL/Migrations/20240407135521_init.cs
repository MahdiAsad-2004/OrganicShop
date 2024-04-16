using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrganicShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Office1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Office2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Office3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsFixDiscount = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    FixValue = table.Column<int>(type: "int", nullable: true),
                    Percent = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FreeDelivery = table.Column<bool>(type: "bit", nullable: false),
                    MinPrice = table.Column<int>(type: "int", nullable: false),
                    MaxPrice = table.Column<int>(type: "int", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faqs",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faqs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<byte>(type: "tinyint", nullable: true),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Permissions_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Permissions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    SoldCount = table.Column<int>(type: "int", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscountCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountCategories_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankCards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cvv2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankCards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baskets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    EntityTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityOldData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityNewData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionId = table.Column<byte>(type: "tinyint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionUsers_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscountProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountProducts_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SizeMB = table.Column<float>(type: "real", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    UserPictureId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryPictureId = table.Column<int>(type: "int", nullable: true),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Picture_Categories_CategoryPictureId",
                        column: x => x.CategoryPictureId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Picture_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Picture_Users_UserPictureId",
                        column: x => x.UserPictureId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBase = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    BaseId = table.Column<int>(type: "int", nullable: true),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Properties_Properties_BaseId",
                        column: x => x.BaseId,
                        principalTable: "Properties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TagProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagProducts_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackingCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    DeliveryType = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    DeliveryDatePredicate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false),
                    ReceiverId = table.Column<long>(type: "bigint", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CoProducts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    UpdatedPrice = table.Column<int>(type: "int", nullable: true),
                    BasketId = table.Column<long>(type: "bigint", nullable: true),
                    OrderId = table.Column<long>(type: "bigint", nullable: true),
                    IsOrdered = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoProducts_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CoProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CoProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrackingDescriptions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackingDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackingDescriptions_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrackingStatuses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoneStatus = table.Column<int>(type: "int", nullable: false),
                    DoneDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Step = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackingStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackingStatuses_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ContactUs",
                columns: new[] { "Id", "Address", "Description", "Email1", "Email2", "Office1", "Office2", "Office3", "Phone1", "Phone2", "Phone3", "PhoneNumber1", "PhoneNumber2", "PhoneNumber3", "BaseEntity_CreateDate", "BaseEntity_DeleteDate", "BaseEntity_IsActive", "BaseEntity_IsDelete", "BaseEntity_LastModified" },
                values: new object[] { (byte)1, "Address", "Descriptions", "OrganicShop@gmail.com", null, "Tehran", null, null, "02134658899", null, null, "09121234455", null, null, new DateTime(2024, 4, 7, 18, 25, 21, 401, DateTimeKind.Local).AddTicks(4624), null, true, false, new DateTime(2024, 4, 7, 18, 25, 21, 401, DateTimeKind.Local).AddTicks(4678) });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "EnTitle", "ParentId", "Title", "BaseEntity_CreateDate", "BaseEntity_DeleteDate", "BaseEntity_IsActive", "BaseEntity_IsDelete", "BaseEntity_LastModified" },
                values: new object[] { (byte)1, "Main Admin", null, "مدیر سایت", new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8518), null, true, false, new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8570) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "PhoneNumber", "Role", "BaseEntity_CreateDate", "BaseEntity_DeleteDate", "BaseEntity_IsActive", "BaseEntity_IsDelete", "BaseEntity_LastModified" },
                values: new object[,]
                {
                    { 1L, "mas1379as@gmail.com", "Mahdi Asadi", "123456", "09369753041", 2, new DateTime(2024, 4, 7, 18, 25, 21, 414, DateTimeKind.Local).AddTicks(731), null, true, false, new DateTime(2024, 4, 7, 18, 25, 21, 414, DateTimeKind.Local).AddTicks(767) },
                    { 2L, "TestEmail@gmail.com", "AmirAli", "1234", "09331234566", 3, new DateTime(2024, 4, 7, 18, 25, 21, 414, DateTimeKind.Local).AddTicks(934), null, true, false, new DateTime(2024, 4, 7, 18, 25, 21, 414, DateTimeKind.Local).AddTicks(943) }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "EnTitle", "ParentId", "Title", "BaseEntity_CreateDate", "BaseEntity_DeleteDate", "BaseEntity_IsActive", "BaseEntity_IsDelete", "BaseEntity_LastModified" },
                values: new object[,]
                {
                    { (byte)2, "Users Admin", (byte)1, "مدیریت کاربران", new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8573), null, true, false, new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8582) },
                    { (byte)3, "Products Admin", (byte)1, "مدیریت محصولات", new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8590), null, true, false, new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8593) },
                    { (byte)4, "Permissions Admin", (byte)1, "مدیریت مجوز ها", new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8595), null, true, false, new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8598) },
                    { (byte)5, "Comments Admin", (byte)1, "مدیریت نظرات", new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8603), null, true, false, new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8605) },
                    { (byte)6, "Discounts Admin", (byte)1, "مدیریت تخفیف ها", new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8609), null, true, false, new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8612) },
                    { (byte)7, "Categories Admin", (byte)1, "مدیریت دسته ها", new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8615), null, true, false, new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8640) }
                });

            migrationBuilder.InsertData(
                table: "Picture",
                columns: new[] { "Id", "CategoryPictureId", "IsMain", "Name", "ProductId", "SizeMB", "UserPictureId", "BaseEntity_CreateDate", "BaseEntity_DeleteDate", "BaseEntity_IsActive", "BaseEntity_IsDelete", "BaseEntity_LastModified" },
                values: new object[] { 1L, null, true, "jocker.png", null, 0.5f, 1L, new DateTime(2024, 4, 7, 18, 25, 21, 410, DateTimeKind.Local).AddTicks(4509), null, true, false, new DateTime(2024, 4, 7, 18, 25, 21, 410, DateTimeKind.Local).AddTicks(4547) });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "EnTitle", "ParentId", "Title", "BaseEntity_CreateDate", "BaseEntity_DeleteDate", "BaseEntity_IsActive", "BaseEntity_IsDelete", "BaseEntity_LastModified" },
                values: new object[] { (byte)8, "Giving Permission", (byte)4, "صدور مجوز", new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8643), null, true, false, new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8646) });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BankCards_UserId",
                table: "BankCards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_UserId",
                table: "Baskets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CoProducts_BasketId",
                table: "CoProducts",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_CoProducts_OrderId",
                table: "CoProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CoProducts_ProductId",
                table: "CoProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCategories_CategoryId",
                table: "DiscountCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCategories_DiscountId",
                table: "DiscountCategories",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountProducts_DiscountId",
                table: "DiscountProducts",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountProducts_ProductId",
                table: "DiscountProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_UserId",
                table: "Operations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressId",
                table: "Orders",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ReceiverId",
                table: "Orders",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ParentId",
                table: "Permissions",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionUsers_PermissionId",
                table: "PermissionUsers",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionUsers_UserId",
                table: "PermissionUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_CategoryPictureId",
                table: "Picture",
                column: "CategoryPictureId",
                unique: true,
                filter: "[CategoryPictureId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_ProductId",
                table: "Picture",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_UserPictureId",
                table: "Picture",
                column: "UserPictureId",
                unique: true,
                filter: "[UserPictureId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_BaseId",
                table: "Properties",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ProductId",
                table: "Properties",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TagProducts_ProductId",
                table: "TagProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TagProducts_TagId",
                table: "TagProducts",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingDescriptions_OrderId",
                table: "TrackingDescriptions",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingStatuses_OrderId",
                table: "TrackingStatuses",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "BankCards");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "CoProducts");

            migrationBuilder.DropTable(
                name: "DiscountCategories");

            migrationBuilder.DropTable(
                name: "DiscountProducts");

            migrationBuilder.DropTable(
                name: "Faqs");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "PermissionUsers");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "TagProducts");

            migrationBuilder.DropTable(
                name: "TrackingDescriptions");

            migrationBuilder.DropTable(
                name: "TrackingStatuses");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
