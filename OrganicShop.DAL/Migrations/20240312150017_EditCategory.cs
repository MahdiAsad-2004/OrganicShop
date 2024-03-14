using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganicShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EditCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EnTitle",
                table: "Categories",
                newName: "Image");

            migrationBuilder.AddColumn<string>(
                name: "IconClass",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IconColor",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconClass",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IconColor",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Categories",
                newName: "EnTitle");

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 5, 18, 1, 13, 979, DateTimeKind.Local).AddTicks(4759), new DateTime(2024, 3, 5, 18, 1, 13, 979, DateTimeKind.Local).AddTicks(4817) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 5, 18, 1, 13, 985, DateTimeKind.Local).AddTicks(3105), new DateTime(2024, 3, 5, 18, 1, 13, 985, DateTimeKind.Local).AddTicks(3150) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)2,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 5, 18, 1, 13, 985, DateTimeKind.Local).AddTicks(3261), new DateTime(2024, 3, 5, 18, 1, 13, 985, DateTimeKind.Local).AddTicks(3267) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)3,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 5, 18, 1, 13, 985, DateTimeKind.Local).AddTicks(3361), new DateTime(2024, 3, 5, 18, 1, 13, 985, DateTimeKind.Local).AddTicks(3366) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)4,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 5, 18, 1, 13, 985, DateTimeKind.Local).AddTicks(3444), new DateTime(2024, 3, 5, 18, 1, 13, 985, DateTimeKind.Local).AddTicks(3448) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)5,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 5, 18, 1, 13, 985, DateTimeKind.Local).AddTicks(3519), new DateTime(2024, 3, 5, 18, 1, 13, 985, DateTimeKind.Local).AddTicks(3523) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)6,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 5, 18, 1, 13, 985, DateTimeKind.Local).AddTicks(3590), new DateTime(2024, 3, 5, 18, 1, 13, 985, DateTimeKind.Local).AddTicks(3594) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)7,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 5, 18, 1, 13, 985, DateTimeKind.Local).AddTicks(3673), new DateTime(2024, 3, 5, 18, 1, 13, 985, DateTimeKind.Local).AddTicks(3693) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 5, 18, 1, 13, 989, DateTimeKind.Local).AddTicks(1690), new DateTime(2024, 3, 5, 18, 1, 13, 989, DateTimeKind.Local).AddTicks(1731) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 3, 5, 18, 1, 13, 989, DateTimeKind.Local).AddTicks(1854), new DateTime(2024, 3, 5, 18, 1, 13, 989, DateTimeKind.Local).AddTicks(1860) });
        }
    }
}
