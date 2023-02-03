using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.DataAccess.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoLists",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoLists", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TodoTask",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    isdone = table.Column<int>(name: "is_done", type: "INTEGER", nullable: false),
                    listid = table.Column<int>(name: "list_id", type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoTask", x => x.id);
                    table.ForeignKey(
                        name: "FK_TodoTask_TodoLists_list_id",
                        column: x => x.listid,
                        principalTable: "TodoLists",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoTask_list_id",
                table: "TodoTask",
                column: "list_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoTask");

            migrationBuilder.DropTable(
                name: "TodoLists");
        }
    }
}
