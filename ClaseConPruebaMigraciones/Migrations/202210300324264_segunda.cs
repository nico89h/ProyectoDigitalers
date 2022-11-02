namespace ClaseConPruebaMigraciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class segunda : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articulo", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Articulo", "Autor", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Articulo", "Cuerpo", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Comentario", "Autor", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Comentario", "Cuerpo", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comentario", "Cuerpo", c => c.String());
            AlterColumn("dbo.Comentario", "Autor", c => c.String());
            AlterColumn("dbo.Articulo", "Cuerpo", c => c.String());
            AlterColumn("dbo.Articulo", "Autor", c => c.String());
            AlterColumn("dbo.Articulo", "Name", c => c.String());
        }
    }
}
