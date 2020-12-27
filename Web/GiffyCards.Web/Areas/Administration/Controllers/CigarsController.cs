namespace GiffyCards.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using GiffyCards.Data.Common.Repositories;
    using GiffyCards.Data.Models;
    using GiffyCards.Web.Areas.Administration.Services;
    using GiffyCards.Web.ViewModels.Cigar;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Area("Administration")]
    public class CigarsController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Cigar> cigarEntity;
        private readonly ICigarServiceAdmin cigarServiceAdmin;

        public CigarsController(IDeletableEntityRepository<Cigar> cigarEntity, ICigarServiceAdmin cigarServiceAdmin)
        {
            this.cigarEntity = cigarEntity;
            this.cigarServiceAdmin = cigarServiceAdmin;
        }

        // GET: Administration/Cigars
        public IActionResult Index()
        {
            var allCigars = new AllCigarsAdmin
            {
                AllAdmin = this.cigarServiceAdmin.GetAll(),
            };

            return this.View(allCigars);
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
            var viewModel = new CreateCigarInputModel
            {
                BrandItems = this.cigarServiceAdmin.BrandsAsKeyValuePairs(),
                ShapeItems = this.cigarServiceAdmin.ShapeAsKeyValuePairs(),
                StrenghtItems = this.cigarServiceAdmin.StrengthAsKeyValuePairs(),
                TasteItems = this.cigarServiceAdmin.TasteAsKeyValuePairs(),
                SizeItems = this.cigarServiceAdmin.SizeAsKeyValuePairs(),
            };

            return this.View(viewModel);
        }

        // POST: Administration/Cigars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCigarInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var viewModel = new CreateCigarInputModel
                {
                    BrandItems = this.cigarServiceAdmin.BrandsAsKeyValuePairs(),
                    ShapeItems = this.cigarServiceAdmin.ShapeAsKeyValuePairs(),
                    StrenghtItems = this.cigarServiceAdmin.StrengthAsKeyValuePairs(),
                    TasteItems = this.cigarServiceAdmin.TasteAsKeyValuePairs(),
                    SizeItems = this.cigarServiceAdmin.SizeAsKeyValuePairs(),
                };

                return this.View(viewModel);
            }

            await this.cigarServiceAdmin.CreateCigar(input);
            return this.RedirectToAction(nameof(this.Index));
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

            var cigar = await this.cigarServiceAdmin.DeleteCigar(id);

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
            await this.cigarServiceAdmin.DeleteCigarConfirmed(id);

            return this.RedirectToAction(nameof(this.Index));
        }

        private bool CigarExists(int id)
        {
            return this.cigarEntity.All().Any(x => x.Id == id);
        }
    }
}
