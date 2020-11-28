using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Seterator.Migrations
{
    public partial class FixedColumnsNullability : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetitionRelJuries_Users_JuryGuid",
                table: "CompetitionRelJuries");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "longblob",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "varchar(128)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "Users",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserGuid",
                table: "Roles",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "Roles",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");

            migrationBuilder.AlterColumn<string>(
                name: "Data",
                table: "Profiles",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleGuid",
                table: "Profiles",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Prizes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CompetitionGuid",
                table: "Prizes",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "Prizes",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Poems",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Poems",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ParticipantGuid",
                table: "Poems",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "Poems",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserGuid",
                table: "Participants",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");

            migrationBuilder.AlterColumn<string>(
                name: "Nickname",
                table: "Participants",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CompetitionGuid",
                table: "Participants",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "Participants",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");

            migrationBuilder.AlterColumn<Guid>(
                name: "ParticipantGuid",
                table: "ParticipantAssessments",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");

            migrationBuilder.AlterColumn<Guid>(
                name: "JuryGuid",
                table: "ParticipantAssessments",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "ParticipantAssessments",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Competitions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Competitions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Extra",
                table: "Competitions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Competitions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorUserGuid",
                table: "Competitions",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "Competitions",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");

            migrationBuilder.AlterColumn<Guid>(
                name: "JuryGuid",
                table: "CompetitionRelJuries",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "JuryUserGuid",
                table: "CompetitionRelJuries",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompetitionGuid",
                table: "CompetitionRelJuries",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompetitionGuid",
                table: "CompetitionRelCategories",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryGuid",
                table: "CompetitionRelCategories",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompetitionGuid",
                table: "CompetitionConstraints",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");

            migrationBuilder.AlterColumn<string>(
                name: "CheckedValue",
                table: "CompetitionConstraints",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "CompetitionConstraints",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CompetitionCategories",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "CompetitionCategories",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");

            migrationBuilder.AddForeignKey(
                name: "FK_CompetitionRelJuries_Users_JuryGuid",
                table: "CompetitionRelJuries",
                column: "JuryGuid",
                principalTable: "Users",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetitionRelJuries_Users_JuryGuid",
                table: "CompetitionRelJuries");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "longblob",
                nullable: true,
                oldClrType: typeof(byte[]));

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "varchar(128)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(128)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Guid",
                table: "Users",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<byte[]>(
                name: "UserGuid",
                table: "Roles",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<byte[]>(
                name: "Guid",
                table: "Roles",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Data",
                table: "Profiles",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<byte[]>(
                name: "RoleGuid",
                table: "Profiles",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Prizes",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<byte[]>(
                name: "CompetitionGuid",
                table: "Prizes",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<byte[]>(
                name: "Guid",
                table: "Prizes",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Poems",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Poems",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<byte[]>(
                name: "ParticipantGuid",
                table: "Poems",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<byte[]>(
                name: "Guid",
                table: "Poems",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<byte[]>(
                name: "UserGuid",
                table: "Participants",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Nickname",
                table: "Participants",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<byte[]>(
                name: "CompetitionGuid",
                table: "Participants",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<byte[]>(
                name: "Guid",
                table: "Participants",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<byte[]>(
                name: "ParticipantGuid",
                table: "ParticipantAssessments",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<byte[]>(
                name: "JuryGuid",
                table: "ParticipantAssessments",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<byte[]>(
                name: "Guid",
                table: "ParticipantAssessments",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Competitions",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Competitions",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Extra",
                table: "Competitions",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Competitions",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<byte[]>(
                name: "CreatorUserGuid",
                table: "Competitions",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<byte[]>(
                name: "Guid",
                table: "Competitions",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<byte[]>(
                name: "JuryGuid",
                table: "CompetitionRelJuries",
                type: "varbinary(16)",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<byte[]>(
                name: "JuryUserGuid",
                table: "CompetitionRelJuries",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<byte[]>(
                name: "CompetitionGuid",
                table: "CompetitionRelJuries",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<byte[]>(
                name: "CompetitionGuid",
                table: "CompetitionRelCategories",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<byte[]>(
                name: "CategoryGuid",
                table: "CompetitionRelCategories",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<byte[]>(
                name: "CompetitionGuid",
                table: "CompetitionConstraints",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "CheckedValue",
                table: "CompetitionConstraints",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<byte[]>(
                name: "Guid",
                table: "CompetitionConstraints",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CompetitionCategories",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<byte[]>(
                name: "Guid",
                table: "CompetitionCategories",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_CompetitionRelJuries_Users_JuryGuid",
                table: "CompetitionRelJuries",
                column: "JuryGuid",
                principalTable: "Users",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
