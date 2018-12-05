using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetTracking.Data.Migrations
{
    public partial class domaininit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    ManufacturerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Model_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TagNumber = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: false),
                    AssetTypeId = table.Column<int>(nullable: false),
                    ModelId = table.Column<int>(nullable: false),
                    AssignedTo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asset_AssetType_AssetTypeId",
                        column: x => x.AssetTypeId,
                        principalTable: "AssetType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asset_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AssetType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Desktop PC" },
                    { 2, "Laptop" },
                    { 3, "Tablet" },
                    { 4, "Monitor" },
                    { 5, "Mobile Phone" },
                    { 6, "Desk Phone" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dell" },
                    { 2, "HP" },
                    { 3, "Acer" },
                    { 4, "Apple" },
                    { 5, "Samsung" },
                    { 6, "LG" },
                    { 7, "Avaya" },
                    { 8, "Polycom" },
                    { 9, "Cisco" }
                });

            migrationBuilder.InsertData(
                table: "Model",
                columns: new[] { "Id", "ManufacturerId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Inspiron" },
                    { 21, 7, "9612G" },
                    { 14, 6, "22MP" },
                    { 20, 5, "Galaxy Note5" },
                    { 19, 5, "Galaxy S5" },
                    { 18, 5, "Galaxy S4" },
                    { 11, 5, "Galaxy Tab3" },
                    { 17, 4, "iPhone 6" },
                    { 16, 4, "iPhone 5" },
                    { 10, 4, "iPad Air" },
                    { 22, 8, "SoundPoint 331" },
                    { 9, 4, "iPad mini" },
                    { 7, 4, "MacBook Air" },
                    { 13, 3, "STQ414" },
                    { 12, 3, "S200" },
                    { 4, 3, "Aspire" },
                    { 15, 2, "Pavilion" },
                    { 3, 2, "Elite" },
                    { 6, 1, "Latitude E5550" },
                    { 5, 1, "Latitude E4550" },
                    { 2, 1, "XPS" },
                    { 8, 4, "MacBook Pro" },
                    { 23, 9, "SPA525G2" }
                });

            migrationBuilder.InsertData(
                table: "Asset",
                columns: new[] { "Id", "AssetTypeId", "AssignedTo", "Description", "ModelId", "SerialNumber", "TagNumber" },
                values: new object[] { 1, 1, "DO1001", "Office Computer", 1, "X821908-014", "Z396" });

            migrationBuilder.InsertData(
                table: "Asset",
                columns: new[] { "Id", "AssetTypeId", "AssignedTo", "Description", "ModelId", "SerialNumber", "TagNumber" },
                values: new object[] { 2, 1, "CA1002", "Office2 Computer", 2, "X821908-080", "H591" });

            migrationBuilder.InsertData(
                table: "Asset",
                columns: new[] { "Id", "AssetTypeId", "AssignedTo", "Description", "ModelId", "SerialNumber", "TagNumber" },
                values: new object[] { 3, 2, "SM1003", "HR laptop", 5, "X85981-254", "P655" });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_AssetTypeId",
                table: "Asset",
                column: "AssetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_ModelId",
                table: "Asset",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Model_ManufacturerId",
                table: "Model",
                column: "ManufacturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "AssetType");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "Manufacturer");
        }
    }
}
