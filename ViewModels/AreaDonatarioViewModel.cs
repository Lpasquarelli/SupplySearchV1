using SupplySearchV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupplySearchV1.ViewModels
{
    public class AreaDonatarioViewModel
    {
        public List<Doacoes> doacoes { get; set; }
        public Donatario donatario { get; set; }
    }
}
