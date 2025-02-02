using CooperativaAgropecuaria.web.Data;
using CooperativaAgropecuaria.web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CooperativaAgropecuaria.web.Controllers
{
    public class UsoMaquinariaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsoMaquinariaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var viewModel = new Models.RegistrarUsoMaquinariaViewModel
            {
                Maquinarias = await _context.Maquinarias
                    .Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Nombre })
                    .ToListAsync(),

                Agricultores = await _context.Agricultores
                    .Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Nombre })
                    .ToListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(Models.RegistrarUsoMaquinariaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var maquinaria = await _context.Maquinarias.FindAsync(model.MaquinariaId);
                if (maquinaria == null) return NotFound();

                var uso = new UsoMaquinaria
                {
                    Id = Guid.NewGuid(),
                    MaquinariaId = model.MaquinariaId,
                    AgricultorId = model.AgricultorId,
                    HorasUso = model.HorasUso,
                    CostoTotal = (decimal)model.HorasUso * maquinaria.CostoHora

                };

                _context.UsosMaquinaria.Add(uso);
                await _context.SaveChangesAsync();

                return RedirectToAction("List", "UsoMaquinaria");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var usos = await _context.UsosMaquinaria
                .Include(u => u.Maquinaria)
                .Include(u => u.Agricultor)
                .ToListAsync();

            return View(usos);
        }

        [HttpGet]
        public async Task<IActionResult> statistics()
        {
            var estadisticas = await _context.UsosMaquinaria
                .GroupBy(u => u.Maquinaria)
                .Select(g => new
                {
                    Maquinaria = g.Key,
                    TotalHoras = g.Sum(u => u.HorasUso)
                })
                .OrderByDescending(m => m.TotalHoras)
                .ToListAsync();

            var viewModel = estadisticas.Select(e => new Models.EstadisticasMaquinariaViewModel
            {
                MaquinariaId = e.Maquinaria.Id,
                NombreMaquinaria = e.Maquinaria.Nombre,
                TotalHorasUso = e.TotalHoras
            }).ToList();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> StatisticsAgricultores()
        {
            var estadisticas = await _context.UsosMaquinaria
                .GroupBy(u => u.Agricultor)
                .Select(g => new
                {
                    Agricultor = g.Key,
                    TotalHoras = g.Sum(u => u.HorasUso)
                })
                .OrderByDescending(a => a.TotalHoras)
                .ToListAsync();

            var viewModel = estadisticas.Select(e => new Models.EstadisticasAgricultorViewModel
            {
                AgricultorId = e.Agricultor.Id,
                NombreAgricultor = e.Agricultor.Nombre,
                TotalHorasUso = e.TotalHoras
            }).ToList();

            return View(viewModel);
        }
    }
}
