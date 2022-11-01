using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class AddTripRelationToRule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "Rules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rules_TripId",
                table: "Rules",
                column: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rules_Trips_TripId",
                table: "Rules",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rules_Trips_TripId",
                table: "Rules");

            migrationBuilder.DropIndex(
                name: "IX_Rules_TripId",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "Rules");
        }
    }
}
