namespace DAB32.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postnummer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Adresses", "ByPostNummer_Postnummer", "dbo.ByPostNummers");
            DropIndex("dbo.Adresses", new[] { "ByPostNummer_Postnummer" });
            RenameColumn(table: "dbo.Adresses", name: "ByPostNummer_Postnummer", newName: "PostNummer");
            AlterColumn("dbo.Adresses", "PostNummer", c => c.Int(nullable: true));
            CreateIndex("dbo.Adresses", "PostNummer");
            AddForeignKey("dbo.Adresses", "PostNummer", "dbo.ByPostNummers", "Postnummer", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Adresses", "PostNummer", "dbo.ByPostNummers");
            DropIndex("dbo.Adresses", new[] { "PostNummer" });
            AlterColumn("dbo.Adresses", "PostNummer", c => c.Int());
            RenameColumn(table: "dbo.Adresses", name: "PostNummer", newName: "ByPostNummer_Postnummer");
            CreateIndex("dbo.Adresses", "ByPostNummer_Postnummer");
            AddForeignKey("dbo.Adresses", "ByPostNummer_Postnummer", "dbo.ByPostNummers", "Postnummer");
        }
    }
}
