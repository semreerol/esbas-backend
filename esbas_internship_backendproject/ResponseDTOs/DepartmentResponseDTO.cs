using System.ComponentModel.DataAnnotations.Schema;

namespace esbas_internship_backendproject.ResponseDTOs
{
    public class DepartmentResponseDTO
    {
#nullable disable
        public string Name { get; set; }

        [ForeignKey("CostCenterID")]
        public int CostCenterID { get; set; }

        [ForeignKey("TaskID")]
        public int TaskID { get; set; }
       
    }
}
