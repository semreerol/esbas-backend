using System.ComponentModel.DataAnnotations.Schema;

namespace esbas_internship_backendproject.ResponseDTO
{
    public class EventsUsersResponseDTO
    {
#nullable disable

        [ForeignKey("EventID")]
        public int EventID { get; set; }

        [ForeignKey("CardID")]
        public int CardID  { get; set; }
    }
}
