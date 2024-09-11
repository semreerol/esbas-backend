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

        public class DepartmentDTOController : ControllerBase
        {

            private readonly EsbasDbContext _context;
            private readonly IMapper _mapper;
            public DepartmentDTOController(EsbasDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            [HttpGet]
            [Produces("application/json")]
            public IActionResult GetDepartments()
            {
                   var departments = _context.Department
                     .Include( d => d.CostCenters)
                     //.Include( d => d.Task)
                     .Where(d => d.Status == true)
                     .Select(d => _mapper.Map<DepartmentDTO>(d))
                     .ToList();
         
            return Ok(departments);
            }

            [HttpGet("{id}")]
            [Produces("application/json")]
            public IActionResult GetDepartmentByID(int id)
            {
            var departments = _context.Department
                .Where(d => d.DepartmentID == id)
               .Include(d => d.CostCenters)
              // .Include(d => d.Task)
               .Select(d => _mapper.Map<DepartmentDTO>(d))
               .FirstOrDefault();

            if (departments == null)
                {
                    return NotFound();
                }

                return Ok(departments);
            }

            [HttpPost]
            [Produces("application/json")]
            public IActionResult CreateDepartment([FromBody] DepartmentResponseDTO departmentResponseDTO)
            {
                if (departmentResponseDTO == null)
                {
                    return BadRequest();
                }

                var departmentResponse = _mapper.Map<Department>(departmentResponseDTO);

                _context.Department.Add(departmentResponse);
                _context.SaveChanges();

                return Ok(departmentResponse);
            }

            [HttpPut("{id}")]
            [Produces("application/json")]
            public IActionResult UpdateDepartment(int id, [FromBody] DepartmentResponseDTO departmentResponseDTO)
            {
                if (departmentResponseDTO == null)
                {
                    return BadRequest();
                }

                var departmentResponse = _context.Department.FirstOrDefault(d => d.DepartmentID == id);

                if (departmentResponse == null)
                {
                    return NotFound();
                }

                departmentResponse.Name = departmentResponseDTO.Name;

                _context.SaveChanges();

                return Ok(departmentResponse);
            }

            [HttpDelete("{id}")]
            [Produces("application/json")]
            public IActionResult SoftDeleteDepartment(int id)
            {
                var department = _context.Department.FirstOrDefault(d => d.DepartmentID == id);

                if (department == null)
                {
                    return NotFound();
                }

                // Kaydın durumunu "deleted" olarak günceller.
                department.Status = false;


                _context.Department.Update(department);
                _context.SaveChanges();

                return NoContent();
            }
        }
    }


