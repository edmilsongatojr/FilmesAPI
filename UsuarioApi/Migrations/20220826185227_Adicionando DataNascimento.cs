using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuarioApi.Migrations
{
    public partial class AdicionandoDataNascimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "a49ba608-4d7d-4281-a4ab-e98f383105ea");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "800aefb6-7d4f-44e3-aacb-74bbf608cb59");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf9791ac-8633-4068-96e9-46878449d385", "AQAAAAEAACcQAAAAEO9KEtsycwOBK9JxuNbYcIrmEintbw1Ykd0FXHQQkSJ7rW1DM7JVNDqc6mP7lyYttQ==", "f0d0a132-d50c-4b3e-b9a8-c458e05cd9ae" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "4b524909-d805-4c37-9735-990c0cf2087f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "db684088-5d4d-444a-b4f9-e0e321635abd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ac53224-afbe-4c3f-a9b4-ca6e74aa0ca3", "AQAAAAEAACcQAAAAEAsgXXFFVkBzc1MyOKRN1AXxhRxtCJyk8wJLXYjvU5uJODnLYw5Idt6S7fLBoj5X9A==", "c75501de-1459-49ed-a3fd-c4eefc526546" });
        }
    }
}
