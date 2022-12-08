using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
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
        public string MailID { get; set; }

        public PersonalDetails(string name,string fatherName,Gender gender,long mobileNumber,string mailID)
        {
            Name = name;
            FatherName = fatherName;
            Gender = gender;
            MobileNumber = mobileNumber;  
            MailID = mailID;           
        }
        public PersonalDetails(string data)
        {
            string[] values = data.Split(',');
            Name = values[1];
            FatherName = values[2];
            Gender = Enum.Parse<Gender>(values[3]);
            MobileNumber = long.Parse(values[4]);
            MailID = values[5];   
        }
    }
}