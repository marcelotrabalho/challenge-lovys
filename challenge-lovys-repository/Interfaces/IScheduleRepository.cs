using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using challenge_lovys_repository.Entities;

namespace challenge_lovys_repository.Interfaces
{
    public interface IScheduleRepository
    {
        public ScheduleEntities Add(ScheduleEntities schedule);
        public IList<ScheduleEntities> GetAll();
        public IList<ScheduleEntities> Get(Expression<Func<ScheduleEntities, bool>> condicao);
    }
}
