using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeStudentAdmission
{
    public class AdmissionDetails
    {
        private static int s_AdmissionID = 1000;
        public string AdmissionID { get;}
        public string StudentID { get; set; }
        public string DepartmentID { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string AdmissionStatus { get; set; }

        public AdmissionDetails(string studentID,string departmentID,DateTime admissionDate,string admissionStatus)
        {
            s_AdmissionID++;
            AdmissionID = "AID"+s_AdmissionID;
            StudentID = studentID;
            DepartmentID = departmentID;
            AdmissionDate = admissionDate;
            AdmissionStatus = admissionStatus;  
        }
    }
}