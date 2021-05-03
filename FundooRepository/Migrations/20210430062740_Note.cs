using Microsoft.EntityFrameworkCore.Migrations;

namespace FundooRepository.Migrations
{
    public partial class Note : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Note_model",
                columns: table => new
                {
                    NoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Reminder = table.Column<string>(nullable: true),
                    Pin = table.Column<bool>(nullable: false),
                    Archive = table.Column<bool>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Colour = table.Column<string>(nullable: true),
                    isTrash = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note_model", x => x.NoteId);
                    table.ForeignKey(
                        name: "FK_Note_model_RegisterModels_UserId",
                        column: x => x.UserId,
                        principalTable: "RegisterModels",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Note_model_UserId",
                table: "Note_model",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Note_model");
        }
    }
}
