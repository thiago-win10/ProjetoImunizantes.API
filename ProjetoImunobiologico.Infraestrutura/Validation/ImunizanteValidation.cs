using FluentValidation;
using ProjetoImunobiologico.Entidades.Models;

namespace ProjetoImunobiologico.Infraestrutura.Validation
{
    public class ImunizanteValidation : AbstractValidator<Imunizante>
	{
		public ImunizanteValidation()
        {
			RuleFor(m => m.Fabricante).NotEmpty().WithMessage("Campo obrigatório");
			RuleFor(m => m.AnoLote).NotEmpty().WithMessage("Campo obrigatório");
		}
    }
}	