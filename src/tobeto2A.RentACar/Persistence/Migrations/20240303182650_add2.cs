using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e583266a-6fc9-4ab2-b737-aa710307c4c7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c4272b74-6c63-48ab-8781-4a3efe35caa5"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "IndividualCustomers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "IndividualCustomers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "IndividualCustomers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "IndividualCustomers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CorporateCustomerId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IndividualCustomerId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CorporateCustomers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "CorporateCustomers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CorporateCustomers_CorporateCustomerId",
                table: "Customers",
                column: "CorporateCustomerId",
                principalTable: "CorporateCustomers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_IndividualCustomers_IndividualCustomerId",
                table: "Customers",
                column: "IndividualCustomerId",
                principalTable: "IndividualCustomers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CorporateCustomers_CorporateCustomerId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_IndividualCustomers_IndividualCustomerId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CorporateCustomerId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_IndividualCustomerId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("3a9ba402-91d9-445e-9f58-24a65de77d56"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3b086d54-2b70-4171-b5d8-b7430a48ab62"));

            migrationBuilder.DropColumn(
                name: "Email",
                table: "IndividualCustomers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "IndividualCustomers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "IndividualCustomers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "IndividualCustomers");

            migrationBuilder.DropColumn(
                name: "CorporateCustomerId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IndividualCustomerId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "CorporateCustomers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "CorporateCustomers");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("c4272b74-6c63-48ab-8781-4a3efe35caa5"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 68, 193, 104, 158, 221, 8, 172, 7, 159, 179, 93, 65, 41, 9, 195, 14, 54, 124, 124, 61, 72, 238, 221, 33, 183, 101, 224, 7, 36, 20, 237, 61, 167, 170, 125, 165, 120, 76, 19, 149, 134, 24, 36, 24, 149, 246, 132, 66, 89, 39, 185, 101, 227, 238, 114, 86, 29, 68, 5, 169, 235, 18, 13, 186 }, new byte[] { 21, 211, 29, 242, 7, 101, 204, 12, 173, 126, 55, 184, 191, 172, 39, 213, 68, 235, 247, 253, 187, 203, 66, 145, 135, 159, 29, 207, 163, 190, 128, 39, 20, 180, 35, 152, 8, 227, 254, 126, 43, 174, 252, 219, 177, 13, 86, 111, 197, 253, 53, 126, 42, 10, 213, 199, 216, 22, 192, 132, 53, 207, 113, 89, 89, 101, 177, 63, 245, 18, 86, 105, 222, 226, 186, 208, 162, 6, 45, 109, 229, 33, 5, 22, 8, 93, 175, 245, 25, 89, 17, 154, 22, 15, 13, 69, 195, 103, 203, 142, 61, 18, 238, 93, 173, 24, 114, 42, 46, 91, 189, 106, 200, 176, 72, 221, 120, 118, 231, 176, 249, 254, 38, 208, 62, 1, 165, 73 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("e583266a-6fc9-4ab2-b737-aa710307c4c7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("c4272b74-6c63-48ab-8781-4a3efe35caa5") });
        }
    }
}
