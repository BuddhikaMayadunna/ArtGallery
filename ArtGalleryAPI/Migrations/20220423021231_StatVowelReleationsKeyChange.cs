using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGalleryAPI.Migrations
{
    public partial class StatVowelReleationsKeyChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_StatVowels_StatVowelsId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatVowels",
                table: "StatVowels");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StatVowels");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "StatVowels",
                newName: "StatId");

            migrationBuilder.RenameColumn(
                name: "StatVowelsId",
                table: "Posts",
                newName: "StatVowelsStatId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_StatVowelsId",
                table: "Posts",
                newName: "IX_Posts_StatVowelsStatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatVowels",
                table: "StatVowels",
                column: "StatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_StatVowels_StatVowelsStatId",
                table: "Posts",
                column: "StatVowelsStatId",
                principalTable: "StatVowels",
                principalColumn: "StatId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_StatVowels_StatVowelsStatId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatVowels",
                table: "StatVowels");

            migrationBuilder.RenameColumn(
                name: "StatId",
                table: "StatVowels",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "StatVowelsStatId",
                table: "Posts",
                newName: "StatVowelsId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_StatVowelsStatId",
                table: "Posts",
                newName: "IX_Posts_StatVowelsId");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "StatVowels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatVowels",
                table: "StatVowels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_StatVowels_StatVowelsId",
                table: "Posts",
                column: "StatVowelsId",
                principalTable: "StatVowels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
