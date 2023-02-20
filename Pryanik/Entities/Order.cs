namespace Pryanik.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int Number { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
