using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Musaca.Migrations
{
    public partial class REceipt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IssuedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CashierId = table.Column<string>(type: "nvarchar(40)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipts_Users_CashierId",
                        column: x => x.CashierId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_CashierId",
                table: "Receipts",
                column: "CashierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receipts");
        }
    }
}
