namespace StanOK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postgres : DbMigration
    {
        public override void Up()
        {
            AlterColumn("public.Machines", "year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("public.Machines", "year", c => c.DateTime(nullable: false));
        }
    }
}
