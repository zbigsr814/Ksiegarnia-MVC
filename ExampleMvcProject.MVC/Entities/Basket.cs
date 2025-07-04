using Microsoft.AspNetCore.Identity;

namespace ExampleMvcProject.MVC.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public string MediaType { get; set; }
        public int Count { get; set; }
        public int MediaId { get; set; }

        public string? OwnerId { get; set; }
        public IdentityUser? Owner { get; set; }
    }
}
