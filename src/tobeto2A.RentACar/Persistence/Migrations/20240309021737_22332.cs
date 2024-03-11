using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _22332 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("4dc18f35-8202-463e-9c53-a49a8d22405b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62a8eaf6-4079-4227-a623-7afebaa4a8fe"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("0426f303-146d-4e1f-8311-3bb09b85ac75"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 183, 87, 189, 167, 75, 248, 232, 90, 89, 45, 214, 33, 76, 78, 96, 152, 165, 191, 239, 129, 53, 7, 66, 24, 43, 156, 180, 44, 149, 143, 150, 200, 247, 240, 65, 91, 167, 187, 17, 95, 127, 120, 26, 128, 28, 84, 39, 110, 65, 195, 254, 205, 96, 187, 66, 213, 226, 133, 67, 58, 138, 208, 150, 48 }, new byte[] { 137, 152, 209, 91, 157, 6, 43, 241, 71, 71, 157, 122, 185, 96, 148, 69, 240, 36, 174, 102, 120, 229, 33, 77, 0, 34, 68, 16, 209, 88, 250, 9, 48, 141, 230, 206, 10, 230, 95, 120, 75, 245, 73, 101, 4, 80, 174, 247, 139, 24, 132, 76, 222, 109, 18, 223, 157, 154, 251, 43, 17, 46, 200, 16, 60, 27, 85, 28, 131, 75, 241, 246, 216, 44, 34, 63, 17, 91, 205, 232, 28, 81, 57, 210, 85, 77, 106, 234, 64, 93, 190, 72, 126, 174, 52, 18, 205, 159, 83, 86, 208, 71, 114, 68, 189, 146, 230, 148, 169, 196, 27, 233, 55, 79, 78, 17, 107, 141, 17, 108, 43, 67, 234, 139, 75, 73, 70, 173 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("77eeeec2-4e87-4bd5-9c0c-50797b1aba15"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("0426f303-146d-4e1f-8311-3bb09b85ac75") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("77eeeec2-4e87-4bd5-9c0c-50797b1aba15"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0426f303-146d-4e1f-8311-3bb09b85ac75"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("62a8eaf6-4079-4227-a623-7afebaa4a8fe"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 235, 37, 167, 49, 70, 229, 214, 198, 252, 95, 232, 72, 81, 53, 132, 19, 12, 252, 14, 194, 62, 151, 179, 129, 223, 18, 250, 239, 61, 153, 214, 156, 148, 200, 222, 2, 182, 163, 215, 47, 138, 250, 144, 218, 111, 116, 54, 185, 177, 149, 16, 255, 40, 218, 9, 138, 176, 29, 14, 147, 117, 110, 80, 199 }, new byte[] { 35, 149, 132, 177, 220, 248, 238, 62, 190, 112, 226, 51, 104, 162, 106, 48, 75, 238, 117, 207, 56, 33, 3, 134, 3, 239, 14, 177, 100, 154, 213, 119, 51, 222, 249, 26, 27, 193, 85, 141, 55, 105, 2, 243, 100, 180, 31, 50, 147, 51, 173, 171, 184, 229, 242, 241, 113, 79, 86, 158, 139, 183, 16, 170, 49, 238, 238, 69, 28, 12, 151, 63, 244, 147, 125, 147, 220, 110, 9, 240, 25, 123, 124, 56, 89, 1, 75, 102, 36, 81, 104, 13, 12, 207, 78, 188, 247, 129, 230, 137, 125, 46, 241, 97, 209, 49, 229, 94, 15, 44, 200, 44, 52, 27, 63, 185, 39, 237, 172, 248, 193, 107, 12, 16, 219, 208, 195, 27 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("4dc18f35-8202-463e-9c53-a49a8d22405b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("62a8eaf6-4079-4227-a623-7afebaa4a8fe") });
        }
    }
}
