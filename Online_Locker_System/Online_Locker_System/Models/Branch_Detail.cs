using System.ComponentModel.DataAnnotations;

namespace Online_Locker_System.Models
{

    public class Branch_Detail
    {
        [Key] public int Branch_Id { get; set; }
        public string Branch_Name { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public int Total_locker { get; set; }
        public int Available_Locker { get; set; }
    }
}
