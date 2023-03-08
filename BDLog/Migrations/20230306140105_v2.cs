using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BDELog.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USR_ROLE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NAME = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    NORMALIZEDNAME = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    CONCURRENCYSTAMP = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USR_ROLE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USR_USER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    FULLUSER = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    USERNAME = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    NORMALIZEDUSERNAME = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    EMAIL = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    NORMALIZEDEMAIL = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    EMAILCONFIRMED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    PASSWORDHASH = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SECURITYSTAMP = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CONCURRENCYSTAMP = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PHONENUMBER = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PHONENUMBERCONFIRMED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    TWOFACTORENABLED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    LOCKOUTEND = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    LOCKOUTENABLED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ACCESSFAILEDCOUNT = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USR_USER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USR_ROLECLAIMS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ROLEID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CLAIMTYPE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CLAIMVALUE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USR_ROLECLAIMS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USR_ROLECLAIMS_USR_ROLE_ROLEID",
                        column: x => x.ROLEID,
                        principalTable: "USR_ROLE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USR_USERCLAIMS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    USERID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CLAIMTYPE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CLAIMVALUE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USR_USERCLAIMS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USR_USERCLAIMS_USR_USER_USERID",
                        column: x => x.USERID,
                        principalTable: "USR_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USR_USERLOGINS",
                columns: table => new
                {
                    LOGINPROVIDER = table.Column<string>(type: "NVARCHAR2(128)", maxLength: 128, nullable: false),
                    PROVIDERKEY = table.Column<string>(type: "NVARCHAR2(128)", maxLength: 128, nullable: false),
                    PROVIDERDISPLAYNAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    USERID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USR_USERLOGINS", x => new { x.LOGINPROVIDER, x.PROVIDERKEY });
                    table.ForeignKey(
                        name: "FK_USR_USERLOGINS_USR_USER_USERID",
                        column: x => x.USERID,
                        principalTable: "USR_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USR_USERROLES",
                columns: table => new
                {
                    USERID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ROLEID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USR_USERROLES", x => new { x.USERID, x.ROLEID });
                    table.ForeignKey(
                        name: "FK_USR_USERROLES_USR_ROLE_ROLEID",
                        column: x => x.ROLEID,
                        principalTable: "USR_ROLE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USR_USERROLES_USR_USER_USERID",
                        column: x => x.USERID,
                        principalTable: "USR_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USR_USERTOKENS",
                columns: table => new
                {
                    USERID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LOGINPROVIDER = table.Column<string>(type: "NVARCHAR2(128)", maxLength: 128, nullable: false),
                    NAME = table.Column<string>(type: "NVARCHAR2(128)", maxLength: 128, nullable: false),
                    VALUE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USR_USERTOKENS", x => new { x.USERID, x.LOGINPROVIDER, x.NAME });
                    table.ForeignKey(
                        name: "FK_USR_USERTOKENS_USR_USER_USERID",
                        column: x => x.USERID,
                        principalTable: "USR_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "USR_ROLE",
                column: "NORMALIZEDNAME",
                unique: true,
                filter: "\"NORMALIZEDNAME\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_USR_ROLECLAIMS_ROLEID",
                table: "USR_ROLECLAIMS",
                column: "ROLEID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "USR_USER",
                column: "NORMALIZEDEMAIL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "USR_USER",
                column: "NORMALIZEDUSERNAME",
                unique: true,
                filter: "\"NORMALIZEDUSERNAME\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_USR_USERCLAIMS_USERID",
                table: "USR_USERCLAIMS",
                column: "USERID");

            migrationBuilder.CreateIndex(
                name: "IX_USR_USERLOGINS_USERID",
                table: "USR_USERLOGINS",
                column: "USERID");

            migrationBuilder.CreateIndex(
                name: "IX_USR_USERROLES_ROLEID",
                table: "USR_USERROLES",
                column: "ROLEID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USR_ROLECLAIMS");

            migrationBuilder.DropTable(
                name: "USR_USERCLAIMS");

            migrationBuilder.DropTable(
                name: "USR_USERLOGINS");

            migrationBuilder.DropTable(
                name: "USR_USERROLES");

            migrationBuilder.DropTable(
                name: "USR_USERTOKENS");

            migrationBuilder.DropTable(
                name: "USR_ROLE");

            migrationBuilder.DropTable(
                name: "USR_USER");
        }
    }
}
