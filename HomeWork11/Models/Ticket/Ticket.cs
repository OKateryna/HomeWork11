namespace HomeWork11.Models.Ticket
{
    public class Ticket
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public Flight.Flight Flight { get; set; }
    }
}