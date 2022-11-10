using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GitHubInfoDownloader.Migrations
{
    /// <inheritdoc />
    public partial class FixingMaxLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_commits_gitusers_committerId",
                table: "commits");

            migrationBuilder.DropForeignKey(
                name: "FK_repos_gitusers_ownerId",
                table: "repos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_gitusers",
                table: "gitusers");

            migrationBuilder.RenameTable(
                name: "gitusers",
                newName: "gitUsers");

            migrationBuilder.RenameColumn(
                name: "gituserId",
                table: "gitUsers",
                newName: "gitUserId");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "repos",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "gitUsers",
                type: "nvarchar(39)",
                maxLength: 39,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "gitUsers",
                type: "nvarchar(320)",
                maxLength: 320,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "message",
                table: "commits",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "sha",
                table: "commits",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_gitUsers",
                table: "gitUsers",
                column: "gitUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_commits_gitUsers_committerId",
                table: "commits",
                column: "committerId",
                principalTable: "gitUsers",
                principalColumn: "gitUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_repos_gitUsers_ownerId",
                table: "repos",
                column: "ownerId",
                principalTable: "gitUsers",
                principalColumn: "gitUserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_commits_gitUsers_committerId",
                table: "commits");

            migrationBuilder.DropForeignKey(
                name: "FK_repos_gitUsers_ownerId",
                table: "repos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_gitUsers",
                table: "gitUsers");

            migrationBuilder.RenameTable(
                name: "gitUsers",
                newName: "gitusers");

            migrationBuilder.RenameColumn(
                name: "gitUserId",
                table: "gitusers",
                newName: "gituserId");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "repos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "gitusers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(39)",
                oldMaxLength: 39);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "gitusers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(320)",
                oldMaxLength: 320);

            migrationBuilder.AlterColumn<string>(
                name: "message",
                table: "commits",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "sha",
                table: "commits",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AddPrimaryKey(
                name: "PK_gitusers",
                table: "gitusers",
                column: "gituserId");

            migrationBuilder.AddForeignKey(
                name: "FK_commits_gitusers_committerId",
                table: "commits",
                column: "committerId",
                principalTable: "gitusers",
                principalColumn: "gituserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_repos_gitusers_ownerId",
                table: "repos",
                column: "ownerId",
                principalTable: "gitusers",
                principalColumn: "gituserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
