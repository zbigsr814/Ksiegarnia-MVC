using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleMvcProject.Domain.Entities
{
    public class Bookstore
    {
        public required int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime CreateAt { get; set; }
        public BookstoreContactDetails contactDetails { get; set; } = default!;

        public string EncodedName { get; private set; } = default!;

        public void EncodeName() => EncodedName = Name.ToLower().Replace(" ", "-");
    }
}
