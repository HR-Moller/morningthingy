using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThoughtfulDining
{
    public class Chopstick
    {
        public int Id { get; set; }
        public bool IsFree { get; set; }

        public Chopstick (int id)
        {
            Id = id;
            IsFree = true;
        }
    }
}
