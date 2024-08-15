using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CreekRiver.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CampsiteTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CampsiteTypeName = table.Column<string>(type: "text", nullable: false),
                    MaxReservationDays = table.Column<int>(type: "integer", nullable: false),
                    FeePerNight = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampsiteTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campsites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nickname = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    CampsiteTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campsites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campsites_CampsiteTypes_CampsiteTypeId",
                        column: x => x.CampsiteTypeId,
                        principalTable: "CampsiteTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CampsiteId = table.Column<int>(type: "integer", nullable: false),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    CheckinDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CheckoutDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Campsites_CampsiteId",
                        column: x => x.CampsiteId,
                        principalTable: "Campsites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CampsiteTypes",
                columns: new[] { "Id", "CampsiteTypeName", "FeePerNight", "MaxReservationDays" },
                values: new object[,]
                {
                    { 1, "Tent", 15.99m, 7 },
                    { 2, "RV", 26.50m, 14 },
                    { 3, "Primitive", 10.00m, 3 },
                    { 4, "Hammock", 12m, 7 }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[] { 1, "bigbabyspur@gmail.com", "Andrew", "Spurlock" });

            migrationBuilder.InsertData(
                table: "Campsites",
                columns: new[] { "Id", "CampsiteTypeId", "ImageUrl", "Nickname" },
                values: new object[,]
                {
                    { 1, 1, "https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg", "Barred Owl" },
                    { 2, 2, "https://i.insider.com/60dc93caa08b100012b417e9?width=910&format=jpeg", "Camp Ross" },
                    { 3, 3, "https://www.alapark.com/sites/default/files/2020-08/dsp_primitive_campground_19.jpg", "Camp Derek" },
                    { 4, 4, "https://terrain-mag.com/wp-content/uploads/2020/02/Barbara_150825_0697.jpg", "Camp Taylor" },
                    { 5, 2, "https://thervadvisor.com/wp-content/uploads/2018/12/Road-Tripping-Tips-for-Choosing-Your-RV-Campsite-e1545074276760.png", "Camp Andrew" },
                    { 6, 1, "https://www.armstrongwatson.co.uk/sites/armstrongwatson.co.uk/files/styles/blog/adaptive-image/public/news-images/2021/campsite_with_tents.jpg?itok=w6XzCVU2", "Camp NSS" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CampsiteId", "CheckinDate", "CheckoutDate", "UserProfileId" },
                values: new object[] { 1, 5, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Campsites_CampsiteTypeId",
                table: "Campsites",
                column: "CampsiteTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CampsiteId",
                table: "Reservations",
                column: "CampsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserProfileId",
                table: "Reservations",
                column: "UserProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Campsites");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "CampsiteTypes");
        }
    }
}
