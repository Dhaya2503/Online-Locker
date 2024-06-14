using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Locker_System.Models
{
    public class Requested_Locker
    {
       [Key]
        public int Request_Id { get; set; }
       public int User_Id { get; set; }
        public string User_Name { get; set;}
        public string User_Email { get; set;}
        public int Branch_Id { get; set; }
        public string Branch_Name { get; set;}
        
    }
}
