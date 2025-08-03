using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NurseryLinkProject.Application.Interfaces;
using NurseryLinkProject.Domain.Dtos.ActivityDtos;
using NurseryLinkProject.Domain.Dtos.ActivityTypeDtos;
using NurseryLinkProject.Domain.Entities;

namespace NurseryLinkProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityTypeController : ControllerBase
    {
        private readonly IBaseRepository<ActivityType> _baseRepository;
        private readonly IMapper _mapper;

        public ActivityTypeController(IBaseRepository<ActivityType> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllAsync/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetAllActivityType(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _baseRepository.GetAllAsync(pageNumber,
                            pageSize);
            if (result.IsSuccess && result.DataList != null)
            {
                var activityTypeDtoList = _mapper.Map<IEnumerable<ActivityTypeDto>>(result.DataList);
                return Ok(activityTypeDtoList);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetByActivity/{name}/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetActivityTypeByName(string name, int pageNumber = 1, int pageSize = 10)
        {
            var result = await _baseRepository.GetByAsync(
                x => x.Name.ToLower() == name.ToLower(),
                pageNumber, pageSize
            );
            if (result.IsSuccess && result.DataList != null)
            {
                var activityTypeDtoList = _mapper.Map<IEnumerable<ActivityTypeDto>>(result.DataList);
                return Ok(activityTypeDtoList);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityTypeById(int id)
        {
            var result = await _baseRepository.GetByIdAsync(id);
            if (result.IsSuccess && result.Data != null)
            {
                var activityTypeDto = _mapper.Map<ActivityTypeDto>(result.Data);
                return Ok(activityTypeDto);
            }
            return BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddActivityTypeDto addActivityTypeDto)
        {
            var activityType = _mapper.Map<ActivityType>(addActivityTypeDto);
            var result = await _baseRepository.AddAsync(activityType);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateActivityTypeDto updateActivityTypeDto)
        {
            var existingActivityType = await _baseRepository.GetByIdAsync(id);
            if (!existingActivityType.IsSuccess || existingActivityType.Data == null)
            {
                return NotFound($"this Activity type id {id} not exist");
            }
            var activityType = _mapper.Map(updateActivityTypeDto, existingActivityType.Data);
            var result = _baseRepository.Update(activityType);
            if (result)
                return Ok("update successfully");
            return BadRequest("failed to update this activity type");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _baseRepository.Delete(id);
            if (result)
                return Ok("delete successfully");
            return BadRequest("failed to delete this activity type");
        }
    }
}
