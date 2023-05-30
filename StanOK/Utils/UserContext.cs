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
        }
    }
}
