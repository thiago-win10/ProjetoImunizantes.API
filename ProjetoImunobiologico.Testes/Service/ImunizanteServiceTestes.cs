using AutoMapper;
using Moq;
using ProjetoImunobiologico.Dominio.Services;
using ProjetoImunobiologico.Dominio.Services.Interfaces;
using ProjetoImunobiologico.Infraestrutura.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoImunobiologico.Testes.Service
{
    public class ImunizanteServiceTestes
    {
        private ImunizanteService imunizanteService;
        public ImunizanteServiceTestes()
        {
            imunizanteService = new ImunizanteService(new Mock<IImunizanteRepository>().Object);        
        }


    }
}
