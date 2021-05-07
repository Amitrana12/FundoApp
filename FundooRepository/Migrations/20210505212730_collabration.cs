using Microsoft.EntityFrameworkCore.Migrations;

namespace FundooRepository.Migrations
{
    public partial class collabration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collaborator",
                columns: table => new
                {
                    CollaboratorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteId = table.Column<int>(nullable: false),
                    SenderEmail = table.Column<string>(nullable: true),
                    ReceiverEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborator", x => x.CollaboratorId);
                    table.ForeignKey(
                        name: "FK_Collaborator_Note_model_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Note_model",
                        principalColumn: "NoteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collaborator_NoteId",
                table: "Collaborator",
                column: "NoteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collaborator");
        }
    }
}
