using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class ComplaintController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComplaintController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Complaints.ToListAsync());
        }
       
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Complaint());
            else
                return View(_context.Complaints.Find(id));
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,OrderId,ProductId,Description,Reason")] Complaint complaint)
        {
            if (ModelState.IsValid)
            {
                if (complaint.Id == 0)
                    _context.Add(complaint);
                else
                    _context.Update(complaint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(complaint);
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            var complaint = await _context.Complaints.FindAsync(id);
            _context.Complaints.Remove(complaint);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
