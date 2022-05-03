using Microsoft.AspNetCore.Mvc;
using ProjetoImunobiologico.Dominio.Services.Interfaces;
using ProjetoImunobiologico.Entidades.ViewModels;
using System;
using System.Threading.Tasks;

namespace ProjetoImunobiologico.MVC.Controllers
{
    public class ImunizanteController : Controller
    {
        private readonly IImunizanteService _imunizanteService;
        public ImunizanteController(IImunizanteService imunizanteService)
        {
            _imunizanteService = imunizanteService;

        }
        public async Task<IActionResult> Index()
        {
            return View(await _imunizanteService.GetImunizantesAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imunizante = await _imunizanteService.FindByIdAsync(id.Value);
            if (imunizante == null)
            {
                return NotFound();
            }

            return View(imunizante);
        }
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ImunizanteViewModel imunizanteView)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
           
            {
                await _imunizanteService.CadastrarImunizanteAsync(imunizanteView);
                return RedirectToAction(nameof(Index));
            }
            return View(imunizanteView);
        }
        public async Task<IActionResult> Edit(int? id, ImunizanteViewModel imunizanteView)
        {

            var obj = _imunizanteService.FindByIdAsync(id.Value);
            if (obj == null)
                return NotFound("Dados nao Encontrado.");

            await _imunizanteService.AtualizarImunizanteAsync(imunizanteView);
            return View(imunizanteView);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ImunizanteViewModel imunizanteView)
        {
            if (id != imunizanteView.ImunizanteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _imunizanteService.AtualizarImunizanteAsync(imunizanteView);

                }
                catch (Exception e)
                {
                    return NotFound(e.Message);
                }
                   
                return RedirectToAction(nameof(Index));
            }
            return View(imunizanteView);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imunizante = await _imunizanteService.FindByIdAsync(id.Value);
            if (imunizante == null)
            {
                return NotFound();
            }

            return View(imunizante);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obj = await _imunizanteService.FindByIdAsync(id);
            if (obj == null)
                return NotFound("Dados nao Encontrado.");

            await _imunizanteService.DeletarImunizanteAsync(id);
            return RedirectToAction(nameof(Index));

        }

    }
}
