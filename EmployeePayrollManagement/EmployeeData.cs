
using System;

namespace EmployeePayrollManagement
{
    public enum Gender
    {
        Default,Male,Female,Transgender
    }
    public enum WorkLocation
    {
        Default,Chennai,Bengalore
    }
    public class EmployeeData
    {
        private static int s_employeeID = 1000;
        public string EmployeeID { get;  }
        public string EmployeeName { get; set; }
        public string Role { get; set; }
        public WorkLocation WorkLocation { get; set; }
        public string Team { get; set; }
        public DateTime Doj { get; set; }
        public int WorkingDays { get; set; }
        public int LeaveTaken { get; set; }

        public Gender Gender { get; set; }

        public EmployeeData(string employeeName,string role,WorkLocation workLocation,string teamName,DateTime doj,Gender gender)
        {
            s_employeeID++;
            EmployeeID = "SF"+s_employeeID;
            EmployeeName = employeeName;
            Role = role;
            WorkLocation = workLocation;
            Team = teamName;
            Doj = doj;
            Gender = gender;
        }

        public long CalculateSalary(int workingDays,int leaveTaken)
        {
            int perDayCharge = 500;
            WorkingDays = workingDays;
            LeaveTaken = leaveTaken;
            long totalSalary = (workingDays-leaveTaken)*perDayCharge;
            return totalSalary;
        }
    }
}