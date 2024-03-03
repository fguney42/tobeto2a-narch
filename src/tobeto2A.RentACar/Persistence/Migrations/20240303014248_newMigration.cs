using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class newMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("02027986-80ac-4571-a373-e4bda953e264"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("feed57df-1b85-4c4d-86f9-0d92f1ee437b"));

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "CarState",
                table: "Cars",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("6fe74fe6-f8b4-4f1b-a014-020aa20dd011"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 170, 162, 32, 20, 198, 222, 67, 41, 222, 195, 213, 245, 18, 77, 219, 68, 81, 113, 40, 97, 228, 191, 48, 154, 118, 128, 220, 130, 49, 77, 55, 46, 168, 253, 191, 79, 112, 126, 55, 223, 49, 186, 63, 144, 190, 87, 112, 81, 159, 219, 201, 254, 12, 84, 201, 169, 80, 254, 65, 6, 4, 16, 82, 46 }, new byte[] { 135, 34, 232, 204, 181, 221, 145, 51, 35, 208, 60, 175, 250, 75, 42, 15, 25, 57, 88, 125, 239, 53, 165, 94, 190, 103, 157, 96, 80, 118, 196, 117, 134, 226, 104, 47, 109, 76, 98, 92, 48, 74, 198, 245, 164, 233, 96, 153, 74, 54, 195, 203, 64, 176, 196, 96, 173, 181, 208, 85, 225, 18, 138, 45, 1, 98, 153, 162, 66, 178, 66, 220, 50, 255, 107, 242, 128, 195, 225, 1, 187, 204, 78, 45, 253, 138, 191, 206, 253, 210, 137, 49, 104, 185, 19, 9, 122, 89, 42, 78, 19, 94, 194, 5, 40, 228, 237, 157, 224, 232, 20, 228, 246, 171, 198, 97, 92, 189, 115, 6, 87, 30, 80, 163, 114, 74, 236, 105 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d3c575d0-692a-4ac6-bdf7-2bb88017363a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("6fe74fe6-f8b4-4f1b-a014-020aa20dd011") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d3c575d0-692a-4ac6-bdf7-2bb88017363a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6fe74fe6-f8b4-4f1b-a014-020aa20dd011"));

            migrationBuilder.AlterColumn<string>(
                name: "CarState",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("feed57df-1b85-4c4d-86f9-0d92f1ee437b"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 108, 204, 229, 223, 81, 88, 178, 178, 89, 192, 121, 141, 220, 165, 175, 220, 210, 24, 101, 245, 27, 148, 83, 57, 201, 223, 227, 12, 218, 60, 250, 16, 102, 212, 28, 215, 9, 103, 233, 61, 218, 36, 185, 48, 247, 94, 128, 43, 74, 24, 255, 38, 212, 33, 140, 119, 212, 94, 151, 234, 33, 233, 138, 4 }, new byte[] { 227, 182, 181, 103, 130, 19, 63, 140, 79, 148, 139, 202, 35, 48, 185, 184, 16, 99, 221, 48, 4, 37, 114, 246, 125, 146, 191, 251, 121, 137, 122, 245, 175, 19, 6, 163, 35, 183, 121, 171, 158, 62, 148, 118, 241, 91, 30, 68, 160, 244, 48, 186, 127, 111, 170, 205, 214, 85, 55, 92, 52, 25, 9, 220, 140, 51, 130, 221, 73, 184, 150, 209, 228, 219, 115, 56, 43, 15, 9, 147, 200, 234, 234, 176, 232, 226, 102, 81, 43, 62, 156, 25, 231, 225, 119, 11, 79, 171, 169, 204, 43, 136, 168, 168, 76, 223, 124, 97, 6, 141, 165, 34, 215, 52, 94, 168, 191, 203, 170, 254, 160, 91, 121, 53, 213, 173, 58, 84 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("02027986-80ac-4571-a373-e4bda953e264"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("feed57df-1b85-4c4d-86f9-0d92f1ee437b") });
        }
    }
}
