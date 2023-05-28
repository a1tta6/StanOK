namespace StanOK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postgres1 : DbMigration
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
                        year = c.DateTime(nullable: false),
                        RepairModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.repair", t => t.RepairModel_Id)
                .Index(t => t.RepairModel_Id);
            
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
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.repair_types",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        repair_name = c.String(),
                        duration = c.DateTime(nullable: false),
                        cost = c.Int(nullable: false),
                        comment = c.String(),
                        RepairModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.repair", t => t.RepairModel_Id)
                .Index(t => t.RepairModel_Id);
            
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
            DropForeignKey("public.repair_types", "RepairModel_Id", "public.repair");
            DropForeignKey("public.Machines", "RepairModel_Id", "public.repair");
            DropIndex("public.repair_types", new[] { "RepairModel_Id" });
            DropIndex("public.Machines", new[] { "RepairModel_Id" });
            DropTable("public.users");
            DropTable("public.repair_types");
            DropTable("public.repair");
            DropTable("public.Machines");
        }
    }
}
