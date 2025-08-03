using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NurseryLinkProject.Application.Interfaces;
using NurseryLinkProject.Domain.Dtos.MealDtos;
using NurseryLinkProject.Domain.Dtos.NotificationDtos;
using NurseryLinkProject.Domain.Entities;

namespace NurseryLinkProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IBaseRepository<Notification> _baseRepository;
        private readonly IMapper _mapper;

        public NotificationController(IBaseRepository<Notification> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllAsync/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetAllNotifications(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _baseRepository.GetAllAsync(pageNumber,
                            pageSize, x => x.Include(s => s.Student).Include(t => t.Parent));
            if (result.IsSuccess && result.DataList != null)
            {
                var notificationDtos = _mapper.Map<IEnumerable<NotificationDto>>(result.DataList);
                return Ok(notificationDtos);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetByNotificationType/{type}/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetNotificationByType(string type, int pageNumber = 1, int pageSize = 10)
        {
            var result = await _baseRepository.GetByAsync(
                x => x.Type.ToString().ToLower() == type.ToLower(),
                pageNumber, pageSize, x => x.Include(s => s.Student).Include(t => t.Parent)
            );
            if (result.IsSuccess && result.DataList != null)
            {
                var notificationList = _mapper.Map<IEnumerable<NotificationDto>>(result.DataList);
                return Ok(notificationList);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationById(int id)
        {
            var result = await _baseRepository.GetByIdAsync(id);
            if (result.IsSuccess && result.Data != null)
            {
                var notificationDto = _mapper.Map<NotificationDto>(result.Data);
                return Ok(notificationDto);
            }
            return BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddNotificationDto addNotificationDto)
        {
            var notification = _mapper.Map<Notification>(addNotificationDto);
            var result = await _baseRepository.AddAsync(notification);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateNotificationDto updateNotificationDto)
        {
            var existingNotification = await _baseRepository.GetByIdAsync(id);
            if (!existingNotification.IsSuccess || existingNotification.Data == null)
            {
                return NotFound($"this notification id {id} not exist");
            }
            var notification = _mapper.Map(updateNotificationDto, existingNotification.Data);
            var result = _baseRepository.Update(notification);
            if (result)
                return Ok("update successfully");
            return BadRequest("failed to update this notification");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _baseRepository.Delete(id);
            if (result)
                return Ok("delete successfully");
            return BadRequest("failed to delete this notification");
        }
    }
}
