namespace esbas_internship_backendproject.Entities
{ 
   using System.ComponentModel.DataAnnotations;
   using System.ComponentModel.DataAnnotations.Schema;


   public class Main_Characteristicts
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
