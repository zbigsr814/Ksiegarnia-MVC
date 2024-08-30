namespace ExampleMvcProject.MVC.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string? BookType { get; set; }
        public string ImagePath { get; set; }
        public int Quantity { get; set; }
    }
}