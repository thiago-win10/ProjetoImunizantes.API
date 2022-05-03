using ProjetoImunobiologico.Entidades.Enum;

namespace ProjetoImunobiologico.Entidades.Models
{
    public class Imunizante
    {
        public int ImunizanteId { get; set; }
        public TipoImunizante Fabricante { get; set; }
        public int AnoLote { get; set; }

    }
}
