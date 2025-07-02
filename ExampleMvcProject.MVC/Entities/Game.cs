namespace ExampleMvcProject.MVC.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string GameType { get; set; }
        public string? ImagePath { get; set; }
        public int Quantity { get; set; }
    }
}
