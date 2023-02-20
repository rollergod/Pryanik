using System.Text.Json.Serialization;

namespace Pryanik.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }
    }
}
