using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBaseDatos.Model
{
    public class Empleado
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string lastName { get; set; }

    }
}
