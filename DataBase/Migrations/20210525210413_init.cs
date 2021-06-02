using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirsName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirsName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Salary = table.Column<int>(type: "int", maxLength: 6, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sum = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    PerfomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Client_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Employee_PerfomerId",
                        column: x => x.PerfomerId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "CompanyName" },
                values: new object[] { 1, "Microsoft" });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "CompanyName" },
                values: new object[] { 2, "Apple" });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "Id", "CompanyId", "FirsName", "LastName" },
                values: new object[,]
                {
                    { 1, 1, "Jorik", "Vartatov" },
                    { 2, 1, "Pupa", "Lupa" },
                    { 3, 1, "Donald", "Trump" },
                    { 6, 2, "Justin", "Bieber" },
                    { 5, 2, "John", "Wick" },
                    { 4, 2, "Hot", "Dog" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "CompanyId", "FirsName", "LastName", "Position", "Salary" },
                values: new object[,]
                {
                    { 10, 2, "Tony", "Stark", "Team Lead", 666665 },
                    { 9, 2, "Clark", "Kent", "Superman", 17500 },
                    { 8, 2, "Bruce", "Wayne", "Brand manager", 640000 },
                    { 7, 2, "Peter", "Parker", "Photographer", 76000 },
                    { 6, 1, "Vladimir", "Putin", "President", 666666 },
                    { 5, 1, "Ulrikh", "Petrel", "Senior java", 310000 },
                    { 4, 1, "Artemi", "Lebedev", "Designer", 250000 },
                    { 3, 1, "Geralt", "Vedmak", "Middle C#", 130000 },
                    { 2, 1, "Alex", "Chpokin", "junior java", 47000 },
                    { 1, 1, "Vasiliy", "Pupkin", "junior C#", 45000 },
                    { 11, 2, "John", "Connor", "Machine Learning Engineer", 284600 },
                    { 12, 2, "Vladimir", "Zelensky", "President", 666666 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_CompanyId",
                table: "Client",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CompanyId",
                table: "Employee",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PerfomerId",
                table: "Order",
                column: "PerfomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
