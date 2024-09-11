namespace esbas_internship_backendproject.DTOs
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    public class TasksDTO
    {
#nullable disable
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int TaskID { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; } = true;
    }
}
