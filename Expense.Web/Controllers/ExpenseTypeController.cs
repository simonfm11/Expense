using Expense.Web.Data;
using Expense.Web.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Expense.Web.Controllers
{
   // [Authorize(Roles = "Admin")]
    public class ExpenseTypeController : Controller
    {
        private readonly DataContext _context;

        public ExpenseTypeController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ExpenseTypes.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ExpenseTypeEntity expenseTypeEntity = await _context.ExpenseTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenseTypeEntity == null)
            {
                return NotFound();
            }

            return View(expenseTypeEntity);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Expense")] ExpenseTypeEntity expenseTypeEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expenseTypeEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expenseTypeEntity);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ExpenseTypeEntity expenseTypeEntity = await _context.ExpenseTypes.FindAsync(id);
            if (expenseTypeEntity == null)
            {
                return NotFound();
            }
            return View(expenseTypeEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Expense")] ExpenseTypeEntity expenseTypeEntity)
        {
            if (id != expenseTypeEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expenseTypeEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseTypeEntityExists(expenseTypeEntity.Id))
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
            return View(expenseTypeEntity);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ExpenseTypeEntity expenseTypeEntity = await _context.ExpenseTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenseTypeEntity == null)
            {
                return NotFound();
            }

            return View(expenseTypeEntity);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ExpenseTypeEntity expenseTypeEntity = await _context.ExpenseTypes.FindAsync(id);
            _context.ExpenseTypes.Remove(expenseTypeEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseTypeEntityExists(int id)
        {
            return _context.ExpenseTypes.Any(e => e.Id == id);
        }
    }
}
