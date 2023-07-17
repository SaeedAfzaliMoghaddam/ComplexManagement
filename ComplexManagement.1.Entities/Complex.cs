namespace ComplexManagement1.Entities
{
    public class Complex
    {
        public Complex()
        {
            Blocks = new List<Block>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitCount { get; set; }
        public List<Block> Blocks { get; set; }

    }
}