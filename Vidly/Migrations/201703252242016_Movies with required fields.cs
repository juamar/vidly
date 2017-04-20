namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Movieswithrequiredfields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "name", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime());
            AlterColumn("dbo.Movies", "name", c => c.String());
        }
    }
}
