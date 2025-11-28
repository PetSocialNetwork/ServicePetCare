using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicePetCare.DataEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class ConvertToTpt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Services");

            migrationBuilder.CreateTable(
                name: "DogWalkingServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogWalkingServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DogWalkingServices_Services_Id",
                        column: x => x.Id,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DogWalkingServices");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Services",
                type: "character varying(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");
        }
    }
}
