namespace BibliotecaBaseDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primera : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empleado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        lastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Empleado");
        }
    }
}
