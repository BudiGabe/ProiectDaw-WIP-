using Microsoft.EntityFrameworkCore.Migrations;

namespace DAW_Lab2_Sgr15.Migrations
{
    public partial class FixedUserToSongRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSongs_Users_SongId",
                table: "UserSongs");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSongs_Users_UserId",
                table: "UserSongs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSongs_Users_UserId",
                table: "UserSongs");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSongs_Users_SongId",
                table: "UserSongs",
                column: "SongId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
