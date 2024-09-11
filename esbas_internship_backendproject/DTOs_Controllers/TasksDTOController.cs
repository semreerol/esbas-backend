using esbas_internship_backendproject.DTOs;
using esbas_internship_backendproject.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;
using esbas_internship_backendproject.Entities;
using AutoMapper;

namespace esbas_internship_backendproject.DTOs_Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksDTOController : ControllerBase
    {
        private readonly EsbasDbContext _context;
        private readonly IMapper _mapper;
        public TasksDTOController(EsbasDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetTasks()
        {
            var tasks = _context.Task
                .Where(t => t.Status == true)
               .Select(t => _mapper.Map<TasksDTO>(t))
               .ToList();

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public IActionResult GetTaskByID(int id)
        {
            var tasks = _context.Task
                .Where(t => t.TaskID == id)
                .Select(t => _mapper.Map<TasksDTO>(t))
                .FirstOrDefault();

            if (tasks == null)
            {
                return NotFound();
            }

            return Ok(tasks);
        }

        [HttpPost]
        [Produces("application/json")]
        public IActionResult CreateTasks([FromBody] TasksResponseDTO TasksResponseDTO)
        {
            if (TasksResponseDTO == null)
            {
                return BadRequest();
            }

            var TasksResponse = _mapper.Map<Taskk>(TasksResponseDTO);

            _context.Task.Add(TasksResponse);
            _context.SaveChanges();

            return Ok(TasksResponse);
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        public IActionResult UpdateTasks(int id, [FromBody] TasksResponseDTO TasksResponseDTO)
        {
            if (TasksResponseDTO == null)
            {
                return BadRequest();
            }

            var TasksResponse = _context.Task.FirstOrDefault(t => t.TaskID == id);

            if (TasksResponse == null)
            {
                return NotFound();
            }

            TasksResponse.Name = TasksResponseDTO.Name;

            _context.SaveChanges();

            return Ok(TasksResponseDTO);
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public IActionResult SoftDeleteTasks(int id)
        {
            var Tasks = _context.Task.FirstOrDefault(t => t.TaskID == id);

            if (Tasks == null)
            {
                return NotFound();
            }


            Tasks.Status = false;


            _context.Task.Update(Tasks);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
