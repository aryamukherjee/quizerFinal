using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Quizer.Migrations
{
    public partial class addCompletedQuizes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompletedQuizes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MCQAnswer = table.Column<int>(nullable: false),
                    QuestionID = table.Column<int>(nullable: true),
                    QuizID = table.Column<int>(nullable: true),
                    TextAnswer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedQuizes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CompletedQuizes_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "QuestionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompletedQuizes_Quizes_QuizID",
                        column: x => x.QuizID,
                        principalTable: "Quizes",
                        principalColumn: "QuizID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompletedQuizes_QuestionID",
                table: "CompletedQuizes",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedQuizes_QuizID",
                table: "CompletedQuizes",
                column: "QuizID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompletedQuizes");
        }
    }
}
