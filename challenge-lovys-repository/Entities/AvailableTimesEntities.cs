using System;

namespace challenge_lovys_repository.Entities
{
    public class AvailableTimesEntities
    {
        public Guid AvailableTimeId { get; set; }
        public AvailableNextWeekEntities NextWeekId { get; set; }
        public int AvailableTime { get; set; }

    }
}
