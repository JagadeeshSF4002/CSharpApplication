using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationForVaccineDrive
{
    public class Vaccine
    {
        private static int s_vaccineID = 100;
        public string VaccineID { get;  }
        public string VaccinationName { get; set; }
        public int NoOfDoes { get; set; }

        public Vaccine(string vaccinationName,int noOfDoes)
        {
            s_vaccineID++;
            VaccineID = "CID"+s_vaccineID;
            VaccinationName = vaccinationName;
            NoOfDoes = noOfDoes;
        }

    }
}