using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kNN
{
    public class IndexAndDistace : IComparable<IndexAndDistace>
    {
        public int idx;
        public double dist;

        public int CompareTo(IndexAndDistace other)
        {
            if (this.dist < other.dist) return -1;
            else if (this.dist > other.dist) return +1;
            else return 0;
        }

    }
}
