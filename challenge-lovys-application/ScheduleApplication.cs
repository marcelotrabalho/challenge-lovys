using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using challenge_lovys_application.Dto;
using challenge_lovys_application.Interfaces;
using challenge_lovys_repository.Entities;
using challenge_lovys_repository.Enums;
using challenge_lovys_repository.Interfaces;
using challenge_lovys_application.Response;
using challenge_lovys_repository.Repository;

namespace challenge_lovys_application
{
    public class ScheduleApplication : IBaseScheduleApplication
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IAvailableTimesRepository _availableTimesRepository;

        public ScheduleApplication(IScheduleRepository scheduleRepository, IAvailableTimesRepository availableTimesRepository)
        {
            _scheduleRepository = scheduleRepository;
            _availableTimesRepository = availableTimesRepository;
        }

        async Task<List<ScheduleDto>> IBaseScheduleApplication.GetAll()
        {
            var result = await Task.FromResult(_scheduleRepository.GetAll())
                .ConfigureAwait(false);

            return Mapear(result).ToList();

        }

        public Task<InterviewAvailableResponse> GetAvailable(string nameCandidate, List<string> nameInterviewers)
        {
            var result = _availableTimesRepository.Get(x => x.NextWeekId.ScheduleEntitiesId.Name.ToLower() == nameCandidate.ToLower());

            if (result == null || result.Count == 0)
            {
                return Task.FromResult(new InterviewAvailableResponse
                {
                    Message = "Candidate not found",
                    Status = InterviewAvailableResponse.statusResponse.error.ToString(),
                    Results = null
                });
            }

            if (nameInterviewers == null || nameInterviewers.Count == 0)
            {
                return Task.FromResult(new InterviewAvailableResponse
                {
                    Message = "Interviewers not found",
                    Status = InterviewAvailableResponse.statusResponse.error.ToString(),
                    Results = null
                });
            }

            var interviewerFound = new[]
            {
                new { day = 0, hour = 0, name = new List<string>() }
            }.ToList();

            foreach (var item in result)
            {
                var interviewers = _availableTimesRepository.Get(
                    x => x.AvailableTime == item.AvailableTime
                    && x.NextWeekId.WeekDay == item.NextWeekId.WeekDay
                    && x.NextWeekId.ScheduleEntitiesId.Role != ERole.Roles.Candidate
                    && nameInterviewers.Contains(x.NextWeekId.ScheduleEntitiesId.Name));
                
                foreach(var interviewer in interviewers)
                {
                    if (interviewerFound.Any(x => x.day == (int)item.NextWeekId.WeekDay 
                                                    && x.hour == item.AvailableTime))
                    {
                        var interviewerResult = interviewerFound.FirstOrDefault(x => x.day == (int)item.NextWeekId.WeekDay
                                                    && x.hour == item.AvailableTime);
                        interviewerResult.name.Add(interviewer.NextWeekId.ScheduleEntitiesId.Name);

                        continue;
                    }

                    interviewerFound.Add(new { 
                        day = (int)item.NextWeekId.WeekDay, 
                        hour = item.AvailableTime, 
                        name = new List<string> { 
                            interviewer.NextWeekId.ScheduleEntitiesId.Name 
                        } });
                }
            }

            return Task.FromResult(new InterviewAvailableResponse
            {
                Message = "Success",
                Status = InterviewAvailableResponse.statusResponse.ok.ToString(),
                Results = interviewerFound.Where(x => x.name?.Count() == nameInterviewers.Count)
            });
        }

        async Task<ScheduleDto> IBaseScheduleApplication.Add(ScheduleDto schedule, ERole.Roles role)
        {
            var entities = new ScheduleEntities()
            {
                Name = schedule.Name,
                Role = role,
                NextWeekEntities = schedule.NextWeek.Select(x => new AvailableNextWeekEntities
                {
                    WeekDay = x.WeekDay,
                    AvailableTime = x.available.Select(y => new AvailableTimesEntities
                    {
                        AvailableTime = y
                    }).ToList()
                }).ToList()
            };
            
            var result = await Task.FromResult(_scheduleRepository.Add(entities))
                .ConfigureAwait(false);

            return Mapear(result);
        }

        private ScheduleDto Mapear(ScheduleEntities scheduleEntities)
        {
            return new ScheduleDto
            {
                Name = scheduleEntities.Name,
                NextWeek = scheduleEntities.NextWeekEntities.Select(x => new NextWeekAvailableDto
                {
                    WeekDay= x.WeekDay,
                    available = x.AvailableTime.Select(y => y.AvailableTime).ToList()
                }).ToList()
            };
        }
        private IList<ScheduleDto> Mapear(IList<ScheduleEntities> scheduleEntities)
        {
            return (from p in scheduleEntities
                    select new ScheduleDto
                        {
                            Name = p.Name,
                            NextWeek = p.NextWeekEntities.Select(x => new NextWeekAvailableDto
                            {
                                WeekDay = x.WeekDay,
                                available = x.AvailableTime.Select(y => y.AvailableTime).ToList()
                            }).ToList()
                        }).ToList();
        }
    }
}
