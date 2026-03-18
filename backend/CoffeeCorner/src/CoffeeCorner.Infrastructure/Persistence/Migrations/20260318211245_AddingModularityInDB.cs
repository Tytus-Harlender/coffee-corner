using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeCorner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingModularityInDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Products_ProductId",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Customers_CustomerId",
                table: "Baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacteristicValues_Characteristics_CharacteristicId",
                table: "CharacteristicValues");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_CustomerId",
                table: "Baskets");

            migrationBuilder.EnsureSchema(
                name: "basket");

            migrationBuilder.EnsureSchema(
                name: "catalog");

            migrationBuilder.EnsureSchema(
                name: "customers");

            migrationBuilder.EnsureSchema(
                name: "orders");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Products",
                newSchema: "catalog");

            migrationBuilder.RenameTable(
                name: "ProductCharacteristicValue",
                newName: "ProductCharacteristicValue",
                newSchema: "catalog");

            migrationBuilder.RenameTable(
                name: "ProductCategory",
                newName: "ProductCategory",
                newSchema: "catalog");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Orders",
                newSchema: "orders");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "OrderItems",
                newSchema: "orders");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customers",
                newSchema: "customers");

            migrationBuilder.RenameTable(
                name: "CharacteristicValues",
                newName: "CharacteristicValues",
                newSchema: "catalog");

            migrationBuilder.RenameTable(
                name: "Characteristics",
                newName: "Characteristics",
                newSchema: "catalog");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categories",
                newSchema: "catalog");

            migrationBuilder.RenameTable(
                name: "Baskets",
                newName: "Baskets",
                newSchema: "basket");

            migrationBuilder.RenameTable(
                name: "BasketItems",
                newName: "BasketItems",
                newSchema: "basket");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "catalog",
                table: "Products",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderPublicId",
                schema: "orders",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Products_PublicId",
                schema: "catalog",
                table: "Products",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderPublicId",
                schema: "orders",
                table: "Orders",
                column: "OrderPublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId_ProductId",
                schema: "orders",
                table: "OrderItems",
                columns: new[] { "OrderId", "ProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_CustomerId",
                schema: "basket",
                table: "Baskets",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_BasketId_ProductId",
                schema: "basket",
                table: "BasketItems",
                columns: new[] { "BasketId", "ProductId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacteristicValues_Characteristics_CharacteristicId",
                schema: "catalog",
                table: "CharacteristicValues",
                column: "CharacteristicId",
                principalSchema: "catalog",
                principalTable: "Characteristics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacteristicValues_Characteristics_CharacteristicId",
                schema: "catalog",
                table: "CharacteristicValues");

            migrationBuilder.DropIndex(
                name: "IX_Products_PublicId",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderPublicId",
                schema: "orders",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrderId_ProductId",
                schema: "orders",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_CustomerId",
                schema: "basket",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_BasketId_ProductId",
                schema: "basket",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "OrderPublicId",
                schema: "orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "catalog",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "ProductCharacteristicValue",
                schema: "catalog",
                newName: "ProductCharacteristicValue");

            migrationBuilder.RenameTable(
                name: "ProductCategory",
                schema: "catalog",
                newName: "ProductCategory");

            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "orders",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                schema: "orders",
                newName: "OrderItems");

            migrationBuilder.RenameTable(
                name: "Customers",
                schema: "customers",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "CharacteristicValues",
                schema: "catalog",
                newName: "CharacteristicValues");

            migrationBuilder.RenameTable(
                name: "Characteristics",
                schema: "catalog",
                newName: "Characteristics");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "catalog",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Baskets",
                schema: "basket",
                newName: "Baskets");

            migrationBuilder.RenameTable(
                name: "BasketItems",
                schema: "basket",
                newName: "BasketItems");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_CustomerId",
                table: "Baskets",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Products_ProductId",
                table: "BasketItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Customers_CustomerId",
                table: "Baskets",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacteristicValues_Characteristics_CharacteristicId",
                table: "CharacteristicValues",
                column: "CharacteristicId",
                principalTable: "Characteristics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
