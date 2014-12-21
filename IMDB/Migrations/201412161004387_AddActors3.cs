namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActors3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Actors", "MovieId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Actors", "MovieId", c => c.Int(nullable: false));
        }
    }
}
