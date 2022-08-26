using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuarioApi.Migrations
{
    public partial class UsuarioRegular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "db684088-5d4d-444a-b4f9-e0e321635abd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99998, "4b524909-d805-4c37-9735-990c0cf2087f", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ac53224-afbe-4c3f-a9b4-ca6e74aa0ca3", "AQAAAAEAACcQAAAAEAsgXXFFVkBzc1MyOKRN1AXxhRxtCJyk8wJLXYjvU5uJODnLYw5Idt6S7fLBoj5X9A==", "c75501de-1459-49ed-a3fd-c4eefc526546" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "99eae837-74cf-4c45-871d-6a69a5050009");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28d581d7-e10f-4472-9d25-10629051efe9", "AQAAAAEAACcQAAAAEN7RSkyKGuuPhi7+o5bR2Xpg5fwA8v1padVUb4sQj7mkCpkWfgpXK6cXkJ4cal2PvA==", "dc52e04b-3284-430a-86a7-6d7f85f6712b" });
        }
    }
}
