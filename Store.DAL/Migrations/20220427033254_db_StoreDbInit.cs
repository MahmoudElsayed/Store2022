using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.DAL.Migrations
{
    public partial class db_StoreDbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Guide");

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                schema: "Guide",
                columns: table => new
                {
                    Seq_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Category_Code = table.Column<string>(type: "varchar(250)", nullable: false),
                    Category_Name = table.Column<string>(type: "varchar(250)", nullable: false),
                    Category_Description = table.Column<string>(type: "varchar(500)", nullable: false),
                    Status = table.Column<string>(type: "varchar(250)", nullable: false),
                    Create_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Delete_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.Seq_Id, x.Product_Category_Code });
                    table.UniqueConstraint("AK_ProductCategories_Product_Category_Code", x => x.Product_Category_Code);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                schema: "Guide",
                columns: table => new
                {
                    Seq_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Type_Code = table.Column<string>(type: "varchar(250)", nullable: false),
                    Product_Category_Code = table.Column<string>(type: "varchar(250)", nullable: false),
                    Type_Name = table.Column<string>(type: "varchar(250)", nullable: false),
                    Type_Description = table.Column<string>(type: "varchar(500)", nullable: false),
                    Status = table.Column<string>(type: "varchar(250)", nullable: false),
                    Create_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Delete_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => new { x.Seq_Id, x.Product_Type_Code });
                    table.UniqueConstraint("AK_ProductTypes_Product_Type_Code", x => x.Product_Type_Code);
                    table.ForeignKey(
                        name: "FK_ProductTypes_ProductCategories_Product_Category_Code",
                        column: x => x.Product_Category_Code,
                        principalSchema: "Guide",
                        principalTable: "ProductCategories",
                        principalColumn: "Product_Category_Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Guide",
                columns: table => new
                {
                    Seq_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Code = table.Column<string>(type: "varchar(250)", nullable: false),
                    Product_Type_Code = table.Column<string>(type: "varchar(250)", nullable: false),
                    Product_Name = table.Column<string>(type: "varchar(250)", nullable: false),
                    Product_Description = table.Column<string>(type: "varchar(500)", nullable: false),
                    Status = table.Column<string>(type: "varchar(250)", nullable: false),
                    Create_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Delete_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => new { x.Seq_Id, x.Product_Code });
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_Product_Type_Code",
                        column: x => x.Product_Type_Code,
                        principalSchema: "Guide",
                        principalTable: "ProductTypes",
                        principalColumn: "Product_Type_Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Product_Type_Code",
                schema: "Guide",
                table: "Products",
                column: "Product_Type_Code");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_Product_Category_Code",
                schema: "Guide",
                table: "ProductTypes",
                column: "Product_Category_Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products",
                schema: "Guide");

            migrationBuilder.DropTable(
                name: "ProductTypes",
                schema: "Guide");

            migrationBuilder.DropTable(
                name: "ProductCategories",
                schema: "Guide");
        }
    }
}
