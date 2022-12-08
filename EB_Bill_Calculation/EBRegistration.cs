namespace EB_Bill_Calculation
{
    public class EBRegistration
    {
        private static int s_meterID = 1000;
        public string MeterID { get;}
        public string UserName { get; set; }
        public ulong PhoneNumber { get; set; }
        public string  MailID { get; set; }
        public int UnitsUsed { get; set; }

        public EBRegistration(string userName,ulong phoneNumber,string mailID)
        {
            s_meterID++;
            MeterID ="EB"+s_meterID;
            UserName = userName;
            PhoneNumber = phoneNumber;
            MailID = mailID;
        }
        
        public long unitCalculation(int units)
        {
            int perUnit = 5;
            UnitsUsed = units;
            long amount = perUnit*units;
            return amount;
        }
    }
}