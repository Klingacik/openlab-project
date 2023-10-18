﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace openlab_project.Data.Migrations
{
    /// <inheritdoc />
    public partial class XpAndGuild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Guild",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Xp",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guild",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Xp",
                table: "AspNetUsers");
        }
    }
}
