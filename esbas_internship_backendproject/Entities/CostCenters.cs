using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace esbas_internship_backendproject.Entities
{
    public class CostCenters
    {
#nullable disable
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CostCenterID { get; set; }

        public string Name { get; set; }

        public decimal Budget {  get; set; }

        public bool Status { get; set; } = true;

    }
}
