using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using challenge_lovys_repository.Entities;

namespace challenge_lovys_repository.Interfaces
{
    public interface IAvailableTimesRepository
    {
        public IList<AvailableTimesEntities> Get(Expression<Func<AvailableTimesEntities, bool>> condicao);

    }
}
