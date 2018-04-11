 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Amigafa.Models
{
    public class Convidado
    {

        [Display(Name = "Convidado Nome")]
        public string Nome { get; set; }

        [Display(Name = "Convidado RG")]
        public string Rg { get; set; }

        [Display(Name = "Parentesco")]
        public string Parentesco { get; set; }

        [Display(Name = "Convidado Camiseta")]
        public string Camisa { get; set; }

        [Display(Name = "Evento Encontro")]
        public string EventoEncontro { get; set; }

        [Display(Name = "Evento Churrasco")]
        public string EventoChurrasco { get; set; }

        [Display(Name = "Evento Completo")]
        public string EventoCompleto { get; set; }

        [Display(Name = "Evento Vinho")]
        public string EventoVinho { get; set; }

        [Key]
        [Required]
        public string MilitarCpf { get; set; }








    }
}