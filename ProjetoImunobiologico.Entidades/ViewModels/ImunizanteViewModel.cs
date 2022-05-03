using System.ComponentModel.DataAnnotations;

namespace ProjetoImunobiologico.Entidades.ViewModels
{
    public class ImunizanteViewModel
    {
        public int ImunizanteId { get; set; }
        public string Fabricante { get; set; }

        [Display(Name = "Ano do Lote")]
        public int AnoLote { get; set; }
    }
}
