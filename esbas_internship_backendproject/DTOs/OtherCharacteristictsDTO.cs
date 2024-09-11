namespace esbas_internship_backendproject.DTOs
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    public class OtherCharacteristictsDTO
    {
#nullable disable
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int OC_ID { get; set; }

        public string EducationalStatus { get; set; }

        public bool Status { get; set; } = true;
    }
}
