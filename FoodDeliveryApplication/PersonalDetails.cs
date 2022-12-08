using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryApplication
{
    /// <summary>
    /// Enum used for default values in this context we used Gender
    /// </summary>
    public enum Gender
    {
        Default,Male,Female,Transgender
    }
    /// <summary>
    /// <see cref="PersonalDetails"> In this class personal information assigned to the properties
    /// </summary>
    public class PersonalDetails
    {
        /// <summary>
        /// Name property used to store user names
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        /// <summary>
        /// Father Property used to store father names in string format
        /// </summary>
        /// <value></value>
        public string FatherName { get; set; }
        /// <summary>
        /// Gender specified three category {Male/Female/Transgender}
        /// </summary>
        /// <value></value>
        public  Gender Gender { get; set; }
        /// <summary>
        /// Mobile Property used to store numbers in integer format
        /// </summary>
        /// <value></value>
        public ulong MobileNumber { get; set; }
        /// <summary>
        /// DateTime Property used to store data of birth
        /// </summary>
        /// <value></value>
        public DateTime DOB { get; set; }
        /// <summary>
        /// Mail ID property used to store mail info from user
        /// </summary>
        /// <value></value>
        public string MailID{ get; set; }
        /// <summary>
        /// Location property used to user info where he is located
        /// </summary>
        /// <value></value>
        public string Location { get; set; }

        /// <summary>
        /// Parameterized Constructor are used to get a info from user assigned to specified properties
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fatherName"></param>
        /// <param name="gender"></param>
        /// <param name="mobileNumber"></param>
        /// <param name="dob"></param>
        /// <param name="mailID"></param>
        /// <param name="location"></param>

        public PersonalDetails(string name,string fatherName,Gender gender,ulong mobileNumber,DateTime dob,string mailID,string location)
        {
            Name = name;
            FatherName = fatherName;
            Gender = gender;
            MobileNumber = mobileNumber;
            DOB = dob;
            MailID = mailID;
            Location = location;
        }
        /// <summary>
        /// Default constructor used for handling some exception
        /// </summary>
        public PersonalDetails()
        {
            
        }
    }
}