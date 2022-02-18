using System;
using System.Collections.Generic;
using System.Text;
using challenge_lovys_application.Dto;

namespace challenge_lovys_application.Response
{
    public class InterviewAvailableResponse
    {
        public enum statusResponse
        {
            ok,
            error
        }
        public string Status { get; set; }
        public string Message { get; set; }
        public object Results { get; set; }
    }
}
