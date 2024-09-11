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

    public class OtherCharacteristictsDTOController : ControllerBase
    {

        private readonly EsbasDbContext _context;
        private readonly IMapper _mapper;
        public OtherCharacteristictsDTOController(EsbasDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetCOtherCharacteristicts()
        {
            var Othercharacteristicts = _context.Other_Characteristicts
                .Where(oc => oc.Status == true)
                .Select(oc => _mapper.Map<OtherCharacteristictsDTO>(oc))
                .ToList();

            return Ok(Othercharacteristicts);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public IActionResult GetOtherCharacteristictByID(int id)
        {
            var Othercharacteristicts = _context.Other_Characteristicts
                .Where(oc => oc.OC_ID == id)
                .Select(oc => _mapper.Map<OtherCharacteristictsDTO>(oc))
               .FirstOrDefault();

            if (Othercharacteristicts == null)
            {
                return NotFound();
            }

            return Ok(Othercharacteristicts);
        }

        [HttpPost]
        [Produces("application/json")]
        public IActionResult CreatOtherCharacteristicts([FromBody] OtherCharacteristictsResponseDTO OtherCharacteristictsResponseDTO)
        {
            if (OtherCharacteristictsResponseDTO == null)
            {
                return BadRequest();
            }

            var OthercharacteristictsResponse = _mapper.Map<Other_Characteristicts>(OtherCharacteristictsResponseDTO);

            _context.Other_Characteristicts.Add(OthercharacteristictsResponse);
            _context.SaveChanges();

            return Ok(OthercharacteristictsResponse);
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        public IActionResult UpdateOtherCharacteristicts(int id, [FromBody] OtherCharacteristictsResponseDTO OtherCharacteristictsResponseDTO)
        {
            if (OtherCharacteristictsResponseDTO == null)
            {
                return BadRequest();
            }

            var OthercharacteristictsResponse = _context.Other_Characteristicts.FirstOrDefault(oc => oc.OC_ID == id);

            if (OthercharacteristictsResponse == null)
            {
                return NotFound();
            }

            OthercharacteristictsResponse.EducationalStatus = OtherCharacteristictsResponseDTO.EducationalStatus;

            _context.SaveChanges();

            return Ok(OthercharacteristictsResponse);
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public IActionResult SoftDeleteOtherCharacteristicts(int id)
        {
            var Othercharacteristicts = _context.Other_Characteristicts.FirstOrDefault(oc => oc.OC_ID == id);

            if (Othercharacteristicts == null)
            {
                return NotFound();
            }

            // Kaydın durumunu "deleted" olarak günceller.
            Othercharacteristicts.Status = false;


            _context.Other_Characteristicts.Update(Othercharacteristicts);
            _context.SaveChanges();

            return NoContent();
        }
    }
}



