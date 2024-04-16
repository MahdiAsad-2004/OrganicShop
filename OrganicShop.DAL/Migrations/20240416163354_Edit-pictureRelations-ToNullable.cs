using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganicShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EditpictureRelationsToNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
