namespace ClaseConPruebaMigraciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primera : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articulo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Autor = c.String(),
                        Cuerpo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comentario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Autor = c.String(),
                        Cuerpo = c.String(),
                        ArticuloId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articulo", t => t.ArticuloId, cascadeDelete: true)
                .Index(t => t.ArticuloId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentario", "ArticuloId", "dbo.Articulo");
            DropIndex("dbo.Comentario", new[] { "ArticuloId" });
            DropTable("dbo.Comentario");
            DropTable("dbo.Articulo");
        }
    }
}
