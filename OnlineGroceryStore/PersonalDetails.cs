using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore
{
    public enum Gender
    {
        Default,Male,Female,Transgender
    } 
    public class PersonalDetails
    {
        public string Name { get; set; }
        public string FatherName { get; set; }
        public Gender Gender { get; set; }
        public long MobileNumber { get; set; }
        public DateTime DOB { get; set; }
        public string MailID { get; set; }

        public PersonalDetails(string name , string fatherName,Gender gender,long mobileNumber,DateTime dob,string mailID)
        {
            Name = name;
            FatherName = fatherName;
            Gender = gender;
            MobileNumber = mobileNumber;
            DOB = dob;
            MailID = mailID; 
        }
        public PersonalDetails()
        {
            
        }
    }
}