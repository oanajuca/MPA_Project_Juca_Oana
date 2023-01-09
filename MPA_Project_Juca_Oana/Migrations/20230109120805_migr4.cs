using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MPAProjectJucaOana.Migrations
{
    /// <inheritdoc />
    public partial class migr4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stadiums_Teams_TeamsID",
                table: "Stadiums");

            migrationBuilder.AlterColumn<int>(
                name: "TeamsID",
                table: "Stadiums",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                table: "Stadiums",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stadiums_Teams_TeamsID",
                table: "Stadiums",
                column: "TeamsID",
                principalTable: "Teams",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stadiums_Teams_TeamsID",
                table: "Stadiums");

            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "Stadiums");

            migrationBuilder.AlterColumn<int>(
                name: "TeamsID",
                table: "Stadiums",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stadiums_Teams_TeamsID",
                table: "Stadiums",
                column: "TeamsID",
                principalTable: "Teams",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
