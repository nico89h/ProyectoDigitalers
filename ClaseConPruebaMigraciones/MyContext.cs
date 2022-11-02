using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseConPruebaMigraciones
{
    public class MyContext:DbContext
    {
        //inicio de el constructor de mi context
        public MyContext() : base("Data Source=localhost ; Initial Catalog=PruebaMigraciones;Integrated Security=yes")
        {

        }

        //inicio de configuracion
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder); //crea el modelo del cual esta en esta clase
        }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
    }
}
