using System;

/// <summary>
/// used to process the Online medical item purchasing using this application
/// </summary>
namespace OnlineMedicalStore
{
    public class MedicineDetails
    {
         ///field
         /// <summary>
         /// static field used to auto increment and it uniquely indentify an instance of  medicine id
         /// </summary>
         private static int s_medicineID = 100;
         /// <summary>
         /// Property ID used to  Medicine ID in object of <see cref="MedicineID" /> class
         /// </summary>
         /// <value></value>
         public string MedicineID { get;}
         /// <summary>
         /// Property ID name  to  Medicine Name in object of <see cref="MedicineName" /> class
         /// </summary>
         /// <value></value>
         public string MedicineName { get; set; }
         /// <summary>
         /// Total available stocks in medical store <see cref="Count" /> class
         /// </summary>
         /// <value></value>
         public int AvailableCount { get; set; }
         /// <summary>
         /// Price property display the medicine price in medical store <see cref="Price" /> class
         /// </summary>
         /// <value></value>
         public long Price { get; set; }

         /// <summary>
         /// DOE property display the expiry date for given medicine list <see cref="DOE" /> class
         /// </summary>
         /// <value></value>
         public DateTime DOE { get; set; }

         //parameterized constructor used to initialize the properties of an object with user provided values by using parameter at object created time
         public MedicineDetails(string medicineName,int availableCount,long price,DateTime doe)
         {
             s_medicineID++;
             MedicineID = "MD"+s_medicineID;
             MedicineName = medicineName;
             AvailableCount = availableCount;
             Price = price;
             DOE = doe;
         }

        
         /// <summary>
         /// update stock
         /// </summary>
         /// <param name="UpdateStock">used to update the stock</param>
         public void UpdateStock(int availableCount)
         {
            AvailableCount = AvailableCount+availableCount;
         }
    }
}