using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyNewProject.Service.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderStatus = table.Column<int>(nullable: false),
                    DeliveryMethod = table.Column<int>(nullable: false),
                    DeliveryTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "DeliveryMethod", "DeliveryTime", "OrderStatus" },
                values: new object[] { 1L, 1, new DateTime(2020, 4, 25, 19, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "DeliveryMethod", "DeliveryTime", "OrderStatus" },
                values: new object[] { 2L, 1, new DateTime(2020, 4, 25, 19, 0, 0, 0, DateTimeKind.Unspecified), 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
