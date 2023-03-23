using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eWallet.Data.Migrations
{
    /// <inheritdoc />
    public partial class temp01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("1083fdbe-1f26-4aa6-bddc-d06fa6bc523e"),
                column: "ConcurrencyStamp",
                value: "76afc48e-333e-4520-8cf7-b88b42ca9400");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("ba9a22f7-4843-4638-8b9b-ba3241973892"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c8a8b276-712a-46cf-b7da-9205a3cacc7e", "AQAAAAEAACcQAAAAEGSMw/g30t9TEqgKg6tyzlUsMAylbkUFHvbYqNhuAbUGRg75iNJ73QGrtmwicDGzNg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("1083fdbe-1f26-4aa6-bddc-d06fa6bc523e"),
                column: "ConcurrencyStamp",
                value: "2f703c7c-8ac2-477a-b844-4220cc452ff2");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("ba9a22f7-4843-4638-8b9b-ba3241973892"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "98e3564d-358a-419f-bcb4-07b7210fb0ce", "AQAAAAEAACcQAAAAELfBK3tBC/urzTDNnPCfueu3PJaI+TnFysjsfMlciWekrut9vhD7jhiH+DlPEWBnAw==" });
        }
    }
}
