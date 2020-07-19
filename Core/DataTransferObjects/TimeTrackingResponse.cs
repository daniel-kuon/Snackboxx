using System;

namespace Core.DataTransferObjects
{
    public class TimeTrackingResponse
    {
        public UserOverview UserOverview { get; set; }
        public bool IsPresent { get; set; }
        public TimeSpan? PresenceTime { get; set; }
    }
}