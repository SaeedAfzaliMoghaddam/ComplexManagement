using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Entities
{
    public class Complex
    {
        public Complex()
        {
            Blocks= new HashSet<Block>();
        }

        public string Name { get; set; }
        public int Id { get; set; }
        public int UnitCount { get; set; }
        public HashSet<Block> Blocks { get; set; }
        
    }
}
