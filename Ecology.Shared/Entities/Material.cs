using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecology.Shared.Entities
{
    public class Material
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Este campo es requerido")]
        public string Name { get; set; } = null;
        
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Description { get; set; } = null;

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Peso { get; set; } = null;

        public string Typmateria { get; set; } = null; 

        public int RecyclerId { get; set; }

        public Recycler Recycler {  get; set; }

        public int TypMaterialId { get; set; }

        public TypMaterial TypMaterial { get; set; }
    }
}
