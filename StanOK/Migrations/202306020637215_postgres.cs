namespace StanOK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postgres : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Machines",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        machine_type = c.String(),
                        country = c.String(),
                        brand = c.String(),
                        year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.repair",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        machine_type = c.Int(nullable: false),
                        repair_type = c.Int(nullable: false),
                        date_begin = c.DateTime(nullable: false),
                        comment = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.Machines", t => t.machine_type, cascadeDelete: true)
                .ForeignKey("public.repair_types", t => t.repair_type, cascadeDelete: true)
                .Index(t => t.machine_type)
                .Index(t => t.repair_type);
            
            CreateTable(
                "public.repair_types",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        repair_name = c.String(),
                        duration = c.DateTime(nullable: false),
                        cost = c.Int(nullable: false),
                        comment = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.users",
                c => new
                    {
                        login = c.String(nullable: false, maxLength: 128),
                        password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.login);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.repair", "repair_type", "public.repair_types");
            DropForeignKey("public.repair", "machine_type", "public.Machines");
            DropIndex("public.repair", new[] { "repair_type" });
            DropIndex("public.repair", new[] { "machine_type" });
            DropTable("public.users");
            DropTable("public.repair_types");
            DropTable("public.repair");
            DropTable("public.Machines");
        }
    }
}
