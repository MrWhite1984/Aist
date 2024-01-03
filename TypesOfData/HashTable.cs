using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aist.TypesOfData
{
    public class HashTable
    {
        public Dictionary<int, (int, int)> Hashes;
        public HashTable()
        {
            Hashes = new Dictionary<int, (int, int)>();
        }

    }
}
