using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Learning.Migrations
{
    public partial class LearningModelsLearningContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) => migrationBuilder.CreateTable(
            name: "LearningPractises",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn),
                Pressure = table.Column<int>(nullable: false),
                Humidity = table.Column<int>(nullable: false),
                Temperature = table.Column<int>(nullable: false),
                DateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
            },
            constraints: table => { table.PrimaryKey("PK_LearningPractises", x => x.Id); });

        protected override  void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LearningPractises");
        }
    }
}
