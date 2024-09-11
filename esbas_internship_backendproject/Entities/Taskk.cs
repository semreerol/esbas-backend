namespace esbas_internship_backendproject.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Taskk
    {
#nullable disable 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int TaskID { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; } = true;
    }
}
