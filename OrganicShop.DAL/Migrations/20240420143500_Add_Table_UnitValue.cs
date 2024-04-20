using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganicShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Add_Table_UnitValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitType = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    BaseEntity_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseEntity_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    BaseEntity_DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Units_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 20, 19, 5, 0, 149, DateTimeKind.Local).AddTicks(1813), new DateTime(2024, 4, 20, 19, 5, 0, 149, DateTimeKind.Local).AddTicks(1948) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 20, 19, 5, 0, 162, DateTimeKind.Local).AddTicks(1937), new DateTime(2024, 4, 20, 19, 5, 0, 162, DateTimeKind.Local).AddTicks(2012) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)2,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 20, 19, 5, 0, 162, DateTimeKind.Local).AddTicks(2028), new DateTime(2024, 4, 20, 19, 5, 0, 162, DateTimeKind.Local).AddTicks(2048) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)3,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 20, 19, 5, 0, 162, DateTimeKind.Local).AddTicks(2062), new DateTime(2024, 4, 20, 19, 5, 0, 162, DateTimeKind.Local).AddTicks(2068) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)4,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 20, 19, 5, 0, 162, DateTimeKind.Local).AddTicks(2075), new DateTime(2024, 4, 20, 19, 5, 0, 162, DateTimeKind.Local).AddTicks(2080) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)5,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 20, 19, 5, 0, 162, DateTimeKind.Local).AddTicks(2090), new DateTime(2024, 4, 20, 19, 5, 0, 162, DateTimeKind.Local).AddTicks(2096) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)6,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 20, 19, 5, 0, 162, DateTimeKind.Local).AddTicks(2104), new DateTime(2024, 4, 20, 19, 5, 0, 162, DateTimeKind.Local).AddTicks(2109) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)7,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 20, 19, 5, 0, 162, DateTimeKind.Local).AddTicks(2115), new DateTime(2024, 4, 20, 19, 5, 0, 162, DateTimeKind.Local).AddTicks(2141) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: (byte)8,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 20, 19, 5, 0, 162, DateTimeKind.Local).AddTicks(2148), new DateTime(2024, 4, 20, 19, 5, 0, 162, DateTimeKind.Local).AddTicks(2153) });

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 20, 19, 5, 0, 165, DateTimeKind.Local).AddTicks(3584), new DateTime(2024, 4, 20, 19, 5, 0, 165, DateTimeKind.Local).AddTicks(3645) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 20, 19, 5, 0, 172, DateTimeKind.Local).AddTicks(8741), new DateTime(2024, 4, 20, 19, 5, 0, 172, DateTimeKind.Local).AddTicks(8805) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 20, 19, 5, 0, 172, DateTimeKind.Local).AddTicks(9036), new DateTime(2024, 4, 20, 19, 5, 0, 172, DateTimeKind.Local).AddTicks(9049) });

            migrationBuilder.CreateIndex(
                name: "IX_Units_ProductId",
                table: "Units",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.UpdateData(
                table: "ContactUs",
                keyColumn: "Id",
                keyValue: (byte)1,
                columns: new[] { "BaseEntity_CreateDate", "BaseEntity_LastModified" },
                values: new object[] { new DateTime(2024, 4, 17, 22, 46, 29, 686, DateTimeKind.Local).AddTicks(6365), new DateTime(2024, 4, 17, 22, 46, 29, 686, DateTimeKind.Local).AddTicks(6502) });

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
        }
    }
}
