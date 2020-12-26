namespace GiffyCards.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GiffyCards.Data;
    using GiffyCards.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    [Area("Administration")]
    public class CigarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CigarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administration/Cigars
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cigars.Include(c => c.Brand).Include(c => c.Description).Include(c => c.Question).Include(c => c.Shape).Include(c => c.Size).Include(c => c.Strenght).Include(c => c.Taste);
            return this.View(await applicationDbContext.ToListAsync());
        }

        // GET: Administration/Cigars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var cigar = await _context.Cigars
                .Include(c => c.Brand)
                .Include(c => c.Description)
                .Include(c => c.Question)
                .Include(c => c.Shape)
                .Include(c => c.Size)
                .Include(c => c.Strenght)
                .Include(c => c.Taste)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cigar == null)
            {
                return this.NotFound();
            }

            return this.View(cigar);
        }

        // GET: Administration/Cigars/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id");
            ViewData["DescriptionId"] = new SelectList(_context.Descriptions, "Id", "Id");
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id");
            ViewData["ShapeId"] = new SelectList(_context.Shapes, "Id", "Id");
            ViewData["SizeId"] = new SelectList(_context.Sizes, "Id", "Id");
            ViewData["StrenghtId"] = new SelectList(_context.Strenghts, "Id", "Id");
            ViewData["TasteId"] = new SelectList(_context.Tastes, "Id", "Id");
            return this.View();
        }

        // POST: Administration/Cigars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrandId,CigarName,StrenghtId,TasteId,SizeId,QuestionId,Bland,DescriptionId,ShapeId,PricePerUnit,ImageUrl,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Cigar cigar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cigar);
                await _context.SaveChangesAsync();
                return this.RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id", cigar.BrandId);
            ViewData["DescriptionId"] = new SelectList(_context.Descriptions, "Id", "Id", cigar.DescriptionId);
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id", cigar.QuestionId);
            ViewData["ShapeId"] = new SelectList(_context.Shapes, "Id", "Id", cigar.ShapeId);
            ViewData["SizeId"] = new SelectList(_context.Sizes, "Id", "Id", cigar.SizeId);
            ViewData["StrenghtId"] = new SelectList(_context.Strenghts, "Id", "Id", cigar.StrenghtId);
            ViewData["TasteId"] = new SelectList(_context.Tastes, "Id", "Id", cigar.TasteId);
            return View(cigar);
        }

        // GET: Administration/Cigars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var cigar = await _context.Cigars.FindAsync(id);
            if (cigar == null)
            {
                return this.NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id", cigar.BrandId);
            ViewData["DescriptionId"] = new SelectList(_context.Descriptions, "Id", "Id", cigar.DescriptionId);
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id", cigar.QuestionId);
            ViewData["ShapeId"] = new SelectList(_context.Shapes, "Id", "Id", cigar.ShapeId);
            ViewData["SizeId"] = new SelectList(_context.Sizes, "Id", "Id", cigar.SizeId);
            ViewData["StrenghtId"] = new SelectList(_context.Strenghts, "Id", "Id", cigar.StrenghtId);
            ViewData["TasteId"] = new SelectList(_context.Tastes, "Id", "Id", cigar.TasteId);
            return this.View(cigar);
        }

        // POST: Administration/Cigars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BrandId,CigarName,StrenghtId,TasteId,SizeId,QuestionId,Bland,DescriptionId,ShapeId,PricePerUnit,ImageUrl,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Cigar cigar)
        {
            if (id != cigar.Id)
            {
                return this.NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cigar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CigarExists(cigar.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id", cigar.BrandId);
            ViewData["DescriptionId"] = new SelectList(_context.Descriptions, "Id", "Id", cigar.DescriptionId);
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id", cigar.QuestionId);
            ViewData["ShapeId"] = new SelectList(_context.Shapes, "Id", "Id", cigar.ShapeId);
            ViewData["SizeId"] = new SelectList(_context.Sizes, "Id", "Id", cigar.SizeId);
            ViewData["StrenghtId"] = new SelectList(_context.Strenghts, "Id", "Id", cigar.StrenghtId);
            ViewData["TasteId"] = new SelectList(_context.Tastes, "Id", "Id", cigar.TasteId);
            return View(cigar);
        }

        // GET: Administration/Cigars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var cigar = await _context.Cigars
                .Include(c => c.Brand)
                .Include(c => c.Description)
                .Include(c => c.Question)
                .Include(c => c.Shape)
                .Include(c => c.Size)
                .Include(c => c.Strenght)
                .Include(c => c.Taste)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cigar == null)
            {
                return this.NotFound();
            }

            return this.View(cigar);
        }

        // POST: Administration/Cigars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cigar = await _context.Cigars.FindAsync(id);
            _context.Cigars.Remove(cigar);
            await _context.SaveChangesAsync();
            return this.RedirectToAction(nameof(Index));
        }

        private bool CigarExists(int id)
        {
            return _context.Cigars.Any(e => e.Id == id);
        }
    }
}
