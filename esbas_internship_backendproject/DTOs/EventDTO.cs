namespace esbas_internship_backendproject.DTOs
{
  
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class EventDTO
    {
#nullable disable
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventID { get; set; }
        public string Name { get; set; }
        public DateTime EventDateTime { get; set; }
        public bool Status { get; set; } = true;
        public bool Event_Status { get; set; }

        public EventLocationDTO Event_Location { get; set; }

        public EventTypeDTO Event_Type { get; set; }
    }
}
