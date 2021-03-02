using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamOne.Migrations
{
    public partial class Relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gathering_Users_UserId",
                table: "Gathering");

            migrationBuilder.DropForeignKey(
                name: "FK_Participation_Gathering_EventGatheringId",
                table: "Participation");

            migrationBuilder.DropForeignKey(
                name: "FK_Participation_Users_UserId",
                table: "Participation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participation",
                table: "Participation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gathering",
                table: "Gathering");

            migrationBuilder.RenameTable(
                name: "Participation",
                newName: "Participations");

            migrationBuilder.RenameTable(
                name: "Gathering",
                newName: "Gatherings");

            migrationBuilder.RenameIndex(
                name: "IX_Participation_UserId",
                table: "Participations",
                newName: "IX_Participations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Participation_EventGatheringId",
                table: "Participations",
                newName: "IX_Participations_EventGatheringId");

            migrationBuilder.RenameIndex(
                name: "IX_Gathering_UserId",
                table: "Gatherings",
                newName: "IX_Gatherings_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participations",
                table: "Participations",
                column: "ParticipationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gatherings",
                table: "Gatherings",
                column: "GatheringId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gatherings_Users_UserId",
                table: "Gatherings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participations_Gatherings_EventGatheringId",
                table: "Participations",
                column: "EventGatheringId",
                principalTable: "Gatherings",
                principalColumn: "GatheringId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Participations_Users_UserId",
                table: "Participations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gatherings_Users_UserId",
                table: "Gatherings");

            migrationBuilder.DropForeignKey(
                name: "FK_Participations_Gatherings_EventGatheringId",
                table: "Participations");

            migrationBuilder.DropForeignKey(
                name: "FK_Participations_Users_UserId",
                table: "Participations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participations",
                table: "Participations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gatherings",
                table: "Gatherings");

            migrationBuilder.RenameTable(
                name: "Participations",
                newName: "Participation");

            migrationBuilder.RenameTable(
                name: "Gatherings",
                newName: "Gathering");

            migrationBuilder.RenameIndex(
                name: "IX_Participations_UserId",
                table: "Participation",
                newName: "IX_Participation_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Participations_EventGatheringId",
                table: "Participation",
                newName: "IX_Participation_EventGatheringId");

            migrationBuilder.RenameIndex(
                name: "IX_Gatherings_UserId",
                table: "Gathering",
                newName: "IX_Gathering_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participation",
                table: "Participation",
                column: "ParticipationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gathering",
                table: "Gathering",
                column: "GatheringId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gathering_Users_UserId",
                table: "Gathering",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participation_Gathering_EventGatheringId",
                table: "Participation",
                column: "EventGatheringId",
                principalTable: "Gathering",
                principalColumn: "GatheringId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Participation_Users_UserId",
                table: "Participation",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
