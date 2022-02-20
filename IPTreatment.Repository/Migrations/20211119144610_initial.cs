using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IPTreatment.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PackageDetail",
                columns: table => new
                {
                    PackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreatmentPackageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    TreatmentDuration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageDetail", x => x.PackageId);
                });

            migrationBuilder.CreateTable(
                name: "PatientDetail",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ailment = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    TreatmentPackageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreatmentCommencementDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDetail", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "SpecialistDetails",
                columns: table => new
                {
                    SpecialistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaOfExpertise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceInYears = table.Column<int>(type: "int", nullable: false),
                    TreatmentDuration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialistDetails", x => x.SpecialistId);
                });

            migrationBuilder.CreateTable(
                name: "IPTreatmentPackage",
                columns: table => new
                {
                    IPTreatmentPackagesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ailment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPTreatmentPackage", x => x.IPTreatmentPackagesId);
                    table.ForeignKey(
                        name: "FK_IPTreatmentPackage_PackageDetail_PackageId",
                        column: x => x.PackageId,
                        principalTable: "PackageDetail",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentPlan",
                columns: table => new
                {
                    TreatmentPlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageDetailName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    TreatmentCommencementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TreatmentEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpecialistId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentPlan", x => x.TreatmentPlanId);
                    table.ForeignKey(
                        name: "FK_TreatmentPlan_PatientDetail_PatientId",
                        column: x => x.PatientId,
                        principalTable: "PatientDetail",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentPlan_SpecialistDetails_SpecialistId",
                        column: x => x.SpecialistId,
                        principalTable: "SpecialistDetails",
                        principalColumn: "SpecialistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IPTreatmentPackage_PackageId",
                table: "IPTreatmentPackage",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentPlan_PatientId",
                table: "TreatmentPlan",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentPlan_SpecialistId",
                table: "TreatmentPlan",
                column: "SpecialistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IPTreatmentPackage");

            migrationBuilder.DropTable(
                name: "TreatmentPlan");

            migrationBuilder.DropTable(
                name: "PackageDetail");

            migrationBuilder.DropTable(
                name: "PatientDetail");

            migrationBuilder.DropTable(
                name: "SpecialistDetails");
        }
    }
}
