using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace First.Ecard.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenamePasswordField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Agents",
                type: "character varying(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Agents",
                type: "integer",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1)",
                oldMaxLength: 1);
        }
    }
}
