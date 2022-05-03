using ProjetoImunobiologico.Entidades.Models;
using ProjetoImunobiologico.Entidades.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoImunobiologico.Dominio.Services.Interfaces
{
    public interface IImunizanteService
    {
        public Task<List<Imunizante>> GetImunizantesAsync();
        public Task<Imunizante> FindByIdAsync(int id);
        public Task CadastrarImunizanteAsync(ImunizanteViewModel imunizanteViewModel);
        public Task AtualizarImunizanteAsync(ImunizanteViewModel imunizanteViewModel);
        public Task DeletarImunizanteAsync(int id);
    }
}
