namespace hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ElementPonude",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        JedinicnaCijena = c.Int(nullable: false),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Stavke",
                c => new
                    {
                        PrivremeniRacunID = c.Int(nullable: false),
                        ElementPonudeID = c.Int(nullable: false),
                        Kolicina = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PrivremeniRacunID, t.ElementPonudeID })
                .ForeignKey("dbo.ElementPonude", t => t.ElementPonudeID, cascadeDelete: true)
                .ForeignKey("dbo.PrivremeniRacun", t => t.PrivremeniRacunID, cascadeDelete: true)
                .Index(t => t.PrivremeniRacunID)
                .Index(t => t.ElementPonudeID);
            
            CreateTable(
                "dbo.PrivremeniRacun",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RezervacijaID = c.Int(nullable: false),
                        Placeno = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Rezervacija", t => t.RezervacijaID, cascadeDelete: true)
                .Index(t => t.RezervacijaID);
            
            CreateTable(
                "dbo.Rezervacija",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GostID = c.Int(nullable: false),
                        SobaID = c.Int(nullable: false),
                        DatumOd = c.DateTime(nullable: false),
                        DatumDo = c.DateTime(nullable: false),
                        DatumOdDolaska = c.DateTime(nullable: false),
                        DatumDoDolaska = c.DateTime(nullable: false),
                        Popust = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Gost", t => t.GostID, cascadeDelete: true)
                .ForeignKey("dbo.Soba", t => t.SobaID, cascadeDelete: true)
                .Index(t => t.GostID)
                .Index(t => t.SobaID);
            
            CreateTable(
                "dbo.Gost",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Ime = c.String(),
                        Prezime = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.IzdaniRacun",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Rezervacija", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Soba",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SobaTipID = c.Int(nullable: false),
                        HotelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Hotel", t => t.HotelID, cascadeDelete: true)
                .ForeignKey("dbo.SobaTip", t => t.SobaTipID, cascadeDelete: true)
                .Index(t => t.SobaTipID)
                .Index(t => t.HotelID);
            
            CreateTable(
                "dbo.Hotel",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Adresa = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SobaTip",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Cijena = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stavke", "PrivremeniRacunID", "dbo.PrivremeniRacun");
            DropForeignKey("dbo.Rezervacija", "SobaID", "dbo.Soba");
            DropForeignKey("dbo.Soba", "SobaTipID", "dbo.SobaTip");
            DropForeignKey("dbo.Soba", "HotelID", "dbo.Hotel");
            DropForeignKey("dbo.PrivremeniRacun", "RezervacijaID", "dbo.Rezervacija");
            DropForeignKey("dbo.IzdaniRacun", "ID", "dbo.Rezervacija");
            DropForeignKey("dbo.Rezervacija", "GostID", "dbo.Gost");
            DropForeignKey("dbo.Stavke", "ElementPonudeID", "dbo.ElementPonude");
            DropIndex("dbo.Soba", new[] { "HotelID" });
            DropIndex("dbo.Soba", new[] { "SobaTipID" });
            DropIndex("dbo.IzdaniRacun", new[] { "ID" });
            DropIndex("dbo.Rezervacija", new[] { "SobaID" });
            DropIndex("dbo.Rezervacija", new[] { "GostID" });
            DropIndex("dbo.PrivremeniRacun", new[] { "RezervacijaID" });
            DropIndex("dbo.Stavke", new[] { "ElementPonudeID" });
            DropIndex("dbo.Stavke", new[] { "PrivremeniRacunID" });
            DropTable("dbo.SobaTip");
            DropTable("dbo.Hotel");
            DropTable("dbo.Soba");
            DropTable("dbo.IzdaniRacun");
            DropTable("dbo.Gost");
            DropTable("dbo.Rezervacija");
            DropTable("dbo.PrivremeniRacun");
            DropTable("dbo.Stavke");
            DropTable("dbo.ElementPonude");
        }
    }
}
