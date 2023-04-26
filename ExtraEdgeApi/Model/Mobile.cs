using System.ComponentModel.DataAnnotations;

namespace ExtraEdgeApi.Model
{
    public class Mobile
    {
        public int MobileId { get; set; }
        public string? Model { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
