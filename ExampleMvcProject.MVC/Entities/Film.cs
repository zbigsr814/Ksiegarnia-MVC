namespace ExampleMvcProject.MVC.Entities
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string FilmType { get; set; }
        public string ImagePath { get; set; }
        public int Quantity { get; set; }
    }
}
