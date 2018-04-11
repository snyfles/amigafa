using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Amigafa.Models
{
    public class Pagamentos
    {
        [Key]
        [Required]
        [Display(Name = "Militar Nome")]
        public string Nome { get; set; }

        [Display(Name = "CPF Militar")]
        public string Cpf { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

      
        public string Status { get; set; }

        [Display(Name = "Valor do pagamento")]
        public string ValorPagamento { get; set; }


        public DateTime DataPagamento { get; set; }



    }
}