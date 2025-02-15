using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gordeszka_sim
{
    internal class Trick
    {
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public int Points { get; set; }
        public int Injury { get; set; }

        public Trick(string name, int difficulty, int points, int injury)
        {
            Name = name;
            Difficulty = difficulty;
            Points = points;
            Injury = injury;
        }
    }
}
