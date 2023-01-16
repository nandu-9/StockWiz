namespace API.Entities
{
    public class Trade
    {
        public int Id { get; set; }
        public string CompanySym { get; set; }
        public int Volume { get; set; }
        public DateTime TimeStamp { get; set; }

        // Navigation properties
        public string UserName { get; set; }
    }
}
