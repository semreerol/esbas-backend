using AutoMapper;
using esbas_internship_backendproject.DTOs;
using esbas_internship_backendproject.Entities;
using esbas_internship_backendproject.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace esbas_internship_backendproject.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MainCharacteristictsDTOController : ControllerBase
    {

        private readonly EsbasDbContext _context;
        private readonly IMapper _mapper;
        public MainCharacteristictsDTOController(EsbasDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetCMainCharacteristicts()
        {
            var maincharacteristicts = _context.Main_Characteristicts
                .Where(mc => mc.Status == true)
                .Select(mc => _mapper.Map< MainCharacteristictsDTO>(mc))
                .ToList();

            return Ok(maincharacteristicts);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public IActionResult GetMainCharacteristictByID(int id)
        {
            var maincharacteristicts = _context.Main_Characteristicts
                .Where( mc => mc.MC_ID == id)
                .Select( mc => _mapper.Map<MainCharacteristictsDTO>(mc))
               .FirstOrDefault();

            if (maincharacteristicts == null)
            {
                return NotFound();
            }

            return Ok(maincharacteristicts);
        }

        [HttpPost]
        [Produces("application/json")]
        public IActionResult CreatMainCharacteristicts([FromBody] MainCharacteristictsResponseDTO mainCharacteristictsResponseDTO)
        {
            if (mainCharacteristictsResponseDTO == null)
            {
                return BadRequest();
            }

            var maincharacteristictsResponse = _mapper.Map<Main_Characteristicts>(mainCharacteristictsResponseDTO);

            _context.Main_Characteristicts.Add(maincharacteristictsResponse);
            _context.SaveChanges();

            return Ok(maincharacteristictsResponse);
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        public IActionResult UpdateMainCharacteristicts(int id, [FromBody] MainCharacteristictsResponseDTO mainCharacteristictsResponseDTO)
        {
            if (mainCharacteristictsResponseDTO == null)
            {
                return BadRequest();
            }

            var maincharacteristictsResponse = _context.Main_Characteristicts.FirstOrDefault(mc => mc.MC_ID == id);

            if (maincharacteristictsResponse == null)
            {
                return NotFound();
            }

            maincharacteristictsResponse.WorkingMethod = mainCharacteristictsResponseDTO.WorkingMethod;
            maincharacteristictsResponse.IsOfficeEmployee = mainCharacteristictsResponseDTO.IsOfficeEmployee;
            maincharacteristictsResponse.TypeOfHazard = mainCharacteristictsResponseDTO.TypeOfHazard;

            _context.SaveChanges();

            return Ok(maincharacteristictsResponse);
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public IActionResult SoftDeleteMainCharacteristicts(int id)
        {
            var maincharacteristicts = _context.Main_Characteristicts.FirstOrDefault(mc => mc.MC_ID == id);

            if (maincharacteristicts == null)
            {
                return NotFound();
            }

            // Kaydın durumunu "deleted" olarak günceller.
            maincharacteristicts.Status = false;


            _context.Main_Characteristicts.Update(maincharacteristicts);
            _context.SaveChanges();

            return NoContent();
        }
    }
}



