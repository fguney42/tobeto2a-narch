using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d3c575d0-692a-4ac6-bdf7-2bb88017363a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6fe74fe6-f8b4-4f1b-a014-020aa20dd011"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CorporateCustomers",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "CorporateCustomers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("c4272b74-6c63-48ab-8781-4a3efe35caa5"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 68, 193, 104, 158, 221, 8, 172, 7, 159, 179, 93, 65, 41, 9, 195, 14, 54, 124, 124, 61, 72, 238, 221, 33, 183, 101, 224, 7, 36, 20, 237, 61, 167, 170, 125, 165, 120, 76, 19, 149, 134, 24, 36, 24, 149, 246, 132, 66, 89, 39, 185, 101, 227, 238, 114, 86, 29, 68, 5, 169, 235, 18, 13, 186 }, new byte[] { 21, 211, 29, 242, 7, 101, 204, 12, 173, 126, 55, 184, 191, 172, 39, 213, 68, 235, 247, 253, 187, 203, 66, 145, 135, 159, 29, 207, 163, 190, 128, 39, 20, 180, 35, 152, 8, 227, 254, 126, 43, 174, 252, 219, 177, 13, 86, 111, 197, 253, 53, 126, 42, 10, 213, 199, 216, 22, 192, 132, 53, 207, 113, 89, 89, 101, 177, 63, 245, 18, 86, 105, 222, 226, 186, 208, 162, 6, 45, 109, 229, 33, 5, 22, 8, 93, 175, 245, 25, 89, 17, 154, 22, 15, 13, 69, 195, 103, 203, 142, 61, 18, 238, 93, 173, 24, 114, 42, 46, 91, 189, 106, 200, 176, 72, 221, 120, 118, 231, 176, 249, 254, 38, 208, 62, 1, 165, 73 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("e583266a-6fc9-4ab2-b737-aa710307c4c7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("c4272b74-6c63-48ab-8781-4a3efe35caa5") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e583266a-6fc9-4ab2-b737-aa710307c4c7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c4272b74-6c63-48ab-8781-4a3efe35caa5"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "CorporateCustomers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "CorporateCustomers",
                newName: "Name");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("6fe74fe6-f8b4-4f1b-a014-020aa20dd011"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 170, 162, 32, 20, 198, 222, 67, 41, 222, 195, 213, 245, 18, 77, 219, 68, 81, 113, 40, 97, 228, 191, 48, 154, 118, 128, 220, 130, 49, 77, 55, 46, 168, 253, 191, 79, 112, 126, 55, 223, 49, 186, 63, 144, 190, 87, 112, 81, 159, 219, 201, 254, 12, 84, 201, 169, 80, 254, 65, 6, 4, 16, 82, 46 }, new byte[] { 135, 34, 232, 204, 181, 221, 145, 51, 35, 208, 60, 175, 250, 75, 42, 15, 25, 57, 88, 125, 239, 53, 165, 94, 190, 103, 157, 96, 80, 118, 196, 117, 134, 226, 104, 47, 109, 76, 98, 92, 48, 74, 198, 245, 164, 233, 96, 153, 74, 54, 195, 203, 64, 176, 196, 96, 173, 181, 208, 85, 225, 18, 138, 45, 1, 98, 153, 162, 66, 178, 66, 220, 50, 255, 107, 242, 128, 195, 225, 1, 187, 204, 78, 45, 253, 138, 191, 206, 253, 210, 137, 49, 104, 185, 19, 9, 122, 89, 42, 78, 19, 94, 194, 5, 40, 228, 237, 157, 224, 232, 20, 228, 246, 171, 198, 97, 92, 189, 115, 6, 87, 30, 80, 163, 114, 74, 236, 105 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d3c575d0-692a-4ac6-bdf7-2bb88017363a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("6fe74fe6-f8b4-4f1b-a014-020aa20dd011") });
        }
    }
}
