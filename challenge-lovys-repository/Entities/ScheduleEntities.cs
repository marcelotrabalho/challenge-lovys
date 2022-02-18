using System;
using System.Collections.Generic;
using challenge_lovys_repository.Enums;

namespace challenge_lovys_repository.Entities
{
    public class ScheduleEntities
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ERole.Roles Role { get; set; }

        public List<AvailableNextWeekEntities> NextWeekEntities { get; set; }
    }
}
