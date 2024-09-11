namespace esbas_internship_backendproject.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Events
    {
#nullable disable
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int EventID { get; set; }

        [ForeignKey("L_ID")]
        public int L_ID { get; set; }

        [ForeignKey("T_ID")]
        public int T_ID { get; set; }
       
        public string Name { get; set; }

        public DateTime EventDateTime { get; set; } = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);

        public bool Status { get; set; } = true;
        public bool Event_Status { get; set; } = true;

        public Event_Location Event_Location { get; set; }

        public Event_Type Event_Type { get; set; }

        public Events() { }
    }
}

