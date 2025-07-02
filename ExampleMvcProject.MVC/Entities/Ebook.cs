namespace ExampleMvcProject.MVC.Entities
{
    public class Ebook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string? EbookType { get; set; }
        public string ImagePath { get; set; }
        public int Quantity { get; set; }
    }
}
