namespace StanOK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postgres11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("public.Machines", "RepairModel_Id", "public.repair");
            DropForeignKey("public.repair_types", "RepairModel_Id", "public.repair");
            DropIndex("public.Machines", new[] { "RepairModel_Id" });
            DropIndex("public.repair_types", new[] { "RepairModel_Id" });
            CreateIndex("public.repair", "machine_type");
            CreateIndex("public.repair", "repair_type");
            AddForeignKey("public.repair", "machine_type", "public.Machines", "id", cascadeDelete: true);
            AddForeignKey("public.repair", "repair_type", "public.repair_types", "id", cascadeDelete: true);
            DropColumn("public.Machines", "RepairModel_Id");
            DropColumn("public.repair_types", "RepairModel_Id");
        }
        
        public override void Down()
        {
            AddColumn("public.repair_types", "RepairModel_Id", c => c.Int());
            AddColumn("public.Machines", "RepairModel_Id", c => c.Int());
            DropForeignKey("public.repair", "repair_type", "public.repair_types");
            DropForeignKey("public.repair", "machine_type", "public.Machines");
            DropIndex("public.repair", new[] { "repair_type" });
            DropIndex("public.repair", new[] { "machine_type" });
            CreateIndex("public.repair_types", "RepairModel_Id");
            CreateIndex("public.Machines", "RepairModel_Id");
            AddForeignKey("public.repair_types", "RepairModel_Id", "public.repair", "id");
            AddForeignKey("public.Machines", "RepairModel_Id", "public.repair", "id");
        }
    }
}
