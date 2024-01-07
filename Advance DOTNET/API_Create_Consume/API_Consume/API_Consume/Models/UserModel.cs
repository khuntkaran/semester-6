using System.ComponentModel.DataAnnotations;

namespace API_Consume.Models
{
    public class UserModel
    {
        public int? EmpID { get; set; }
        [Required]
        public string EmpName { get; set; }
        [Required]
        public string EmpCode { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public double? Salary { get; set; }

    }
}
