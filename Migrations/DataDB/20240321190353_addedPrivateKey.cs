using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace H5ServerSide_ToDoList.Migrations.DataDB
{
    /// <inheritdoc />
    public partial class addedPrivateKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrivateKey",
                table: "CPRs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrivateKey",
                table: "CPRs");
        }
    }
}
