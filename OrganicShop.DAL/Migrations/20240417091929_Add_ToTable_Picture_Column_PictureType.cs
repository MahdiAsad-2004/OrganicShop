using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganicShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Add_ToTable_Picture_Column_PictureType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Picture",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "Type", "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { 0, new DateTime(2024, 4, 17, 13, 49, 28, 645, DateTimeKind.Local).AddTicks(3855), new DateTime(2024, 4, 17, 13, 49, 28, 645, DateTimeKind.Local).AddTicks(3890) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Picture");

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 16, 21, 3, 54, 118, DateTimeKind.Local).AddTicks(9684), new DateTime(2024, 4, 16, 21, 3, 54, 118, DateTimeKind.Local).AddTicks(9860) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 16, 21, 3, 54, 128, DateTimeKind.Local).AddTicks(3621), new DateTime(2024, 4, 16, 21, 3, 54, 128, DateTimeKind.Local).AddTicks(3676) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)2,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 16, 21, 3, 54, 128, DateTimeKind.Local).AddTicks(3684), new DateTime(2024, 4, 16, 21, 3, 54, 128, DateTimeKind.Local).AddTicks(3693) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)3,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 16, 21, 3, 54, 128, DateTimeKind.Local).AddTicks(3702), new DateTime(2024, 4, 16, 21, 3, 54, 128, DateTimeKind.Local).AddTicks(3704) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)4,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 16, 21, 3, 54, 128, DateTimeKind.Local).AddTicks(3707), new DateTime(2024, 4, 16, 21, 3, 54, 128, DateTimeKind.Local).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)5,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 16, 21, 3, 54, 128, DateTimeKind.Local).AddTicks(3718), new DateTime(2024, 4, 16, 21, 3, 54, 128, DateTimeKind.Local).AddTicks(3721) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)6,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 16, 21, 3, 54, 128, DateTimeKind.Local).AddTicks(3725), new DateTime(2024, 4, 16, 21, 3, 54, 128, DateTimeKind.Local).AddTicks(3727) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)7,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 16, 21, 3, 54, 128, DateTimeKind.Local).AddTicks(3730), new DateTime(2024, 4, 16, 21, 3, 54, 128, DateTimeKind.Local).AddTicks(3750) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)8,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 16, 21, 3, 54, 128, DateTimeKind.Local).AddTicks(3752), new DateTime(2024, 4, 16, 21, 3, 54, 128, DateTimeKind.Local).AddTicks(3754) });

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 16, 21, 3, 54, 130, DateTimeKind.Local).AddTicks(3036), new DateTime(2024, 4, 16, 21, 3, 54, 130, DateTimeKind.Local).AddTicks(3083) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 16, 21, 3, 54, 136, DateTimeKind.Local).AddTicks(427), new DateTime(2024, 4, 16, 21, 3, 54, 136, DateTimeKind.Local).AddTicks(489) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 16, 21, 3, 54, 136, DateTimeKind.Local).AddTicks(673), new DateTime(2024, 4, 16, 21, 3, 54, 136, DateTimeKind.Local).AddTicks(682) });
        }
    }
}
