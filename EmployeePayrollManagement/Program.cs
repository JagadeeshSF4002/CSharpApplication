using System;
using System.Collections.Generic;
namespace EmployeePayrollManagement
{
    class Program
    {
        public static void Main(string[] args)
        {
            string choice = "";
            List<EmployeeData> employeeList = new List<EmployeeData>();
            System.Console.WriteLine("****************Employee Payroll Management*****************");
            System.Console.WriteLine();
            System.Console.WriteLine("*******Employee Registration*********");
            do
            {
                System.Console.WriteLine("Enter your name :");
                string employeeName = Console.ReadLine();
                
                System.Console.WriteLine("Enter your role :");
                string employeeRole = Console.ReadLine();
                
                System.Console.WriteLine("Enter your Work Location :");
                WorkLocation workLocation = Enum.Parse<WorkLocation>(Console.ReadLine(),true);

                System.Console.WriteLine("Enter your Team Name :");
                string teamName = Console.ReadLine();
                
                System.Console.WriteLine("Enter your Date of joining :");
                DateTime doj = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);

                System.Console.WriteLine("Enter your Gender : say{Male/Female/Transgender}");
                Gender gender = Enum.Parse<Gender>(Console.ReadLine(),true);

                EmployeeData employee = new EmployeeData(employeeName,employeeRole,workLocation,teamName,doj,gender);            

                employeeList.Add(employee);

                System.Console.WriteLine("Do you want to continue ? say { yes / no }");
                choice = Console.ReadLine();
            }while(choice == "yes");

            System.Console.WriteLine();

            System.Console.WriteLine("***************************************");
            System.Console.WriteLine("*         Employees List              *");
            System.Console.WriteLine("***************************************");
            System.Console.WriteLine();
            foreach(EmployeeData employeeData in employeeList)
            {
                System.Console.WriteLine($"Employee ID is {employeeData.EmployeeID}");
                System.Console.WriteLine($"Employee Name is {employeeData.EmployeeName}");
                System.Console.WriteLine($"Employee Role is {employeeData.Role}");
                System.Console.WriteLine($"Employee Work Location is {employeeData.WorkLocation}");
                System.Console.WriteLine($"Employee Team name is {employeeData.Team}");
                System.Console.WriteLine($"Employee Date of joining is {employeeData.Doj}");
                System.Console.WriteLine($"Gender is {employeeData.Gender}");
            }
            System.Console.WriteLine();
            
            do
            {
                
                System.Console.WriteLine("if you want to calculate salary,please Enter Employee ID otherwise say {NO}");
                string userID = Console.ReadLine().ToUpper();
                bool flag = true;
                foreach(EmployeeData employeeData in employeeList)
                {
                    if(userID == employeeData.EmployeeID)
                    {
                        System.Console.WriteLine("Enter Number of working Days in month :");
                        int workingDays = Convert.ToInt32(Console.ReadLine());
                        
                        System.Console.WriteLine("Enter Number of leave taken in month :");
                        int leaveTaken = Convert.ToInt32(Console.ReadLine());

                        long salary = employeeData.CalculateSalary(workingDays,leaveTaken);

                        System.Console.WriteLine($"{employeeData.EmployeeName}({employeeData.EmployeeID}) Salary is {salary}");

                        flag = false;
    
                    }
                    if(userID == "NO")
                    {
                        break;
                    }
                }

                isValidID(flag);
                System.Console.WriteLine();

                System.Console.WriteLine("if you want to get employee details,please Enter Employee ID otherwise say {NO}");
                userID = Console.ReadLine().ToUpper();
                
                flag = true;
                
                foreach(EmployeeData employeeData in employeeList)
                {
                    if(userID == employeeData.EmployeeID)
                    {
                        
                        System.Console.WriteLine("***************************************");
                        System.Console.WriteLine("*         Employees Details           *");
                        System.Console.WriteLine("***************************************");
                        System.Console.WriteLine();
                        System.Console.WriteLine($"Employee ID is {employeeData.EmployeeID}");
                        System.Console.WriteLine($"Employee Name is {employeeData.EmployeeName}");
                        System.Console.WriteLine($"Employee Role is {employeeData.Role}");
                        System.Console.WriteLine($"Employee Work Location is {employeeData.WorkLocation}");
                        System.Console.WriteLine($"Employee Team name is {employeeData.Team}");
                        System.Console.WriteLine($"Employee Date of joining is {employeeData.Doj.ToString("dd/MM/yyyyno")}");
                        System.Console.WriteLine($"Gender is {employeeData.Gender}");
                        System.Console.WriteLine($"Number of days worked {employeeData.WorkingDays}");
                        System.Console.WriteLine($"Number of leave taken {employeeData.LeaveTaken}");
                        flag = false;
                    }
                }

                isValidID(flag);
                
                System.Console.WriteLine("Do you want to continue for get Employee Details and salary details ? say {yes/no}");
                choice = Console.ReadLine();
                System.Console.WriteLine();
            }while(choice == "yes");

            void isValidID(bool flag)
            {
                if(flag)
                {
                    System.Console.WriteLine("Invalid ID");
                }
            }
        }
    }
}