namespace DAB32.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_postnummerid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Adresses", "PostNummer", "dbo.ByPostNummers");
            DropIndex("dbo.Adresses", new[] { "PostNummer" });
            RenameColumn(table: "dbo.Adresses", name: "PostNummer", newName: "ByPostNummer_Postnummer");
            AlterColumn("dbo.Adresses", "ByPostNummer_Postnummer", c => c.Int());
            CreateIndex("dbo.Adresses", "ByPostNummer_Postnummer");
            AddForeignKey("dbo.Adresses", "ByPostNummer_Postnummer", "dbo.ByPostNummers", "Postnummer");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Adresses", "ByPostNummer_Postnummer", "dbo.ByPostNummers");
            DropIndex("dbo.Adresses", new[] { "ByPostNummer_Postnummer" });
            AlterColumn("dbo.Adresses", "ByPostNummer_Postnummer", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Adresses", name: "ByPostNummer_Postnummer", newName: "PostNummer");
            CreateIndex("dbo.Adresses", "PostNummer");
            AddForeignKey("dbo.Adresses", "PostNummer", "dbo.ByPostNummers", "Postnummer", cascadeDelete: true);
        }
    }
}
