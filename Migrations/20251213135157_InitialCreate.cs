using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OOP_final_project.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GlobalUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkRoom = table.Column<int>(type: "int", nullable: true),
                    WorkArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Illness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    AssignedDoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlobalUsers_GlobalUsers_AssignedDoctorId",
                        column: x => x.AssignedDoctorId,
                        principalTable: "GlobalUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GlobalUsers_AssignedDoctorId",
                table: "GlobalUsers",
                column: "AssignedDoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlobalUsers");
        }
    }
}
