using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace First.Ecard.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenamePasswordToPasswordHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                    name: "CryptedPassword",
                    table: "Agents",
                    newName: "PasswordHash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                    name: "PasswordHash",
                    table: "Agents",
                    newName: "CryptedPassword");
        }
    }
}
