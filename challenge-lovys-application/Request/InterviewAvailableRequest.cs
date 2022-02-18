using System;
using System.Collections.Generic;
using System.Text;

namespace challenge_lovys_application.Request
{
    public class InterviewAvailableRequest
    {
        public string Candidate { get; set; }
        public IList<string> Interviewers { get; set;}
    }
}
