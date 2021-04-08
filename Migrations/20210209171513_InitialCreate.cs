using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace nscccoursemap_ibadk5304.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicYears",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseCode = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiplomaPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiplomaPrograms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    AcademicYearId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Semesters_AcademicYears_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYears",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CoursePrerequisites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(nullable: false),
                    PrerequisiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePrerequisites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursePrerequisites_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CoursePrerequisites_Courses_PrerequisiteId",
                        column: x => x.PrerequisiteId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DiplomaProgramYears",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    DiplomaProgramId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiplomaProgramYears", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiplomaProgramYears_DiplomaPrograms_DiplomaProgramId",
                        column: x => x.DiplomaProgramId,
                        principalTable: "DiplomaPrograms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DiplomaProgramYearSections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    DiplomaProgramYearId = table.Column<int>(nullable: false),
                    AcademicYearId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiplomaProgramYearSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiplomaProgramYearSections_AcademicYears_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYears",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DiplomaProgramYearSections_DiplomaProgramYears_DiplomaProgramYearId",
                        column: x => x.DiplomaProgramYearId,
                        principalTable: "DiplomaProgramYears",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdvisingAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorId = table.Column<int>(nullable: false),
                    DiplomaProgramYearSectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvisingAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvisingAssignments_DiplomaProgramYearSections_DiplomaProgramYearSectionId",
                        column: x => x.DiplomaProgramYearSectionId,
                        principalTable: "DiplomaProgramYearSections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdvisingAssignments_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseOfferings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(nullable: false),
                    InstructorId = table.Column<int>(nullable: false),
                    DiplomaProgramYearSectionId = table.Column<int>(nullable: false),
                    SemesterId = table.Column<int>(nullable: false),
                    IsDirectedElective = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseOfferings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseOfferings_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseOfferings_DiplomaProgramYearSections_DiplomaProgramYearSectionId",
                        column: x => x.DiplomaProgramYearSectionId,
                        principalTable: "DiplomaProgramYearSections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseOfferings_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseOfferings_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicYears_Title",
                table: "AcademicYears",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdvisingAssignments_DiplomaProgramYearSectionId",
                table: "AdvisingAssignments",
                column: "DiplomaProgramYearSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisingAssignments_InstructorId",
                table: "AdvisingAssignments",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseOfferings_CourseId",
                table: "CourseOfferings",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseOfferings_DiplomaProgramYearSectionId",
                table: "CourseOfferings",
                column: "DiplomaProgramYearSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseOfferings_InstructorId",
                table: "CourseOfferings",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseOfferings_SemesterId",
                table: "CourseOfferings",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePrerequisites_CourseId",
                table: "CoursePrerequisites",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePrerequisites_PrerequisiteId",
                table: "CoursePrerequisites",
                column: "PrerequisiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseCode",
                table: "Courses",
                column: "CourseCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DiplomaProgramYears_DiplomaProgramId",
                table: "DiplomaProgramYears",
                column: "DiplomaProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_DiplomaProgramYearSections_AcademicYearId",
                table: "DiplomaProgramYearSections",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_DiplomaProgramYearSections_DiplomaProgramYearId",
                table: "DiplomaProgramYearSections",
                column: "DiplomaProgramYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_AcademicYearId",
                table: "Semesters",
                column: "AcademicYearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvisingAssignments");

            migrationBuilder.DropTable(
                name: "CourseOfferings");

            migrationBuilder.DropTable(
                name: "CoursePrerequisites");

            migrationBuilder.DropTable(
                name: "DiplomaProgramYearSections");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "DiplomaProgramYears");

            migrationBuilder.DropTable(
                name: "AcademicYears");

            migrationBuilder.DropTable(
                name: "DiplomaPrograms");
        }
    }
}
