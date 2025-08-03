using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NurseryLinkProject.Application.Interfaces;
using NurseryLinkProject.Domain.Dtos.ToiletDtos;
using NurseryLinkProject.Domain.Entities;

namespace NurseryLinkProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToiletController : ControllerBase
    {
        private readonly IBaseRepository<Toilet> _baseRepository;
        private readonly IMapper _mapper;

        public ToiletController(IBaseRepository<Toilet> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllAsync/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetAllToilet(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _baseRepository.GetAllAsync(pageNumber,
                            pageSize, x => x.Include(s => s.Student).Include(t => t.Teacher));
            if (result.IsSuccess && result.DataList != null)
            {
                var ToiletDtoList = _mapper.Map<IEnumerable<ToiletDto>>(result.DataList);
                return Ok(ToiletDtoList);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetByToilettype/{type}/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetToiletByVistitType(string type, int pageNumber = 1, int pageSize = 10)
        {
            var result = await _baseRepository.GetByAsync(
                x => x.VisitType.ToString().ToLower() == type.ToLower(),
                pageNumber, pageSize, x => x.Include(s => s.Student).Include(t => t.Teacher)
            );
            if (result.IsSuccess && result.DataList != null)
            {
                var ToiletDtoList = _mapper.Map<IEnumerable<ToiletDto>>(result.DataList);
                return Ok(ToiletDtoList);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetToiletById(int id)
        {
            var result = await _baseRepository.GetByIdAsync(id);
            if (result.IsSuccess && result.Data != null)
            {
                var ToiletDto = _mapper.Map<ToiletDto>(result.Data);
                return Ok(ToiletDto);
            }
            return BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddToiletDto addToiletDto)
        {
            var Toilet = _mapper.Map<Toilet>(addToiletDto);
            var result = await _baseRepository.AddAsync(Toilet);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateToiletDto updateToiletDto)
        {
            var existingToilet = await _baseRepository.GetByIdAsync(id);
            if (!existingToilet.IsSuccess || existingToilet.Data == null)
            {
                return NotFound($"this Toilet id {id} not exist");
            }
            var Toilet = _mapper.Map(updateToiletDto, existingToilet.Data);
            var result = _baseRepository.Update(Toilet);
            if (result)
                return Ok("update successfully");
            return BadRequest("failed to update this Toilet");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _baseRepository.Delete(id);
            if (result)
                return Ok("delete successfully");
            return BadRequest("failed to delete this Toilet");
        }
    }
}
