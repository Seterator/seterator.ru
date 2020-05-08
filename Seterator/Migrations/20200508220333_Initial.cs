using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Seterator.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompetitionCategories",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionCategories", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    RoleGuid = table.Column<Guid>(nullable: false),
                    Data = table.Column<string>(nullable: true),
                    ShortLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.RoleGuid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Login = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    CreatorUserGuid = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    Extra = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Competitions_Users_CreatorUserGuid",
                        column: x => x.CreatorUserGuid,
                        principalTable: "Users",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    UserRole = table.Column<int>(nullable: false),
                    UserGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Roles_Users_UserGuid",
                        column: x => x.UserGuid,
                        principalTable: "Users",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionConstraints",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    CompetitionGuid = table.Column<Guid>(nullable: false),
                    CheckedValue = table.Column<string>(nullable: true),
                    Min = table.Column<int>(nullable: false),
                    Max = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionConstraints", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_CompetitionConstraints_Competitions_CompetitionGuid",
                        column: x => x.CompetitionGuid,
                        principalTable: "Competitions",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionRelCategories",
                columns: table => new
                {
                    CompetitionGuid = table.Column<Guid>(nullable: false),
                    CategoryGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionRelCategories", x => new { x.CategoryGuid, x.CompetitionGuid });
                    table.ForeignKey(
                        name: "FK_CompetitionRelCategories_CompetitionCategories_CategoryGuid",
                        column: x => x.CategoryGuid,
                        principalTable: "CompetitionCategories",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionRelCategories_Competitions_CompetitionGuid",
                        column: x => x.CompetitionGuid,
                        principalTable: "Competitions",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionRelJuries",
                columns: table => new
                {
                    CompetitionGuid = table.Column<Guid>(nullable: false),
                    JuryUserGuid = table.Column<Guid>(nullable: false),
                    JuryGuid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionRelJuries", x => new { x.CompetitionGuid, x.JuryUserGuid });
                    table.ForeignKey(
                        name: "FK_CompetitionRelJuries_Competitions_CompetitionGuid",
                        column: x => x.CompetitionGuid,
                        principalTable: "Competitions",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionRelJuries_Users_JuryGuid",
                        column: x => x.JuryGuid,
                        principalTable: "Users",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    CompetitionGuid = table.Column<Guid>(nullable: false),
                    UserGuid = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Nickname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Participants_Competitions_CompetitionGuid",
                        column: x => x.CompetitionGuid,
                        principalTable: "Competitions",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participants_Users_UserGuid",
                        column: x => x.UserGuid,
                        principalTable: "Users",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prizes",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    CompetitionGuid = table.Column<Guid>(nullable: false),
                    BeginPlace = table.Column<int>(nullable: false),
                    EndPlace = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prizes", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Prizes_Competitions_CompetitionGuid",
                        column: x => x.CompetitionGuid,
                        principalTable: "Competitions",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantAssessments",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    ParticipantGuid = table.Column<Guid>(nullable: false),
                    JuryGuid = table.Column<Guid>(nullable: false),
                    Assessment = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantAssessments", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ParticipantAssessments_Participants_ParticipantGuid",
                        column: x => x.ParticipantGuid,
                        principalTable: "Participants",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Poems",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    ParticipantGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poems", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Poems_Participants_ParticipantGuid",
                        column: x => x.ParticipantGuid,
                        principalTable: "Participants",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionConstraints_CompetitionGuid",
                table: "CompetitionConstraints",
                column: "CompetitionGuid");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionRelCategories_CompetitionGuid",
                table: "CompetitionRelCategories",
                column: "CompetitionGuid");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionRelJuries_JuryGuid",
                table: "CompetitionRelJuries",
                column: "JuryGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_CreatorUserGuid",
                table: "Competitions",
                column: "CreatorUserGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantAssessments_ParticipantGuid",
                table: "ParticipantAssessments",
                column: "ParticipantGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_CompetitionGuid",
                table: "Participants",
                column: "CompetitionGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_UserGuid",
                table: "Participants",
                column: "UserGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Poems_ParticipantGuid",
                table: "Poems",
                column: "ParticipantGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Prizes_CompetitionGuid",
                table: "Prizes",
                column: "CompetitionGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserGuid",
                table: "Roles",
                column: "UserGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetitionConstraints");

            migrationBuilder.DropTable(
                name: "CompetitionRelCategories");

            migrationBuilder.DropTable(
                name: "CompetitionRelJuries");

            migrationBuilder.DropTable(
                name: "ParticipantAssessments");

            migrationBuilder.DropTable(
                name: "Poems");

            migrationBuilder.DropTable(
                name: "Prizes");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "CompetitionCategories");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
