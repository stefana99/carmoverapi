namespace CarMoverApi.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public User User { get; set; }
    }
}