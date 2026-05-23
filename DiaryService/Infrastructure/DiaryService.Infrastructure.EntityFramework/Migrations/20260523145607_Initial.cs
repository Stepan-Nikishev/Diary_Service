using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiaryService.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    firstname = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    middlename = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    lastname = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "teacher",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    firstname = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    middlename = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    lastname = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "exercise",
                columns: table => new
                {
                    exercise_id = table.Column<Guid>(type: "uuid", nullable: false),
                    teacher_id = table.Column<Guid>(type: "uuid", nullable: false),
                    student_id = table.Column<Guid>(type: "uuid", nullable: false),
                    exercise = table.Column<string>(type: "text", nullable: false),
                    completed_exercise = table.Column<string>(type: "text", nullable: true),
                    exercise_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    completed_exercise_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercise", x => x.exercise_id);
                    table.ForeignKey(
                        name: "FK_exercise_student_student_id",
                        column: x => x.student_id,
                        principalTable: "student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_exercise_teacher_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "teacher",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "diary",
                columns: table => new
                {
                    diary_id = table.Column<Guid>(type: "uuid", nullable: false),
                    teacher_id = table.Column<Guid>(type: "uuid", nullable: false),
                    student_id = table.Column<Guid>(type: "uuid", nullable: false),
                    exercise_id = table.Column<Guid>(type: "uuid", nullable: false),
                    grade = table.Column<int>(type: "integer", nullable: false),
                    grade_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diary", x => x.diary_id);
                    table.ForeignKey(
                        name: "FK_diary_exercise_exercise_id",
                        column: x => x.exercise_id,
                        principalTable: "exercise",
                        principalColumn: "exercise_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_diary_student_student_id",
                        column: x => x.student_id,
                        principalTable: "student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_diary_teacher_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "teacher",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_diary_exercise_id",
                table: "diary",
                column: "exercise_id");

            migrationBuilder.CreateIndex(
                name: "IX_diary_student_id",
                table: "diary",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_diary_teacher_id",
                table: "diary",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_student_id",
                table: "exercise",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_teacher_id",
                table: "exercise",
                column: "teacher_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "diary");

            migrationBuilder.DropTable(
                name: "exercise");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "teacher");
        }
    }
}
