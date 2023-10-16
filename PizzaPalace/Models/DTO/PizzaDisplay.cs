namespace PizzaPalace.Models.DTO
{
    public class PizzaDisplay
    {
        public IEnumerable<Pizza>  Pizza { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public string STerm { get; set; } = "";
        public int CategoryId { get; set; } = 0;
    }
}
