using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Moto.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Atualizacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "bike_plate",
                table: "Bikes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "bike_model",
                table: "Bikes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Plans",
                columns: new[] { "plan_id", "plan_created_date", "plan_days", "flan_fee", "plan_price", "plan_updated_date" },
                values: new object[,]
                {
                    { new Guid("38856ca5-0424-46eb-be99-07583da5bf86"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, 1m, 20m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c7c28740-8c15-430b-ba16-39f8147930e3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 1.4m, 28m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e9067552-6ff2-4854-a8de-4dd42f38f228"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, 1m, 22m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ec97a8fc-799e-455a-9a3e-24e599d33b07"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 1m, 18m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("eea05ec5-0da0-4ebd-ba02-bd68fb9c6d6e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1.2m, 30m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "plan_id",
                keyValue: new Guid("38856ca5-0424-46eb-be99-07583da5bf86"));

            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "plan_id",
                keyValue: new Guid("c7c28740-8c15-430b-ba16-39f8147930e3"));

            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "plan_id",
                keyValue: new Guid("e9067552-6ff2-4854-a8de-4dd42f38f228"));

            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "plan_id",
                keyValue: new Guid("ec97a8fc-799e-455a-9a3e-24e599d33b07"));

            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "plan_id",
                keyValue: new Guid("eea05ec5-0da0-4ebd-ba02-bd68fb9c6d6e"));

            migrationBuilder.AlterColumn<string>(
                name: "bike_plate",
                table: "Bikes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "bike_model",
                table: "Bikes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
