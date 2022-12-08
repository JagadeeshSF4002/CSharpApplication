using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmissionWithFile
{
    public enum Gender
    {
        Default,Male,Female,Transgender
    }
    public class StudentDetails
    {
        private static int s_studentID = 3000;
        public string StudentID { get; }
        public string StudentName { get; set; }
        public string  FatherName { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int Maths { get; set; }

        public StudentDetails(string studentName,string fatherName,DateTime dob,Gender gender,int physics,int maths,int chemistry)
        {
            s_studentID++;
            StudentID = "SF"+s_studentID;
            StudentName = studentName;
            FatherName = fatherName;
            Gender = gender;
            DOB = dob;
            Physics = physics;
            Chemistry = chemistry;
            Maths = maths;
        }

        public StudentDetails(string data)
        {
            string[] values = data.Split(",");
            s_studentID = int.Parse(values[0].Remove(0,2));
            StudentID = values[0];
            StudentName = values[1];
            FatherName = values[2];
            Gender = Enum.Parse<Gender>(values[3]);
            DOB = DateTime.ParseExact(values[4],"dd/MM/yyyy",null);
            Physics = int.Parse(values[5]);
            Chemistry = int.Parse(values[6]);
            Maths = int.Parse(values[7]);
        }

        public bool CheckEligibility(double cutOff)
        {
            double average = (Physics+Maths+Chemistry)/3;
            if(average >= cutOff)
            {
                return true;
            }
            return false;
        }

        public  double AverageCalculation()
        {
            return (double)(Physics+Maths+Chemistry)/3;
        }
    }
}