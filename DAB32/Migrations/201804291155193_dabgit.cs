namespace DAB32.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dabgit : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Adresses", "postID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adresses", "postID", c => c.Int(nullable: false));
        }
    }
}
