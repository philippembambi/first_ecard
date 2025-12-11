using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace First.Ecard.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addRoleStringConversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Clients",
                type: "character varying(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<string>(
                name: "CardType",
                table: "Cards",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Agents",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Clients",
                type: "integer",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1)",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<int>(
                name: "CardType",
                table: "Cards",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Agents",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
