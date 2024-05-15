using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moto.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bikes",
                columns: table => new
                {
                    bike_id = table.Column<Guid>(type: "uuid", nullable: false),
                    bike_year = table.Column<int>(type: "integer", nullable: false),
                    bike_plate = table.Column<string>(type: "text", nullable: true),
                    bike_model = table.Column<string>(type: "text", nullable: true),
                    bike_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    bike_updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BIKES", x => x.bike_id);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    plan_id = table.Column<Guid>(type: "uuid", nullable: false),
                    plan_days = table.Column<int>(type: "integer", nullable: false),
                    plan_price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    flan_fee = table.Column<decimal>(type: "numeric(4,2)", nullable: false),
                    plan_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    plan_updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLANS", x => x.plan_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_name = table.Column<string>(type: "text", nullable: false),
                    user_cnpj = table.Column<string>(type: "text", nullable: false),
                    user_birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    user_cnh = table.Column<string>(type: "text", nullable: false),
                    user_cnh_type = table.Column<int>(type: "integer", nullable: false),
                    user_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    rent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rent_end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PreviewEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rent_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rent_bike_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rent_plan_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rent_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rent_updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RENTS", x => x.rent_id);
                    table.ForeignKey(
                        name: "FK_Rents_Bikes_rent_bike_id",
                        column: x => x.rent_bike_id,
                        principalTable: "Bikes",
                        principalColumn: "bike_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_Plans_rent_plan_id",
                        column: x => x.rent_plan_id,
                        principalTable: "Plans",
                        principalColumn: "plan_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_Users_rent_user_id",
                        column: x => x.rent_user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bikes_bike_plate",
                table: "Bikes",
                column: "bike_plate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rents_rent_bike_id",
                table: "Rents",
                column: "rent_bike_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_rent_plan_id",
                table: "Rents",
                column: "rent_plan_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_rent_user_id",
                table: "Rents",
                column: "rent_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_user_cnh",
                table: "Users",
                column: "user_cnh",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_user_cnpj",
                table: "Users",
                column: "user_cnpj",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Bikes");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
