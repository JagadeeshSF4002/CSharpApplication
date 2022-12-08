using System;
/// <summary>
/// used to process the college admission using this application
/// </summary>
namespace CollegeAdmission
{
    /// <summary>
    /// Class <see cref="StudentInfo"/> used to select student's gender information
    /// </summary>
    public enum Gender // pascal case
    {
        Default,Male,Female,Transgender //pascal case
    }
    /// <summary>
    /// Class <see cref="StudentInfo"/> used to select student's gender information
    /// </summary>
    public class StudentDetails
    {
        //field
        /// <summary>
        /// static field used to auto increment and it uniquely indentify an instance of 
        /// </summary>
       
        private static int s_studentID=4000;
        /// <summary>
        /// Property name used to provide name for a student in object of <see cref="StudentInfo" /> class
        /// </summary>
        /// <value></value>
        private string _name;// Backing Field
        /// <summary>
        /// Property nid used to provide id for a student in object of <see cref="StudentInfo" /> class
        /// </summary>
        /// <value></value>
        public string StudentID{ get;}
        /// <summary>
        /// Property name used to provide name for a student in object of <see cref="StudentInfo" /> class
        /// </summary>
        /// <value></value>
        public string Name { get { return _name; } set{ _name=value; } } //Property

        public string FatherName { get; set; } //Auto implemented property {Same as property but data security is not secured}

        public Gender Gender { get; set; }

        public DateTime DOB { get; set; }
        public long MobileNumber { get; set; }

        public int PhysicsMark { get; set; }
        public int ChemistryMark { get; set; }
        public int MathsMark { get; set; }

        //Default Constructor used to initialize default values to field and properties
        
        /// <summary>
        /// Constructor of <see cref="StudentInfo" /> class used to initialize values to its properties
        /// </summary>
        /// <param name="name">Parameter name used to initialize a student's Name property </param>
        /// <param name="fathername">Parameter fathername used to initialize a student's FatherName property </param>
        /// <param name="studentGender"></param>
        /// <param name="physics"></param>
        /// <param name="chemistry"></param>
        /// <param name="maths"></param>
        public StudentDetails()
        {
            Name = "Your name";
            FatherName = "your father name";
            DOB = new DateTime();
            Gender = Gender.Default;
        }

        //parameterized constructor used to initialize the properties of an object with user provided values by using parameter at object created time
        public StudentDetails(string name,string fatherName,Gender gender,long mNumber,DateTime dob,int physicsMark,int chemistryMark,int mathsMark)
        {
            s_studentID++;
            StudentID = "SF"+s_studentID;
            Name = name;
            FatherName = fatherName;
            Gender = Gender.Default;
            MobileNumber = mNumber;
            DOB = dob;
            PhysicsMark = physicsMark;
            ChemistryMark = chemistryMark;
            MathsMark = mathsMark;
        }
        //constructor overloading
        public StudentDetails(string name,string fatherName,Gender gender,long mNumber,DateTime dob)
        {
            Name = name;
            FatherName = fatherName;
            DOB = dob;
            Gender = gender;
            MobileNumber = mNumber;
        }

        ~StudentDetails()
        {
            System.Console.WriteLine("Destructor Called");
        }

        /// <summary>
        /// method check eligibility get cutoff value as parameter and check the eligibility of 
        /// student if cutoff is less or equal then student is eligible and will return true or false
        /// </summary>
        /// <param name="cutOff">used to provide cutOFF value for elibiligity checking</param>
        /// <returns>returns true if eligible else false</returns>
        public bool IsEligible(double cutOff)
        {
            int total = PhysicsMark+ChemistryMark+MathsMark;
            double average = (double)total/3.0;

            if(average >= 75.0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}