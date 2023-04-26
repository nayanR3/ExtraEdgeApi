using System.ComponentModel.DataAnnotations;

namespace ExtraEdgeApi.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Phone { get; set; }


    }
}
