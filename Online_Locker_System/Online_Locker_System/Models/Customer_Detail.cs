using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

namespace Online_Locker_System.Models
{
    public class Customer_Detail
    {
        [Key] public int User_Id { get; set; }
        public string Name { get; set; }
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        //[RegularExpression("^[0-9]{10}$",ErrorMessage ="Mobile Number is not valid")]
        public string Phone { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$",ErrorMessage ="Password is not valid")]
        public string Password { get; set; }
        public bool Locker_Status { get; set; } = false;
    }
}
