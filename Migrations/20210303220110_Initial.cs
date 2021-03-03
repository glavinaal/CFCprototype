using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CFCprototype.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberID);
                });

            migrationBuilder.CreateTable(
                name: "Sermon",
                columns: table => new
                {
                    SermonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SermonTitle = table.Column<string>(nullable: true),
                    SermonLink = table.Column<string>(nullable: true),
                    SermonDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sermon", x => x.SermonID);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventHostMemberID = table.Column<int>(nullable: true),
                    EventTitle = table.Column<string>(nullable: true),
                    EventDescription = table.Column<string>(nullable: true),
                    EventDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Event_Member_EventHostMemberID",
                        column: x => x.EventHostMemberID,
                        principalTable: "Member",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MembersClassifieds",
                columns: table => new
                {
                    MembersClassifiedsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosterNameMemberID = table.Column<int>(nullable: true),
                    ClassifiedTitle = table.Column<string>(nullable: true),
                    ClassifiedBody = table.Column<string>(nullable: true),
                    PostDate = table.Column<DateTime>(nullable: false),
                    PostDuration = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersClassifieds", x => x.MembersClassifiedsID);
                    table.ForeignKey(
                        name: "FK_MembersClassifieds_Member_PosterNameMemberID",
                        column: x => x.PosterNameMemberID,
                        principalTable: "Member",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrayerRequest",
                columns: table => new
                {
                    PrayerRequestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestPosterMemberID = table.Column<int>(nullable: true),
                    RequestSubject = table.Column<string>(nullable: true),
                    RequestBody = table.Column<string>(nullable: true),
                    RequestDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrayerRequest", x => x.PrayerRequestID);
                    table.ForeignKey(
                        name: "FK_PrayerRequest_Member_RequestPosterMemberID",
                        column: x => x.RequestPosterMemberID,
                        principalTable: "Member",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventHostMemberID",
                table: "Event",
                column: "EventHostMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_MembersClassifieds_PosterNameMemberID",
                table: "MembersClassifieds",
                column: "PosterNameMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_PrayerRequest_RequestPosterMemberID",
                table: "PrayerRequest",
                column: "RequestPosterMemberID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "MembersClassifieds");

            migrationBuilder.DropTable(
                name: "PrayerRequest");

            migrationBuilder.DropTable(
                name: "Sermon");

            migrationBuilder.DropTable(
                name: "Member");
        }
    }
}
