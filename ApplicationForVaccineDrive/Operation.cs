using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationForVaccineDrive
{
    public static class Operation
    {
        static List<Beneficiary> beneficiariesList = new List<Beneficiary>();
        static List<Vaccine> vaccineList = new List<Vaccine>();
        static List<Vaccination> vaccinationList = new List<Vaccination>();
        static string line = "+-------------------------------------------------------------------------------+";
        static Beneficiary currentBeneficiary;
        static Vaccine currentVaccine;
        static Vaccination currentVaccinatedPerson;
        public static void MainMenu()
        {
           
            int option = 0;
            do
            {
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine("          Main Menu         ");
                System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<");

                System.Console.WriteLine("1.Beneficiary Registration");
                System.Console.WriteLine("2.Login");
                System.Console.WriteLine("3.Get Vaccine Info");
                System.Console.WriteLine("4.Exit");
                System.Console.WriteLine("Enter the Option :");
                option = int.Parse(Console.ReadLine());

                switch(option)
                {
                    case 1:
                            {
                                Registration();
                                break;
                            }
                            
                    case 2:
                            {
                                Login();
                                break;
                            }
                            
                    case 3:
                            {
                                GetVaccineInfo();
                                break;
                            }
                            
                    case 4:
                            {
                                option =  4; 
                                break;
                            }
                    default:
                            {
                                System.Console.WriteLine("Invalid Option");
                                break;
                            }
                }
            }while(option != 4);
        }

        private static void GetVaccineInfo()
        {
            System.Console.WriteLine("Get vaccine info called");
        }

        public static void Login()
        {

            System.Console.WriteLine("        Login Form         ");
            System.Console.WriteLine("----------------------------");
            
            System.Console.WriteLine("Enter your register number ");
            string registerNumber = Console.ReadLine().ToUpper();
            
            currentBeneficiary = ValidateRegisterNumber(registerNumber);

            if(currentBeneficiary != null)
            {
                SubMenu();
            }
            else
            {
                System.Console.WriteLine("Invalid Register Number ");
            }
            
            
        }

        private static void SubMenu()
        {
            currentVaccinatedPerson = GetVaccinationHistory();
            int option = 0;
            do
            {
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine("               Sub Menu              ");
                System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                System.Console.WriteLine();
                System.Console.WriteLine("1.Show my details ");
                System.Console.WriteLine("2.Take Vaccination");
                System.Console.WriteLine("3.My Vaccination Hostory");
                System.Console.WriteLine("4.Due Date");
                System.Console.WriteLine("5.Exit");
                System.Console.WriteLine("Enter the Option :");
                option = int.Parse(Console.ReadLine());

                switch(option)
                {
                    case 1:
                            {
                                ShowMyDetails();
                                break;
                            }
                    case 2:
                            {
                                TakeVaccination();
                                break;
                            }
                    case 3:
                            {
                                MyVaccinationHistory();
                                break;
                            }
                    case 4:
                            {
                                DueDate();
                                break;
                            }
                    case 5:
                            {
                                option = 5;
                                break;
                            }
                    default:
                            {
                                System.Console.WriteLine("  Invalid Option ");
                                break;
                            }

                }
            }while(option != 5);
        }

        private static void DueDate()
        {
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            System.Console.WriteLine($"  Next DueDate of {currentBeneficiary.RegistrationNumber} ");
            System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
            bool registerFlag = true;
                if(currentVaccinatedPerson.RegistrationNumber == currentBeneficiary.RegistrationNumber)
                {
                    if(DateTime.Now.Date > currentVaccinatedPerson.Date || DateTime.Now.Date == currentVaccinatedPerson.Date || DateTime.Now.Date < currentVaccinatedPerson.Date)
                    {
                        if(currentVaccinatedPerson.DoseNumber < 3)
                        {
                            System.Console.WriteLine($"Next Due Date is of {currentVaccinatedPerson.DoseNumber+1} dose is "+currentVaccinatedPerson.Date.AddDays(30).ToString("dd/MM/yyyy"));
                        }
                        else
                        {
                            System.Console.WriteLine("***********You have completed the vaccination course. Thanks for your participation in the vaccination drive.*********************************");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("you can take vaccine now");
                    }
                    registerFlag = false;
                }
            
            if(registerFlag)
            {
                System.Console.WriteLine("*******************Your not even take single dose and not registered**********************");
            }
        }

        private static void MyVaccinationHistory()
        {
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            System.Console.WriteLine($"Vaccination History of {currentVaccinatedPerson.RegistrationNumber}      ");
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            System.Console.WriteLine(line);
            System.Console.WriteLine("| VaccinationID   | RegisterNumber | Vaccine ID | Dose | Vaccination Date       |");
            System.Console.WriteLine(line);
            System.Console.WriteLine($"| {(currentVaccinatedPerson.VaccinationID).PadRight(16)}| {(currentVaccinatedPerson.RegistrationNumber).PadRight(15)}| {(currentVaccinatedPerson.VaccineID).PadRight(11)}| {(""+currentVaccinatedPerson.DoseNumber).PadRight(5)}| {(""+currentVaccinatedPerson.Date.ToString("dd/MM/yyyy")).PadRight(20)}  |");
            System.Console.WriteLine(line);
        }

        private static void TakeVaccination()
        {
           System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
           System.Console.WriteLine("           Take Vaccination         ");
           System.Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");

           System.Console.WriteLine("+------------------------------------------------------+");
           System.Console.WriteLine("| Vaccination ID | Vaccination Name    | No of Does    |");
           System.Console.WriteLine("+------------------------------------------------------+");
           foreach(Vaccine vaccine in vaccineList)
           {
                System.Console.WriteLine($"| {(vaccine.VaccineID).PadRight(15)}| {(vaccine.VaccinationName).PadRight(20)}| {(""+vaccine.NoOfDoes).PadRight(14)}|");
           }
           System.Console.WriteLine("+------------------------------------------------------+");
           
           System.Console.WriteLine("Enter the Vaccine ID :");
           string vaccineID = Console.ReadLine().ToUpper();
           
           currentVaccine = ValidateVaccineID(vaccineID);

           if(currentVaccine != null)
           {
                if(currentVaccinatedPerson != null)
                {
                    if(currentVaccinatedPerson.DoseNumber <= 3 )
                    {
                        if(currentVaccinatedPerson.VaccineID == vaccineID)
                        {
                            if(DateTime.Now.Date > currentVaccinatedPerson.Date || DateTime.Now.Date == currentVaccinatedPerson.Date)
                            {
                                Vaccination vaccinated = new Vaccination(currentBeneficiary.RegistrationNumber,currentVaccine.VaccineID,(currentVaccinatedPerson.DoseNumber+1),DateTime.Now);
                                currentVaccinatedPerson = vaccinated;
                                vaccinationList.Add(vaccinated);
                                UpdateVaccineStock();
                                System.Console.WriteLine($"*****************{vaccinated.DoseNumber} Dose completed*******************");
                            }
                            else
                            {
                                System.Console.WriteLine("*********Your 30 days still not completed****************");
                            }
                        }                         
                        else
                        {
                            System.Console.WriteLine(" You have selected different vaccine ”. You can vaccine with “Covaccine / Covidshield (His first / second dose vaccine type) ");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("All the three Vaccination course are completed you cannot be vaccinated now.");
                    }
                }
                else
                {
                    if(currentBeneficiary.Age > 14)
                    {
                        Vaccination vaccinated = new Vaccination(currentBeneficiary.RegistrationNumber,currentVaccine.VaccineID,1,DateTime.Now);
                        currentVaccinatedPerson = vaccinated;
                        vaccinationList.Add(vaccinated);
                        UpdateVaccineStock();
                        System.Console.WriteLine($"***********{vaccinated.DoseNumber} Dose completed****************");
                    }
                }
           }
           else
           {
            System.Console.WriteLine(" Invalid Vaccine ID ");
           }
        }

        private static void UpdateVaccineStock()
        {
            foreach(Vaccine vaccine in vaccineList)
            {
                if(vaccine.VaccineID == currentVaccine.VaccineID)
                {
                    vaccine.NoOfDoes--;
                }
            }
        }

        private static Vaccination GetVaccinationHistory()
        {
           foreach(Vaccination vaccinatedPerson in vaccinationList)
           {
                if(vaccinatedPerson.RegistrationNumber == currentBeneficiary.RegistrationNumber)
                {
                    return vaccinatedPerson;
                }
           } 
           return null;
        }

        private static Vaccine ValidateVaccineID(string vaccineID)
        {
            foreach(Vaccine vaccine in vaccineList)
            {
                if(vaccine.VaccineID == vaccineID)
                {
                    return vaccine;
                }
            }
            return null;
        }

        private static void ShowMyDetails()
        {
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            System.Console.WriteLine(" Details of Current Logged in customer");
            System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            System.Console.WriteLine(line);
            System.Console.WriteLine("| Register Number | Name        | Mobile Number    | Gender   | City   | Age    |");
            System.Console.WriteLine(line);
            System.Console.WriteLine($"| {(currentBeneficiary.RegistrationNumber).PadRight(16)}| {(currentBeneficiary.Name).PadRight(12)}| {(""+currentBeneficiary.MobileNumber).PadRight(17)}| {(""+currentBeneficiary.Gender).PadRight(9)}| {(""+currentBeneficiary.City).PadRight(7)}| {(""+currentBeneficiary.Age).PadRight(7)}|");
            System.Console.WriteLine(line);
        }

        private static Beneficiary ValidateRegisterNumber(string registerNumber)
        {
            foreach(Beneficiary beneficiary in beneficiariesList)
            {
                if(beneficiary.RegistrationNumber == registerNumber)
                {
                    return beneficiary;
                }
            }
            
            return null;
        }

        public static void Registration()
        {
            System.Console.WriteLine("      Beneficiary Registration    ");
            System.Console.WriteLine();
            System.Console.WriteLine("Enter your Name  :");
            string name = Console.ReadLine();
            
            System.Console.WriteLine("Enter your Age :");
            int age = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter your Gender");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(),true);

            System.Console.WriteLine("Enter your mobile number :");
            long mobileNumber = long.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter your city :");
            string city = Console.ReadLine();

            Beneficiary beneficiary = new Beneficiary(name,gender,mobileNumber,city,age);
            beneficiariesList.Add(beneficiary);

            System.Console.WriteLine($"Your Number is {beneficiary.RegistrationNumber}");

            System.Console.WriteLine("*********************Registration Successful********************");
        }
        public static void DefaultData()
        {
            //Beneficiary Class
            Beneficiary beneficiary = new Beneficiary("Jagadeesh",Gender.Male,98765432110,"chennai",21);
            Beneficiary beneficiary2 = new Beneficiary("praveen",Gender.Male,98763432110,"chennai",23);
            Beneficiary beneficiary3 = new Beneficiary("praveenKumar",Gender.Male,98333432110,"chennai",25);
            beneficiariesList.Add(beneficiary);
            beneficiariesList.Add(beneficiary2);
            beneficiariesList.Add(beneficiary3);
            
            //vaccine class
            Vaccine vaccine = new Vaccine("CovidShield",50);
            Vaccine vaccine2 = new Vaccine("CovidVaccine",50);
            vaccineList.Add(vaccine);
            vaccineList.Add(vaccine2);

            //vaccination class
            Vaccination vaccination = new Vaccination(beneficiary.RegistrationNumber,vaccine.VaccineID,1,new DateTime(2022,11,06));
            Vaccination vaccination2 = new Vaccination(beneficiary2.RegistrationNumber,vaccine2.VaccineID,2,new DateTime(2022,11,26));
            Vaccination vaccination3 = new Vaccination(beneficiary3.RegistrationNumber,vaccine2.VaccineID,3,new DateTime(2022,11,16));
            vaccinationList.Add(vaccination);
            vaccinationList.Add(vaccination2);
            vaccinationList.Add(vaccination3);
        }
    }
}