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

    public class CostCentersDTOController : ControllerBase
    {

        private readonly EsbasDbContext _context;
        private readonly IMapper _mapper;
        public CostCentersDTOController(EsbasDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetCostCenters()
        {
            var costcenters = _context.CostCenters
                .Where(cc => cc.Status == true)
                .Select(cc => _mapper.Map<CostCentersDTO>(cc))
                .ToList();

            return Ok(costcenters);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public IActionResult GetCostCenterByID(int id)
        {
            var costcenters = _context.CostCenters
                .Where(cc => cc.CostCenterID == id )
               .Select(cc => _mapper.Map<CostCentersDTO>(cc))
               .FirstOrDefault();

            if (costcenters == null)
            {
                return NotFound();
            }

            return Ok(costcenters);
        }

        [HttpPost]
        [Produces("application/json")]
        public IActionResult CreateCostCenters([FromBody] CostCentersResponseDTO costCentersResponseDTO)
        {
            if (costCentersResponseDTO== null)
            {
                return BadRequest();
            }

            var costcenterResponse = _mapper.Map<CostCenters>(costCentersResponseDTO);

            _context.CostCenters.Add(costcenterResponse);
            _context.SaveChanges();

            return Ok(costcenterResponse);
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        public IActionResult UpdateCostCenters(int id, [FromBody] CostCentersResponseDTO costCentersResponseDTO)
        {
            if (costCentersResponseDTO == null)
            {
                return BadRequest();
            }

            var costCentersResponse = _context.CostCenters.FirstOrDefault(cc => cc.CostCenterID == id);

            if (costCentersResponse == null)
            {
                return NotFound();
            }

            costCentersResponse.Name = costCentersResponseDTO.Name;
            costCentersResponse.Budget = costCentersResponseDTO.Budget;

            _context.SaveChanges();

            return Ok(costCentersResponse);
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public IActionResult SoftDeleteCostCenters(int id)
        {
            var costCenters = _context.CostCenters.FirstOrDefault(cc => cc.CostCenterID == id);

            if (costCenters == null)
            {
                return NotFound();
            }

            // Kaydın durumunu "deleted" olarak günceller.
            costCenters.Status = false;

            //son hali
            _context.CostCenters.Update(costCenters);
            _context.SaveChanges();

            return NoContent();
        }
    }
}



