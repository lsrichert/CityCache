using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace finalcapstone.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Neighborhood",
                columns: table => new
                {
                    NeighborhoodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighborhood", x => x.NeighborhoodId);
                });

            migrationBuilder.CreateTable(
                name: "RecommendationType",
                columns: table => new
                {
                    RecommendationTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendationType", x => x.RecommendationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recommendation",
                columns: table => new
                {
                    RecommendationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    StreetAddress = table.Column<string>(nullable: true),
                    WebsiteURL = table.Column<string>(nullable: true),
                    DefaultView = table.Column<bool>(nullable: false),
                    ApplicationUserId = table.Column<int>(nullable: false),
                    NeighborhoodId = table.Column<int>(nullable: false),
                    RecommendationTypeId = table.Column<int>(nullable: false),
                    ApplicationUserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recommendation", x => x.RecommendationId);
                    table.ForeignKey(
                        name: "FK_Recommendation_AspNetUsers_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recommendation_Neighborhood_NeighborhoodId",
                        column: x => x.NeighborhoodId,
                        principalTable: "Neighborhood",
                        principalColumn: "NeighborhoodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recommendation_RecommendationType_RecommendationTypeId",
                        column: x => x.RecommendationTypeId,
                        principalTable: "RecommendationType",
                        principalColumn: "RecommendationTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "d8e565d1-6b07-4c9b-bbd7-698dad017496", 0, "537eeca8-2c5c-4d8d-867c-93aaae8a934c", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEKbrrMyZqmm9EZ3i4mMYUlEjFP04Bz7SpyePvNmnq0baFoEy7nc21rb6WmgOCx8dpg==", null, false, "67fdf855-264a-4eed-8afa-1003e0145e9c", false, "admin@admin.com" },
                    { "fb0bb898-aae2-4126-9565-32827d1ac8df", 0, "eca30e2c-fd47-43c6-91ac-e22c5a16ea5b", "ApplicationUser", "test@test.com", true, false, null, "TEST@TEST.COM", "TEST@TEST.COM", "AQAAAAEAACcQAAAAEMgFApaF0/W6b2uXCRkopikW9LfgzJgnB3vDUtBOj+dizwSNLl/hpVf4NjBdmEptRA==", null, false, "8b65fb3a-7140-48bd-b17f-d09d11cd19ef", false, "test@test.com" }
                });

            migrationBuilder.InsertData(
                table: "Neighborhood",
                columns: new[] { "NeighborhoodId", "Name" },
                values: new object[,]
                {
                    { 14, "Other" },
                    { 13, "Lincoln Square" },
                    { 12, "West Loop" },
                    { 11, "Old Town" },
                    { 10, "Wicker Park" },
                    { 9, "North Center" },
                    { 8, "Southport Corridor" },
                    { 6, "Logan Square" },
                    { 5, "River North" },
                    { 4, "Wrigleyville" },
                    { 3, "Andersonville" },
                    { 2, "Lincoln Park" },
                    { 1, "Ravenswood" },
                    { 7, "Roscoe Village" }
                });

            migrationBuilder.InsertData(
                table: "RecommendationType",
                columns: new[] { "RecommendationTypeId", "Name" },
                values: new object[,]
                {
                    { 2, "Entertainment" },
                    { 1, "Food & Drink" },
                    { 3, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Recommendation",
                columns: new[] { "RecommendationId", "ApplicationUserId", "ApplicationUserId1", "DefaultView", "Description", "Name", "NeighborhoodId", "RecommendationTypeId", "StreetAddress", "WebsiteURL" },
                values: new object[,]
                {
                    { 1, 1, null, false, "Breakfast", "Over Easy", 1, 1, "4943 N. Damen Ave.", "overeasycafechicago.com" },
                    { 2, 1, null, false, "Contemporary-American", "Hub 51", 5, 1, "51 W. Hubbard St.", "hub51chicago.com" },
                    { 4, 1, null, false, "American Comfort", "Crosby's Kitchen", 8, 1, "3455 N. Southport Ave.", "crosbyschicago.com" },
                    { 5, 1, null, false, "Bar", "HopLeaf", 3, 1, "5148 N. Clark St.", "hopleafbar.com" },
                    { 3, 1, null, false, "Comedy Club", "The Second City", 11, 2, "1616 N. Wells St.", "secondcity.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendation_ApplicationUserId1",
                table: "Recommendation",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendation_NeighborhoodId",
                table: "Recommendation",
                column: "NeighborhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendation_RecommendationTypeId",
                table: "Recommendation",
                column: "RecommendationTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Recommendation");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Neighborhood");

            migrationBuilder.DropTable(
                name: "RecommendationType");
        }
    }
}
