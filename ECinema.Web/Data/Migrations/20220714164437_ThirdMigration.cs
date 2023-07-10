using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECinema.Web.Data.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MovieID",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MoviesId",
                table: "Tickets",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MovieName = table.Column<string>(nullable: true),
                    MovieImage = table.Column<string>(nullable: true),
                    MovieDescription = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderForShoppingCarts",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(nullable: false),
                    ShoppingCartID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderForShoppingCarts", x => new { x.OrderID, x.ShoppingCartID });
                    table.ForeignKey(
                        name: "FK_OrderForShoppingCarts_ShoppingCarts_OrderID",
                        column: x => x.OrderID,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderForShoppingCarts_Orders_ShoppingCartID",
                        column: x => x.ShoppingCartID,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_MoviesId",
                table: "Tickets",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderForShoppingCarts_ShoppingCartID",
                table: "OrderForShoppingCarts",
                column: "ShoppingCartID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Movies_MoviesId",
                table: "Tickets",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Movies_MoviesId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "OrderForShoppingCarts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_MoviesId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "MovieID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "MoviesId",
                table: "Tickets");
        }
    }
}
