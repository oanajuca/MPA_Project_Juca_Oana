using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MPAProjectJucaOana.Migrations
{
    /// <inheritdoc />
    public partial class migr2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomersID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Stadiums_StadiumsID",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "StadiumsID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomersID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomersID",
                table: "Orders",
                column: "CustomersID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Stadiums_StadiumsID",
                table: "Orders",
                column: "StadiumsID",
                principalTable: "Stadiums",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomersID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Stadiums_StadiumsID",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "StadiumsID",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CustomersID",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomersID",
                table: "Orders",
                column: "CustomersID",
                principalTable: "Customers",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Stadiums_StadiumsID",
                table: "Orders",
                column: "StadiumsID",
                principalTable: "Stadiums",
                principalColumn: "ID");
        }
    }
}
