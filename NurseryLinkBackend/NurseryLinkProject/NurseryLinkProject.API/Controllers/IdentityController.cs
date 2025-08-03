using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NurseryLinkProject.Application.Interfaces;
using NurseryLinkProject.Domain.Dtos.ActivityDtos;
using NurseryLinkProject.Domain.Dtos.UserDtos;
using NurseryLinkProject.Domain.Entities;
using System.Threading.Tasks;

namespace NurseryLinkProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IBaseRepository<User> _baseRepository;
        private readonly IMapper _mapper;

        public IdentityController(IBaseRepository<User> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllAsync/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetAllUsers(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _baseRepository.GetAllAsync(pageNumber, pageSize, x => x.Include(i => i.Role));
            if (result.IsSuccess && result.DataList != null)
            {
                var userDtoList = _mapper.Map<IEnumerable<UserDto>>(result.DataList);
                return Ok(userDtoList);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetUserByRole/{role}/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetUserByRole(string role ,int pageNumber = 1, int pageSize = 10)
        {
            var result = await _baseRepository.GetByAsync(
                x => x.Role.Name == role, pageNumber, pageSize
            );
            if (result.IsSuccess && result.DataList != null)
            {
                var userDtoList = _mapper.Map<IEnumerable<UserDto>>(result.DataList);
                return Ok(userDtoList);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _baseRepository.GetByIdAsync(id);
            if (result.IsSuccess && result.Data != null)
            {
                var userDto = _mapper.Map<UserDto>(result.Data);
                return Ok(userDto);
            }
            return BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddUserDto addUserDto)
        {
            var user = _mapper.Map<User>(addUserDto);
            var result = await _baseRepository.AddAsync(user);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserDto updateUserDto)
        {
            var existingUser = await _baseRepository.GetByIdAsync(id);
            if(!existingUser.IsSuccess || existingUser.Data == null)
            {
                return NotFound($"this user id {id} not exist");
            }
            var user = _mapper.Map(updateUserDto, existingUser.Data);
            var result = _baseRepository.Update(user);
            if (result)
                return Ok("update successfully");
            return BadRequest("failed to update this user");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _baseRepository.Delete(id);
            if (result)
                return Ok("delete successfully");
            return BadRequest("failed to delete this user");
        }
    }
}
