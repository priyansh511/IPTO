using Microsoft.EntityFrameworkCore.Migrations;

namespace IPTOffering.Repository.Migrations
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
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TreatmentDuration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageDetail", x => x.PackageId);
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
                    IPTreatmentPackagesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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

            migrationBuilder.CreateIndex(
                name: "IX_IPTreatmentPackage_PackageId",
                table: "IPTreatmentPackage",
                column: "PackageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IPTreatmentPackage");

            migrationBuilder.DropTable(
                name: "SpecialistDetails");

            migrationBuilder.DropTable(
                name: "PackageDetail");
        }
    }
}
