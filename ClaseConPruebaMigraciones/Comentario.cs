using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseConPruebaMigraciones
{
    public class Comentario
    {

        //aca se usan las data notacion
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Se produjo un error")]
        [StringLength(50,MinimumLength =5)]
        public string Autor { get; set; }
        [StringLength(50, MinimumLength = 10)]
        public string Cuerpo { get; set; }
        public int ArticuloId { get; set; }
        public DateTime Fecha { get; set; }
    }
}
