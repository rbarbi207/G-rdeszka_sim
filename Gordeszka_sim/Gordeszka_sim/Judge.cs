using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using static System.Formats.Asn1.AsnWriter;

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

        public int Rating(Trick trick)
        {
            float score = 0;

            Random rand = new Random();
            if (Strictness <= 1)
            {
                score = trick.Points / 100f * (rand.Next(80, 101));
            }
            else if (Strictness <= 3)
            {
                score = trick.Points / 100f * (rand.Next(65, 101));
            }
            else if (Strictness <= 5)
            {
                score = trick.Points / 100f * (rand.Next(50, 101));
            }
            return (int)(score);
        }
    }
}
