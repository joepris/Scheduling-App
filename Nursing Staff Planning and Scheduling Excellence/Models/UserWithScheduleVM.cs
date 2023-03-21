using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NursingStaffPlanningandSchedulingExcellence.Models
{
    public class UserWithScheduleVM
    {
        public UserVM User { get; set; }
        public ShiftScheduleVM ShiftSchedule { get; set; } 
    }
}