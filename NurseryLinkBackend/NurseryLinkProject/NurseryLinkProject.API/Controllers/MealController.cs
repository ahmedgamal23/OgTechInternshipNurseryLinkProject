using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NurseryLinkProject.Application.Interfaces;
using NurseryLinkProject.Domain.Dtos.ActivityTypeDtos;
using NurseryLinkProject.Domain.Dtos.MealDtos;
using NurseryLinkProject.Domain.Entities;

namespace NurseryLinkProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IBaseRepository<Meal> _baseRepository;
        private readonly IMapper _mapper;

        public MealController(IBaseRepository<Meal> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllAsync/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetAllMeal(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _baseRepository.GetAllAsync(pageNumber,
                            pageSize, x => x.Include(s=> s.Student).Include(t => t.Teacher));
            if (result.IsSuccess && result.DataList != null)
            {
                var mealDtoList = _mapper.Map<IEnumerable<MealDto>>(result.DataList);
                return Ok(mealDtoList);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetByMealType/{type}/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetMealByType(string type, int pageNumber = 1, int pageSize = 10)
        {
            var result = await _baseRepository.GetByAsync(
                x => x.MealType.ToString().ToLower() == type.ToLower(),
                pageNumber, pageSize, x => x.Include(s => s.Student).Include(t => t.Teacher)
            );
            if (result.IsSuccess && result.DataList != null)
            {
                var mealDtoList = _mapper.Map<IEnumerable<MealDto>>(result.DataList);
                return Ok(mealDtoList);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetMealByStatus/{status}/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetMealByStatus(string status, int pageNumber = 1, int pageSize = 10)
        {
            var result = await _baseRepository.GetByAsync(
                x => x.MealStatus.ToString().ToLower() == status.ToLower(),
                pageNumber, pageSize, x => x.Include(s => s.Student).Include(t => t.Teacher)
            );
            if (result.IsSuccess && result.DataList != null)
            {
                var mealDtoList = _mapper.Map<IEnumerable<MealDto>>(result.DataList);
                return Ok(mealDtoList);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMealById(int id)
        {
            var result = await _baseRepository.GetByIdAsync(id);
            if (result.IsSuccess && result.Data != null)
            {
                var mealDto = _mapper.Map<MealDto>(result.Data);
                return Ok(mealDto);
            }
            return BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddMealDto addMealDto)
        {
            var meal = _mapper.Map<Meal>(addMealDto);
            var result = await _baseRepository.AddAsync(meal);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateMealDto updateMealDto)
        {
            var existingMeal = await _baseRepository.GetByIdAsync(id);
            if (!existingMeal.IsSuccess || existingMeal.Data == null)
            {
                return NotFound($"this Meal id {id} not exist");
            }
            var meal = _mapper.Map(updateMealDto, existingMeal.Data);
            var result = _baseRepository.Update(meal);
            if (result)
                return Ok("update successfully");
            return BadRequest("failed to update this meal");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _baseRepository.Delete(id);
            if (result)
                return Ok("delete successfully");
            return BadRequest("failed to delete this meal");
        }
    }
}
