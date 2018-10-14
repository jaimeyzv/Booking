using System.ComponentModel.DataAnnotations;

namespace Stamping.Api.Models
{
    public class MobileModel
    {
        public int MobileId { get; set; }
        //[Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        //[Required(ErrorMessage = "Imei is required")]
        public string Imei { get; set; }
        public bool IsActive { get; set; }
    }
}