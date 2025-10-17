using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day09CF.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_nvtSan_Pham_nvtLoai_SanPham_nvtLoai_SanPhamnvtId",
                table: "nvtSan_Pham");

            migrationBuilder.DropIndex(
                name: "IX_nvtSan_Pham_nvtLoai_SanPhamnvtId",
                table: "nvtSan_Pham");

            migrationBuilder.DropColumn(
                name: "nvtLoai_SanPhamnvtId",
                table: "nvtSan_Pham");

            migrationBuilder.CreateIndex(
                name: "IX_nvtSan_Pham_nvtLoaiSanPhamId",
                table: "nvtSan_Pham",
                column: "nvtLoaiSanPhamId");

            migrationBuilder.AddForeignKey(
                name: "FK_nvtSan_Pham_nvtLoai_SanPham_nvtLoaiSanPhamId",
                table: "nvtSan_Pham",
                column: "nvtLoaiSanPhamId",
                principalTable: "nvtLoai_SanPham",
                principalColumn: "nvtId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_nvtSan_Pham_nvtLoai_SanPham_nvtLoaiSanPhamId",
                table: "nvtSan_Pham");

            migrationBuilder.DropIndex(
                name: "IX_nvtSan_Pham_nvtLoaiSanPhamId",
                table: "nvtSan_Pham");

            migrationBuilder.AddColumn<long>(
                name: "nvtLoai_SanPhamnvtId",
                table: "nvtSan_Pham",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_nvtSan_Pham_nvtLoai_SanPhamnvtId",
                table: "nvtSan_Pham",
                column: "nvtLoai_SanPhamnvtId");

            migrationBuilder.AddForeignKey(
                name: "FK_nvtSan_Pham_nvtLoai_SanPham_nvtLoai_SanPhamnvtId",
                table: "nvtSan_Pham",
                column: "nvtLoai_SanPhamnvtId",
                principalTable: "nvtLoai_SanPham",
                principalColumn: "nvtId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
