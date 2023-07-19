using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagement1.Entities
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BlockId { get; set; }
        public Block Block { get; set; }
        public ResidenseType ResidenseType { get; set; }
    }

    public enum ResidenseType
    {
        empty = 1,
        owner = 2,
        tenent = 3
    }
}

