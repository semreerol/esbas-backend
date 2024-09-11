namespace esbas_internship_backendproject.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Users
    {
#nullable disable
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public string UserRegistrationID { get; set; }
        public int CardID { get; set; }

       [ForeignKey("G_ID")]
        public int G_ID { get; set; }

        [ForeignKey("MC_ID")]
        public int MC_ID { get; set; }

        [ForeignKey("OC_ID")]
        public int OC_ID { get; set; }
      
        [ForeignKey("DepartmentID")]
        public int DepartmentID { get; set; }
      
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string MailAddress { get; set; }

        public DateTime HireDate { get; set; }

        public string PhoneNumber { get; set; }
        public bool Status { get; set; } = true;

        public User_Gender User_Gender { get; set; }
        public Main_Characteristicts Main_Characteristicts { get; set; }
        public Other_Characteristicts Other_Characteristicts { get; set; }
        public Department Department { get; set; }
        
        public Users() { }
    }
}
