using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExampleMvcProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookstores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    contactDetailsCity = table.Column<string>(name: "contactDetails_City", type: "nvarchar(max)", nullable: true),
                    contactDetailsStreet = table.Column<string>(name: "contactDetails_Street", type: "nvarchar(max)", nullable: true),
                    contactDetailsPhoneNumber = table.Column<string>(name: "contactDetails_PhoneNumber", type: "nvarchar(max)", nullable: true),
                    contactDetailsPostalCode = table.Column<string>(name: "contactDetails_PostalCode", type: "nvarchar(max)", nullable: true),
                    EncodedName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookstores", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookstores");
        }
    }
}
