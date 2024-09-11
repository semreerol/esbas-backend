using esbas_internship_backendproject.DTOs;
using esbas_internship_backendproject.ResponseDTO;
using Microsoft.AspNetCore.Mvc;
using esbas_internship_backendproject.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace esbas_internship_backendproject.DTOs_Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EventsDTOController : ControllerBase
    {
        private readonly EsbasDbContext _context;
        private readonly IMapper _mapper;
        public EventsDTOController(EsbasDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetEvents()
        {
            var events = _context.Events
                .Include(e => e.Event_Type)
                .Include(e => e.Event_Location)
                .Where(e => e.Status == true)
                .Select(e => _mapper.Map<EventDTO>(e))
                .ToList();

            return Ok(events);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public IActionResult GetEventByID(int id)
        {
            var events = _context.Events
               .Include(e => e.Event_Type)
                .Include(e => e.Event_Location)
                 .Where(e => e.EventID == id)
                .Where(e => e.Status == true )
                .Select(e => _mapper.Map<EventDTO>(e))
                .FirstOrDefault();

            if (events == null)
            {
                return NotFound();
            }

            return Ok(events);
        }

        [HttpGet("status/{eventStatus}")]
        [Produces("application/json")]
        public IActionResult GetEventByStatus(bool eventStatus)
        {
            var events = _context.Events
                .Where(e => e.Event_Status == eventStatus)
                .Select(e => _mapper.Map<EventDTO>(e))
                .ToList();

            if (events.Count == 0)
            {
                return NotFound();
            }

            return Ok(events);
        }

        [HttpPost]
        [Produces("application/json")]
        public IActionResult CreateEvents([FromBody] EventResponseDTO eventResponseDTO)
        {
            if (eventResponseDTO == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventsResponse = _mapper.Map<Events>(eventResponseDTO);

            _context.Events.Add(eventsResponse);
            _context.SaveChanges();

            return Ok(eventsResponse);
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        public IActionResult UpdateEvents(int id, [FromBody] EventResponseDTO eventResponseDTO )
        {
            if (eventResponseDTO == null)
            {
                return BadRequest();
            }

            var eventsResponse = _context.Events.FirstOrDefault(e => e.EventID == id);

            if (eventsResponse == null)
            {
                return NotFound();
            }
            var eventLocation = _context.Event_Location.FirstOrDefault(l => l.L_ID == eventResponseDTO.L_ID);
            if (eventLocation == null)
            {
                return NotFound($"Event Location with ID {eventResponseDTO.L_ID} not found.");
            }

            // T_ID'ye karşılık gelen Event_Type nesnesini al
            var eventType = _context.Event_Type.FirstOrDefault(t => t.T_ID == eventResponseDTO.T_ID);
            if (eventType == null)
            {
                return NotFound($"Event Type with ID {eventResponseDTO.T_ID} not found.");
            }

            // Event nesnesini güncelle
            eventsResponse.Name = eventResponseDTO.Name;
            eventsResponse.Event_Location = eventLocation; // Doğrudan ilgili nesneyi ata
            eventsResponse.Event_Type = eventType;         // Doğrudan ilgili nesneyi ata
            eventsResponse.EventDateTime = eventResponseDTO.EventDateTime;
            

            _context.SaveChanges();

             return Ok(eventsResponse);
        }

        [HttpDelete("SoftDelete_Status{id}")]
        [Produces("application/json")]
        public IActionResult SoftDeleteEventsByStatus(int id)
        {
            var events = _context.Events.FirstOrDefault(e => e.EventID == id);

            if (events == null)
            {
                return NotFound();
            }


            events.Status = false;


            _context.Events.Update(events);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("SoftDelete_EventStatus{id}")]
        [Produces("application/json")]
        public IActionResult SoftDeleteEventsbyEventStatus(int id)
        {
            var events = _context.Events.FirstOrDefault(e => e.EventID == id);

            if (events == null)
            {
                return NotFound();
            }


            events.Event_Status = false;


            _context.Events.Update(events);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
