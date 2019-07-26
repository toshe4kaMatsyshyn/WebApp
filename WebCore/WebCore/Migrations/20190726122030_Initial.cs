using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Terminal",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    Id = table.Column<string>(maxLength: 10, nullable: false),
                    ProducedBrands = table.Column<int>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProducedBrands",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 20, nullable: false),
                    BrandId = table.Column<string>(maxLength: 10, nullable: false),
                    YearOfProduced = table.Column<DateTime>(type: "date", nullable: true),
                    CountOfProduced = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProducedBrands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProducedBrands_Brands",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveredBrands",
                columns: table => new
                {
                    ProduceBrandsId = table.Column<string>(maxLength: 20, nullable: false),
                    Id = table.Column<string>(maxLength: 20, nullable: false),
                    CountOfDelivered = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveredBrands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveredBrands_ProducedBrands",
                        column: x => x.ProduceBrandsId,
                        principalTable: "ProducedBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TerminalsAndBrands",
                columns: table => new
                {
                    ProducedBrandsId = table.Column<string>(maxLength: 20, nullable: false),
                    TerminalId = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminalsAndBrands", x => new { x.ProducedBrandsId, x.TerminalId });
                    table.ForeignKey(
                        name: "FK_TerminalsAndBrands_ProducedBrands",
                        column: x => x.ProducedBrandsId,
                        principalTable: "ProducedBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TerminalsAndBrands_Terminal",
                        column: x => x.TerminalId,
                        principalTable: "Terminal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveredBrands_ProduceBrandsId",
                table: "DeliveredBrands",
                column: "ProduceBrandsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProducedBrands_BrandId",
                table: "ProducedBrands",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_TerminalsAndBrands_TerminalId",
                table: "TerminalsAndBrands",
                column: "TerminalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveredBrands");

            migrationBuilder.DropTable(
                name: "TerminalsAndBrands");

            migrationBuilder.DropTable(
                name: "ProducedBrands");

            migrationBuilder.DropTable(
                name: "Terminal");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
