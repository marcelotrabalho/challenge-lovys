using System;
using System.Linq;
using System.Collections.Generic;
using challenge_lovys_repository.Context;
using challenge_lovys_repository.Entities;
using challenge_lovys_repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace challenge_lovys_repository.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly LovysContext _lovysContext;

        public ScheduleRepository(LovysContext lovysContext)
        {
            _lovysContext = lovysContext;
        }
        public ScheduleEntities Add(ScheduleEntities schedule)
        {
            _lovysContext.Schedules.Add(schedule);
            _lovysContext.SaveChanges();

            return schedule;
        }

        public IList<ScheduleEntities> Get(Expression<Func<ScheduleEntities, bool>> condicao)
        {
            return _lovysContext.Schedules.Where(condicao).Include(x=> x.NextWeekEntities).ThenInclude(y => y.AvailableTime).ToList();
        }

        public IList<ScheduleEntities> GetAll()
        {
            return (from p in _lovysContext.Schedules.Include(x => x.NextWeekEntities).ThenInclude(y => y.AvailableTime)
                    select p).ToList();
        }
    }
}
