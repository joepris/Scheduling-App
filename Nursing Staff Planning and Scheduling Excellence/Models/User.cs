//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NursingStaffPlanningandSchedulingExcellence.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int MaritalStatusId { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<int> Sex { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public Nullable<int> UserRole { get; set; }
        public Nullable<int> AccessLevel { get; set; }
        public string Specialization { get; set; }
        public string FullName { get; set; }
        public string Image { get; set; }
        public string Note { get; set; }
        public string Fax { get; set; }
    
        public virtual Gender Gender { get; set; }
        public virtual MaritalStatus MaritalStatus { get; set; }
        public virtual Role Role { get; set; }
    }
}
