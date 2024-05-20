using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Moto.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrigindoCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "user_updated_date",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "user_created_date",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "user_birth_date",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "rent_updated_date",
                table: "Rents",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "rent_end_date",
                table: "Rents",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "rent_created_date",
                table: "Rents",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PreviewEndDate",
                table: "Rents",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Rents",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "plan_updated_date",
                table: "Plans",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "plan_created_date",
                table: "Plans",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "bike_updated_date",
                table: "Bikes",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "bike_created_date",
                table: "Bikes",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.InsertData(
                table: "Plans",
                columns: new[] { "plan_id", "plan_created_date", "plan_days", "flan_fee", "plan_price", "plan_updated_date" },
                values: new object[,]
                {
                    { new Guid("01f5b1c5-de54-454f-ba35-5602b679bb35"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, 1m, 20m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("686f94d8-83ab-4c42-91f9-a7999cdf6c86"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 1.4m, 28m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("70b1f0b6-1d43-4d7e-810e-10bcfe532de3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1.2m, 30m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("74d9c5f0-5d88-4d43-939f-f74f8bb04d82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 1m, 18m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9c2cdcbe-bc7c-4c99-b5a8-d604b735f9ee"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, 1m, 22m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "user_birth_date", "user_cnh", "user_cnh_type", "user_cnpj", "user_created_date", "user_name", "user_password", "Role", "user_updated_date" },
                values: new object[,]
                {
                    { new Guid("832ea094-11d8-4c5d-977c-517507c5267a"), new DateTime(1994, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "68690498097", 1, "85.017.314/0001-50", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrador", "admin", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("acf06da3-a70a-463a-bddc-ebe6aa704898"), new DateTime(1994, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "16604016578", 1, "33.029.871/0001-97", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Motoboy", "motoboy", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "plan_id",
                keyValue: new Guid("01f5b1c5-de54-454f-ba35-5602b679bb35"));

            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "plan_id",
                keyValue: new Guid("686f94d8-83ab-4c42-91f9-a7999cdf6c86"));

            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "plan_id",
                keyValue: new Guid("70b1f0b6-1d43-4d7e-810e-10bcfe532de3"));

            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "plan_id",
                keyValue: new Guid("74d9c5f0-5d88-4d43-939f-f74f8bb04d82"));

            migrationBuilder.DeleteData(
                table: "Plans",
                keyColumn: "plan_id",
                keyValue: new Guid("9c2cdcbe-bc7c-4c99-b5a8-d604b735f9ee"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("832ea094-11d8-4c5d-977c-517507c5267a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("acf06da3-a70a-463a-bddc-ebe6aa704898"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "user_updated_date",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "user_created_date",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "user_birth_date",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "rent_updated_date",
                table: "Rents",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "rent_end_date",
                table: "Rents",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "rent_created_date",
                table: "Rents",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PreviewEndDate",
                table: "Rents",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Rents",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "plan_updated_date",
                table: "Plans",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "plan_created_date",
                table: "Plans",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "bike_updated_date",
                table: "Bikes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "bike_created_date",
                table: "Bikes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

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
    }
}
