
using System;
using System.Collections.Generic;
/// <summary>
/// used to process the college admission using this application
/// </summary>
namespace CollegeAdmission
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<StudentDetails> studentList = new List<StudentDetails>();
            // System.Console.WriteLine("*******Student Registration form with default constructor*******");
            // string choice = "";
            // do
            // {
            //     StudentDetails student = new StudentDetails();

            //     System.Console.WriteLine("Enter your name");
            //     student.Name = Console.ReadLine();//call set method {used to set the information to field}

            //     System.Console.WriteLine("Enter your father name ");
            //     student.FatherName = Console.ReadLine();

            //     System.Console.WriteLine("Enter your gender ");
            //     student.Gender = Console.ReadLine();

            //     System.Console.WriteLine("Enter your Date of Birth dd/MM/yyyy");
            //     student.DOB = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

            //     System.Console.WriteLine("Enter your mobile number ");
            //     student.MobileNumber = Convert.ToInt64(Console.ReadLine());

            //     System.Console.WriteLine("Enter your physics mark ");
            //     student.PhysicsMark = Convert.ToInt32(Console.ReadLine());

            //     System.Console.WriteLine("Enter your chemistry mark ");
            //     student.ChemistryMark = Convert.ToInt32(Console.ReadLine());

            //     System.Console.WriteLine("Enter your maths mark ");
            //     student.MathsMark = Convert.ToInt32(Console.ReadLine());

            //     studentList.Add(student);
                    
            //     System.Console.WriteLine("Do you want to continue?say yes/no");
            //     choice = Console.ReadLine();
            // }while(choice == "yes");
            

            System.Console.WriteLine("*******Student Registration form with parameterized constructor*******");
            string choice1 = "";
            do
            {

                System.Console.WriteLine("Enter your name");
                string name = Console.ReadLine();//call set method {used to set the information to field}

                System.Console.WriteLine("Enter your father name ");
                string fatherName = Console.ReadLine();

                System.Console.WriteLine("Enter your gender ");
                Gender gender =Enum.Parse<Gender>(Console.ReadLine(),true); // Enumerated types //true is any case (lower or upper)

                System.Console.WriteLine("Enter your mobile number ");
                long mobileNumber = Convert.ToInt64(Console.ReadLine());

                System.Console.WriteLine("Enter your Date of Birth dd/MM/yyyy");
                DateTime dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

                System.Console.WriteLine("Enter your physics mark ");
                int physicsMark = Convert.ToInt32(Console.ReadLine());

                System.Console.WriteLine("Enter your chemistry mark ");
                int chemistryMark = Convert.ToInt32(Console.ReadLine());

                System.Console.WriteLine("Enter your maths mark ");
                int mathsMark = Convert.ToInt32(Console.ReadLine());

                StudentDetails student = new StudentDetails(name,fatherName,gender,mobileNumber,dob,physicsMark,chemistryMark,mathsMark);

                studentList.Add(student);

                System.Console.WriteLine($"Your ID is {student.StudentID}");
                    
                System.Console.WriteLine("Do you want to continue?say yes/no");
                choice1 = Console.ReadLine().ToLower();
            }while(choice1 == "yes");
            
            bool flag = true;
            
            System.Console.WriteLine("Enter student ID You want to search ");
            string userID = Console.ReadLine().ToUpper();
            
            foreach(StudentDetails studentData in studentList)
            {

                if(userID == studentData.StudentID)
                {
                    flag = false;
                    System.Console.WriteLine($"Student ID is {studentData.StudentID}\nName is {studentData.Name} \nFather's name is {studentData.FatherName} \nGender is {studentData.Gender} \nDOB is {studentData.DOB.ToString("dd/MM/yyyy")} \nMobileNumber is {studentData.MobileNumber} \nPhysics mark is {studentData.PhysicsMark} \nChemistry mark is {studentData.ChemistryMark} \nMaths mark is {studentData.MathsMark}"); 
                    bool status = studentData.IsEligible(75);

                    if(status)
                    {
                        System.Console.WriteLine("you are Eligible for admission");
                    }
                    else
                    {
                        System.Console.WriteLine("you are Not Eligible for admission");
                    }
                    System.Console.WriteLine();
                }
            }
            if(flag)
            {
                System.Console.WriteLine("Invalid ID Entered");
            }
        }
    }
}