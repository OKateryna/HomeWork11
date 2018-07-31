namespace HomeWork11.Models.Ticket
{
    public class Ticket : Entity
    {
        public double Price { get; set; }
        public Flight.Flight Flight { get; set; }
    }
}