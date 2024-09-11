using System.ComponentModel.DataAnnotations.Schema;

namespace esbas_internship_backendproject.ResponseDTO
{
    public class UserResponseDTO
    {
#nullable disable

        public int CardID { get; set; }
        public string UserRegistrationID { get; set; }
        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string MailAddress { get; set; }

        public DateTime HireDate { get; set; }

        public string PhoneNumber { get; set; }

        [ForeignKey("G_ID")]
        public int G_ID { get; set; }

        [ForeignKey("MC_ID")]
        public int MC_ID { get; set; }

        [ForeignKey("OC_ID")]
        public int OC_ID { get; set; }

        [ForeignKey("DepartmentID")]
        public int DepartmentID { get; set; }
      
    }
}
