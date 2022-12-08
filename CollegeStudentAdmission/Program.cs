using System.Runtime.ConstrainedExecution;
using System;
using System.Collections.Generic;
namespace CollegeStudentAdmission
{
    class Program
    {
        private static List<StudentDetails> studentList = new List<StudentDetails>();
        private static List<DepartmentDetails> departmentList = new List<DepartmentDetails>();
        private static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();
        public static void Main(string[] args)
        {
            Default();//Default method used for default students,departments,admission detatils are added to list
            
            DisplayMainMenu();

            void DisplayMainMenu()
            {
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine("<               Admission in College            >");
                System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                System.Console.WriteLine();
                System.Console.WriteLine("1.Student Registration");
                System.Console.WriteLine("2.Student Login");
                System.Console.WriteLine("3.Check Department wise seat availability");
                System.Console.WriteLine("4.Exit");
                System.Console.WriteLine("Enter the Option :");
                int choice = int.Parse(Console.ReadLine());
                bool status;
                switch(choice)
                {
                    case 1:
                            {
                                StudentRegistration();
                                Console.ReadLine();
                                DisplayMainMenu();
                                break;
                            }
                    
                    case 2:
                            {
                                status = StudentLogin();
                                if(!status)
                                {
                                    System.Console.WriteLine("Invalid student id");    
                                }
                                Console.ReadLine();
                                DisplayMainMenu();
                                break;
                            }
                    
                    case 3:
                            {
                                SeatAvailability();
                                Console.ReadLine();
                                DisplayMainMenu();
                                break;
                            }
                    case 4:
                            {
                                System.Environment.Exit(0);
                                break;
                            }
                    default:
                            {
                                System.Console.WriteLine("Invalid Option");
                                break;
                            }
                }
            }

            void StudentRegistration()
            {
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine("<         Registration           >");
                System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");

                System.Console.WriteLine("Enter the Student Name :");
                string name = Console.ReadLine();
                
                System.Console.WriteLine("Enter the Father Name :");
                string fatherName = Console.ReadLine();
                
                System.Console.WriteLine("Enter the date of birth : {dd/MM/yyyy}");
                DateTime dat = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

                System.Console.WriteLine("Enter the Gender :");
                Gender gender = Enum.Parse<Gender>(Console.ReadLine(),true);

                System.Console.WriteLine("Enter the HSC Marksheet Number :");
                long hscMarksheetNumber = long.Parse(Console.ReadLine());

                System.Console.WriteLine("Enter the Physics Mark :");
                int physics = int.Parse(Console.ReadLine());

                System.Console.WriteLine("Enter the Chemistry Mark :");
                int chemistry = int.Parse(Console.ReadLine());

                System.Console.WriteLine("Enter the Maths Mark :");
                int maths = int.Parse(Console.ReadLine());

                StudentDetails student = new StudentDetails(name,fatherName,dat,gender,hscMarksheetNumber,physics,chemistry,maths);
                studentList.Add(student);

                System.Console.WriteLine($"Student Added Successfully and student ID is {student.StudentID}");
            }

            bool StudentLogin()
            {
                System.Console.WriteLine("Enter the Student ID :");
                string studentID = Console.ReadLine().ToUpper();

                bool status = ValidateID(studentID);

                if(status)
                {
                    submenu:
                    System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    System.Console.WriteLine("<            Main Menu              >");
                    System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                    System.Console.WriteLine("a.Check Eligibity ");
                    System.Console.WriteLine("b.Show Details ");
                    System.Console.WriteLine("c.Take Admission");
                    System.Console.WriteLine("d.Cancel Admission");
                    System.Console.WriteLine("e.ShowAdmissionDetails");
                    System.Console.WriteLine("f.Exit");
                    System.Console.WriteLine("Enter the option :");
                    char options = char.Parse(Console.ReadLine());
                    switch(options)
                    {
                        case 'a':
                                {
                                    CheckEligibity(75.0f,studentID);
                                    Console.ReadLine();
                                    goto submenu;
                                }
                        case 'b':
                                {
                                    ShowDetails(studentID);
                                    Console.ReadLine();
                                    goto submenu;
                                }
                        case 'c':
                                {
                                    TakeAdmission(studentID);
                                    Console.ReadLine();
                                    goto submenu;
                                }
                        case 'd':
                                {
                                    CancelAdmission(studentID);
                                    Console.ReadLine();
                                    goto submenu;
                                }
                        case 'e':
                                {
                                    ShowAdmissionDetails(studentID);
                                    Console.ReadLine();
                                    goto submenu;
                                }
                        case 'f':
                                {
                                    DisplayMainMenu();
                                    break;
                                }
                        default:
                                {
                                    System.Console.WriteLine("Invalid Option");
                                    goto submenu;
                                }
                    }
                    return true;
                }
                return false;
            }

            bool ValidateID(string studentID)
            {
                foreach(StudentDetails studentData in studentList)
                {
                   if(studentID == studentData.StudentID) 
                   {
                        return true;
                   }      
                }
                return false;
            }

            void CheckEligibity(float average,string studentID)
            {
                foreach(StudentDetails studentData in studentList)
                {
                    if(studentData.StudentID == studentID)
                    {
                        float getMark = (float)(studentData.Chemistry+studentData.Physics+studentData.Maths)/3;
                        if(getMark>=average)
                        {
                            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                            System.Console.WriteLine("Student is eligible");
                            System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                        }
                        else
                        {
                            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                            System.Console.WriteLine("Student is not eligible");
                            System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                        }
                    }
                }
            }

            void ShowDetails(string studentID)
            {
                System.Console.WriteLine("Student ID   |StudentName     |FatherName     |DOB        |Gender     |Physics        |Chemistry      |Maths ");
                foreach(StudentDetails studentData in studentList)
                {
                    System.Console.WriteLine($"{studentData.StudentID}       |{studentData.StudentName}      |{studentData.FatherName}   |{studentData.DOB.ToString("dd/MM/yyyy")}   |{studentData.Gender}     |{studentData.Physics}       |{studentData.Chemistry}                |{studentData.Maths}");
                }
            }

            void TakeAdmission(string studentID)
            {
                Departments();
                System.Console.WriteLine("Select One Department ID in List");
                string departmentID = Console.ReadLine().ToUpper();

                bool status = ValidateDepartmentID(departmentID,studentID);
                
                if(status)
                {
                    bool checkStatus = isAdmissionTaken(studentID);
                    if(checkStatus)
                    {
                        foreach(DepartmentDetails departmentData in departmentList)
                        {
                            if(departmentData.DepartmentID == departmentID)
                            {
                                departmentData.NumberOfSeats = departmentData.NumberOfSeats-1;
                                AdmissionDetails admit = new AdmissionDetails(studentID,departmentID,DateTime.Now,"Booked");
                                admissionList.Add(admit);
                                System.Console.WriteLine($"Admission took succesully.Your admission ID - {admit.AdmissionID}");
                            }
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    System.Console.WriteLine("             You already taken one seat");
                    System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                }


            }

            void Departments()
            {
                System.Console.WriteLine("DeparmentID       DeparmentName       Number Of seats");
                foreach(DepartmentDetails departmentData in departmentList)
                {
                    System.Console.WriteLine($"{departmentData.DepartmentID}                {departmentData.DepartmentName}                     {departmentData.NumberOfSeats}");
                }
            }

            bool ValidateDepartmentID(string departmentID,string studentID)
            {
                foreach(DepartmentDetails departmentData in departmentList)
                {
                    if(departmentID == departmentData.DepartmentID)
                    {
                        bool status = ValidateID(studentID);
                        if(status)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return false;
            }

            bool isAdmissionTaken(string studentID)
            {
                foreach(AdmissionDetails admissionData in admissionList)
                {
                    if(admissionData.StudentID == studentID)
                    {
                         return false;   
                    }
                }
                return true;
            }

            void CancelAdmission(string studentID)
            {
                foreach(AdmissionDetails admissionData in admissionList)
                {
                    if(admissionData.StudentID == studentID)
                    {
                        System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                        System.Console.WriteLine($"                                                 {studentID} student details shown below                                                                 ");
                        System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                        System.Console.WriteLine();
                        System.Console.WriteLine(admissionData.AdmissionID+" "+admissionData.StudentID+" "+admissionData.DepartmentID+" "+admissionData.AdmissionDate.ToString("dd/MM/yyyy")+" "+"  "+admissionData.AdmissionStatus);
                        admissionData.AdmissionStatus = "Cancelled";
                        bool updateStatus = UpdateSeats(admissionData.DepartmentID);
                        if(updateStatus)
                        {
                            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                            System.Console.WriteLine("Seat Cancelled successfully");
                            System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                        }
                    }
                }
            }

            bool UpdateSeats(string departmentID)
            {
                foreach(DepartmentDetails departmentData in departmentList)
                {
                    if(departmentData.DepartmentID == departmentID)
                    {
                        departmentData.NumberOfSeats = departmentData.NumberOfSeats+1;
                        return true;
                    }
                }
                return false;
            }

            void ShowAdmissionDetails(string studentID)
            {
                foreach(AdmissionDetails admissionData in admissionList)
                {
                    if(admissionData.StudentID == studentID)
                    {
                        System.Console.WriteLine("Your admission ID is "+admissionData.AdmissionID);
                        System.Console.WriteLine("Student ID is "+admissionData.StudentID);
                        System.Console.WriteLine("Department ID is "+admissionData.DepartmentID);
                        System.Console.WriteLine("Admission Date is "+admissionData.AdmissionDate);
                        System.Console.WriteLine("Admission status "+admissionData.AdmissionStatus);
                    }
                }
            }
            
            void SeatAvailability()
            {
                System.Console.WriteLine("DeparmentID       DeparmentName       Number Of seats");
                foreach(DepartmentDetails departmentData in departmentList)
                {
                    System.Console.WriteLine($"{departmentData.DepartmentID}                {departmentData.DepartmentName}                     {departmentData.NumberOfSeats}");
                }
            }


        }
        static void Default()
        {

            DateTime defaultStudent1Date = new DateTime(1999,11,11);
            DateTime defaultStudent2Date = new DateTime(2000,11,11);
            StudentDetails defaultStudent1 = new StudentDetails("Ravichandran","Ettaparajan",defaultStudent1Date,Gender.Male,9876534,95,95,95);
            StudentDetails defaultStudent2 = new StudentDetails("Jagadeesh","Elumalai",defaultStudent2Date,Gender.Male,23523637,95,95,95);
            studentList.Add(defaultStudent1);
            studentList.Add(defaultStudent2);

            DepartmentDetails ECE = new DepartmentDetails("ECE",29);
            DepartmentDetails CSE = new DepartmentDetails("CSE",29);
            DepartmentDetails EEE = new DepartmentDetails("EEE",30);
            DepartmentDetails MECH = new DepartmentDetails("MECH",30);
            departmentList.Add(ECE);
            departmentList.Add(CSE);
            departmentList.Add(EEE);
            departmentList.Add(MECH);

            AdmissionDetails defaultAdmit = new AdmissionDetails(defaultStudent1.StudentID,CSE.DepartmentID,DateTime.Now,"Booked");
            AdmissionDetails defaultAdmit2 = new AdmissionDetails(defaultStudent2.StudentID,EEE.DepartmentID,DateTime.Now,"Booked");
            admissionList.Add(defaultAdmit);
            admissionList.Add(defaultAdmit2);
        }
    }
}