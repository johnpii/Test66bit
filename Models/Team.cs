namespace Test66bit.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Footballer> Footballers { get; } = new List<Footballer>();
    }
}
