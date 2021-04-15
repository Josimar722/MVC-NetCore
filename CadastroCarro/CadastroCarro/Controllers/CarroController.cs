using CadastroCarro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CadastroCarro.Controllers
{
    public class CarroController : Controller  
    {
        private readonly Context _context;

        public CarroController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Carros.ToListAsync());
        }

        [HttpGet]
        public IActionResult CriarCarro()
        {

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CriarCarro(Carro carro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            else return View(carro);
        }

        [HttpGet]

        public IActionResult AtualizarCarro(int? id)
        {
            if(id != null)
            {
                Carro carro = _context.Carros.Find(id);
                return View(carro);
            }
            else return NotFound();
        }

        [HttpPost]

        public async Task<IActionResult> AtualizarCarro(int? id, Carro carro)
        {
            if(id != null)
            {
                if (ModelState.IsValid)
                {
                    _context.Update(carro);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                else return View(carro);
            }
            else return NotFound();
        }
        
        [HttpGet]
        
        public IActionResult ExcluirCarro(int? id)
        {
            if (id != null)
            {
                Carro carro = _context.Carros.Find(id);
                return View(carro);
            }
            else return NotFound();
        }

        [HttpPost]

        public async Task<IActionResult> ExcluirCarro(int? id, Carro carro)
        {
            if (id != null)
            {
                _context.Remove(carro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else return NotFound();
        }
    }
}
