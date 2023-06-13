using StanOK.Models;
using StanOK.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace StanOK.Repair.ViewModel
{
    public class RepairViewModel
    {
        string Type;
        public UserContext context = new UserContext();
        public RepairTypeModel Repair => context.RepairTypes.First(x => x.Repair_name == Type);
        public bool IsReadOnly { get; set; }
        public bool CanEdit { get; set; }
        public RepairViewModel(string type)
        {
            Type = type;
            IsReadOnly = true;
        }
        public void Changing()
        {
            context.SaveChanges();
        }

    }
}
