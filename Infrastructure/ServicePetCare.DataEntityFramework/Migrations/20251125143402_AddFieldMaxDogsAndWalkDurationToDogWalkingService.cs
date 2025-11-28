using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicePetCare.DataEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldMaxDogsAndWalkDurationToDogWalkingService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxDogs",
                table: "DogWalkingServices",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WalkDurationMinutes",
                table: "DogWalkingServices",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxDogs",
                table: "DogWalkingServices");

            migrationBuilder.DropColumn(
                name: "WalkDurationMinutes",
                table: "DogWalkingServices");
        }
    }
}
