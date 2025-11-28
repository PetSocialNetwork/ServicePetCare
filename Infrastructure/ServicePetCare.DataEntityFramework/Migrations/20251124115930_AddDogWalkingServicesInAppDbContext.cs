using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicePetCare.DataEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddDogWalkingServicesInAppDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Services",
                type: "character varying(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Services");
        }
    }
}
