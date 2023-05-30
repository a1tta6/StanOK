using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using StanOK.Models;
using StanOK.Authorization.Model;

namespace StanOK.Utils
{
    public class UserContext : DbContext
    {
        public DbSet<RepairTypeModel> RepairTypes { get; set; }
        public DbSet<MachineModel> Machines { get; set; }
        public DbSet<LoginModel> Users { get; set; }
        public DbSet<RepairModel> Repairs { get; set; }

        public UserContext()
            : base(nameOrConnectionString: "PGConnectionString")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);

            //Users.Add(new LoginModel { Login = "TEST", Role = "TEST", Password = "TEST" });
            //RepairTypes.Add(
            //    new RepairTypeModel
            //    {
            //        Id = 0,
            //        Repair_name = "Мелкий ремонт",
            //        Cost = 300,
            //        Comment = "Ремонт малой продолжительности",
            //        Duration = DateTime.UtcNow
            //    }
            //);
            //Machines.Add(new MachineModel { Id = 0, Year = DateTime.UtcNow, Brand = "KSKSK", MachineType = "sada", Country = "afasf" });
            //Repairs.Add(new RepairModel { Id = 0, MachineType = 0, Comment = "safas", DateBegin = DateTime.UtcNow, RepairType = 0 });

        }
    }
}
