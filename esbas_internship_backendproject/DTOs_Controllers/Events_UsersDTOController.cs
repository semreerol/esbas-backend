using esbas_internship_backendproject.DTOs;
using esbas_internship_backendproject.ResponseDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using esbas_internship_backendproject.Entities;
using AutoMapper;
using Microsoft.Extensions.Logging;


namespace esbas_internship_backendproject.DTOs_Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Events_UsersDTOController : ControllerBase
    {
        private readonly EsbasDbContext _context;
        private readonly IMapper _mapper;
        public Events_UsersDTOController(EsbasDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetEventsUsers()
        {
            var eventsusers = _context.Events_Users
     .Include(eu => eu.Event)
         .ThenInclude(e => e.Event_Location)

     .Include(eu => eu.Event)
         .ThenInclude(e => e.Event_Type)

     .Include(eu => eu.User)
         .ThenInclude(u => u.User_Gender)
        
     .Include(eu => eu.User)
         .ThenInclude(u => u.Main_Characteristicts)
   
     .Include(eu => eu.User)
         .ThenInclude(u => u.Other_Characteristicts)

     .Include(eu => eu.User)
       
            .ThenInclude(u => u.Department)
             .ThenInclude(d => d.CostCenters)
     .Include(eu => eu.User)
         .ThenInclude(u => u.Department)
          //   .ThenInclude(d => d.Task)
     .Where(eu => eu.Status == true)
     .OrderBy(eu => eu.Event.EventID) // Sorting by EventID
     .ToList();



            var groupedEventUsers = eventsusers
                .GroupBy(eu => eu.Event.EventID)
                
                .Select(g => new
                {
                    ID = g.First().ID, // İlk öğeden ID'yi alıyoruz.
                    Status = g.First().Status, // İlk öğeden Status'u alıyoruz.
                    Event = _mapper.Map<EventDTO>(g.First().Event),// İlk kullanıcıdan etkinlik bilgilerini alır(zaten tüm kullanıcılar aynı etkinlikte olduğundan sorun olmaz).
                    User = g.Select(eu => _mapper.Map<UserDTO>(eu.User)).ToList()//Her grup için kullanıcıları listeler
                })
                .ToList();

            return Ok(groupedEventUsers);
        }


        [HttpGet("{eventid}")]
        [Produces("application/json")]
        public IActionResult GetEventsUserByID(int eventid)
        {

            var eventsusers = _context.Events_Users
              .Include(eu => eu.Event)
                  .ThenInclude(e => e.Event_Location)

              .Include(eu => eu.Event)
                  .ThenInclude(e => e.Event_Type)

              .Include(eu => eu.User)
                  .ThenInclude(u => u.User_Gender)

              .Include(eu => eu.User)
                  .ThenInclude(u => u.Main_Characteristicts)

              .Include(eu => eu.User)
                  .ThenInclude(u => u.Other_Characteristicts)

              .Include(eu => eu.User)

                     .ThenInclude(u => u.Department)
                      .ThenInclude(d => d.CostCenters)
              .Include(eu => eu.User)
                  .ThenInclude(u => u.Department)
                      //.ThenInclude(d => d.Task)
              .ToList();


            var groupedEventUsersById = eventsusers
            .Where(eu => eu.EventID == eventid) // Belirli bir EventID'ye göre filtreleme yapıyoruzz
            .GroupBy(eu => eu.Event.EventID)
            .Select(g => new
             {
             ID = g.First().ID, // İlk öğeden ID'yi alıyoruz.
             Status = g.First().Status, // İlk öğeden Status'u alıyoruz.
             Event = _mapper.Map<EventDTO>(g.First().Event), // İlk öğeden etkinlik bilgilerini alıyoruz.
             User = g.Select(eu => _mapper.Map<UserDTO>(eu.User)).ToList() // Her grup için kullanıcıları listeliyoruz.
             })

            .FirstOrDefault(); 

            return Ok(groupedEventUsersById);
        }


         [HttpPost()]
         [Produces("application/json")]
         public IActionResult CreateEventsUsersMap([FromBody] EventsUsersResponseDTO eventsUsersResponseDTO)
         {
             if (eventsUsersResponseDTO == null || !ModelState.IsValid)
             {
                 return BadRequest(ModelState); 
             }

           var event_UsersResponse = _mapper.Map<Events_Users>(eventsUsersResponseDTO);

            Console.WriteLine($"Mapped EventID: {event_UsersResponse.EventID}, Mapped CardID: {event_UsersResponse.CardID}");

            _context.Events_Users.Add(event_UsersResponse);
             _context.SaveChanges();

             return Ok(event_UsersResponse);
         }
     


        [HttpPut("{id}")]
        [Produces("application/json")]
        public IActionResult UpdateEventsUsers(int id, [FromBody] EventsUsersResponseDTO eventsUsersResponseDTO)
        {
            if (eventsUsersResponseDTO == null)
            {
                return BadRequest();
            }

            var eventsUsersResponse = _context.Events_Users.FirstOrDefault(eu => eu.ID == id);

            if (eventsUsersResponse == null)
            {
                return NotFound();
            }

            eventsUsersResponse.EventID = eventsUsersResponseDTO.EventID;
            eventsUsersResponse.CardID = eventsUsersResponseDTO.CardID;
          
       
            _context.SaveChanges();

            return Ok(eventsUsersResponse);
        }

        [HttpDelete("SoftDelete/{eventID}/{cardID}")]
        [Produces("application/json")]
        public IActionResult SoftDeleteEventsUsers(int eventID, int cardID)
        {
            var eventsUsers = _context.Events_Users.FirstOrDefault(eu => eu.EventID == eventID && eu.CardID == cardID );

            if (eventsUsers == null)
            {
                return NotFound();
            }

            eventsUsers.Status = false;


            _context.Events_Users.Update(eventsUsers);
            _context.SaveChanges();

            return NoContent();
        }
    }

  }
