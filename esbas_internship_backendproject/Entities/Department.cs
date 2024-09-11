using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace esbas_internship_backendproject.Entities
{
    public class Department
    {
#nullable disable
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int DepartmentID { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; } = true;

        [ForeignKey("CostCenterID")]
        public int CostCenterID { get; set; }

        [ForeignKey("TaskID")]
        public int TaskID { get; set; }

        public CostCenters CostCenters { get; set; }

        public Taskk Task { get; set; }
       
    }
}
