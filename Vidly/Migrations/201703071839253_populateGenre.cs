namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres Values (1,'Romance')");
            Sql("Insert into Genres Values (2,'Thriller')");
            Sql("Insert into Genres Values (3,'Comedy')");
            Sql("Insert into Genres Values (4,'Action')");
            Sql("Insert into Genres Values (5,'Family')");
        }
        
        public override void Down()
        {

        }
    }
}
