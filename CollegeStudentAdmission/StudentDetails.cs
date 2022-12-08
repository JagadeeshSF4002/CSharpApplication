using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeStudentAdmission
{
    public enum Gender
    {
        Default,Male,Female,Transgender
    }
    public class StudentDetails
    {
        private static int s_studentID = 3000;
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public long HSCMarksheetNumber { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int Maths { get; set; }

        public StudentDetails(string studentName,string fatherName,DateTime dob,Gender gender,long hscMarksheetNumber,int physics,int chemistry,int maths)
        {
            s_studentID++;
            StudentID = "SF"+s_studentID;
            StudentName = studentName;
            FatherName = fatherName;
            DOB = dob;
            Gender = gender;
            HSCMarksheetNumber = hscMarksheetNumber;
            Physics = physics;
            Chemistry = chemistry;
            Maths = maths;
        }
    }
}