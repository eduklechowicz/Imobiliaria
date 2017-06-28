using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Imobiliaria2._0.Models
{
    public class Proprietario
    {
        [Key, ScaffoldColumn(false)]
        public int Id { set; get; }

        [Required(ErrorMessage = "Favor Preencher Campo Nome!")]
        public string Nome { set; get; }

        [Required(ErrorMessage = "Favor Preencher Campo Endereço!")]
        [Display(Name = "Endereço")]
        public string Endereco { set; get; }

        [Required(ErrorMessage = "Favor Preencher Campo Rg!")]
        public string Rg { set; get; }

        [Required(ErrorMessage = "Favor Preencher Campo Cpf!")]
        public string Cpf { set; get; }

        [Required(ErrorMessage = "Favor Preencher Campo Telefone!")]
        public string Telefone { set; get; }

        [Required(ErrorMessage = "Favor Preencher Campo Matricula do Imovel!")]
        [Display(Name = "Matricula do Imovel")]
        public string MatriculaImovel { set; get; }

        [Required(ErrorMessage = "Favor Preencher Campo Inscrição Do Imovel!")]
        [Display(Name = "Inscrição Do Imovel")]
        public string InscricaoImovel { set; get; }

        [Required]
        public bool Ativo { set; get; }

    }
}