using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using challenge_lovys_application.Dto;
using challenge_lovys_application.Response;
using challenge_lovys_repository.Enums;

namespace challenge_lovys_application.Interfaces
{
    public interface IBaseScheduleApplication
    {
        public Task<ScheduleDto> Add(ScheduleDto schedule, ERole.Roles role);
        public Task<InterviewAvailableResponse> GetAvailable(string nameCandidate, List<string> nameInterviewers);
        public Task<List<ScheduleDto>> GetAll();
    }
}
