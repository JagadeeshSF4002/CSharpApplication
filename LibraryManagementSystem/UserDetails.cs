using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public enum Gender
    {
        Default,Male,Female,Transgender
    }
    public enum Department
    {
        Default,EEE,ECE,MECH,CSE
    }
    public class UserDetails
    {
        private static int s_registrationID = 3000;
        public string RegistrationID { get; set; }
        public string UserName { get; set; }
        public long MobileNumber { get; set; }
        public Gender Gender { get; set; }
        public string MailID { get; set; }
        public Department Department { get; set; }

        public UserDetails(string userName,Gender gender,Department department,long mobileNumber,string mailID)
        {
            s_registrationID++;
            RegistrationID = "SF"+s_registrationID;
            UserName = userName;
            Gender = gender;
            Department = department;
            MobileNumber = mobileNumber;
            MailID = mailID;
        }
    }
}