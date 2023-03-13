﻿using Newtonsoft.Json;
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
        public async Task<ActionResult> profile(int? UserID)
        {

            int UserIDs = LoginRepository.GetUserID(User.Identity.Name);
            if(UserIDs==0)
            {
                UserIDs = UserID??0;
            }
            UserVM obj = new UserVM();
            try
            {
                if (UserID != 0 || UserIDs !=0)
                {
                     var task = db.User.Where(x => x.UserId == UserIDs).FirstOrDefault();
                    obj.UserId = task.UserId;
                    obj.FirstName = task.FirstName;
                    obj.LastName = task.LastName;
                    obj.DOB = task.DOB;
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
            }
            catch (Exception ex)
            {

            }
            return View(obj);

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
                    obj.DOB = task.DOB;
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

  
    }
}