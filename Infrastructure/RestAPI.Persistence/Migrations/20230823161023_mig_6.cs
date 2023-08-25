using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Customers",
                newName: "Username");

            migrationBuilder.AddColumn<string>(
                name: "HashedPassword",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TelNo",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashedPassword",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TelNo",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Customers",
                newName: "Email");
        }
    }
}
