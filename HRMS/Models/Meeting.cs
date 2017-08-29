using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Agenda { get; set; }
        public string MinutesOfMeeting { get; set; }

        public IEnumerable<ApplicationUser> Attendees { get; set; }
        public Hall MeetingRoom { get; set; }


    }
}