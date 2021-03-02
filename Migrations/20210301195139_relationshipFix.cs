using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamOne.Migrations
{
    public partial class relationshipFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participations_Gatherings_EventGatheringId",
                table: "Participations");

            migrationBuilder.DropIndex(
                name: "IX_Participations_EventGatheringId",
                table: "Participations");

            migrationBuilder.DropColumn(
                name: "EventGatheringId",
                table: "Participations");

            migrationBuilder.DropColumn(
                name: "UnionId",
                table: "Participations");

            migrationBuilder.AddColumn<int>(
                name: "GatheringId",
                table: "Participations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Participations_GatheringId",
                table: "Participations",
                column: "GatheringId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participations_Gatherings_GatheringId",
                table: "Participations",
                column: "GatheringId",
                principalTable: "Gatherings",
                principalColumn: "GatheringId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participations_Gatherings_GatheringId",
                table: "Participations");

            migrationBuilder.DropIndex(
                name: "IX_Participations_GatheringId",
                table: "Participations");

            migrationBuilder.DropColumn(
                name: "GatheringId",
                table: "Participations");

            migrationBuilder.AddColumn<int>(
                name: "EventGatheringId",
                table: "Participations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnionId",
                table: "Participations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Participations_EventGatheringId",
                table: "Participations",
                column: "EventGatheringId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participations_Gatherings_EventGatheringId",
                table: "Participations",
                column: "EventGatheringId",
                principalTable: "Gatherings",
                principalColumn: "GatheringId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
