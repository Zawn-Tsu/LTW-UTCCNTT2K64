using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Day09CF.Models;

namespace Day09CF.Controllers
{
    public class nvtSan_PhamController : Controller
    {
        private readonly Day09CFContext _context;

        public nvtSan_PhamController(Day09CFContext context)
        {
            _context = context;
        }

        // GET: nvtSan_Pham
        public async Task<IActionResult> Index()
        {
            var list = await _context.nvtSan_Phams
                .Include(x => x.nvtLoai_SanPham) // để hiển thị luôn tên loại
                .ToListAsync();
            return View(list);
        }

        // GET: nvtSan_Pham/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
                return NotFound();

            var nvtSan_Pham = await _context.nvtSan_Phams
                .Include(x => x.nvtLoai_SanPham)
                .FirstOrDefaultAsync(m => m.nvtId == id);

            if (nvtSan_Pham == null)
                return NotFound();

            return View(nvtSan_Pham);
        }

        // GET: nvtSan_Pham/Create
        public IActionResult Create()
        {
            ViewData["nvtLoaiSanPhamId"] = new SelectList(
                _context.nvtLoai_SanPhams,
                "nvtId",
                "nvtTenLoai"
            );
            return View();
        }

        // POST: nvtSan_Pham/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nvtId,nvtMaSanPham,nvtTenSanPham,nvtHinhAnh,nvtSoLuong,nvtDonGia,nvtLoaiSanPhamId")] nvtSan_Pham nvtSan_Pham)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("❌ ModelState invalid:");
                foreach (var kvp in ModelState)
                {
                    foreach (var error in kvp.Value.Errors)
                    {
                        Console.WriteLine($"❌ {kvp.Key}: {error.ErrorMessage}");
                    }
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(nvtSan_Pham);
                await _context.SaveChangesAsync();
                Console.WriteLine("✅ Đã thêm sản phẩm thành công!");
                return RedirectToAction(nameof(Index));
            }

            ViewData["nvtLoaiSanPhamId"] = new SelectList(
                _context.nvtLoai_SanPhams,
                "nvtId",
                "nvtTenLoai",
                nvtSan_Pham.nvtLoaiSanPhamId
            );
            return View(nvtSan_Pham);
        }


        // GET: nvtSan_Pham/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
                return NotFound();

            var nvtSan_Pham = await _context.nvtSan_Phams.FindAsync(id);
            if (nvtSan_Pham == null)
                return NotFound();

            ViewData["nvtLoaiSanPhamId"] = new SelectList(
                _context.nvtLoai_SanPhams,
                "nvtId",
                "nvtTenLoai",
                nvtSan_Pham.nvtLoaiSanPhamId
            );

            return View(nvtSan_Pham);
        }

        // POST: nvtSan_Pham/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("nvtId,nvtMaSanPham,nvtTenSanPham,nvtHinhAnh,nvtSoLuong,nvtDonGia,nvtLoaiSanPhamId")] nvtSan_Pham nvtSan_Pham)
        {
            if (id != nvtSan_Pham.nvtId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nvtSan_Pham);
                    await _context.SaveChangesAsync();
                    Console.WriteLine("✅ Cập nhật sản phẩm thành công!");
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!nvtSan_PhamExists(nvtSan_Pham.nvtId))
                        return NotFound();
                    else
                        throw;
                }
            }

            ViewData["nvtLoaiSanPhamId"] = new SelectList(
                _context.nvtLoai_SanPhams,
                "nvtId",
                "nvtTenLoai",
                nvtSan_Pham.nvtLoaiSanPhamId
            );

            return View(nvtSan_Pham);
        }

        // GET: nvtSan_Pham/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
                return NotFound();

            var nvtSan_Pham = await _context.nvtSan_Phams
                .Include(x => x.nvtLoai_SanPham)
                .FirstOrDefaultAsync(m => m.nvtId == id);

            if (nvtSan_Pham == null)
                return NotFound();

            return View(nvtSan_Pham);
        }

        // POST: nvtSan_Pham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var nvtSan_Pham = await _context.nvtSan_Phams.FindAsync(id);
            if (nvtSan_Pham != null)
                _context.nvtSan_Phams.Remove(nvtSan_Pham);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool nvtSan_PhamExists(long id)
        {
            return _context.nvtSan_Phams.Any(e => e.nvtId == id);
        }
    }
}
