using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace openlab_project.Data.Migrations
{
    /// <inheritdoc />
    public partial class Guildss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Guild_GuildId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "GuildId",
                table: "AspNetUsers",
                newName: "GuildInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_GuildId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_GuildInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Guild_GuildInfoId",
                table: "AspNetUsers",
                column: "GuildInfoId",
                principalTable: "Guild",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Guild_GuildInfoId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "GuildInfoId",
                table: "AspNetUsers",
                newName: "GuildId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_GuildInfoId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_GuildId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Guild_GuildId",
                table: "AspNetUsers",
                column: "GuildId",
                principalTable: "Guild",
                principalColumn: "Id");
        }
    }
}
