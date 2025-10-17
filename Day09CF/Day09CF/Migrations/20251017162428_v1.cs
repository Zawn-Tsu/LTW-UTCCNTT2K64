using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day09CF.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nvtLoai_SanPham",
                columns: table => new
                {
                    nvtId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nvtMaLoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    nvtTenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nvtTrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nvtLoai_SanPham", x => x.nvtId);
                });

            migrationBuilder.CreateTable(
                name: "nvtSan_Pham",
                columns: table => new
                {
                    nvtId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nvtMaSanPham = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    nvtTenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nvtHinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nvtSoLuong = table.Column<int>(type: "int", nullable: false),
                    nvtDonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    nvtLoaiSanPhamId = table.Column<long>(type: "bigint", nullable: false),
                    nvtLoai_SanPhamnvtId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nvtSan_Pham", x => x.nvtId);
                    table.ForeignKey(
                        name: "FK_nvtSan_Pham_nvtLoai_SanPham_nvtLoai_SanPhamnvtId",
                        column: x => x.nvtLoai_SanPhamnvtId,
                        principalTable: "nvtLoai_SanPham",
                        principalColumn: "nvtId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_nvtLoai_SanPham_nvtMaLoai",
                table: "nvtLoai_SanPham",
                column: "nvtMaLoai",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_nvtSan_Pham_nvtLoai_SanPhamnvtId",
                table: "nvtSan_Pham",
                column: "nvtLoai_SanPhamnvtId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nvtSan_Pham");

            migrationBuilder.DropTable(
                name: "nvtLoai_SanPham");
        }
    }
}
