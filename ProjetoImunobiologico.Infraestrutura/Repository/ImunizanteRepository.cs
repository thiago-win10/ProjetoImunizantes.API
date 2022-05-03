using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetoImunobiologico.Entidades.Models;
using ProjetoImunobiologico.Entidades.ViewModels;
using ProjetoImunobiologico.Infraestrutura.Configuration;
using ProjetoImunobiologico.Infraestrutura.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoImunobiologico.Infraestrutura.Repository
{
    public class ImunizanteRepository : IImunizanteRepository
    {
        private readonly ImunizanteContext _context;
        private readonly IMapper _mapper;

        public ImunizanteRepository(ImunizanteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Imunizante>> GetImunizantesAsync()
        {

            var lista = await _context.Imunizantes.ToListAsync();
            return lista;
        }

        public async Task<Imunizante> FindByIdAsync(int id)
        {
            return await _context.Imunizantes.AsNoTracking()
                        .FirstOrDefaultAsync(a => a.ImunizanteId == id);

        }
        public async Task CadastrarImunizanteAsync(ImunizanteViewModel imunizanteView)
        {
            var rec = _mapper.Map<Imunizante>(imunizanteView);
            await _context.Imunizantes.AddAsync(rec);
            await _context.SaveChangesAsync();

        }
        public async Task AtualizarImunizanteAsync(ImunizanteViewModel imunizanteView)
        {
            bool hasAny = await _context.Imunizantes
            .AnyAsync(x => x.ImunizanteId == imunizanteView.ImunizanteId);

            if (!hasAny)
            {
                throw new Exception("Id não encontrado.");
            }
            var recAtualizar = _mapper.Map<Imunizante>(imunizanteView);
            _context.UpdateRange(recAtualizar);
            await _context.SaveChangesAsync();

        }

        public async Task DeletarImunizanteAsync(int id)
        {
            var imunizante = _context.Imunizantes.Find(id);
            _context.Imunizantes.Remove(imunizante);
            await _context.SaveChangesAsync();

        }

    }
}

