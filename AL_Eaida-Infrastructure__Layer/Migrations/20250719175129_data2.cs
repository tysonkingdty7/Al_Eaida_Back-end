using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AL_Eaida_Infrastructure__Layer.Migrations
{
    /// <inheritdoc />
    public partial class data2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "039806be-49c2-420f-9a53-2038d9df6f42");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "366a2914-2d46-49fa-8b66-c5078e3c793d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4122e635-875b-4eaa-b69f-ba7e25ff39d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9322cadf-8600-46c6-8750-2feb6dd26090");

            migrationBuilder.AlterColumn<string>(
                name: "BirthDate",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05d735eb-e134-4037-b9aa-61dcfab14267", null, "Doctor", "DOCTOR" },
                    { "17b2ebb5-23f5-4e4a-b7a2-e9e52596cc41", null, "Receptionist", "RECEPTIONIST" },
                    { "ef21745a-30d0-4830-8c84-6e8c6c534147", null, "Admin", "ADMIN" },
                    { "ffc1032a-baf1-4b0d-96cf-10fa064a48e7", null, "Accountant ", "ACCOUNTANT " }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05d735eb-e134-4037-b9aa-61dcfab14267");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17b2ebb5-23f5-4e4a-b7a2-e9e52596cc41");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef21745a-30d0-4830-8c84-6e8c6c534147");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffc1032a-baf1-4b0d-96cf-10fa064a48e7");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Patients");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Patients",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "039806be-49c2-420f-9a53-2038d9df6f42", null, "Accountant ", "ACCOUNTANT " },
                    { "366a2914-2d46-49fa-8b66-c5078e3c793d", null, "Doctor", "DOCTOR" },
                    { "4122e635-875b-4eaa-b69f-ba7e25ff39d1", null, "Admin", "ADMIN" },
                    { "9322cadf-8600-46c6-8750-2feb6dd26090", null, "Receptionist", "RECEPTIONIST" }
                });
        }
    }
}
