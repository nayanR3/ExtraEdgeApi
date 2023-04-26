namespace ExtraEdgeApi.Model
{
    public class ProfitLossReport
    {
        public DateTime CurrentFromDate { get; set; }
        public DateTime CurrentToDate { get; set; }
        public int CurrentProfit { get; set; }
        public DateTime PreviousFromDate { get; set; }
        public DateTime PreviousToDate { get; set; }
        public int PreviousProfit { get; set; }
    }

}
