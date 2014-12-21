namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActors2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Actors", "MovieId", "dbo.Movies");
            DropIndex("dbo.Actors", new[] { "MovieId" });
            CreateTable(
                "dbo.ActorMovies",
                c => new
                    {
                        Actor_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Actor_Id, t.Movie_Id })
                .ForeignKey("dbo.Actors", t => t.Actor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Actor_Id)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActorMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.ActorMovies", "Actor_Id", "dbo.Actors");
            DropIndex("dbo.ActorMovies", new[] { "Movie_Id" });
            DropIndex("dbo.ActorMovies", new[] { "Actor_Id" });
            DropTable("dbo.ActorMovies");
            CreateIndex("dbo.Actors", "MovieId");
            AddForeignKey("dbo.Actors", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
        }
    }
}
