using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using kt1.Models;

namespace kt1.Controllers
{
    public class CtHoaDonsController : Controller
    {
        private readonly AppDbConntext _context;

        public CtHoaDonsController(AppDbConntext context)
        {
            _context = context;
        }

        // GET: CtHoaDons
        public async Task<IActionResult> Index()
        {
            var appDbConntext = _context.CtHoaDons.Include(c => c.HoaDon).Include(c => c.SanPham);
            return View(await appDbConntext.ToListAsync());
        }

        // GET: CtHoaDons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctHoaDon = await _context.CtHoaDons
                .Include(c => c.HoaDon)
                .Include(c => c.SanPham)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ctHoaDon == null)
            {
                return NotFound();
            }

            return View(ctHoaDon);
        }

        // GET: CtHoaDons/Create
        public IActionResult Create()
        {
            ViewData["HoaDonID"] = new SelectList(_context.HoaDons, "ID", "ID");
            ViewData["SanPhamID"] = new SelectList(_context.SanPhams, "ID", "TenSanPham");
            return View();
        }

        // POST: CtHoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,HoaDonID,SanPhamID,SoLuongMua,DonGiaMua,ThanhTien,TrangThai")] CtHoaDon ctHoaDon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ctHoaDon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HoaDonID"] = new SelectList(_context.HoaDons, "ID", "ID", ctHoaDon.HoaDonID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPhams, "ID", "TenSanPham", ctHoaDon.SanPhamID);
            return View(ctHoaDon);
        }

        // GET: CtHoaDons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctHoaDon = await _context.CtHoaDons.FindAsync(id);
            if (ctHoaDon == null)
            {
                return NotFound();
            }
            ViewData["HoaDonID"] = new SelectList(_context.HoaDons, "ID", "ID", ctHoaDon.HoaDonID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPhams, "ID", "TenSanPham", ctHoaDon.SanPhamID);
            return View(ctHoaDon);
        }

        // POST: CtHoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,HoaDonID,SanPhamID,SoLuongMua,DonGiaMua,ThanhTien,TrangThai")] CtHoaDon ctHoaDon)
        {
            if (id != ctHoaDon.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ctHoaDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CtHoaDonExists(ctHoaDon.ID))
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
            ViewData["HoaDonID"] = new SelectList(_context.HoaDons, "ID", "ID", ctHoaDon.HoaDonID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPhams, "ID", "TenSanPham", ctHoaDon.SanPhamID);
            return View(ctHoaDon);
        }

        // GET: CtHoaDons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctHoaDon = await _context.CtHoaDons
                .Include(c => c.HoaDon)
                .Include(c => c.SanPham)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ctHoaDon == null)
            {
                return NotFound();
            }

            return View(ctHoaDon);
        }

        // POST: CtHoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ctHoaDon = await _context.CtHoaDons.FindAsync(id);
            if (ctHoaDon != null)
            {
                _context.CtHoaDons.Remove(ctHoaDon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CtHoaDonExists(int id)
        {
            return _context.CtHoaDons.Any(e => e.ID == id);
        }
    }
}
