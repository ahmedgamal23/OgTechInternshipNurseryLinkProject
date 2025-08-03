using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NurseryLinkProject.Application.Interfaces;
using NurseryLinkProject.Domain.Dtos.ActivityDtos;
using NurseryLinkProject.Domain.Dtos.UserDtos;
using NurseryLinkProject.Domain.Entities;

namespace NurseryLinkProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IBaseRepository<Activity> _baseRepository;
        private readonly IMapper _mapper;

        public ActivityController(IBaseRepository<Activity> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllAsync/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetAllActivites(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _baseRepository.GetAllAsync(pageNumber,
                            pageSize, 
                            x => x.Include(i => i.Student).Include(y => y.Teacher));
            if (result.IsSuccess && result.DataList != null)
            {
                var activityDtoList = _mapper.Map<IEnumerable<ActivityDto>>(result.DataList);
                return Ok(activityDtoList);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetByActivity/{activity}/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetActivityByType(string activity, int pageNumber = 1, int pageSize = 10)
        {
            var result = await _baseRepository.GetByAsync(
                x => x.ActivityType.Name.ToLower() == activity.ToLower(),
                pageNumber, pageSize, x => x.Include(i => i.Student).Include(y => y.Teacher)
            );
            if (result.IsSuccess && result.DataList != null)
            {
                var activityDtoList = _mapper.Map<IEnumerable<ActivityDto>>(result.DataList);
                return Ok(activityDtoList);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityById(int id)
        {
            var result = await _baseRepository.GetByIdAsync(id);
            if (result.IsSuccess && result.Data != null)
            {
                var activityDto = _mapper.Map<ActivityDto>(result.Data);
                return Ok(activityDto);
            }
            return BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddActivityDto addActivityDto)
        {
            var activity = _mapper.Map<Activity>(addActivityDto);
            var result = await _baseRepository.AddAsync(activity);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateActivityDto updateActivityDto)
        {
            var existingActivity = await _baseRepository.GetByIdAsync(id);
            if (!existingActivity.IsSuccess || existingActivity.Data == null)
            {
                return NotFound($"this Activity id {id} not exist");
            }
            var activity = _mapper.Map(updateActivityDto, existingActivity.Data);
            var result = _baseRepository.Update(activity);
            if (result)
                return Ok("update successfully");
            return BadRequest("failed to update this activity");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _baseRepository.Delete(id);
            if (result)
                return Ok("delete successfully");
            return BadRequest("failed to delete this activity");
        }
    }
}
