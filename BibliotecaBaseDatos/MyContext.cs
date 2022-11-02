using BibliotecaBaseDatos.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//inicio de la conexion a bd con entity framework y ADO.NET
namespace BibliotecaBaseDatos
{
    public class MyContext : DbContext
    {
        //private DbSet<Empleado> empleados;
        public DbSet<Empleado> EmpleadoA { get; set; }
        //inicio de la conexion de la base de datos
        public MyContext() : base("Data Source=localhost ; Initial Catalog=PruebaGlobal;Integrated Security=yes")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }


        //internal DbSet<Empleado> Empleados1 { get => Empleados; set => Empleados = value; }
    
    }
}
