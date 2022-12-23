namespace SearchProperty.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class EditAddressModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "FullAddress",
                table: "Addresses",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Lat",
                table: "Addresses",
                type: "decimal(10,4)",
                precision: 10,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Lng",
                table: "Addresses",
                type: "decimal(10,4)",
                precision: 10,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Neighborhood",
                table: "Addresses",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Addresses",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullAddress",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Neighborhood",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Addresses",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "");
        }
    }
}
