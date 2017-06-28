using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Imobiliaria2._0.Models
{
    public class Cliente
    {
        [Key, ScaffoldColumn(false)]
        public int Id { set; get; }

        [Required(ErrorMessage = "Favor Preencher Campo Nome!")]
        public string Nome { set; get; }

        [Required(ErrorMessage = "Favor Preencher Campo Rg!")]
        public string Rg { set; get; }

        [Required(ErrorMessage = "Favor Preencher Campo Cpf!")]
        public string Cpf { set; get; }

        [Required(ErrorMessage = "Favor Preencher Campo Telefone!")]
        public string Telefone { set; get; }

        [Required(ErrorMessage = "Favor Preencher Campo Filiação!")]
        [Display(Name = "Filiação")]
        public string Filiacao { set; get; }

        [Required(ErrorMessage = "Favor Preencher Campo Comprovante De Renda!")]
        [Display(Name = "Comprovante De Renda")]
        public float ComprovanteRenda { set; get; }

        [Required]
        public string EstadoCivil { set; get; }

        [Required]
        public bool Ativo { set; get; }

        [Required(ErrorMessage = "Favor Preencher Campo Propiedade Id!")]
        public int PropriedadeID { get; set; }

        [Display(Name = "Propriedade")]
        public virtual Propriedade _Propriedade { get; set; }
    }
}