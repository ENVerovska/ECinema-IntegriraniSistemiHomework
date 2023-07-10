using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECinema.Web.Data.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Movies_MoviesId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_MoviesId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "MoviesId",
                table: "Tickets");

            migrationBuilder.AlterColumn<Guid>(
                name: "MovieID",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_MovieID",
                table: "Tickets",
                column: "MovieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Movies_MovieID",
                table: "Tickets",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Movies_MovieID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_MovieID",
                table: "Tickets");

            migrationBuilder.AlterColumn<string>(
                name: "MovieID",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "MoviesId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_MoviesId",
                table: "Tickets",
                column: "MoviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Movies_MoviesId",
                table: "Tickets",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
