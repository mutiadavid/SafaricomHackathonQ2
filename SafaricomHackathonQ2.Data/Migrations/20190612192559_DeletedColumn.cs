using Microsoft.EntityFrameworkCore.Migrations;

namespace SafaricomHackathonQ2.Data.Migrations
{
    public partial class DeletedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "CreditVouchers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "CreditVouchers");
        }
    }
}
