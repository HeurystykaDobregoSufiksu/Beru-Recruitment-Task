namespace BeruTask.Server.Models
{
    public class GoldPriceModel
    {
        public int Id { get; set; }

        public double StartPrice { get; set; }

        public double EndPrice { get; set; }

        public double AvgPrice { get; set; }

        public DateTime SaveDate { get; set; }
    }
}
