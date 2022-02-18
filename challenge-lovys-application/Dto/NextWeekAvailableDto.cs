using System;
using System.Collections.Generic;
using System.Text;
using challenge_lovys_repository.Enums;

namespace challenge_lovys_application.Dto
{
    public class NextWeekAvailableDto
    {
        public EWeekDay.WeekDay WeekDay { get; set; }
        public List<int> available { get; set; }
    }
}
