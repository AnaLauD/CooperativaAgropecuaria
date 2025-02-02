using CooperativaAgropecuaria.web.Data;
using CooperativaAgropecuaria.web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CooperativaAgropecuaria.web.Controllers
{
    public class AgricultoresController : Controller
    {

        private readonly ApplicationDbContext _context;

        public AgricultoresController(ApplicationDbContext context)
        { 
            this._context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Models.AddAgricultorViewModel addAgricultorViewModel)
        {

            var agricultor = new Agricultor
            {
                Nombre = addAgricultorViewModel.Nombre,
                TamanoCampo = addAgricultorViewModel.TamanoCampo
            };

            await _context.Agricultores.AddAsync(agricultor);
            await _context.SaveChangesAsync();


            return RedirectToAction("List", "Agricultores");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var agricultores = await _context.Agricultores.ToListAsync();
            return View(agricultores);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var agricultor = await _context.Agricultores.FindAsync(id);

            return View(agricultor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Agricultor viewModel)
        {
            var agricultor = await _context.Agricultores.FindAsync(viewModel.Id);

            if(agricultor is not null) {

                agricultor.Nombre = viewModel.Nombre;
                agricultor.TamanoCampo = viewModel.TamanoCampo;

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("List", "Agricultores");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Agricultor viewModel)
        {
            var agricultor = await _context.Agricultores.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (agricultor is not null)
            {

                _context.Agricultores.Remove(viewModel);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("List", "Agricultores");

        }


    }
}
