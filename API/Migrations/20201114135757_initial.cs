using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Pokedex_Index = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 36, nullable: false),
                    Hp = table.Column<int>(nullable: false),
                    Attack = table.Column<int>(nullable: false),
                    Defense = table.Column<int>(nullable: false),
                    Special_Attack = table.Column<int>(nullable: false),
                    Special_Defense = table.Column<int>(nullable: false),
                    Speed = table.Column<int>(nullable: false),
                    Generation = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PokemonType = table.Column<string>(maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PokemonTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PokemonId = table.Column<Guid>(nullable: true),
                    TypeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PokemonTypes_Pokemons_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PokemonTypes_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_Name",
                table: "Pokemons",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_Pokedex_Index",
                table: "Pokemons",
                column: "Pokedex_Index",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTypes_PokemonId",
                table: "PokemonTypes",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTypes_TypeId",
                table: "PokemonTypes",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Types_PokemonType",
                table: "Types",
                column: "PokemonType",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonTypes");

            migrationBuilder.DropTable(
                name: "Pokemons");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
