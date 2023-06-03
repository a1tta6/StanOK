using StanOK.Models;
using StanOK.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanOK.Benches.ViewModel
{
    public class BenchesViewModel
    {
        UserContext context = new UserContext();

        public List<MachineModel> BenchesList => context.Machines.ToList();
    }
}
