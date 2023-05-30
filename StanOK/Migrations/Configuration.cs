namespace StanOK.Migrations
{
    using StanOK.Authorization.Model;
    using StanOK.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StanOK.Utils.UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StanOK.Utils.UserContext context)
        {
            context.Users.Add(new LoginModel { Login = "TEST", Role = "TEST", Password = "TEST" });
            context.RepairTypes.Add(
                new RepairTypeModel
                {
                    Id = 1,
                    Repair_name = "Мелкий ремонт",
                    Cost = 5600,
                    Comment = "Ремонт малой продолжительности, c которым может справиться один мастер в течение рабочей смены",
                    Duration = DateTime.Parse("00.00.00 4:00")
                }
            );
            context.Machines.Add(new MachineModel { Id = 0, Year = DateTime.UtcNow, Brand = "KSKSK", MachineType = "sada", Country = "afasf" });
            context.Repairs.Add(new RepairModel { Id = 0, MachineType = 0, Comment = "safas", DateBegin = DateTime.UtcNow, RepairType = 0 });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
