using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Amigafa.Models
{
    public class Militar_Evento
    {
        [Key]
        [Required]
        public string Militar_Cpf { get; set; }

        [Display(Name = "Militar Camiseta")]
        public string Camiseta { get; set; }

        [Display(Name = "Evento Encontro")]
        public string EventoEncontro { get; set; }

        [Display(Name = "Evento Churrasco")]
        public string EventoChurrasco { get; set; }

        [Display(Name = "Evento Completo")]
        public string EventoCompleto { get; set; }

        [Display(Name = "Evento Vinho")]
        public string EventoVinho { get; set; }









    }
}