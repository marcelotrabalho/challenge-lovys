using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using challenge_lovys_repository.Context;
using challenge_lovys_repository.Entities;
using challenge_lovys_repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace challenge_lovys_repository.Repository
{
    public class AvailableTimesRepository : IAvailableTimesRepository
    {
        private readonly LovysContext _lovysContext;

        public AvailableTimesRepository(LovysContext lovysContext)
        {
            _lovysContext = lovysContext;
        }
        public IList<AvailableTimesEntities> Get(Expression<Func<AvailableTimesEntities, bool>> condicao)
        {
            return _lovysContext.AvailableTimes.Where(condicao).Include(x => x.NextWeekId).ThenInclude(y => y.ScheduleEntitiesId).ToList();

        }
    }
}
