using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner
{
    class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Tip Tip { get; set; }

        public int Number { get; set; }

        public ColorCell Color { get; set; }

        public Cell(int x, int y, Tip tip)
        {
            X = x;
            Y = y;
            Tip = tip;
        }
    }
}
