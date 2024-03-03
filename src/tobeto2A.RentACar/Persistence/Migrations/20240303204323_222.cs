using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _222 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("3a9ba402-91d9-445e-9f58-24a65de77d56"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3b086d54-2b70-4171-b5d8-b7430a48ab62"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("5edad709-234e-47d1-9a5b-aa812a6ee564"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 54, 218, 190, 29, 51, 168, 233, 72, 143, 89, 18, 117, 35, 206, 124, 155, 71, 158, 143, 179, 150, 181, 32, 29, 228, 43, 111, 0, 81, 195, 206, 30, 115, 8, 233, 232, 255, 126, 53, 42, 86, 107, 249, 5, 127, 252, 163, 97, 144, 25, 133, 59, 243, 26, 226, 176, 102, 32, 109, 197, 7, 121, 177, 113 }, new byte[] { 49, 238, 216, 23, 234, 64, 176, 30, 246, 196, 154, 232, 25, 97, 47, 77, 144, 239, 59, 214, 96, 108, 18, 4, 231, 178, 162, 84, 240, 98, 164, 156, 33, 217, 85, 106, 172, 89, 101, 128, 9, 55, 58, 103, 52, 132, 229, 52, 152, 253, 100, 155, 124, 54, 3, 101, 236, 73, 62, 251, 150, 205, 178, 88, 97, 114, 120, 101, 109, 96, 170, 178, 240, 111, 205, 236, 109, 124, 146, 224, 116, 254, 165, 140, 131, 141, 206, 133, 147, 39, 108, 17, 160, 160, 115, 208, 91, 194, 61, 127, 137, 28, 87, 158, 191, 114, 209, 16, 49, 101, 2, 169, 180, 145, 79, 189, 172, 195, 9, 216, 109, 106, 185, 78, 113, 220, 9, 8 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("6de2881e-ff22-44cc-9623-f00b7fe3218c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("5edad709-234e-47d1-9a5b-aa812a6ee564") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("6de2881e-ff22-44cc-9623-f00b7fe3218c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5edad709-234e-47d1-9a5b-aa812a6ee564"));

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorporateCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndividualCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_CorporateCustomers_CorporateCustomerId",
                        column: x => x.CorporateCustomerId,
                        principalTable: "CorporateCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_IndividualCustomers_IndividualCustomerId",
                        column: x => x.IndividualCustomerId,
                        principalTable: "IndividualCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("3b086d54-2b70-4171-b5d8-b7430a48ab62"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 28, 111, 13, 81, 225, 110, 54, 212, 5, 55, 196, 231, 184, 102, 194, 10, 9, 33, 147, 48, 185, 166, 246, 44, 167, 39, 173, 54, 239, 67, 80, 246, 149, 185, 221, 35, 5, 130, 25, 214, 111, 238, 65, 226, 160, 67, 222, 52, 9, 132, 252, 108, 204, 223, 53, 73, 246, 241, 100, 111, 45, 212, 170, 139 }, new byte[] { 225, 167, 226, 222, 48, 166, 247, 84, 167, 18, 122, 181, 35, 236, 251, 80, 169, 79, 12, 30, 131, 230, 188, 98, 228, 181, 232, 111, 173, 34, 206, 74, 124, 78, 144, 0, 92, 250, 144, 127, 215, 181, 65, 35, 152, 220, 69, 15, 107, 17, 2, 162, 237, 99, 84, 210, 106, 247, 68, 130, 23, 90, 206, 151, 29, 80, 104, 161, 223, 175, 165, 26, 80, 236, 104, 26, 52, 118, 10, 254, 87, 39, 140, 136, 47, 130, 29, 143, 2, 90, 58, 112, 220, 246, 76, 228, 49, 207, 110, 26, 23, 233, 189, 130, 202, 240, 137, 180, 49, 80, 43, 131, 172, 101, 26, 93, 204, 107, 161, 2, 51, 119, 176, 135, 242, 93, 242, 250 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("3a9ba402-91d9-445e-9f58-24a65de77d56"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("3b086d54-2b70-4171-b5d8-b7430a48ab62") });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CorporateCustomerId",
                table: "Customers",
                column: "CorporateCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IndividualCustomerId",
                table: "Customers",
                column: "IndividualCustomerId");
        }
    }
}
