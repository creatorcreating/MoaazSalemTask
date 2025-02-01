using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Person_Details",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Person_Details",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Person_Details",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Person_Details",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Telephone_Number",
                table: "Person_Details",
                newName: "telephone Number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Person_Details",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Person_Details",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Person_Details",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Person_Details",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "telephone Number",
                table: "Person_Details",
                newName: "Telephone_Number");
        }
    }
}
