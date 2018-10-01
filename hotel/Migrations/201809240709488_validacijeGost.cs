namespace hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validacijeGost : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Gost", "Ime", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Gost", "Prezime", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Gost", "Prezime", c => c.String(maxLength: 255));
            AlterColumn("dbo.Gost", "Ime", c => c.String(maxLength: 255));
        }
    }
}
