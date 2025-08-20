using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qjc.AbpDemo.Application.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(128)", maxLength: 128, nullable: false),
                    ExtraProperties = table.Column<string>(type: "NVARCHAR2(32767)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "NVARCHAR2(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    CreatorId = table.Column<Guid>(type: "CHAR(36)", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "CHAR(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Test");
        }
    }
}
