using Microsoft.EntityFrameworkCore.Migrations;

namespace FundooRepository.Migrations
{
    public partial class LableTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lable_Models",
                columns: table => new
                {
                    LableId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    NoteId = table.Column<int>(nullable: true),
                    Lable = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lable_Models", x => x.LableId);
                    table.ForeignKey(
                        name: "FK_Lable_Models_Note_model_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Note_model",
                        principalColumn: "NoteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lable_Models_RegisterModels_UserId",
                        column: x => x.UserId,
                        principalTable: "RegisterModels",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lable_Models_NoteId",
                table: "Lable_Models",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Lable_Models_UserId",
                table: "Lable_Models",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lable_Models");
        }
    }
}
