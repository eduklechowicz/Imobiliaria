using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Imobiliaria2._0.Util
{
    public class Enumeradores
    {
        public enum SituacaoPropriedade
        {
            [Display(Name = "A Venda")]
            AVenda,
            [Display(Name = "A Locação")]
            ALocacao,
            Vendido,
            Locado,
            [Display(Name = "Em Reforma")]
            EmReforma
        }

        public enum TipoMaterial
        {
            Alvenaria,
            Madeira
        }


    }
}