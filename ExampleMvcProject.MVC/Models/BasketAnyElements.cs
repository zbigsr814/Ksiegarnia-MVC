using ExampleMvcProject.MVC.Entities;

namespace ExampleMvcProject.MVC.Models
{
    public class BasketAnyElements
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Ebook> Ebooks { get; set; } = new List<Ebook>();
        public List<Audiobook> Audiobooks { get; set; } = new List<Audiobook>();
        public List<Music> Musics { get; set; } = new List<Music>();
        public List<Film> Films { get; set; } = new List<Film>();
        public List<Game> Games { get; set; } = new List<Game>();
    }
}
