using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gordeszka_sim
{
    internal class Record
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public Record(string name, int points)
        {
            Name = name;
            Points = points;
        }

        public override string ToString()
        {
            return $"{Name}: {Points} pont";
        }
    }
}
