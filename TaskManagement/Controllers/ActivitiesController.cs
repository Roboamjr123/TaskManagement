using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Dto;
using TaskManagement.Interface;
using TaskManagement.Models;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityRepository _repository;
        private readonly IMapper _mapper;

        public ActivitiesController(IActivityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            var activities = await _repository.GetAllActivitiesAsync();
            var activityDtos = _mapper.Map<IEnumerable<ActivityDto>>(activities);
            return Ok(activityDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivity(int id)
        {
            var activity = await _repository.GetActivityByIdAsync(id);
            if (activity == null)
            {
                return NotFound();
            }
            var activityDto = _mapper.Map<ActivityDto>(activity);
            return Ok(activityDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity([FromBody] ActivityDto activityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var activity = _mapper.Map<Activity>(activityDto);
            await _repository.AddActivityAsync(activity);
            var createdActivityDto = _mapper.Map<ActivityDto>(activity);
            return CreatedAtAction(nameof(GetActivity), new { id = createdActivityDto.Act_Id }, createdActivityDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(int id, [FromBody] ActivityDto activityDto)
        {
            if (id != activityDto.Act_Id)
            {
                return BadRequest("ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var activity = _mapper.Map<Activity>(activityDto);

            await _repository.UpdateActivityAsync(activity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            await _repository.DeleteActivityAsync(id);
            return NoContent();
        }
    }
}
