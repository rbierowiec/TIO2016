namespace Zad6b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookPageCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Books", "pageCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("public.Books", "pageCount");
        }
    }
}
