using Dapper.Contrib.Extensions;

namespace BookClubApp.Models
{
    [Table("person")]
    public class Person
    {
        [Key]
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }
}
