using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Proyecto_01.Migrations
{
    /// <inheritdoc />
    public partial class seedcategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categorias_Id",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Productos",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "IdCagtegoria",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Productos",
                newName: "IdCategoria");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categorias",
                newName: "IdCategoria");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Productos",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Productos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AddColumn<uint>(
                name: "IdProducto",
                table: "Productos",
                type: "int unsigned",
                nullable: false,
                defaultValue: 0u)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productos",
                table: "Productos",
                column: "IdProducto");

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Nombre" },
                values: new object[,]
                {
                    { 1u, "categoria1" },
                    { 2u, "categoria2" },
                    { 3u, "categoria3" },
                    { 4u, "categoria4" },
                    { 5u, "categoria5" },
                    { 6u, "categoria6" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdCategoria",
                table: "Productos",
                column: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categorias_IdCategoria",
                table: "Productos",
                column: "IdCategoria",
                principalTable: "Categorias",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categorias_IdCategoria",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Productos",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_IdCategoria",
                table: "Productos");

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 1u);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 2u);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 3u);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 4u);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 5u);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: 6u);

            migrationBuilder.DropColumn(
                name: "IdProducto",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "IdCategoria",
                table: "Productos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdCategoria",
                table: "Categorias",
                newName: "Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Productos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Productos",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<int>(
                name: "IdCagtegoria",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productos",
                table: "Productos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categorias_Id",
                table: "Productos",
                column: "Id",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
