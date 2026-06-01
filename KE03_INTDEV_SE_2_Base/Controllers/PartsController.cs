
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;
using DataAccessLayer;

public class PartsController : Controller
{
    private readonly MatrixIncDbContext _context;

    public PartsController(MatrixIncDbContext context)
    {
        _context = context;
    }

    // GET: PARTS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Parts.ToListAsync());
    }

    // GET: PARTS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var part = await _context.Parts
            .FirstOrDefaultAsync(m => m.Id == id);
        if (part == null)
        {
            return NotFound();
        }

        return View(part);
    }

    // GET: PARTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PARTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Description,Products")] Part part)
    {
        if (ModelState.IsValid)
        {
            _context.Add(part);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(part);
    }

    // GET: PARTS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var part = await _context.Parts.FindAsync(id);
        if (part == null)
        {
            return NotFound();
        }
        return View(part);
    }

    // POST: PARTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Description,Products")] Part part)
    {
        if (id != part.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(part);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartExists(part.Id))
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
        return View(part);
    }

    // GET: PARTS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var part = await _context.Parts
            .FirstOrDefaultAsync(m => m.Id == id);
        if (part == null)
        {
            return NotFound();
        }

        return View(part);
    }

    // POST: PARTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var part = await _context.Parts.FindAsync(id);
        if (part != null)
        {
            _context.Parts.Remove(part);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PartExists(int? id)
    {
        return _context.Parts.Any(e => e.Id == id);
    }
}
