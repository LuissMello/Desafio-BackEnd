using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Moto.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Plans",
                columns: new[] { "plan_id", "plan_created_date", "plan_days", "flan_fee", "plan_price", "plan_updated_date" },
                values: new object[,]
                {
                    { new Guid("2586b77c-3329-49cc-a31e-8cd19ad83f49"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, 1m, 22m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2f5d4fa5-c195-4aad-bb4a-0c1bb7115ec3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, 1m, 20m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("80a8ccbd-c021-4c85-85d9-0f006909e28f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1.2m, 30m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("86fb1746-1165-4fc5-a101-0e8768b50fe2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 1m, 18m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9cb46d4e-ff50-46ed-8bf8-c4ea3341c03f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 1.4m, 28m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "user_birth_date", "user_cnh", "user_cnh_type", "user_cnpj", "user_created_date", "user_name", "user_password", "Role", "user_updated_date" },
                values: new object[,]
                {
                    { new Guid("06ad9df4-3ba2-4ef3-8923-a209c1d8d047"), new DateTime(1994, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "16604016578", 1, "33.029.871/0001-97", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Motoboy", "motoboy", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("57fa9e3d-eb33-4f4a-9218-d29a87de96c2"), new DateTime(1994, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "68690498097", 1, "85.017.314/0001-50", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrador", "admin", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "plan_id",
                keyValue: new Guid("2586b77c-3329-49cc-a31e-8cd19ad83f49"));

            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "plan_id",
                keyValue: new Guid("2f5d4fa5-c195-4aad-bb4a-0c1bb7115ec3"));

            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "plan_id",
                keyValue: new Guid("80a8ccbd-c021-4c85-85d9-0f006909e28f"));

            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "plan_id",
                keyValue: new Guid("86fb1746-1165-4fc5-a101-0e8768b50fe2"));

            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "plan_id",
                keyValue: new Guid("9cb46d4e-ff50-46ed-8bf8-c4ea3341c03f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("06ad9df4-3ba2-4ef3-8923-a209c1d8d047"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("57fa9e3d-eb33-4f4a-9218-d29a87de96c2"));

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
    }
}
