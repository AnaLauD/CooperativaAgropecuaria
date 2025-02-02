using CooperativaAgropecuaria.web.Data;
using CooperativaAgropecuaria.web.Models;
using CooperativaAgropecuaria.web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace CooperativaAgropecuaria.web.Controllers
{
    public class MaquinariasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaquinariasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var viewModel = new AddMaquinariaViewModel
            {
                Agricultores = await _context.Agricultores
            .Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Nombre
            }).ToListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Models.AddMaquinariaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var maquinaria = new Maquinaria
                {
                    Id = Guid.NewGuid(),
                    Nombre = model.Nombre,
                    Tipo = model.Tipo,
                    CostoHora = model.CostoHora,
                    AgricultorId = model.AgricultorId
                };

                _context.Maquinarias.Add(maquinaria);
                await _context.SaveChangesAsync();

                return RedirectToAction("List", "Maquinarias");
            }

            model.Agricultores = await _context.Agricultores
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Nombre
                }).ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var maquinarias = await _context.Maquinarias
            .Include(m => m.Agricultor)
            .ToListAsync();

            return View(maquinarias);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var maquinaria = await _context.Maquinarias.FindAsync(id);

            if (maquinaria is null)
            {
                return NotFound();
            }

            ViewBag.Agricultores = await _context.Agricultores
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Nombre
                }).ToListAsync();

            return View(maquinaria);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Maquinaria viewModel)
        {
            var maquinaria = await _context.Maquinarias.FindAsync(viewModel.Id);

            if (maquinaria is not null)
            {
                maquinaria.Nombre = viewModel.Nombre;
                maquinaria.Tipo = viewModel.Tipo;
                maquinaria.CostoHora = viewModel.CostoHora;
                maquinaria.AgricultorId = viewModel.AgricultorId;

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("List", "Maquinarias");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Maquinaria viewModel)
        {
            var maquinaria = await _context.Maquinarias.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (maquinaria is not null)
            {

                _context.Maquinarias.Remove(viewModel);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("List", "Maquinarias");

        }


    }
}
