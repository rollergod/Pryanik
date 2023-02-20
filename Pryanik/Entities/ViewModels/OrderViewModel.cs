namespace Pryanik.Entities.ViewModels
{
    public class OrderViewModel
    {
        public int Number { get; set; }
        public IEnumerable<int>? itemIds { get; set; }
    }
}
