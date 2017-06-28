using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static Imobiliaria2._0.Util.Enumeradores;

namespace Imobiliaria2._0.Models
{
    public class Propriedade
    {
        [Key, ScaffoldColumn(false)]
        public int Id { set; get; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "Favor Preencher Campo Endereço!")]
        public string Endereco { set; get; }

        [Required(ErrorMessage = "Favor Preencher Campo Cep!")]
        public string Cep { set; get; }

        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        public string Descricao { set; get; }


        [Required(ErrorMessage = "Favor Preencher Campo Preço!")]
        [Display(Name = "Preço")]
        public decimal Preco { set; get; }

        [Required]
        public string Material { set; get; }

        [Required]
        public bool Ativo { set; get; }

        [Display(Name = "Proprietario")]
        public int ProprietarioID { get; set; }

        [Display(Name = "Proprietario")]
        public virtual Proprietario _Proprietario { get; set; }

        //alvenaria ou madeira

        public SituacaoPropriedade Situacao { get; set; }
    }
}