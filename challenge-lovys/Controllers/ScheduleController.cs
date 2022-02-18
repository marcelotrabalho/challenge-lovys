using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge_lovys_application.Dto;
using challenge_lovys_application.Interfaces;
using challenge_lovys_application.Request;
using challenge_lovys_application.Response;
using challenge_lovys_repository.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace challenge_lovys.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly ILogger<ScheduleController> _logger;
        private readonly IBaseScheduleApplication _scheduleApplication;

        public ScheduleController(ILogger<ScheduleController> logger,
            IBaseScheduleApplication scheduleApplication)
        {
            _logger = logger;
            _scheduleApplication = scheduleApplication;
        }

        [HttpPost]
        [Route("interviewer/create")]
        public async Task<ActionResult<ScheduleDto>> InterviewerCreate([FromBodyAttribute] ScheduleDto availableSchedule )
        {
            return await _scheduleApplication.Add(availableSchedule,ERole.Roles.Interviewer);
        }

        [HttpPost]
        [Route("candidate/create")]
        public async Task<ActionResult<ScheduleDto>> CandidateCreate([FromBodyAttribute] ScheduleDto availableSchedule)
        {
            return await _scheduleApplication.Add(availableSchedule, ERole.Roles.Candidate);
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IList<ScheduleDto>>> GetAll()
        {
            return await _scheduleApplication.GetAll();
        }

        [HttpGet]
        [Route("available")]
        public async Task<InterviewAvailableResponse> Get([FromBodyAttribute] InterviewAvailableRequest interviewerRequest)
        {
            return await _scheduleApplication.GetAvailable(interviewerRequest.Candidate, interviewerRequest.Interviewers.ToList());
        }
    }
}
