namespace esbas_internship_backendproject.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public class Other_Characteristicts
    {
#nullable disable
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int OC_ID { get; set; }

        public string EducationalStatus { get; set; }

        public bool Status { get; set; } = true;
    }
}

