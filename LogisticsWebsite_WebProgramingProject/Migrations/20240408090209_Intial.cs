using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsWebsite_WebProgramingProject.Migrations
{
    /// <inheritdoc />
    public partial class Intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryRegion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingInfomation",
                columns: table => new
                {
                    BookingNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    To = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Commodity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PriceOwner = table.Column<bool>(type: "bit", nullable: false),
                    CutOffSI = table.Column<DateOnly>(type: "date", nullable: false),
                    CutOffVGM = table.Column<double>(type: "float", nullable: false),
                    CutOffCY = table.Column<DateOnly>(type: "date", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageInfomation", x => x.BookingNo);
                });

            migrationBuilder.CreateTable(
                name: "Container",
                columns: table => new
                {
                    ContainerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoWeight = table.Column<double>(type: "float", nullable: false),
                    ContainerSize = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    NumberOfContainer = table.Column<byte>(type: "tinyint", nullable: false),
                    Type = table.Column<bool>(type: "bit", nullable: false),
                    PlaceToPickUp = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Container", x => x.ContainerID);
                });

            migrationBuilder.CreateTable(
                name: "Port",
                columns: table => new
                {
                    PortID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Port", x => x.PortID);
                });

            migrationBuilder.CreateTable(
                name: "Ship",
                columns: table => new
                {
                    ShipID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipCode = table.Column<string>(type: "nchar(6)", fixedLength: true, maxLength: 6, nullable: false),
                    ShipName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ship", x => x.ShipID);
                });

            migrationBuilder.CreateTable(
                name: "WareHouse",
                columns: table => new
                {
                    WhareHouseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Type = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhareHouse", x => x.WhareHouseID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Schedule",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipID = table.Column<int>(type: "int", nullable: true),
                    POL = table.Column<int>(type: "int", nullable: false),
                    POD = table.Column<int>(type: "int", nullable: false),
                    DayGo = table.Column<DateOnly>(type: "date", nullable: false),
                    TimeGo = table.Column<TimeOnly>(type: "time", nullable: true),
                    DayCome = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedule_Port",
                        column: x => x.POD,
                        principalTable: "Port",
                        principalColumn: "PortID");
                    table.ForeignKey(
                        name: "FK_Schedule_Port1",
                        column: x => x.POL,
                        principalTable: "Port",
                        principalColumn: "PortID");
                    table.ForeignKey(
                        name: "FK_Schedule_Ship",
                        column: x => x.ShipID,
                        principalTable: "Ship",
                        principalColumn: "ShipID");
                });

            migrationBuilder.CreateTable(
                name: "BillOfLading",
                columns: table => new
                {
                    BillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingNo = table.Column<int>(type: "int", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: false),
                    ContainerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BillID);
                    table.ForeignKey(
                        name: "FK_BillOfLading_BookingInfomation",
                        column: x => x.BookingNo,
                        principalTable: "BookingInfomation",
                        principalColumn: "BookingNo");
                    table.ForeignKey(
                        name: "FK_BillOfLading_Container1",
                        column: x => x.ContainerID,
                        principalTable: "Container",
                        principalColumn: "ContainerID");
                    table.ForeignKey(
                        name: "FK_BillOfLading_Schedule1",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "ScheduleId");
                });

            migrationBuilder.CreateTable(
                name: "Booking-WareHouse",
                columns: table => new
                {
                    No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillID = table.Column<int>(type: "int", nullable: false),
                    WhareHouseID = table.Column<int>(type: "int", nullable: false),
                    Dayin = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking-WhareHouse", x => x.No);
                    table.ForeignKey(
                        name: "FK_Booking-WhareHouse_Booking",
                        column: x => x.BillID,
                        principalTable: "BillOfLading",
                        principalColumn: "BillID");
                    table.ForeignKey(
                        name: "FK_Booking-WhareHouse_WhareHouse",
                        column: x => x.WhareHouseID,
                        principalTable: "WareHouse",
                        principalColumn: "WhareHouseID");
                });

            migrationBuilder.CreateTable(
                name: "CostsIncurred",
                columns: table => new
                {
                    CostsIncurredID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    BillID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostsIncurred", x => x.CostsIncurredID);
                    table.ForeignKey(
                        name: "FK_CostsIncurred_BillOfLading",
                        column: x => x.BillID,
                        principalTable: "BillOfLading",
                        principalColumn: "BillID");
                });

            migrationBuilder.CreateTable(
                name: "Tracking",
                columns: table => new
                {
                    TrackingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracking", x => x.TrackingID);
                    table.ForeignKey(
                        name: "FK_Tracking_BillOfLading",
                        column: x => x.BillID,
                        principalTable: "BillOfLading",
                        principalColumn: "BillID");
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillID = table.Column<int>(type: "int", nullable: false),
                    CostsIncurredID = table.Column<int>(type: "int", nullable: true),
                    Surcharge = table.Column<decimal>(type: "money", nullable: true),
                    Total = table.Column<decimal>(type: "money", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Invoice_BillOfLading",
                        column: x => x.BillID,
                        principalTable: "BillOfLading",
                        principalColumn: "BillID");
                    table.ForeignKey(
                        name: "FK_Invoice_CostsIncurred",
                        column: x => x.CostsIncurredID,
                        principalTable: "CostsIncurred",
                        principalColumn: "CostsIncurredID");
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
                name: "IX_BillOfLading_BookingNo",
                table: "BillOfLading",
                column: "BookingNo");

            migrationBuilder.CreateIndex(
                name: "IX_BillOfLading_ContainerID",
                table: "BillOfLading",
                column: "ContainerID");

            migrationBuilder.CreateIndex(
                name: "IX_BillOfLading_ScheduleId",
                table: "BillOfLading",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking-WareHouse_BillID",
                table: "Booking-WareHouse",
                column: "BillID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking-WareHouse_WhareHouseID",
                table: "Booking-WareHouse",
                column: "WhareHouseID");

            migrationBuilder.CreateIndex(
                name: "IX_CostsIncurred_BillID",
                table: "CostsIncurred",
                column: "BillID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_BillID",
                table: "Invoice",
                column: "BillID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CostsIncurredID",
                table: "Invoice",
                column: "CostsIncurredID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_POD",
                table: "Schedule",
                column: "POD");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_POL",
                table: "Schedule",
                column: "POL");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_ShipID",
                table: "Schedule",
                column: "ShipID");

            migrationBuilder.CreateIndex(
                name: "IX_Tracking_BillID",
                table: "Tracking",
                column: "BillID");
        }

        /// <inheritdoc />
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
                name: "Booking-WareHouse");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Tracking");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "WareHouse");

            migrationBuilder.DropTable(
                name: "CostsIncurred");

            migrationBuilder.DropTable(
                name: "BillOfLading");

            migrationBuilder.DropTable(
                name: "BookingInfomation");

            migrationBuilder.DropTable(
                name: "Container");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Port");

            migrationBuilder.DropTable(
                name: "Ship");
        }
    }
}
