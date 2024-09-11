using System.ComponentModel.DataAnnotations.Schema;

namespace esbas_internship_backendproject.ResponseDTO
{
    public class EventResponseDTO
    {
#nullable disable
        public string Name { get; set; }
        public DateTime EventDateTime { get; set; }

        [ForeignKey("L_ID")]
        public int L_ID { get; set; }

        [ForeignKey("T_ID")]
        public int T_ID { get; set; }
       
    }
}
