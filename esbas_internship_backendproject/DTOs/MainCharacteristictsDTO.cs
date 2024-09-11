namespace esbas_internship_backendproject.DTOs
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class MainCharacteristictsDTO
    {
#nullable disable
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int MC_ID { get; set; }

        public string WorkingMethod { get; set; }

        public string IsOfficeEmployee { get; set; }

        public string TypeOfHazard { get; set; }

        public bool Status { get; set; } = true;

    }
}
