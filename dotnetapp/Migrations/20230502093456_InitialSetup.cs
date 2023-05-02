using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetapp.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adminTable",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserRole = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adminTable", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "documentTable",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentUpload = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documentTable", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "loginTable",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loginTable", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "paymentTable",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentTable", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "planTable",
                columns: table => new
                {
                    PlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicableAge = table.Column<int>(type: "int", nullable: false),
                    years = table.Column<int>(type: "int", nullable: true),
                    claimamount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InterestRate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_planTable", x => x.PlanId);
                });

            migrationBuilder.CreateTable(
                name: "policyTable",
                columns: table => new
                {
                    PolicyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolicyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantAadhaar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantPan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantSalary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_policyTable", x => x.PolicyId);
                });

            migrationBuilder.CreateTable(
                name: "userTable",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserRole = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userTable", x => x.Username);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adminTable");

            migrationBuilder.DropTable(
                name: "documentTable");

            migrationBuilder.DropTable(
                name: "loginTable");

            migrationBuilder.DropTable(
                name: "paymentTable");

            migrationBuilder.DropTable(
                name: "planTable");

            migrationBuilder.DropTable(
                name: "policyTable");

            migrationBuilder.DropTable(
                name: "userTable");
        }
    }
}
