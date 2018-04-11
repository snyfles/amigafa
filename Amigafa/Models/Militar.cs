using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Amigafa.Models
{
    public class Militar
    {

        [Key]
        [Required]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Display(Name = "RG Civil")]
        public string RgCivil { get; set; }

        [Display(Name = "RG Militar")]
        public string RgMilitar { get; set; }

        [Required]
        [Display(Name = "Nome completo")]
        public string Nome { get; set; }

        [Display(Name = "Nome de Guerra")]
        public string NomeGuerra { get; set; }

        [Display(Name = "Posto/Graduação")]
        public string PostoGrad { get; set; }

        [Required]
        [Display(Name = "Data formatura EEAR")]
        public string DataFormatura { get; set; }

        [Required]
        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Display(Name = "Número")]
        public string NumeroEndereco { get; set; }

        [Display(Name = "Complemento")]
        public string ComplementoEndereco { get; set; }

        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Required]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "Celular")]
        public string Celular { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}