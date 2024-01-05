using System.ComponentModel.DataAnnotations;

namespace TruckTransportManegment.Areas.MainPages.Models
{
    public class GoodsTypeModel
    {
        public int? GoodsTypeID { get; set; }
        [Required]
        public string GoodsTypeName { get; set; }
        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}
