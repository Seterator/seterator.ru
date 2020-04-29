using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Seterator.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "competition_categories",
                columns: table => new
                {
                    GUID = table.Column<byte[]>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competition_categories", x => x.GUID);
                });

            migrationBuilder.CreateTable(
                name: "profiles",
                columns: table => new
                {
                    user_role_guid = table.Column<byte[]>(nullable: false),
                    data = table.Column<string>(nullable: true),
                    short_link = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profiles", x => x.user_role_guid);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    GUID = table.Column<byte[]>(nullable: false),
                    login = table.Column<string>(nullable: true),
                    password_hash = table.Column<byte[]>(type: "BINARY(24)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.GUID);
                });

            migrationBuilder.CreateTable(
                name: "competition",
                columns: table => new
                {
                    GUID = table.Column<byte[]>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    creator_user_guid = table.Column<byte[]>(nullable: false),
                    start_date = table.Column<DateTime>(nullable: false),
                    end_date = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    short_description = table.Column<string>(nullable: true),
                    extra = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competition", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_competition_user_creator_user_guid",
                        column: x => x.creator_user_guid,
                        principalTable: "user",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    GUID = table.Column<byte[]>(nullable: false),
                    role = table.Column<string>(type: "Enum( 'moderator', 'jury', 'user', 'manager', 'admin' )", nullable: false),
                    user_guid = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_roles_user_user_guid",
                        column: x => x.user_guid,
                        principalTable: "user",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "competition_constraints",
                columns: table => new
                {
                    GUID = table.Column<byte[]>(nullable: false),
                    competition_guid = table.Column<byte[]>(nullable: false),
                    checked_value = table.Column<string>(nullable: true),
                    min = table.Column<int>(nullable: false),
                    max = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competition_constraints", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_competition_constraints_competition_competition_guid",
                        column: x => x.competition_guid,
                        principalTable: "competition",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "competition_rel_category",
                columns: table => new
                {
                    competition_category_guid = table.Column<byte[]>(nullable: false),
                    competition_guid = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competition_rel_category", x => new { x.competition_guid, x.competition_category_guid });
                    table.ForeignKey(
                        name: "FK_competition_rel_category_competition_categories_competition_guid",
                        column: x => x.competition_guid,
                        principalTable: "competition_categories",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_competition_rel_category_competition_competition_category_guid",
                        column: x => x.competition_category_guid,
                        principalTable: "competition",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "competition_rel_jury",
                columns: table => new
                {
                    competition_guid = table.Column<byte[]>(nullable: false),
                    jury_user_guid = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competition_rel_jury", x => new { x.competition_guid, x.jury_user_guid });
                    table.ForeignKey(
                        name: "FK_competition_rel_jury_competition_competition_guid",
                        column: x => x.competition_guid,
                        principalTable: "competition",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_competition_rel_jury_user_jury_user_guid",
                        column: x => x.jury_user_guid,
                        principalTable: "user",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "participant",
                columns: table => new
                {
                    GUID = table.Column<byte[]>(nullable: false),
                    competition_guid = table.Column<byte[]>(nullable: false),
                    user_guid = table.Column<byte[]>(nullable: false),
                    status = table.Column<string>(type: "enum('New','Approved','Rejected','Updated')", nullable: false),
                    create_date = table.Column<DateTime>(nullable: false),
                    nickname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participant", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_participant_competition_competition_guid",
                        column: x => x.competition_guid,
                        principalTable: "competition",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_participant_user_user_guid",
                        column: x => x.user_guid,
                        principalTable: "user",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prizes",
                columns: table => new
                {
                    GUID = table.Column<byte[]>(nullable: false),
                    competition_guid = table.Column<byte[]>(nullable: false),
                    begin_place = table.Column<int>(nullable: false),
                    end_place = table.Column<int>(nullable: false),
                    value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prizes", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_prizes_competition_competition_guid",
                        column: x => x.competition_guid,
                        principalTable: "competition",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "participant_assessment",
                columns: table => new
                {
                    GUID = table.Column<byte[]>(nullable: false),
                    participant_guid = table.Column<byte[]>(nullable: false),
                    jury_guid = table.Column<byte[]>(nullable: false),
                    assessment = table.Column<string>(type: "enum('0', '2', '3', '4', '5')", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participant_assessment", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_participant_assessment_participant_participant_guid",
                        column: x => x.participant_guid,
                        principalTable: "participant",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "poem",
                columns: table => new
                {
                    GUID = table.Column<byte[]>(nullable: false),
                    text = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    author_participant_guid = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_poem", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_poem_participant_author_participant_guid",
                        column: x => x.author_participant_guid,
                        principalTable: "participant",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_competition_creator_user_guid",
                table: "competition",
                column: "creator_user_guid");

            migrationBuilder.CreateIndex(
                name: "IX_competition_constraints_competition_guid",
                table: "competition_constraints",
                column: "competition_guid");

            migrationBuilder.CreateIndex(
                name: "IX_competition_rel_category_competition_category_guid",
                table: "competition_rel_category",
                column: "competition_category_guid");

            migrationBuilder.CreateIndex(
                name: "IX_competition_rel_jury_jury_user_guid",
                table: "competition_rel_jury",
                column: "jury_user_guid");

            migrationBuilder.CreateIndex(
                name: "IX_participant_competition_guid",
                table: "participant",
                column: "competition_guid");

            migrationBuilder.CreateIndex(
                name: "IX_participant_user_guid",
                table: "participant",
                column: "user_guid");

            migrationBuilder.CreateIndex(
                name: "IX_participant_assessment_participant_guid",
                table: "participant_assessment",
                column: "participant_guid");

            migrationBuilder.CreateIndex(
                name: "IX_poem_author_participant_guid",
                table: "poem",
                column: "author_participant_guid");

            migrationBuilder.CreateIndex(
                name: "IX_prizes_competition_guid",
                table: "prizes",
                column: "competition_guid");

            migrationBuilder.CreateIndex(
                name: "IX_roles_user_guid",
                table: "roles",
                column: "user_guid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "competition_constraints");

            migrationBuilder.DropTable(
                name: "competition_rel_category");

            migrationBuilder.DropTable(
                name: "competition_rel_jury");

            migrationBuilder.DropTable(
                name: "participant_assessment");

            migrationBuilder.DropTable(
                name: "poem");

            migrationBuilder.DropTable(
                name: "prizes");

            migrationBuilder.DropTable(
                name: "profiles");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "competition_categories");

            migrationBuilder.DropTable(
                name: "participant");

            migrationBuilder.DropTable(
                name: "competition");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
