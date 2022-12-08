using System.Runtime.InteropServices;
using System.Runtime.ConstrainedExecution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmissionApplication
{
    public static class Operation
    {
      static List<StudentDetails> studentList = new List<StudentDetails>();
      static List<DepartmentDetails> departmentList = new List<DepartmentDetails>();
      static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();

      public static StudentDetails student;

      public static void MainMenu()
      {
        System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        System.Console.WriteLine("     Welcome to main menu    ");
        System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        int option = 0;
        do
        {
            System.Console.WriteLine();
            System.Console.WriteLine("1.Student Registration");
            System.Console.WriteLine("2.Student Login");
            System.Console.WriteLine("3.Exit");
            System.Console.WriteLine("Enter the option :");
            option = int.Parse(Console.ReadLine());

            switch(option)
            {
                    case 1:
                            {
                                Operation.Registration();
                                break;
                            }
                    case 2:
                            {
                                Operation.Login();
                                break;
                            }
                    case 3:
                            {
                                option = 3;
                                System.Environment.Exit(0);
                                break;
                            }
                    default:
                            {
                                System.Console.WriteLine("invalid option");
                                break;
                            }
            }

            }while(option != 3);
      }   

      static void Registration()
      {
         System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
         System.Console.WriteLine("<            RegistrationFrom      >");
         System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
         System.Console.WriteLine();
         
         System.Console.WriteLine("Enter your name :");
         string studentName = Console.ReadLine();
         
         System.Console.WriteLine("Enter your father name :");
         string fatherName = Console.ReadLine();

         System.Console.WriteLine("Enter your gender :");
         Gender gender = Enum.Parse<Gender>(Console.ReadLine(),true);

         System.Console.WriteLine("Enter Date of birth : say {dd/MM/yyyy}");
         DateTime dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

         System.Console.WriteLine("Enter Physics Mark");
         int physicsMark = int.Parse(Console.ReadLine());

         System.Console.WriteLine("Enter Chemistry Mark");
         int chemistryMark = int.Parse(Console.ReadLine());

         System.Console.WriteLine("Enter Maths Mark");
         int mathsMark = int.Parse(Console.ReadLine());

         StudentDetails student = new StudentDetails(studentName,fatherName,dob,gender,physicsMark,chemistryMark,mathsMark);
        
         studentList.Add(student);

         System.Console.WriteLine($"Your registration is successfull.your ID is {student.StudentID}");

      }
      private static void Login()
      {
         System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
         System.Console.WriteLine("<            LoginForm         >");
         System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
         System.Console.WriteLine();

         System.Console.WriteLine("Enter your ID :");
         string userID = Console.ReadLine().ToUpper();
         
         student = IsValidStudentID(userID);

         if(student != null)
         {
            System.Console.WriteLine();
            System.Console.WriteLine("<*************Login successfull**************>");
            System.Console.WriteLine();
            SubMenu();
         }
         else
         {
            System.Console.WriteLine("  Invalid ID  ");
         }
      }

      public static void SubMenu()
      {
        char option = '\0';
        do
        {
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            System.Console.WriteLine("<          Sub Menu           >");
            System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
            System.Console.WriteLine();
            System.Console.WriteLine("a.Check Eligibility ");
            System.Console.WriteLine("b.Show Details");
            System.Console.WriteLine("c.Take Admission");
            System.Console.WriteLine("d.Cancel Admission");
            System.Console.WriteLine("e.Show Admission Details");
            System.Console.WriteLine("f.Exit");
            System.Console.WriteLine("Enter the Option :");
            option = char.Parse(Console.ReadLine());
            switch(option)
            {
                case 'a':
                {
                    CheckEligibity();               
                    break;
                }
                case 'b':
                {
                    ShowDetails();                   
                    break;
                }
                case 'c':
                {
                    TakeAdmission();               
                    break;
                }
                case 'd':
                {  
                    CancelAdmission();              
                    break;
                }
                case 'e':
                {
                    ShowAdmissionDetails();              
                    break;
                }
                case 'f':
                {
                    option = 'f';              
                    break;
                }
                default:
                {
                    System.Console.WriteLine("invalid option");
                    break;
                }
            }

        }while(option != 'f');

      }

     private static void ShowAdmissionDetails()
     {
         foreach(AdmissionDetails admission in admissionList)
         {
            if(admission.StudentID == student.StudentID)
            {
                System.Console.WriteLine($"{admission.AdmissionID}  {admission.StudentID} {admission.DepartmentID} {admission.AdmissionDate} {admission.AdmissionStatus}");
            }
         }
     }

     private static void CancelAdmission()
     {
        foreach(AdmissionDetails admission in admissionList)
        {
            if(student.StudentID == admission.StudentID  && admission.AdmissionStatus == AdmissionStatus.Booked)
            {
                admission.AdmissionStatus = AdmissionStatus.Cancelled;
                
                foreach(DepartmentDetails department in departmentList)
                {
                    if(department.DepartmentID == admission.DepartmentID)
                    {
                        department.NumberOfSeats++;
                        System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                        System.Console.WriteLine("******************Admission Cancelled successfully****************");
                        System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                    }
                }
            }
        }   
     }

      private static void TakeAdmission()
      {
            foreach(DepartmentDetails departmentData in departmentList)
            {
                System.Console.WriteLine($"{departmentData.DepartmentID}       {departmentData.DepartmentName}      {departmentData.NumberOfSeats}");
            }
            System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
            System.Console.WriteLine("<             Take Admission                 >");
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            System.Console.WriteLine();
            
            System.Console.WriteLine("Enter the department ID :");
            string departmentID = Console.ReadLine().ToUpper();
            
            DepartmentDetails department = ValidateDepartmentID(departmentID);

            bool admitted = false;
            if(department != null)
            {
                if(department.NumberOfSeats > 0)
                {
                    if(student.CheckEligibility(75.0))
                    {
                        foreach(AdmissionDetails admission in admissionList)
                        {
                            if(student.StudentID == admission.StudentID && admission.AdmissionStatus == AdmissionStatus.Booked)
                            {
                                admitted = true;
                                System.Console.WriteLine("****************you have already taken admission****************");
                                break;
                            }
                        }
                        if(!admitted)
                        {
                            department.NumberOfSeats--;
                            AdmissionDetails admission = new AdmissionDetails(student.StudentID,department.DepartmentID,DateTime.Now,AdmissionStatus.Booked);
                            admissionList.Add(admission);
                            System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                            System.Console.WriteLine($"<                Your Admission ID is {admission.AdmissionID}              >");
                            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("*************Not Eligible****************");
                    }
                }
                else
                {
                    System.Console.WriteLine("******************There is no seat available in department************************");
                }
            }
            else
            {
                System.Console.WriteLine("***************Invalid Department ID**************");
            }
      }
     
      private static DepartmentDetails ValidateDepartmentID(string departmentID)
      {
        foreach(DepartmentDetails department in departmentList)
        {
            if(department.DepartmentID == departmentID)
            {
                return department;
            }
        } 
        return null;
      }

      private static void ShowDetails()
      {
           
            System.Console.WriteLine($"{student.StudentID} {student.StudentName} {student.FatherName} {student.DOB.ToString("dd/MM/yyyy")} {student.Gender} {student.Physics} {student.Chemistry}  {student.Maths}");   
      }



      private static void CheckEligibity()
      {
            double average = student.AverageCalculation();
            bool eligibility = student.CheckEligibility(average);

            if(eligibility)
            {
                System.Console.WriteLine();
                System.Console.WriteLine("<*******************Student is eligible***************>");
                System.Console.WriteLine();
            }
            else
            {
                System.Console.WriteLine();
                System.Console.WriteLine("<******************Student is not eligible****************>");
                System.Console.WriteLine();
            }
      }

      static StudentDetails IsValidStudentID(string userID)
      {
        foreach(StudentDetails currentStudent in studentList)
        {
            if(currentStudent.StudentID == userID)
            {
                return currentStudent;
            }
        }
        return null;
      } 
      public static void DefaultData()
      {       
            DateTime dat = new DateTime(1999,11,11);
            DateTime dat2 = new DateTime(1999,05,05);
            StudentDetails student1 = new StudentDetails("Ravichandran","Ettaparajan",dat,Gender.Male,95,95,95);
            StudentDetails student2 = new StudentDetails("Baskaran","Sethurajan",dat2,Gender.Male,95,85,95);
            studentList.Add(student1);
            studentList.Add(student2);
            
            
            DepartmentDetails department1 = new DepartmentDetails("EEE",30);
            DepartmentDetails department2 = new DepartmentDetails("ECE",30);
            DepartmentDetails department3 = new DepartmentDetails("CSE",30);
            DepartmentDetails department4 = new DepartmentDetails("MECH",30);
            departmentList.Add(department1);
            departmentList.Add(department2);
            departmentList.Add(department3);
            departmentList.Add(department4);

            AdmissionDetails admission1 = new AdmissionDetails(student1.StudentID,department1.DepartmentID,DateTime.Now,AdmissionStatus.Booked);
            AdmissionDetails admission2 = new AdmissionDetails(student2.StudentID,department2.DepartmentID,DateTime.Now,AdmissionStatus.Booked);
            admissionList.Add(admission1);
            admissionList.Add(admission2);


            System.Console.WriteLine("Student details list");
            foreach(StudentDetails studentData in studentList)
            {
                System.Console.WriteLine($"{studentData.StudentID}  {studentData.StudentName}   {studentData.FatherName}    {studentData.DOB.ToString("dd/MM/yyyy")}      {studentData.Gender}        {studentData.Physics}       {studentData.Chemistry}     {studentData.Maths}");    
            }

            System.Console.WriteLine("List of Departments");
            foreach(DepartmentDetails departmentData in departmentList)
            {
                System.Console.WriteLine($"{departmentData.DepartmentID}       {departmentData.DepartmentName}      {departmentData.NumberOfSeats}");
            }


            System.Console.WriteLine("Admission Details ");
            System.Console.WriteLine();
            foreach(AdmissionDetails admissionData in admissionList)
            {
                System.Console.WriteLine($"{admissionData.AdmissionID}  {admissionData.StudentID}   {admissionData.DepartmentID}    {admissionData.AdmissionDate.ToString("dd/MM/yyyy")}   {admissionData.AdmissionStatus}");
            }
        }
    }
}