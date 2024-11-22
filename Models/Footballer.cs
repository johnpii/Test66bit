using Test66bit.Enums;

namespace Test66bit.Models
{
    public class Footballer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; } = null!;

        public Country Country { get; set; }
    }
}
