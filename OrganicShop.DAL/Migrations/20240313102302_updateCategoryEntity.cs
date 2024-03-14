using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganicShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateCategoryEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IconColor",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IconClass",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 13, 13, 53, 1, 514, DateTimeKind.Local).AddTicks(6879), new DateTime(2024, 3, 13, 13, 53, 1, 514, DateTimeKind.Local).AddTicks(6929) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 13, 13, 53, 1, 522, DateTimeKind.Local).AddTicks(1554), new DateTime(2024, 3, 13, 13, 53, 1, 522, DateTimeKind.Local).AddTicks(1599) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)2,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 13, 13, 53, 1, 522, DateTimeKind.Local).AddTicks(1789), new DateTime(2024, 3, 13, 13, 53, 1, 522, DateTimeKind.Local).AddTicks(1796) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)3,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 13, 13, 53, 1, 522, DateTimeKind.Local).AddTicks(1935), new DateTime(2024, 3, 13, 13, 53, 1, 522, DateTimeKind.Local).AddTicks(1940) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)4,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 13, 13, 53, 1, 522, DateTimeKind.Local).AddTicks(2057), new DateTime(2024, 3, 13, 13, 53, 1, 522, DateTimeKind.Local).AddTicks(2063) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)5,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 13, 13, 53, 1, 522, DateTimeKind.Local).AddTicks(2175), new DateTime(2024, 3, 13, 13, 53, 1, 522, DateTimeKind.Local).AddTicks(2179) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)6,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 13, 13, 53, 1, 522, DateTimeKind.Local).AddTicks(2287), new DateTime(2024, 3, 13, 13, 53, 1, 522, DateTimeKind.Local).AddTicks(2292) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)7,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 13, 13, 53, 1, 522, DateTimeKind.Local).AddTicks(2392), new DateTime(2024, 3, 13, 13, 53, 1, 522, DateTimeKind.Local).AddTicks(2398) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 13, 13, 53, 1, 526, DateTimeKind.Local).AddTicks(1060), new DateTime(2024, 3, 13, 13, 53, 1, 526, DateTimeKind.Local).AddTicks(1091) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 13, 13, 53, 1, 526, DateTimeKind.Local).AddTicks(1248), new DateTime(2024, 3, 13, 13, 53, 1, 526, DateTimeKind.Local).AddTicks(1254) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IconColor",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IconClass",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 12, 18, 30, 16, 849, DateTimeKind.Local).AddTicks(4790), new DateTime(2024, 3, 12, 18, 30, 16, 849, DateTimeKind.Local).AddTicks(4938) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 12, 18, 30, 16, 861, DateTimeKind.Local).AddTicks(421), new DateTime(2024, 3, 12, 18, 30, 16, 861, DateTimeKind.Local).AddTicks(495) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)2,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 12, 18, 30, 16, 861, DateTimeKind.Local).AddTicks(754), new DateTime(2024, 3, 12, 18, 30, 16, 861, DateTimeKind.Local).AddTicks(767) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)3,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 12, 18, 30, 16, 861, DateTimeKind.Local).AddTicks(1179), new DateTime(2024, 3, 12, 18, 30, 16, 861, DateTimeKind.Local).AddTicks(1198) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)4,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 12, 18, 30, 16, 861, DateTimeKind.Local).AddTicks(1437), new DateTime(2024, 3, 12, 18, 30, 16, 861, DateTimeKind.Local).AddTicks(1451) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)5,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 12, 18, 30, 16, 861, DateTimeKind.Local).AddTicks(1643), new DateTime(2024, 3, 12, 18, 30, 16, 861, DateTimeKind.Local).AddTicks(1656) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)6,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 12, 18, 30, 16, 861, DateTimeKind.Local).AddTicks(1878), new DateTime(2024, 3, 12, 18, 30, 16, 861, DateTimeKind.Local).AddTicks(1892) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)7,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 12, 18, 30, 16, 861, DateTimeKind.Local).AddTicks(2074), new DateTime(2024, 3, 12, 18, 30, 16, 861, DateTimeKind.Local).AddTicks(2119) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 12, 18, 30, 16, 868, DateTimeKind.Local).AddTicks(7977), new DateTime(2024, 3, 12, 18, 30, 16, 868, DateTimeKind.Local).AddTicks(8050) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 12, 18, 30, 16, 868, DateTimeKind.Local).AddTicks(8327), new DateTime(2024, 3, 12, 18, 30, 16, 868, DateTimeKind.Local).AddTicks(8341) });
        }
    }
}
