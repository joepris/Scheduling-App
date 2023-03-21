using DayPilot.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NursingStaffPlanningandSchedulingExcellence.Models;
using NursingStaffPlanningandSchedulingExcellence.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace NursingStaffPlanningandSchedulingExcellence.Controllers
{
    public class AdminController : Controller
    {
        NursingStaffEntities db = new NursingStaffEntities();

        public ActionResult Index()
        {
            return View();
        }



        #region Staff
        public ActionResult AllStaffList()
        {
            UserVM obj = new UserVM();

            try
            {
                var user = db.User.Where(m => m.UserRole == 2);
                if (user != null)
                {
                    obj.userList = user.Select(s => new UserVM
                    {
                        UserId = s.UserId,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Address = s.Address,
                        Sex = s.Sex,
                        DOB = (DateTime)s.DOB,
                        ZipCode = s.ZipCode,
                        City = s.City,
                        Province = s.Province,
                        Email = s.Email,
                        CellPhone = s.CellPhone,
                        UserRole = s.UserRole,
                        MaritalStatusId = s.MaritalStatusId,
                        UserName = s.UserName,
                        Password = s.Password,
                        Image = s.Image,
                        Note = s.Note,
                        Fax = s.Fax,

                        FullName = s.FirstName + "" + s.LastName,
                        GenderName = s.Gender.GenderName,
                        MaritalStatus = s.MaritalStatus.MaritalStatusName,
                    }).ToList();
                }
               
            }
            catch (Exception ex)
            {

            }
            return View(obj);

        }

        [HttpGet]
        public ActionResult AddStaff(int? id)
        {
            int UserID = LoginRepository.GetUserID(User.Identity.Name);
            UserVM obj = new UserVM();
            try
            {
                if (id != null)
                {
                    var task = db.User.Where(x => x.UserId == id).FirstOrDefault();
                    obj.UserId = task.UserId;
                    obj.FirstName = task.FirstName;
                    obj.LastName = task.LastName;
                    obj.DOB = (DateTime)task.DOB;
                    obj.ZipCode = task.ZipCode;
                    obj.City = task.City;
                    obj.Province = task.Province;
                    obj.CellPhone = task.CellPhone;
                    obj.Email = task.Email;
                    obj.Address = task.Address;
                    obj.Sex = task.Sex;
                    obj.MaritalStatusId = task.MaritalStatusId;
                    obj.UserName = task.UserName;
                    obj.Password = task.Password;
                    obj.Image = task.Image;
                    obj.Specialization = task.Specialization;
                    obj.UserRole = task.UserRole;
                    obj.Note = task.Note;
                    obj.Fax = task.Fax;

                    obj.GenderName = task.Gender?.GenderName;
                    obj.MaritalStatus = task.MaritalStatus?.MaritalStatusName;
                }
                obj.gendersList = db.Gender.ToList();
                obj.maritalsList = db.MaritalStatus.ToList();
                obj.rolesList = db.Role.ToList();

            }
            catch (Exception ex)
            {
                return View("Error");
            }
            return View(obj);
        }


        [HttpPost]
        public ActionResult AddStaff(UserVM objuser)
        {
            User user = new User();
            if (objuser.UserId == 0)
            {
                user.FirstName = objuser.FirstName;
                user.LastName = objuser.LastName;
                user.DOB = objuser.DOB;
                user.ZipCode = objuser.ZipCode;
                user.City = objuser.City;
                user.Province = objuser.Province;
                user.HomePhone = objuser.HomePhone;
                user.CellPhone = objuser.CellPhone;
                user.Email = objuser.Email;
                user.Address = objuser.Address;
                user.Sex = objuser.Sex;
                user.MaritalStatusId = objuser.MaritalStatusId ?? 0;
                user.UserName = objuser.UserName;
                user.Password = objuser.Password;
                user.Image = objuser.Image;
                user.Note = objuser.Note;

                user.UserRole = 2;
                db.User.Add(user);

            }
            if (objuser.UserId > 0)
            {
                user = db.User.Where(m => m.UserId == objuser.UserId).FirstOrDefault();
                if (objuser != null)
                {
                    user.FirstName = objuser.FirstName;
                    user.LastName = objuser.LastName;
                    user.DOB = objuser.DOB;
                    user.ZipCode = objuser.ZipCode;
                    user.City = objuser.City;
                    user.Province = objuser.Province;
                    user.HomePhone = objuser.HomePhone;
                    user.CellPhone = objuser.CellPhone;
                    user.UserRole = 2;
                    user.Email = objuser.Email;
                    user.Address = objuser.Address;
                    user.Sex = objuser.Sex;
                    user.MaritalStatusId = objuser.MaritalStatusId ?? 0;
                    user.UserName = objuser.UserName;
                    user.Password = objuser.Password;
                    user.Note = objuser.Note;
                    user.Fax = objuser.Fax;

                    db.Entry(user).State = EntityState.Modified;
                }
            }
            try
            {
                db.SaveChanges();
                TempData["message"] = string.Format("Record save successfully. ");
                return RedirectToAction("AllStaffList");
            } catch (Exception ex) {
                Console.WriteLine(ex);
                return RedirectToAction("AddStaff");
            }

        }


        public ActionResult DeleteStaff(int id)
        {

            if (id != 0)
            {
                var user = db.User.Where(x => x.UserId == id).FirstOrDefault();
                if (user != null)
                {
                    db.User.Remove(user);
                    db.SaveChanges();
                    TempData["message"] = string.Format("Record delete successfully. ");
                    return RedirectToAction("AllStaffList");
                }
            }
            return RedirectToAction("AllStaffList");
        }

        [HttpGet]
        public ActionResult StaffDetails(int id)
        {
            int UserID = id;
            UserID = LoginRepository.GetUserID(User.Identity.Name);
            UserVM obj = new UserVM();
            ShiftScheduleVM obj2 = new ShiftScheduleVM();
            try
            {
                if (id != null)
                {
                    var task = db.User.Where(x => x.UserId == id).FirstOrDefault();

                    obj.UserId = task.UserId;
                    obj.FirstName = task.FirstName;
                    obj.LastName = task.LastName;
                    obj.DOB = (DateTime)task.DOB;
                    obj.ZipCode = task.ZipCode;
                    obj.City = task.City;
                    obj.Province = task.Province;
                    obj.CellPhone = task.CellPhone;
                    obj.Email = task.Email;
                    obj.Address = task.Address;
                    obj.Sex = task.Sex;
                    obj.MaritalStatusId = task.MaritalStatusId;
                    obj.UserName = task.UserName;
                    obj.Password = task.Password;
                    obj.Image = task.Image;
                    obj.Specialization = task.Specialization;
                    obj.UserRole = task.UserRole;
                    obj.Note = task.Note;
                    obj.Fax = task.Fax;

                    obj.GenderName = task.Gender?.GenderName;
                    obj.MaritalStatus = task.MaritalStatus?.MaritalStatusName;

                    var task2 = db.ShiftSchedule.Where(x => x.UserId == id).FirstOrDefault();
                    if (task2 != null)
                    {
                        obj2.Id = task2.Id;
                        obj2.UserId = task2.UserId;
                        obj2.StartDate = task2.StartDate;
                        obj2.EndDate = task2.EndDate;
                        obj2.StartTime = task2.StartTime;
                        obj2.EndTime = task2.EndTime;
                        obj2.ShiftId = task2.ShiftId;
                        //obj2.Hours = task2.StartDate.Hours}
                    }
                    obj.gendersList = db.Gender.ToList();
                    obj.maritalsList = db.MaritalStatus.ToList();
                    obj.rolesList = db.Role.ToList();
                }
            }

            
            catch (Exception ex)
            {
                return View("Error");
            }

            UserWithScheduleVM obj3 = new UserWithScheduleVM() { User = obj, ShiftSchedule = obj2};
            return View(obj3);
        }


        #endregion Staff

        #region Shift Schedule
        [HttpGet]
        public ActionResult ShiftSchedule(int? UserId, int? id, int? hours, DateTime? StartDate)
        {
            int UserID = LoginRepository.GetUserID(User.Identity.Name);
            ShiftScheduleVM obj = new ShiftScheduleVM();
            try
            {
                if (id != null)
                {
                    var task = db.ShiftSchedule.Where(x => x.Id == id).FirstOrDefault();
                    if (task != null)
                    {
                        obj.Id = task.Id;
                        obj.UserId = task.UserId;
                        obj.StartDate = task.StartDate;
                        obj.EndDate = task.EndDate.Value.AddHours(hours ?? 0);
                        //obj.EndDate = task.EndDate;
                        obj.StartTime = task.StartTime;
                        obj.EndTime = task.EndTime;
                        obj.ShiftId = task.ShiftId;
                    }
                }
                if (hours != null)
                {
                    obj.EndDate = StartDate.Value.AddHours(hours ?? 0);
                    //obj.EndDate = EndDate;
                    obj.StartDate = StartDate;
                    obj.Hours = hours;
                }
                obj.ShiftScheduleList = db.ShiftSchedule.Where(x => x.UserId == UserId && x.EndDate >= DateTime.Now).ToList();
                var assignname = db.User.Where(x => x.UserId == UserId).FirstOrDefault();
                obj.Assignname = assignname.UserName;
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            return View(obj);
        }




        [HttpPost]
        public ActionResult ShiftSchedules(ShiftScheduleVM objShift)
        {
            ShiftSchedule Shift = new ShiftSchedule();
            if (objShift.Hours > 12)
            {
                TempData["DeleteMessage"] = string.Format("Shift hours can not exceed 12 hours");
                return RedirectToAction("ShiftSchedule", new { userid = objShift.UserId });
            }
            if (objShift.Hours < 1)
            {
                TempData["DeleteMessage"] = string.Format("Shift hours can not be 0");
                return RedirectToAction("ShiftSchedule", new { userid = objShift.UserId });
            }
            var sh = db.ShiftSchedule.Where(x => (EntityFunctions.TruncateTime(x.StartDate) == EntityFunctions.TruncateTime(objShift.StartDate) || EntityFunctions.TruncateTime(x.EndDate) == EntityFunctions.TruncateTime(objShift.EndDate)) && x.UserId == objShift.UserId && x.Id != objShift.Id).FirstOrDefault();
            if (sh != null)
            {
                TempData["DeleteMessage"] = string.Format("Already schedule the user for this date please choose new date ");
                return RedirectToAction("ShiftSchedule", new { userid = objShift.UserId });
            }
            else
            {

                if (objShift.Id == 0)
                {
                    Shift.UserId = objShift.UserId;
                    Shift.StartDate = objShift.StartDate;
                    Shift.EndDate = objShift.EndDate;
                    Shift.StartTime = objShift.StartTime;
                    TimeSpan? addHours = objShift.Hours.HasValue ? TimeSpan.FromHours(objShift.Hours.Value) : (TimeSpan?)null;
                    Shift.EndTime = (objShift.StartTime + addHours);
                    Shift.ShiftId = objShift.ShiftId;
                    db.ShiftSchedule.Add(Shift);
                }
                else if (objShift.Id > 0)
                {
                    Shift = db.ShiftSchedule.Where(m => m.Id == objShift.Id).FirstOrDefault();
                    if (objShift != null)
                    {
                        Shift.Id = objShift.Id;
                        Shift.UserId = objShift.UserId;
                        Shift.StartDate = objShift.StartDate;
                        Shift.EndDate = objShift.EndDate;
                        Shift.StartTime = objShift.StartDate.Value.TimeOfDay;
                        Shift.EndTime = objShift.EndDate.Value.TimeOfDay;
                        Shift.ShiftId = objShift.ShiftId;
                        db.Entry(Shift).State = EntityState.Modified;
                    }
                }
                db.SaveChanges();
                TempData["message"] = string.Format("Record save successfully. ");
            }
            return RedirectToAction("ShiftSchedule", new { userid = Shift.UserId });

        }


        public ActionResult DeleteShiftSchedule(int id, int userid)
        {

            if (id != 0)
            {
                var Shift = db.ShiftSchedule.Where(x => x.Id == id).FirstOrDefault();
                if (Shift != null)
                {
                    db.ShiftSchedule.Remove(Shift);
                    db.SaveChanges();
                    TempData["message"] = string.Format("Record delete successfully. ");
                    return RedirectToAction("ShiftSchedule", new { userid = userid });
                }
            }
            return RedirectToAction("ShiftSchedule", new { userid = userid });
        }


        public ActionResult ScheduleList()
        {
            UserVM obj = new UserVM();

            try
            {
                var user = db.User.Where(m => m.UserRole == 2);
                if (user != null)
                {
                    obj.userList = user.Select(s => new UserVM
                    {
                        UserId = s.UserId,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Address = s.Address,
                        Sex = s.Sex,
                        DOB = s.DOB,
                        ZipCode = s.ZipCode,
                        City = s.City,
                        Province = s.Province,
                        Email = s.Email,
                        CellPhone = s.CellPhone,
                        UserRole = s.UserRole,
                        MaritalStatusId = s.MaritalStatusId,
                        UserName = s.UserName,
                        Password = s.Password,
                        Image = s.Image,
                        Note = s.Note,
                        Fax = s.Fax,

                        FullName = s.FirstName + "" + s.LastName,
                        GenderName = s.Gender.GenderName,
                        MaritalStatus = s.MaritalStatus.MaritalStatusName,
                    }).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return View(obj);

        }

        #endregion Shift Schedule

    }
}