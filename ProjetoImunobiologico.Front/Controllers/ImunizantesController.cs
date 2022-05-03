using Microsoft.AspNetCore.Mvc;
using ProjetoImunobiologico.Dominio.Services.Interfaces;
using ProjetoImunobiologico.Entidades.ViewModels;
using System;
using System.Threading.Tasks;

namespace ProjetoImunobiologico.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]


    public class ImunizantesController : ControllerBase
    {

        private readonly IImunizanteService _imunizanteService;
        public ImunizantesController(IImunizanteService imunizanteService)
        {
            _imunizanteService = imunizanteService;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var list = await _imunizanteService.GetImunizantesAsync();
                return Ok(list);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Obter(int? id)
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

            return Ok(imunizante);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(ImunizanteViewModel imunizanteView)
        {

            if (imunizanteView == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            try
            {
                await _imunizanteService.CadastrarImunizanteAsync(imunizanteView);
                return Ok(imunizanteView);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(int id, ImunizanteViewModel imunizanteView)
        {
            var obj = _imunizanteService.FindByIdAsync(id);
            if (obj == null)
                return NotFound("Dados nao Encontrado.");

            if (imunizanteView == null)
                return BadRequest();

            await _imunizanteService.AtualizarImunizanteAsync(imunizanteView);
            return Ok(imunizanteView);
        }

        [HttpDelete]
        public async Task<IActionResult> Deletar(int id)
        {
            var obj = _imunizanteService.FindByIdAsync(id);
            if (obj == null)
                return NotFound("Dados nao Encontrado.");

            await _imunizanteService.DeletarImunizanteAsync(id);

            return NoContent();
        }

    }
}

