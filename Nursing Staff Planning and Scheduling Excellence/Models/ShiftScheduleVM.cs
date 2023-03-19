using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NursingStaffPlanningandSchedulingExcellence.Models
{
    public class ShiftScheduleVM
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        [Required(ErrorMessage = " Start Date is required")]
        public Nullable<System.DateTime> StartDate { get; set; }
        [Required(ErrorMessage = " End Date is required")]
        public Nullable<System.DateTime> EndDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        [Required(ErrorMessage = " Shift is required")]
        public Nullable<int> ShiftId { get; set; }
        public string Assignname { get; set; }
        public int? Hours { get; set; }

        public List<ShiftSchedule> ShiftScheduleList { get; set; }
    }
}