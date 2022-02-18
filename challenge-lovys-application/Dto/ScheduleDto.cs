using System;
using System.Collections.Generic;
using System.Text;
using challenge_lovys_repository.Enums;

namespace challenge_lovys_application.Dto
{
    public class ScheduleDto
    {
        public string Name { get; set; }
        public List<NextWeekAvailableDto> NextWeek { get; set; }
    }
}
