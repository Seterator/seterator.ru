using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Seterator.Migrations
{
    public partial class Binary_data_stored_in_ImmutableArray : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FbProfile",
                table: "Users",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "INN",
                table: "Users",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "InstProfile",
                table: "Users",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "PrivateEmail",
                table: "Users",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "PrivatePhone",
                table: "Users",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Users",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "PublicEmail",
                table: "Users",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "PublicPhone",
                table: "Users",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "RegisterAddress",
                table: "Users",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "SNILS",
                table: "Users",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "Users",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "UserUrls",
                table: "Users",
                nullable: false);

            migrationBuilder.AddColumn<bool>(
                name: "Verified",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "VkProfile",
                table: "Users",
                nullable: false);

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OwnerGuid = table.Column<Guid>(nullable: false),
                    type = table.Column<string>(nullable: false),
                    data = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.id);
                    table.ForeignKey(
                        name: "FK_Documents_Users_OwnerGuid",
                        column: x => x.OwnerGuid,
                        principalTable: "Users",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_OwnerGuid",
                table: "Documents",
                column: "OwnerGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropColumn(
                name: "FbProfile",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "INN",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InstProfile",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PrivateEmail",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PrivatePhone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PublicEmail",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PublicPhone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RegisterAddress",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SNILS",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserUrls",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Verified",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VkProfile",
                table: "Users");
        }
    }
}
