using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NurseryLinkProject.Application.Interfaces;
using NurseryLinkProject.Domain.Dtos.RoleDtos;
using NurseryLinkProject.Domain.Entities;

namespace NurseryLinkProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IBaseRepository<Role> _baseRepository;
        private readonly IMapper _mapper;

        public RoleController(IBaseRepository<Role> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllAsync/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetAllRole(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _baseRepository.GetAllAsync(pageNumber,
                            pageSize);
            if (result.IsSuccess && result.DataList != null)
            {
                var RoleDtoList = _mapper.Map<IEnumerable<RoleDto>>(result.DataList);
                return Ok(RoleDtoList);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetByRoleName/{name}/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetRoleByName(string name, int pageNumber = 1, int pageSize = 10)
        {
            var result = await _baseRepository.GetByAsync(
                x => x.Name.ToLower() == name.ToLower(),
                pageNumber, pageSize
            );
            if (result.IsSuccess && result.DataList != null)
            {
                var RoleDtoList = _mapper.Map<IEnumerable<RoleDto>>(result.DataList);
                return Ok(RoleDtoList);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var result = await _baseRepository.GetByIdAsync(id);
            if (result.IsSuccess && result.Data != null)
            {
                var RoleDto = _mapper.Map<RoleDto>(result.Data);
                return Ok(RoleDto);
            }
            return BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddRoleDto addRoleDto)
        {
            var Role = _mapper.Map<Role>(addRoleDto);
            var result = await _baseRepository.AddAsync(Role);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateRoleDto updateRoleDto)
        {
            var existingRole = await _baseRepository.GetByIdAsync(id);
            if (!existingRole.IsSuccess || existingRole.Data == null)
            {
                return NotFound($"this Role id {id} not exist");
            }
            var Role = _mapper.Map(updateRoleDto, existingRole.Data);
            var result = _baseRepository.Update(Role);
            if (result)
                return Ok("update successfully");
            return BadRequest("failed to update this Role");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _baseRepository.Delete(id);
            if (result)
                return Ok("delete successfully");
            return BadRequest("failed to delete this Role");
        }
    }
}
