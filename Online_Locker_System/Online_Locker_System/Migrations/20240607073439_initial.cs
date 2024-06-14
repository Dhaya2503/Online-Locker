using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Locker_System.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branchs",
                columns: table => new
                {
                    Branch_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total_locker = table.Column<int>(type: "int", nullable: false),
                    Available_Locker = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branchs", x => x.Branch_Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locker_Status = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Requested_Date = table.Column<DateOnly>(type: "date", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    customer_DetailUser_Id = table.Column<int>(type: "int", nullable: false),
                    Branch_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    branch_DetailBranch_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Requested_Date);
                    table.ForeignKey(
                        name: "FK_Requests_Branchs_branch_DetailBranch_Id",
                        column: x => x.branch_DetailBranch_Id,
                        principalTable: "Branchs",
                        principalColumn: "Branch_Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Requests_Customers_customer_DetailUser_Id",
                        column: x => x.customer_DetailUser_Id,
                        principalTable: "Customers",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Approves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    customer_DetailUser_Id = table.Column<int>(type: "int", nullable: false),
                    Branch_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    branch_DetailBranch_Id = table.Column<int>(type: "int", nullable: false),
                    Requested_Date = table.Column<DateOnly>(type: "date", nullable: false),
                    requested_LockerRequested_Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Approved_Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Approves_Branchs_branch_DetailBranch_Id",
                        column: x => x.branch_DetailBranch_Id,
                        principalTable: "Branchs",
                        principalColumn: "Branch_Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Approves_Customers_customer_DetailUser_Id",
                        column: x => x.customer_DetailUser_Id,
                        principalTable: "Customers",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Approves_Requests_requested_LockerRequested_Date",
                        column: x => x.requested_LockerRequested_Date,
                        principalTable: "Requests",
                        principalColumn: "Requested_Date",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Approves_branch_DetailBranch_Id",
                table: "Approves",
                column: "branch_DetailBranch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Approves_customer_DetailUser_Id",
                table: "Approves",
                column: "customer_DetailUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Approves_requested_LockerRequested_Date",
                table: "Approves",
                column: "requested_LockerRequested_Date");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_branch_DetailBranch_Id",
                table: "Requests",
                column: "branch_DetailBranch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_customer_DetailUser_Id",
                table: "Requests",
                column: "customer_DetailUser_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Approves");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Branchs");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
