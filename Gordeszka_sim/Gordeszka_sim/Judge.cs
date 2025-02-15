using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gordeszka_sim
{
    internal class Judge
    {
        public string Name { get; set; }
        public int Strictness { get; set; }
        public Judge(string name, int strictness)
        {
            Name = name;
            Strictness = strictness;
        } 
    }
}
