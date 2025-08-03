using AutoMapper;
using NurseryLinkProject.Domain.Dtos.ActivityDtos;
using NurseryLinkProject.Domain.Dtos.ActivityTypeDtos;
using NurseryLinkProject.Domain.Dtos.MealDtos;
using NurseryLinkProject.Domain.Dtos.NotificationDtos;
using NurseryLinkProject.Domain.Dtos.NurseryClassDtos;
using NurseryLinkProject.Domain.Dtos.ParentStudentDtos;
using NurseryLinkProject.Domain.Dtos.RoleDtos;
using NurseryLinkProject.Domain.Dtos.StudentDtos;
using NurseryLinkProject.Domain.Dtos.SupplyRequestDtos;
using NurseryLinkProject.Domain.Dtos.TemperatureDtos;
using NurseryLinkProject.Domain.Dtos.ToiletDtos;
using NurseryLinkProject.Domain.Dtos.UserDtos;
using NurseryLinkProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryLinkProject.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // user mapping
            CreateMap<AddUserDto, User>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<User, UserDto>();

            // Activity mapping
            CreateMap<Activity, ActivityDto>();
            CreateMap<AddActivityDto, Activity>();
            CreateMap<UpdateActivityDto, Activity>();

            // Activity Type mapping
            CreateMap<ActivityType, ActivityTypeDto>();
            CreateMap<AddActivityTypeDto, ActivityType>();
            CreateMap<UpdateActivityTypeDto, ActivityType>();

            // Meal mapping
            CreateMap<Meal, MealDto>();
            CreateMap<AddMealDto, Meal>();
            CreateMap<UpdateMealDto, Meal>();

            // Notification Mapping
            CreateMap<Notification, NotificationDto>();
            CreateMap<AddNotificationDto, Notification>();
            CreateMap<UpdateNotificationDto, Notification>();

            // NurseryClass Mapping
            CreateMap<NurseryClass, NurseryClassDto>();
            CreateMap<AddNurseryClassDto, NurseryClass>();
            CreateMap<UpdateNurseryClassDto, NurseryClass>();

            // ParentStudent Mapping
            CreateMap<ParentStudent, ParentStudentDto>();
            CreateMap<AddParentStudentDto, ParentStudent>();
            CreateMap<UpdateParentStudentDto, ParentStudent>();

            // Role Mapping
            CreateMap<Role, RoleDto>();
            CreateMap<AddRoleDto, Role>();
            CreateMap<UpdateRoleDto, Role>();

            // Toilet Mapping
            CreateMap<Toilet, ToiletDto>();
            CreateMap<AddToiletDto, Toilet>();
            CreateMap<UpdateToiletDto, Toilet>();

            // Temperature Mapping
            CreateMap<Temperature, TemperatureDto>();
            CreateMap<AddTemperatureDto, Temperature>();
            CreateMap<UpdateTemperatureDto, Temperature>();

            // SupplyRequest Mapping
            CreateMap<SupplyRequest, SupplyRequestDto>();
            CreateMap<AddSupplyRequestDto, SupplyRequest>();
            CreateMap<UpdateSupplyRequestDto, SupplyRequest>();

            // Student Mapping
            CreateMap<Student, StudentDto>();
            CreateMap<AddStudentDto, Student>();
            CreateMap<UpdateStudentDto, Student>();

            

        }
    }
}
