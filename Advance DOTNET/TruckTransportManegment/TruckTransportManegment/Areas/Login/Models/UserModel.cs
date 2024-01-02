using System.ComponentModel.DataAnnotations;


namespace TruckTransportManegment.Areas.Login.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        [Required] 
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

    }
}
