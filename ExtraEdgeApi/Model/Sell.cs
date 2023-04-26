using System.ComponentModel.DataAnnotations;

namespace ExtraEdgeApi.Model
{
    public class Sell
    {
        public int SellId { get; set; }
        public int CustomerId { get; set; }
        public Mobile Mobile { get; set; }
        public DateTime SellDate { get; set; }
        public int SellPrice { get; set; }
        public int Discount { get; set; }
        public int FinalPrice { get; set; }
    }
}
