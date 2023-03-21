using Newtonsoft.Json;
using NursingStaffPlanningandSchedulingExcellence.Models;
using NursingStaffPlanningandSchedulingExcellence.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NursingStaffPlanningandSchedulingExcellence.Controllers
{
    public class StaffController : Controller
    {
        NursingStaffEntities db = new NursingStaffEntities();

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult StaffDetails(int id)
        {
            int UserID = id;
            UserID = LoginRepository.GetUserID(User.Identity.Name);
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

        [HttpGet]
        public async Task<ActionResult> profile(int? UserID)
        {

            int UserIDs = LoginRepository.GetUserID(User.Identity.Name);
            if(UserIDs==0)
            {
                UserIDs = UserID??0;
            }
            UserVM obj = new UserVM();
            ShiftScheduleVM obj2 = new ShiftScheduleVM();
            try
            {
                if (UserIDs != null)
                {
                    var task = db.User.Where(x => x.UserId == UserIDs).FirstOrDefault();
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

                    var task2 = db.ShiftSchedule.Where(x => x.UserId == UserIDs).FirstOrDefault();
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
                }
                obj.gendersList = db.Gender.ToList();
                obj.maritalsList = db.MaritalStatus.ToList();
                obj.rolesList = db.Role.ToList();

            }
            catch (Exception ex)
            {
                return View("Error");
            }
            UserWithScheduleVM obj3 = new UserWithScheduleVM() { User = obj, ShiftSchedule = obj2 };
            return View(obj3);

        }

        [HttpGet]
        public async Task<ActionResult> SaveStaff(int? id)
        {
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
                obj.doctorList = db.User.Where(x => x.UserRole == 4).ToList();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            return View(obj);
        }


        [HttpPost]
        public async Task<ActionResult> SaveStaff(UserVM objuser)
        {
            int UserID = LoginRepository.GetUserID(User.Identity.Name);
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
                db.SaveChanges();

                TempData["message"] = string.Format("Record save successfully. ");
                return RedirectToAction("profile", "staff", new { UserID = UserID });
            }

        [HttpGet]
        public ActionResult ShiftSchedule()
        {
            int UserID = LoginRepository.GetUserID(User.Identity.Name);
            ShiftScheduleVM obj = new ShiftScheduleVM();
            try
            {
                obj.ShiftScheduleList = db.ShiftSchedule.Where(x => x.UserId == UserID && x.EndDate >= DateTime.Now).ToList();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            return View(obj);
        }


    }
}