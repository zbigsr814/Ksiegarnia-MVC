using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExampleMvcProject.MVC.Migrations
{
    /// <inheritdoc />
    public partial class AddedBasketOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "baskets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_baskets_OwnerId",
                table: "baskets",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_baskets_AspNetUsers_OwnerId",
                table: "baskets",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_baskets_AspNetUsers_OwnerId",
                table: "baskets");

            migrationBuilder.DropIndex(
                name: "IX_baskets_OwnerId",
                table: "baskets");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "baskets");
        }
    }
}
