namespace DAB32.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        AdresseId = c.Int(nullable: false, identity: true),
                        VejNavn = c.String(),
                        Husnummer = c.Int(nullable: false),
                        ByPostNummer_Postnummer = c.Int(),
                    })
                .PrimaryKey(t => t.AdresseId)
                .ForeignKey("dbo.ByPostNummers", t => t.ByPostNummer_Postnummer)
                .Index(t => t.ByPostNummer_Postnummer);
            
            CreateTable(
                "dbo.ByPostNummers",
                c => new
                    {
                        Postnummer = c.Int(nullable: false, identity: true),
                        ByNavn = c.String(),
                        Land = c.String(),
                    })
                .PrimaryKey(t => t.Postnummer);
            
            CreateTable(
                "dbo.PersonAdresses",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        PersonCpr = c.Int(nullable: false),
                        AdresseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.Adresses", t => t.AdresseId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonCpr, cascadeDelete: true)
                .Index(t => t.PersonCpr)
                .Index(t => t.AdresseId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Cpr = c.Int(nullable: false, identity: true),
                        Fornavn = c.String(),
                        MellemNavn = c.String(),
                        EfterNavn = c.String(),
                        PersonType = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Cpr);
            
            CreateTable(
                "dbo.TelefonNummers",
                c => new
                    {
                        Telefonnummer = c.Int(nullable: false, identity: true),
                        TelefonnummerType = c.String(),
                        TelefonSelskab = c.String(),
                        PersonCpr = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Telefonnummer)
                .ForeignKey("dbo.People", t => t.PersonCpr, cascadeDelete: true)
                .Index(t => t.PersonCpr);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TelefonNummers", "PersonCpr", "dbo.People");
            DropForeignKey("dbo.PersonAdresses", "PersonCpr", "dbo.People");
            DropForeignKey("dbo.PersonAdresses", "AdresseId", "dbo.Adresses");
            DropForeignKey("dbo.Adresses", "ByPostNummer_Postnummer", "dbo.ByPostNummers");
            DropIndex("dbo.TelefonNummers", new[] { "PersonCpr" });
            DropIndex("dbo.PersonAdresses", new[] { "AdresseId" });
            DropIndex("dbo.PersonAdresses", new[] { "PersonCpr" });
            DropIndex("dbo.Adresses", new[] { "ByPostNummer_Postnummer" });
            DropTable("dbo.TelefonNummers");
            DropTable("dbo.People");
            DropTable("dbo.PersonAdresses");
            DropTable("dbo.ByPostNummers");
            DropTable("dbo.Adresses");
        }
    }
}
