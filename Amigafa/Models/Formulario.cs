using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Amigafa.Models
{
    public class Formulario
    {
        [Key]
        public string Id { get; set; }

        [Display(Name = "Ano")]
        public DateTime Ano { get; set; }

        [Display(Name = "Encontro Veterano")]
        public string EncontroVeterano { get; set; }

        [Display(Name = "Churrasco Veterano")]
        public string ChurrascoVeterano { get; set; }

        [Display(Name = "Completo Veterano")]
        public string CompletoVeterano { get; set; }

        [Display(Name = "Camisa Extra")]
        public string CamisaExtra { get; set; }

        [Display(Name = "Bone Extra")]
        public string BoneExtra { get; set; }

        [Display(Name = "Vinho Veterano")]
        public string VinhoVeterano { get; set; }

        [Display(Name = "Vinho Convidado")]
        public string VinhoConvidado { get; set; }

    }
}