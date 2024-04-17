using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganicShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Add_ToTable_ContactUs_Column_ShortDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "Comments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "ShortDescription", "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { "ShorDescriptions", new DateTime(2024, 4, 17, 22, 46, 29, 686, DateTimeKind.Local).AddTicks(6365), new DateTime(2024, 4, 17, 22, 46, 29, 686, DateTimeKind.Local).AddTicks(6502) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 17, 22, 46, 29, 695, DateTimeKind.Local).AddTicks(2842), new DateTime(2024, 4, 17, 22, 46, 29, 695, DateTimeKind.Local).AddTicks(2905) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)2,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 17, 22, 46, 29, 695, DateTimeKind.Local).AddTicks(2911), new DateTime(2024, 4, 17, 22, 46, 29, 695, DateTimeKind.Local).AddTicks(2919) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)3,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 17, 22, 46, 29, 695, DateTimeKind.Local).AddTicks(2928), new DateTime(2024, 4, 17, 22, 46, 29, 695, DateTimeKind.Local).AddTicks(2931) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)4,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 17, 22, 46, 29, 695, DateTimeKind.Local).AddTicks(2934), new DateTime(2024, 4, 17, 22, 46, 29, 695, DateTimeKind.Local).AddTicks(2936) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)5,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 17, 22, 46, 29, 695, DateTimeKind.Local).AddTicks(2943), new DateTime(2024, 4, 17, 22, 46, 29, 695, DateTimeKind.Local).AddTicks(2946) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)6,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 17, 22, 46, 29, 695, DateTimeKind.Local).AddTicks(2950), new DateTime(2024, 4, 17, 22, 46, 29, 695, DateTimeKind.Local).AddTicks(2952) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)7,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 17, 22, 46, 29, 695, DateTimeKind.Local).AddTicks(2955), new DateTime(2024, 4, 17, 22, 46, 29, 695, DateTimeKind.Local).AddTicks(2974) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)8,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 17, 22, 46, 29, 695, DateTimeKind.Local).AddTicks(2978), new DateTime(2024, 4, 17, 22, 46, 29, 695, DateTimeKind.Local).AddTicks(2980) });

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 17, 22, 46, 29, 697, DateTimeKind.Local).AddTicks(1986), new DateTime(2024, 4, 17, 22, 46, 29, 697, DateTimeKind.Local).AddTicks(2217) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 17, 22, 46, 29, 701, DateTimeKind.Local).AddTicks(5855), new DateTime(2024, 4, 17, 22, 46, 29, 701, DateTimeKind.Local).AddTicks(5919) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 17, 22, 46, 29, 701, DateTimeKind.Local).AddTicks(6056), new DateTime(2024, 4, 17, 22, 46, 29, 701, DateTimeKind.Local).AddTicks(6067) });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Products_ProductId",
                table: "Comments",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Products_ProductId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ProductId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 17, 13, 49, 28, 637, DateTimeKind.Local).AddTicks(1410), new DateTime(2024, 4, 17, 13, 49, 28, 637, DateTimeKind.Local).AddTicks(1521) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 17, 13, 49, 28, 643, DateTimeKind.Local).AddTicks(8660), new DateTime(2024, 4, 17, 13, 49, 28, 643, DateTimeKind.Local).AddTicks(8714) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)2,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 17, 13, 49, 28, 643, DateTimeKind.Local).AddTicks(8721), new DateTime(2024, 4, 17, 13, 49, 28, 643, DateTimeKind.Local).AddTicks(8727) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)3,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 17, 13, 49, 28, 643, DateTimeKind.Local).AddTicks(8737), new DateTime(2024, 4, 17, 13, 49, 28, 643, DateTimeKind.Local).AddTicks(8740) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)4,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 17, 13, 49, 28, 643, DateTimeKind.Local).AddTicks(8743), new DateTime(2024, 4, 17, 13, 49, 28, 643, DateTimeKind.Local).AddTicks(8745) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)5,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 17, 13, 49, 28, 643, DateTimeKind.Local).AddTicks(8750), new DateTime(2024, 4, 17, 13, 49, 28, 643, DateTimeKind.Local).AddTicks(8753) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)6,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 17, 13, 49, 28, 643, DateTimeKind.Local).AddTicks(8757), new DateTime(2024, 4, 17, 13, 49, 28, 643, DateTimeKind.Local).AddTicks(8759) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)7,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 17, 13, 49, 28, 643, DateTimeKind.Local).AddTicks(8762), new DateTime(2024, 4, 17, 13, 49, 28, 643, DateTimeKind.Local).AddTicks(8809) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)8,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 17, 13, 49, 28, 643, DateTimeKind.Local).AddTicks(8813), new DateTime(2024, 4, 17, 13, 49, 28, 643, DateTimeKind.Local).AddTicks(8815) });

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 17, 13, 49, 28, 645, DateTimeKind.Local).AddTicks(3855), new DateTime(2024, 4, 17, 13, 49, 28, 645, DateTimeKind.Local).AddTicks(3890) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 17, 13, 49, 28, 648, DateTimeKind.Local).AddTicks(6176), new DateTime(2024, 4, 17, 13, 49, 28, 648, DateTimeKind.Local).AddTicks(6210) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 17, 13, 49, 28, 648, DateTimeKind.Local).AddTicks(6328), new DateTime(2024, 4, 17, 13, 49, 28, 648, DateTimeKind.Local).AddTicks(6335) });
        }
    }
}
