using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Amigafa.Models
{
    public class ContagemTotal
    {
        [Key]
        public int Id { get; set; }

        public string EventoEncontroVeterano { get; set; }
        public string EventoChurrascoVeterano { get; set; }
        public string EventoCompletoVeterano { get; set; }
        public string EventoEncontroConvidado { get; set; }
        public string EventoChurrascoConvidado { get; set; }
        public string EventoCompletoConvidado { get; set; }
        public string CamisetaP { get; set; }
        public string CamisetaM { get; set; }
        public string CamisetaG { get; set; }
        public string CamisetaGG { get; set; }
        public string CamisetaXG { get; set; }
        public string CamisetaXGG { get; set; }
        public string Bone { get; set; }






    }
}