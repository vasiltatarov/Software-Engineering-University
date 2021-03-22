using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstates.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RealEstatePropertyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstatePropertyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagProperty = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RealEstatePropertyAds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: false),
                    YardSize = table.Column<int>(type: "int", nullable: true),
                    Floor = table.Column<int>(type: "int", nullable: true),
                    TotalBuildingFloors = table.Column<int>(type: "int", nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    BuildingYear = table.Column<int>(type: "int", nullable: true),
                    RealEstatePropertyTypeId = table.Column<int>(type: "int", nullable: false),
                    BuildingTypeId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstatePropertyAds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstatePropertyAds_BuildingTypes_BuildingTypeId",
                        column: x => x.BuildingTypeId,
                        principalTable: "BuildingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RealEstatePropertyAds_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RealEstatePropertyAds_RealEstatePropertyTypes_RealEstatePropertyTypeId",
                        column: x => x.RealEstatePropertyTypeId,
                        principalTable: "RealEstatePropertyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RealEstatePropertyTags",
                columns: table => new
                {
                    RealEstatePropertyAdId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstatePropertyTags", x => new { x.RealEstatePropertyAdId, x.TagId });
                    table.ForeignKey(
                        name: "FK_RealEstatePropertyTags_RealEstatePropertyAds_RealEstatePropertyAdId",
                        column: x => x.RealEstatePropertyAdId,
                        principalTable: "RealEstatePropertyAds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RealEstatePropertyTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealEstatePropertyAds_BuildingTypeId",
                table: "RealEstatePropertyAds",
                column: "BuildingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstatePropertyAds_DistrictId",
                table: "RealEstatePropertyAds",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstatePropertyAds_RealEstatePropertyTypeId",
                table: "RealEstatePropertyAds",
                column: "RealEstatePropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstatePropertyTags_TagId",
                table: "RealEstatePropertyTags",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealEstatePropertyTags");

            migrationBuilder.DropTable(
                name: "RealEstatePropertyAds");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "BuildingTypes");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "RealEstatePropertyTypes");
        }
    }
}
