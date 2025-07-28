using NurseryLinkProject.Domain.Dtos.ActivityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseryLinkProject.Domain.Dtos.TemperatureDtos
{
    public class AddTemperatureDto: AddActivityDto
    {
        public double TemperatureReading { get; set; }
    }
}
