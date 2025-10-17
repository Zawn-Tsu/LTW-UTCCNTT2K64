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
            return View(await _context.nvtSan_Phams.ToListAsync());
        }

        // GET: nvtSan_Pham/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nvtSan_Pham = await _context.nvtSan_Phams
                .FirstOrDefaultAsync(m => m.nvtId == id);
            if (nvtSan_Pham == null)
            {
                return NotFound();
            }

            return View(nvtSan_Pham);
        }

        // GET: nvtSan_Pham/Create
        public IActionResult Create()
        {
            ViewData["nvtLoaiSanPhamId"] = new SelectList(_context.nvtLoai_SanPhams, "nvtId", "nvtTenLoai");
            return View();
        }

        // POST: nvtSan_Pham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nvtId,nvtMaSanPham,nvtTenSanPham,nvtHinhAnh,nvtSoLuong,nvtDonGia,nvtLoaiSanPhamId")] nvtSan_Pham nvtSan_Pham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nvtSan_Pham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nvtSan_Pham);
        }

        // GET: nvtSan_Pham/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nvtSan_Pham = await _context.nvtSan_Phams.FindAsync(id);
            if (nvtSan_Pham == null)
            {
                return NotFound();
            }
            ViewData["nvtLoaiSanPhamId"] = new SelectList(_context.nvtLoai_SanPhams, "nvtId", "nvtTenLoai", nvtSan_Pham.nvtLoaiSanPhamId);
            return View(nvtSan_Pham);
        }

        // POST: nvtSan_Pham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("nvtId,nvtMaSanPham,nvtTenSanPham,nvtHinhAnh,nvtSoLuong,nvtDonGia,nvtLoaiSanPhamId")] nvtSan_Pham nvtSan_Pham)
        {
            if (id != nvtSan_Pham.nvtId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                foreach (var err in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine("⚠️ Model Error: " + err.ErrorMessage);
                }
                try
                {
                    _context.Update(nvtSan_Pham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!nvtSan_PhamExists(nvtSan_Pham.nvtId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["nvtLoaiSanPhamId"] = new SelectList(_context.nvtLoai_SanPhams, "nvtId", "nvtTenLoai", nvtSan_Pham.nvtLoaiSanPhamId);
            return View(nvtSan_Pham);
        }

        // GET: nvtSan_Pham/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nvtSan_Pham = await _context.nvtSan_Phams
                .FirstOrDefaultAsync(m => m.nvtId == id);
            if (nvtSan_Pham == null)
            {
                return NotFound();
            }

            return View(nvtSan_Pham);
        }

        // POST: nvtSan_Pham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var nvtSan_Pham = await _context.nvtSan_Phams.FindAsync(id);
            if (nvtSan_Pham != null)
            {
                _context.nvtSan_Phams.Remove(nvtSan_Pham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool nvtSan_PhamExists(long id)
        {
            return _context.nvtSan_Phams.Any(e => e.nvtId == id);
        }
    }
}
