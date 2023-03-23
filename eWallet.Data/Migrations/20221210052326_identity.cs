using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eWallet.Data.Migrations
{
    /// <inheritdoc />
    public partial class identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FristName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "AppUserUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserUserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    buyerId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    amount = table.Column<decimal>(type: "decimal(18,2)", maxLength: 30, nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.buyerId);
                    table.ForeignKey(
                        name: "FK_Buyer_AppUser",
                        column: x => x.UserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Merchants",
                columns: table => new
                {
                    shopId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MerchantName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    amount = table.Column<decimal>(type: "decimal(18,2)", maxLength: 30, nullable: true),
                    accessKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    serectKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NotifyUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReturnUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchants", x => x.shopId);
                    table.ForeignKey(
                        name: "FK_Merchant_AppUser",
                        column: x => x.UserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OderRequests",
                columns: table => new
                {
                    transId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", maxLength: 30, nullable: false),
                    shopId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    oderInfo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    responseTime = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    signature = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OderRequests", x => x.transId);
                    table.ForeignKey(
                        name: "FK_OderRequest_Merchant",
                        column: x => x.shopId,
                        principalTable: "Merchants",
                        principalColumn: "shopId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConfirmOderRequests",
                columns: table => new
                {
                    corId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    statusCode = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    payUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    signature = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmOderRequests", x => x.corId);
                    table.ForeignKey(
                        name: "FK_ConfirmOderRequest_OderRequest",
                        column: x => x.transId,
                        principalTable: "OderRequests",
                        principalColumn: "transId");
                });

            migrationBuilder.CreateTable(
                name: "OrderPaymentReceipts",
                columns: table => new
                {
                    oprId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    amount = table.Column<decimal>(type: "decimal(18,2)", maxLength: 30, nullable: true),
                    statusCode = table.Column<int>(type: "int", maxLength: 10, nullable: true),
                    responseTime = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    signature = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPaymentReceipts", x => x.oprId);
                    table.ForeignKey(
                        name: "FK_OrderPaymentReceipt_OderRequest",
                        column: x => x.transId,
                        principalTable: "OderRequests",
                        principalColumn: "transId");
                });

            migrationBuilder.CreateTable(
                name: "PaymentRequests",
                columns: table => new
                {
                    paymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    amount = table.Column<decimal>(type: "decimal(18,2)", maxLength: 30, nullable: true),
                    buyerId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    responseTime = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    signature = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRequests", x => x.paymentId);
                    table.ForeignKey(
                        name: "FK_PaymentRequest_Buyer",
                        column: x => x.buyerId,
                        principalTable: "Buyers",
                        principalColumn: "buyerId");
                    table.ForeignKey(
                        name: "FK_PaymentRequest_OderRequest",
                        column: x => x.transId,
                        principalTable: "OderRequests",
                        principalColumn: "transId");
                });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("1083fdbe-1f26-4aa6-bddc-d06fa6bc523e"), "2f703c7c-8ac2-477a-b844-4220cc452ff2", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "FristName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("ba9a22f7-4843-4638-8b9b-ba3241973892"), 0, "98e3564d-358a-419f-bcb4-07b7210fb0ce", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "some-admin-email@nonce.fake", true, "Administrator", "Role", false, null, "some-admin-email@nonce.fake", "admin", "AQAAAAEAACcQAAAAELfBK3tBC/urzTDNnPCfueu3PJaI+TnFysjsfMlciWekrut9vhD7jhiH+DlPEWBnAw==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("1083fdbe-1f26-4aa6-bddc-d06fa6bc523e"), new Guid("ba9a22f7-4843-4638-8b9b-ba3241973892") });

            migrationBuilder.InsertData(
                table: "Buyers",
                columns: new[] { "buyerId", "amount", "Password", "UserId", "Username" },
                values: new object[,]
                {
                    { "buyer001", 0m, "admin", new Guid("ba9a22f7-4843-4638-8b9b-ba3241973892"), "admin" },
                    { "default", 0m, "default", new Guid("ba9a22f7-4843-4638-8b9b-ba3241973892"), "default" }
                });

            migrationBuilder.InsertData(
                table: "Merchants",
                columns: new[] { "shopId", "accessKey", "Address", "amount", "MerchantName", "NotifyUrl", "ReturnUrl", "serectKey", "UserId" },
                values: new object[] { "admin", "xUHfoPq35RGAHSJvuNc4AfR3YJ6RsTHG", "", 0m, "admin", "https://localhost:7299/Pay/NotifyURL", "https://localhost:7299/Pay/ReturnURL", "xUHfoPq35RGAHSJvuNc4AfR3YJ6RsTHG", new Guid("ba9a22f7-4843-4638-8b9b-ba3241973892") });

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_UserId",
                table: "Buyers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmOderRequests_transId",
                table: "ConfirmOderRequests",
                column: "transId",
                unique: true,
                filter: "[transId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_UserId",
                table: "Merchants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OderRequests_shopId",
                table: "OderRequests",
                column: "shopId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPaymentReceipts_transId",
                table: "OrderPaymentReceipts",
                column: "transId",
                unique: true,
                filter: "[transId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRequests_buyerId",
                table: "PaymentRequests",
                column: "buyerId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRequests_transId",
                table: "PaymentRequests",
                column: "transId",
                unique: true,
                filter: "[transId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRole");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoleClaims");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserUserTokens");

            migrationBuilder.DropTable(
                name: "ConfirmOderRequests");

            migrationBuilder.DropTable(
                name: "OrderPaymentReceipts");

            migrationBuilder.DropTable(
                name: "PaymentRequests");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "OderRequests");

            migrationBuilder.DropTable(
                name: "Merchants");

            migrationBuilder.DropTable(
                name: "AppUser");
        }
    }
}
