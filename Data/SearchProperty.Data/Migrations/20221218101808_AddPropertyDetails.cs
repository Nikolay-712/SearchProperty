namespace SearchProperty.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddPropertyDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BusinessDetailsId",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResidentalDetailsId",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BusinessDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BusinessType = table.Column<int>(type: "int", nullable: false),
                    PropertyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessDetails_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResidentialDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ResidentialTypes = table.Column<int>(type: "int", nullable: false),
                    PropertyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Bedrooms = table.Column<int>(type: "int", nullable: false),
                    Bathrooms = table.Column<int>(type: "int", nullable: false),
                    YardSquareMeters = table.Column<int>(type: "int", nullable: true),
                    Floor = table.Column<int>(type: "int", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentialDetails_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDetails_PropertyId",
                table: "BusinessDetails",
                column: "PropertyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialDetails_PropertyId",
                table: "ResidentialDetails",
                column: "PropertyId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessDetails");

            migrationBuilder.DropTable(
                name: "ResidentialDetails");

            migrationBuilder.DropColumn(
                name: "BusinessDetailsId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ResidentalDetailsId",
                table: "Properties");
        }
    }
}
