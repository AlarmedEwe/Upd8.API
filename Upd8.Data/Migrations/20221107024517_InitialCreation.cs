using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Upd8.Data.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpf = table.Column<string>(type: "varchar(20)", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "varchar(1)", nullable: false),
                    Address = table.Column<string>(type: "varchar(max)", nullable: true),
                    State = table.Column<string>(type: "varchar(2)", nullable: true),
                    City = table.Column<string>(type: "varchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "getdate()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
