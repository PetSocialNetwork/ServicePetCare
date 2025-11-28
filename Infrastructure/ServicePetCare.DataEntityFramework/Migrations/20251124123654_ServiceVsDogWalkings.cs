using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicePetCare.DataEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class ServiceVsDogWalkings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DogWalkingServices_Services_Id",
                table: "DogWalkingServices");

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceId",
                table: "DogWalkingServices",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DogWalkingServices_ServiceId",
                table: "DogWalkingServices",
                column: "ServiceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DogWalkingServices_Services_ServiceId",
                table: "DogWalkingServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DogWalkingServices_Services_ServiceId",
                table: "DogWalkingServices");

            migrationBuilder.DropIndex(
                name: "IX_DogWalkingServices_ServiceId",
                table: "DogWalkingServices");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "DogWalkingServices");

            migrationBuilder.AddForeignKey(
                name: "FK_DogWalkingServices_Services_Id",
                table: "DogWalkingServices",
                column: "Id",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
