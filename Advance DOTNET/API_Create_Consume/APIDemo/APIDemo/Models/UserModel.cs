namespace APIDemo.Models
{
    public class UserModel
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpCode { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public double Salary { get; set; }



        public string ProductName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string ConfirmPassword { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public int Price { get; set; }

        public int Discount { get; set; }

        public int StockCount { get; set; }

    }
}
