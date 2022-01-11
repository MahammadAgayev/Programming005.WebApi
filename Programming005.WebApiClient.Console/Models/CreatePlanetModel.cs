using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming005.WebApiClient.ConsoleUI.Models
{
    public class CreatePlanetModel
    {
        public string Name { get; set; }
        public bool HasWater { get; set; }
        public string PlenatarySystem { get; set; }
        public bool Livable { get; set; }
    }
}
