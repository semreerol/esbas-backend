namespace esbas_internship_backendproject.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class CostCentersDTO
    {
#nullable disable
     [Key]
     [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

         public int CostCenterID { get; set; }

        public string Name { get; set; }

        public decimal Budget { get; set; }

        public bool Status { get; set; } = true;
    }
}
