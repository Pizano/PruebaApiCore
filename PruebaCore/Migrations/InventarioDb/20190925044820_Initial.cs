using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaCore.Migrations.InventarioDb
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulo",
                columns: table => new
                {
                    Sku_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sku_Codigo = table.Column<string>(nullable: true),
                    Sku_NumeroSerie = table.Column<string>(nullable: true),
                    Sku_Descripcion = table.Column<string>(nullable: true),
                    Sku_Cantidad = table.Column<string>(nullable: true),
                    Sku_Cat_ID = table.Column<int>(nullable: false),
                    Sku_Sub_Cat_ID = table.Column<int>(nullable: false),
                    Sku_Latitud = table.Column<string>(nullable: true),
                    Sku_Longitud = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulo", x => x.Sku_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articulo");
        }
    }
}
