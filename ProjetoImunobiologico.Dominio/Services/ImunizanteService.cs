using ProjetoImunobiologico.Dominio.Services.Interfaces;
using ProjetoImunobiologico.Entidades.Models;
using ProjetoImunobiologico.Entidades.ViewModels;
using ProjetoImunobiologico.Infraestrutura.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoImunobiologico.Dominio.Services
{
    public class ImunizanteService : IImunizanteService
    {
        private readonly IImunizanteRepository _imunizante;
        public ImunizanteService(IImunizanteRepository imunizante)
        {
            _imunizante = imunizante;
        }

        public async Task<List<Imunizante>> GetImunizantesAsync()
        {
            return await _imunizante.GetImunizantesAsync();

        }

        public async Task<Imunizante> FindByIdAsync(int id)
        {
            return await _imunizante.FindByIdAsync(id);

        }
        public async Task CadastrarImunizanteAsync(ImunizanteViewModel imunizanteViewModel)
        {
            await _imunizante.CadastrarImunizanteAsync(imunizanteViewModel);
        }

        public async Task AtualizarImunizanteAsync(ImunizanteViewModel imunizanteViewModel)
        {
            await _imunizante.AtualizarImunizanteAsync(imunizanteViewModel);

        }
        public async Task DeletarImunizanteAsync(int id)
        {
            await _imunizante.DeletarImunizanteAsync(id);

        }

    }
}

