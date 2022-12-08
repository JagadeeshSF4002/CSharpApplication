using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineThreatreTicketBooking
{
    public class PersonalDetails
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public ulong PhoneNumber { get; set; }
        public PersonalDetails(string name,int age,ulong phoneNumber)
        {
            Name = name;
            Age = age;
            PhoneNumber = phoneNumber;
        }
        public PersonalDetails(string data)
        {
            
        }
    }
}