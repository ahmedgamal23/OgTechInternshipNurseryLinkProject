using NurseryLinkProject.Domain.Dtos.ActivityDtos;
using NurseryLinkProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryLinkProject.Domain.Dtos.MealDtos
{
    public class MealDto:ActivityDto
    {
        public MealType MealType { get; set; }
        public MealStatus MealStatus { get; set; }
    }
}
