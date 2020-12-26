namespace GiffyCards.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using GiffyCards.Data.Common.Repositories;
    using GiffyCards.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Area("Administration")]
    public class CigarsController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Cigar> cigarEntity;

        public CigarsController(IDeletableEntityRepository<Cigar> cigarEntity)
        {
            this.cigarEntity = cigarEntity;
        }

        // GET: Administration/Cigars
        public async Task<IActionResult> Index()
        {
            return this.View(await this.cigarEntity.AllWithDeleted().ToListAsync());
        }

        // GET: Administration/Cigars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var cigar = await this.cigarEntity.All().FirstOrDefaultAsync(m => m.Id == id);

            if (cigar == null)
            {
                return this.NotFound();
            }

            return this.View(cigar);
        }

        // GET: Administration/Cigars/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Administration/Cigars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrandId,CigarName,StrenghtId,TasteId,SizeId,QuestionId,Bland,DescriptionId,ShapeId,PricePerUnit,ImageUrl,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Cigar cigar)
        {
            if (this.ModelState.IsValid)
            {
                await this.cigarEntity.AddAsync(cigar);
                await this.cigarEntity.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(cigar);
        }

        // GET: Administration/Cigars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var cigar = await this.cigarEntity.All().FirstOrDefaultAsync(x => x.Id == id);

            if (cigar == null)
            {
                return this.NotFound();
            }

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

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.cigarEntity.Update(cigar);
                    await this.cigarEntity.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.CigarExists(cigar.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(cigar);
        }

        // GET: Administration/Cigars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var cigar = await this.cigarEntity.All().FirstOrDefaultAsync(x => x.Id == id);
            if (cigar == null)
            {
                return this.NotFound();
            }

            return this.View(cigar);
        }

        // POST: Administration/Cigars/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cigar = await this.cigarEntity.All().FirstOrDefaultAsync(x => x.Id == id);

            this.cigarEntity.Delete(cigar);

            await this.cigarEntity.SaveChangesAsync();

            return this.RedirectToAction(nameof(this.Index));
        }

        private bool CigarExists(int id)
        {
            return this.cigarEntity.All().Any(x => x.Id == id);
        }
    }
}
