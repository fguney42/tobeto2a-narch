using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("066b1a80-092c-41ef-a69b-a589a1712d8d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0dfbea2d-4703-4751-b1d9-8e00076d977c"));

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    CarState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kilometer = table.Column<int>(type: "int", nullable: false),
                    ModelYear = table.Column<short>(type: "smallint", nullable: false),
                    Plate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CorporateCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fuels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndividualCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NationalIdentity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transmission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    FuelId = table.Column<int>(type: "int", nullable: false),
                    TransmissionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<short>(type: "smallint", nullable: false),
                    DailyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BrandId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FuelId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TransmissionId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandId1",
                        column: x => x.BrandId1,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Models_Fuels_FuelId1",
                        column: x => x.FuelId1,
                        principalTable: "Fuels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Models_Transmission_TransmissionId1",
                        column: x => x.TransmissionId1,
                        principalTable: "Transmission",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("3c0a36d5-f70c-486f-88c3-4a271671478a"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 8, 19, 233, 124, 33, 87, 49, 232, 40, 171, 28, 34, 56, 27, 92, 208, 238, 173, 51, 53, 169, 221, 21, 249, 112, 105, 140, 146, 152, 233, 36, 29, 40, 95, 174, 63, 119, 7, 138, 48, 100, 167, 9, 6, 84, 66, 188, 142, 90, 196, 244, 34, 132, 95, 241, 254, 12, 179, 137, 222, 196, 61, 137, 121 }, new byte[] { 109, 4, 243, 35, 6, 70, 123, 118, 30, 90, 29, 220, 61, 11, 191, 113, 211, 163, 158, 81, 15, 170, 204, 195, 4, 113, 224, 168, 54, 3, 204, 179, 223, 105, 176, 112, 237, 144, 216, 136, 85, 84, 137, 2, 200, 251, 157, 4, 197, 121, 254, 31, 194, 18, 95, 101, 214, 11, 179, 157, 5, 86, 173, 223, 43, 243, 54, 25, 115, 55, 54, 99, 253, 95, 182, 115, 42, 252, 210, 162, 255, 230, 9, 178, 159, 229, 159, 239, 43, 217, 203, 195, 96, 159, 78, 183, 250, 148, 105, 223, 78, 193, 192, 217, 169, 2, 40, 255, 51, 107, 177, 53, 197, 193, 75, 200, 42, 9, 203, 227, 71, 111, 144, 3, 104, 197, 57, 8 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("9e568875-90c9-43a2-aed4-5db40241e0f1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("3c0a36d5-f70c-486f-88c3-4a271671478a") });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId1",
                table: "Customers",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId1",
                table: "Models",
                column: "BrandId1");

            migrationBuilder.CreateIndex(
                name: "IX_Models_FuelId1",
                table: "Models",
                column: "FuelId1");

            migrationBuilder.CreateIndex(
                name: "IX_Models_TransmissionId1",
                table: "Models",
                column: "TransmissionId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "CorporateCustomers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "IndividualCustomers");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Fuels");

            migrationBuilder.DropTable(
                name: "Transmission");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("9e568875-90c9-43a2-aed4-5db40241e0f1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3c0a36d5-f70c-486f-88c3-4a271671478a"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("0dfbea2d-4703-4751-b1d9-8e00076d977c"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 91, 95, 201, 107, 171, 236, 194, 153, 147, 193, 56, 238, 39, 58, 210, 111, 8, 40, 125, 15, 148, 127, 64, 113, 194, 59, 166, 85, 147, 121, 83, 233, 217, 132, 14, 38, 116, 148, 254, 201, 195, 13, 208, 38, 86, 101, 121, 169, 122, 175, 141, 101, 116, 219, 196, 252, 117, 208, 23, 107, 185, 38, 10, 229 }, new byte[] { 202, 210, 154, 6, 133, 181, 176, 141, 236, 195, 124, 181, 234, 66, 101, 8, 103, 195, 187, 120, 54, 49, 1, 85, 173, 71, 194, 117, 27, 80, 164, 140, 135, 122, 31, 162, 197, 188, 201, 81, 125, 100, 10, 149, 216, 67, 133, 67, 81, 198, 55, 38, 98, 16, 136, 108, 153, 49, 97, 125, 31, 159, 113, 156, 4, 213, 61, 183, 235, 48, 249, 159, 88, 87, 137, 219, 62, 239, 207, 33, 93, 48, 240, 39, 80, 221, 24, 198, 19, 105, 139, 186, 223, 25, 30, 151, 78, 11, 229, 38, 15, 46, 105, 4, 218, 44, 23, 146, 40, 110, 127, 113, 66, 213, 117, 19, 190, 180, 210, 79, 106, 233, 137, 245, 214, 133, 191, 163 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("066b1a80-092c-41ef-a69b-a589a1712d8d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("0dfbea2d-4703-4751-b1d9-8e00076d977c") });
        }
    }
}
