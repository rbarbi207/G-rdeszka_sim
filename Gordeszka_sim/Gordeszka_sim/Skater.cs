using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gordeszka_sim
{
    internal class Skater
    {
        public string Name { get; set; }
        public int Skill { get; set; }
        public int Score { get; set; }
        public List<Trick> tricks { get; set; }
        public Skater(string name, int skill)
        {
            Name = name;
            Skill = skill;
            Score = 0;
            tricks = new List<Trick>();
        }

    }
}

