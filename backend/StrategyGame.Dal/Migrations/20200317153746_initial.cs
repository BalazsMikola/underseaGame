using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StrategyGame.Dal.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    BuildingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Grow_pop = table.Column<int>(nullable: false),
                    Grow_coral = table.Column<int>(nullable: false),
                    Space = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.BuildingId);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Population = table.Column<int>(nullable: false),
                    Pearl = table.Column<int>(nullable: false),
                    Coral = table.Column<int>(nullable: false),
                    Rank = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ElapsedRounds = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Attack = table.Column<int>(nullable: false),
                    Defend = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    Food = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Upgrades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Coral = table.Column<int>(nullable: false),
                    Defend = table.Column<int>(nullable: false),
                    Attack = table.Column<int>(nullable: false),
                    Tax = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upgrades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CityBuilding",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false),
                    BuildingId = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    RoundToFinish = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityBuilding", x => new { x.CityId, x.BuildingId });
                    table.ForeignKey(
                        name: "FK_CityBuilding_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityBuilding_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CityArmy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    EnemyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityArmy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityArmy_Cities_Id",
                        column: x => x.Id,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityArmy_Units_Id",
                        column: x => x.Id,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CityUnit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityUnit_Cities_Id",
                        column: x => x.Id,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityUnit_Units_Id",
                        column: x => x.Id,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityUnit_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CityUpgrade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    RoundToFinish = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityUpgrade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityUpgrade_Cities_Id",
                        column: x => x.Id,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityUpgrade_Upgrades_Id",
                        column: x => x.Id,
                        principalTable: "Upgrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "BuildingId", "Grow_coral", "Grow_pop", "Name", "Price", "Space" },
                values: new object[,]
                {
                    { 1, 200, 50, "áramlásirányító", 1000, 0 },
                    { 2, 0, 0, "zátonyvár", 1000, 200 }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Attack", "Cost", "Defend", "Food", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 6, 1, 2, 1, "rohamfóka", 50 },
                    { 2, 2, 1, 6, 1, "csatacsikó", 50 },
                    { 3, 5, 3, 5, 2, "lézercápa", 100 }
                });

            migrationBuilder.InsertData(
                table: "Upgrades",
                columns: new[] { "Id", "Attack", "Coral", "Defend", "Name", "Tax" },
                values: new object[,]
                {
                    { 1, 0, 10, 0, "iszaptraktor", 0 },
                    { 2, 0, 15, 0, "iszapkombájn", 0 },
                    { 3, 0, 0, 20, "korallfal", 0 },
                    { 4, 20, 0, 0, "szonárágyú", 0 },
                    { 5, 10, 0, 10, "vízalatti harcművészetek", 0 },
                    { 6, 0, 0, 0, "alkímia", 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityBuilding_BuildingId",
                table: "CityBuilding",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_CityUnit_UnitId",
                table: "CityUnit",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityArmy");

            migrationBuilder.DropTable(
                name: "CityBuilding");

            migrationBuilder.DropTable(
                name: "CityUnit");

            migrationBuilder.DropTable(
                name: "CityUpgrade");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Upgrades");
        }
    }
}
