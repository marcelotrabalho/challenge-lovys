using System;
using System.Collections.Generic;
using challenge_lovys_repository.Enums;

namespace challenge_lovys_repository.Entities
{
    public class AvailableNextWeekEntities
    {
        public Guid NextWeekId { get; set; }
        public ScheduleEntities ScheduleEntitiesId { get; set; }
        public EWeekDay.WeekDay WeekDay { get; set; }
        public List<AvailableTimesEntities> AvailableTime { get; set; }
    }
}
