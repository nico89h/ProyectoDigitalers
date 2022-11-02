using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseConPruebaMigraciones
{
    public class Articulo 
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Se produjo un error")]
        [StringLength(100,MinimumLength =5)]

        [Display(Name = "Titulo del articulo")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Se produjo un error")]
        [StringLength(50, MinimumLength = 5)]
        public string Autor { get; set; }
        [Required(ErrorMessage = "Se produjo un error")]
        [StringLength(100, MinimumLength = 10)]
        public string Cuerpo { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}
