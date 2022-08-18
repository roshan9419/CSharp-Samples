using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListCol
{
    internal class Country
    {
        public Country(int name, int population)
        {
            Name = name;
            Population = population;
        }

        public int Name { get; }
        public int Population { get;  }
    }
}
