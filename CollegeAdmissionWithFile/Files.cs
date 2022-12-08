
using System.IO;
namespace CollegeAdmissionWithFile
{
    public static class Files
    {
        public static void Create()
        {
            if(!Directory.Exists("CollegeAdmission"))
            {
                System.Console.WriteLine("Creating folder");
                Directory.CreateDirectory("CollegeAdmission");
                System.Console.WriteLine("**************Folder created***************");
            }
            else
            {
                System.Console.WriteLine("Folder Found");
            }

            if(!File.Exists("CollegeAdmission/StudentDetails.csv"))
            {
                System.Console.WriteLine("Creating file - StudentDetails.csv");
                var file = File.Create("CollegeAdmission/StudentDetails.csv");
                file.Close();
            }

            if(!File.Exists("CollegeAdmission/DepartmentDetails.csv"))
            {
                System.Console.WriteLine("Creating file - DepartmentDetails.csv");
                var file = File.Create("CollegeAdmission/DepartmentDetails.csv");
                file.Close();
            }
            if(!File.Exists("CollegeAdmission/AdmissionDetails.csv"))
            {
                System.Console.WriteLine("Creating file - AdmissionDetails.csv");
                var file = File.Create("CollegeAdmission/AdmissionDetails.csv");
                file.Close();
            }
        }


        public static void WriteFiles()
        {
            int i = 0;
            string[] studentDetails = new string[Operation.studentList.Count];

            for( i=0; i < Operation.studentList.Count;i++)
            {
                System.Console.WriteLine(Operation.studentList[i].StudentID);
                studentDetails[i] = Operation.studentList[i].StudentID+","+Operation.studentList[i].StudentName+","+Operation.studentList[i].FatherName+","+Operation.studentList[i].Gender+","+Operation.studentList[i].DOB.ToString("dd/MM/yyyy")+","+Operation.studentList[i].Physics+","+Operation.studentList[i].Chemistry+","+Operation.studentList[i].Maths;
            }

            File.WriteAllLines("CollegeAdmission/StudentDetails.csv",studentDetails);

            string[] departmentDetails = new string[Operation.departmentList.Count];

            for(i = 0;i < Operation.departmentList.Count;i++)
            {
                departmentDetails[i] = Operation.departmentList[i].DepartmentID +","+Operation.departmentList[i].DepartmentName+","+Operation.departmentList[i].NumberOfSeats;
            }

            File.WriteAllLines("CollegeAdmission/DepartmentDetails.csv",departmentDetails);

            string[] admissionDetils = new string[Operation.admissionList.Count];

            for(i = 0; i < Operation.admissionList.Count;i++)
            {
                admissionDetils[i] = Operation.admissionList[i].AdmissionID+","+Operation.admissionList[i].DepartmentID+","+Operation.admissionList[i].StudentID+","+Operation.admissionList[i].AdmissionDate.ToString("dd/MM/yyyy")+","+Operation.admissionList[i].AdmissionStatus;
            }
            File.WriteAllLines("CollegeAdmission/AdmissionDetails.csv",admissionDetils);
        } 

        public static void ReadFiles()
        {
            string[] studentDetails = File.ReadAllLines("CollegeAdmission/StudentDetails.csv");

            foreach(string data in studentDetails)
            {
                StudentDetails student = new StudentDetails(data);
                Operation.studentList.Add(student);          
            }

            string[] departmentDetails = File.ReadAllLines("CollegeAdmission/DepartmentDetails.csv");

            foreach(string data in departmentDetails)
            {
                DepartmentDetails department = new DepartmentDetails(data);
                Operation.departmentList.Add(department);
                    
            }

            string[] admissionDetails = File.ReadAllLines("CollegeAdmission/AdmissionDetails.csv");

            foreach(string data in admissionDetails)
            {
                AdmissionDetails admission = new AdmissionDetails(data);
                Operation.admissionList.Add(admission);
                    
            }
        }       
    }
}