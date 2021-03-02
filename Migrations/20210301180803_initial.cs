using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamOne.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Gathering",
                columns: table => new
                {
                    GatheringId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    DurationInt = table.Column<int>(nullable: false),
                    DurationString = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gathering", x => x.GatheringId);
                    table.ForeignKey(
                        name: "FK_Gathering_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participation",
                columns: table => new
                {
                    ParticipationId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    UnionId = table.Column<int>(nullable: false),
                    EventGatheringId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participation", x => x.ParticipationId);
                    table.ForeignKey(
                        name: "FK_Participation_Gathering_EventGatheringId",
                        column: x => x.EventGatheringId,
                        principalTable: "Gathering",
                        principalColumn: "GatheringId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Participation_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gathering_UserId",
                table: "Gathering",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Participation_EventGatheringId",
                table: "Participation",
                column: "EventGatheringId");

            migrationBuilder.CreateIndex(
                name: "IX_Participation_UserId",
                table: "Participation",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participation");

            migrationBuilder.DropTable(
                name: "Gathering");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
