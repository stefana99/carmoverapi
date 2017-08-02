namespace CarMoverApi.Models
{
    public class Car
    {
        private string _plate;
        public int Id { get; set; }
        public string Plate { get => _plate ; set => _plate = value.ToUpper().Trim().Replace("-","").Replace(" ","");  }
        public User User { get; set; }
    }
}