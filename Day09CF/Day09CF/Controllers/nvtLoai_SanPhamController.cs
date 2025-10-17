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
    public class nvtLoai_SanPhamController : Controller
    {
        private readonly Day09CFContext _context;

        public nvtLoai_SanPhamController(Day09CFContext context)
        {
            _context = context;
        }

        // GET: nvtLoai_SanPham
        public async Task<IActionResult> Index()
        {
            return View(await _context.nvtLoai_SanPhams.ToListAsync());
        }

        // GET: nvtLoai_SanPham/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nvtLoai_SanPham = await _context.nvtLoai_SanPhams
                .FirstOrDefaultAsync(m => m.nvtId == id);
            if (nvtLoai_SanPham == null)
            {
                return NotFound();
            }

            return View(nvtLoai_SanPham);
        }

        // GET: nvtLoai_SanPham/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: nvtLoai_SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nvtId,nvtMaLoai,nvtTenLoai,nvtTrangThai")] nvtLoai_SanPham nvtLoai_SanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nvtLoai_SanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nvtLoai_SanPham);
        }

        // GET: nvtLoai_SanPham/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nvtLoai_SanPham = await _context.nvtLoai_SanPhams.FindAsync(id);
            if (nvtLoai_SanPham == null)
            {
                return NotFound();
            }
            return View(nvtLoai_SanPham);
        }

        // POST: nvtLoai_SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("nvtId,nvtMaLoai,nvtTenLoai,nvtTrangThai")] nvtLoai_SanPham nvtLoai_SanPham)
        {
            if (id != nvtLoai_SanPham.nvtId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nvtLoai_SanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!nvtLoai_SanPhamExists(nvtLoai_SanPham.nvtId))
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
            return View(nvtLoai_SanPham);
        }

        // GET: nvtLoai_SanPham/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nvtLoai_SanPham = await _context.nvtLoai_SanPhams
                .FirstOrDefaultAsync(m => m.nvtId == id);
            if (nvtLoai_SanPham == null)
            {
                return NotFound();
            }

            return View(nvtLoai_SanPham);
        }

        // POST: nvtLoai_SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var nvtLoai_SanPham = await _context.nvtLoai_SanPhams.FindAsync(id);
            if (nvtLoai_SanPham != null)
            {
                _context.nvtLoai_SanPhams.Remove(nvtLoai_SanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool nvtLoai_SanPhamExists(long id)
        {
            return _context.nvtLoai_SanPhams.Any(e => e.nvtId == id);
        }
    }
}
