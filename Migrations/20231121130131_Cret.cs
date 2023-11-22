using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PP_1lab_Anna.Migrations
{
    /// <inheritdoc />
    public partial class Cret : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_group",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи группы")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_group_name = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Название группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_group_group_id", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_course",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи предмета")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_title = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Название предмета"),
                    с_group_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_course_course_id", x => x.group_id);
                    table.ForeignKey(
                        name: "fk_с_group_id",
                        column: x => x.с_group_id,
                        principalTable: "cd_group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи студента")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_student_firstname = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Имя студента"),
                    c_student_lastname = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Фамилия студента"),
                    c_student_middlename = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: true, comment: "Отчество студента"),
                    f_group_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_student_student_id", x => x.student_id);
                    table.ForeignKey(
                        name: "FK_Students_cd_group_f_group_id",
                        column: x => x.f_group_id,
                        principalTable: "cd_group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_course_fk_с_group_id",
                table: "cd_course",
                column: "с_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_f_group_id",
                table: "Students",
                column: "f_group_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_course");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "cd_group");
        }
    }
}
