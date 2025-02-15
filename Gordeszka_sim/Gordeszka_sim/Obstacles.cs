using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gordeszka_sim
{
    internal class Obstacles
    {
        public string Type { get; set; }
        public int Difficulty { get; set; }
        public Obstacles(string type, int difficulty)
        {
            Type = type;
            Difficulty = difficulty;
        }
    }
}
