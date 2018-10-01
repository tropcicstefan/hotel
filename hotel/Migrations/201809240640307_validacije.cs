namespace hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validacije : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ElementPonude", "Naziv", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Gost", "Ime", c => c.String(maxLength: 255));
            AlterColumn("dbo.Gost", "Prezime", c => c.String(maxLength: 255));
            AlterColumn("dbo.Hotel", "Naziv", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Hotel", "Adresa", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Hotel", "Adresa", c => c.String());
            AlterColumn("dbo.Hotel", "Naziv", c => c.String());
            AlterColumn("dbo.Gost", "Prezime", c => c.String());
            AlterColumn("dbo.Gost", "Ime", c => c.String());
            AlterColumn("dbo.ElementPonude", "Naziv", c => c.String());
        }
    }
}
