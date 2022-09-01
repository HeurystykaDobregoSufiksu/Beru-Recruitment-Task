namespace BeruTask.Server.DTOs
{
    public class GoldPriceJsonDto
    {
        public double StartPrice { get; set; }
        public double EndPrice { get; set; }
        public double AvgPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime SaveDate { get; set; }
    }
}
