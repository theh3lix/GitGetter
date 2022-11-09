using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GitHubInfoDownloader.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gitusers",
                columns: table => new
                {
                    gituserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gitusers", x => x.gituserId);
                });

            migrationBuilder.CreateTable(
                name: "repos",
                columns: table => new
                {
                    repoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ownerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_repos", x => x.repoId);
                    table.ForeignKey(
                        name: "FK_repos_gitusers_ownerId",
                        column: x => x.ownerId,
                        principalTable: "gitusers",
                        principalColumn: "gituserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "commits",
                columns: table => new
                {
                    sha = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    repoId = table.Column<int>(type: "int", nullable: false),
                    committerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commits", x => x.sha);
                    table.ForeignKey(
                        name: "FK_commits_gitusers_committerId",
                        column: x => x.committerId,
                        principalTable: "gitusers",
                        principalColumn: "gituserId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_commits_repos_repoId",
                        column: x => x.repoId,
                        principalTable: "repos",
                        principalColumn: "repoId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_commits_committerId",
                table: "commits",
                column: "committerId");

            migrationBuilder.CreateIndex(
                name: "IX_commits_repoId",
                table: "commits",
                column: "repoId");

            migrationBuilder.CreateIndex(
                name: "IX_repos_ownerId",
                table: "repos",
                column: "ownerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "commits");

            migrationBuilder.DropTable(
                name: "repos");

            migrationBuilder.DropTable(
                name: "gitusers");
        }
    }
}
