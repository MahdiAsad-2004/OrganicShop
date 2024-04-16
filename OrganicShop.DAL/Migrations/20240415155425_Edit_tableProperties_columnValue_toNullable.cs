using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganicShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Edit_tableProperties_columnValue_toNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 15, 20, 24, 25, 201, DateTimeKind.Local).AddTicks(6804), new DateTime(2024, 4, 15, 20, 24, 25, 201, DateTimeKind.Local).AddTicks(6921) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 15, 20, 24, 25, 209, DateTimeKind.Local).AddTicks(6742), new DateTime(2024, 4, 15, 20, 24, 25, 209, DateTimeKind.Local).AddTicks(6802) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)2,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 15, 20, 24, 25, 209, DateTimeKind.Local).AddTicks(6809), new DateTime(2024, 4, 15, 20, 24, 25, 209, DateTimeKind.Local).AddTicks(6820) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)3,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 15, 20, 24, 25, 209, DateTimeKind.Local).AddTicks(6829), new DateTime(2024, 4, 15, 20, 24, 25, 209, DateTimeKind.Local).AddTicks(6832) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)4,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 15, 20, 24, 25, 209, DateTimeKind.Local).AddTicks(6835), new DateTime(2024, 4, 15, 20, 24, 25, 209, DateTimeKind.Local).AddTicks(6837) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)5,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 15, 20, 24, 25, 209, DateTimeKind.Local).AddTicks(6844), new DateTime(2024, 4, 15, 20, 24, 25, 209, DateTimeKind.Local).AddTicks(6846) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)6,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 15, 20, 24, 25, 209, DateTimeKind.Local).AddTicks(6850), new DateTime(2024, 4, 15, 20, 24, 25, 209, DateTimeKind.Local).AddTicks(6853) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)7,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 15, 20, 24, 25, 209, DateTimeKind.Local).AddTicks(6856), new DateTime(2024, 4, 15, 20, 24, 25, 209, DateTimeKind.Local).AddTicks(6873) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)8,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 15, 20, 24, 25, 209, DateTimeKind.Local).AddTicks(6877), new DateTime(2024, 4, 15, 20, 24, 25, 209, DateTimeKind.Local).AddTicks(6879) });

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 15, 20, 24, 25, 211, DateTimeKind.Local).AddTicks(5675), new DateTime(2024, 4, 15, 20, 24, 25, 211, DateTimeKind.Local).AddTicks(5728) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 15, 20, 24, 25, 215, DateTimeKind.Local).AddTicks(4811), new DateTime(2024, 4, 15, 20, 24, 25, 215, DateTimeKind.Local).AddTicks(4862) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 15, 20, 24, 25, 215, DateTimeKind.Local).AddTicks(4991), new DateTime(2024, 4, 15, 20, 24, 25, 215, DateTimeKind.Local).AddTicks(4999) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Properties",
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
                values: new object[] { new DateTime(2024, 4, 7, 18, 25, 21, 401, DateTimeKind.Local).AddTicks(4624), new DateTime(2024, 4, 7, 18, 25, 21, 401, DateTimeKind.Local).AddTicks(4678) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8518), new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8570) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)2,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8573), new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8582) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)3,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8590), new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8593) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)4,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8595), new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8598) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)5,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8603), new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8605) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)6,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8609), new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8612) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)7,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8615), new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8640) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)8,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8643), new DateTime(2024, 4, 7, 18, 25, 21, 408, DateTimeKind.Local).AddTicks(8646) });

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 7, 18, 25, 21, 410, DateTimeKind.Local).AddTicks(4509), new DateTime(2024, 4, 7, 18, 25, 21, 410, DateTimeKind.Local).AddTicks(4547) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 7, 18, 25, 21, 414, DateTimeKind.Local).AddTicks(731), new DateTime(2024, 4, 7, 18, 25, 21, 414, DateTimeKind.Local).AddTicks(767) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 7, 18, 25, 21, 414, DateTimeKind.Local).AddTicks(934), new DateTime(2024, 4, 7, 18, 25, 21, 414, DateTimeKind.Local).AddTicks(943) });
        }
    }
}
