using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGalleryAPI.Migrations
{
    public partial class StatVowelFkKeyChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_StatVowels_StatVowelsStatId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_StatVowelsStatId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "StatVowelsStatId",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "PostId",
                table: "StatVowels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_StatVowels_PostId",
                table: "StatVowels",
                column: "PostId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StatVowels_Posts_PostId",
                table: "StatVowels",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatVowels_Posts_PostId",
                table: "StatVowels");

            migrationBuilder.DropIndex(
                name: "IX_StatVowels_PostId",
                table: "StatVowels");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "StatVowels");

            migrationBuilder.AddColumn<Guid>(
                name: "StatVowelsStatId",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Posts_StatVowelsStatId",
                table: "Posts",
                column: "StatVowelsStatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_StatVowels_StatVowelsStatId",
                table: "Posts",
                column: "StatVowelsStatId",
                principalTable: "StatVowels",
                principalColumn: "StatId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
