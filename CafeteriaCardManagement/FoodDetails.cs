

namespace CafeteriaCardManagement
{
    public class FoodDetails
    {
        private static int s_foodID;

        public string FoodID { get;}
        public string FoodName { get; set; }
        public int FoodPrice { get; set; }
        public int AvailableQuantity { get; set; }

        public FoodDetails(string foodName,int foodPrice,int availableQuantity)
        {
            s_foodID++;
            FoodID = "FID"+s_foodID;
            FoodName = foodName;
            FoodPrice = foodPrice;
            AvailableQuantity = availableQuantity;
        }

        public FoodDetails(string data)
        {
            string[] values = data.Split(',');

            s_foodID = int.Parse(values[0].Remove(0,3));
            FoodID = values[0];
            FoodName = values[1];
            FoodPrice = int.Parse(values[2]);
            AvailableQuantity = int.Parse(values[3]);
        }

        public long CalculatePrice(int quantity,int price)
        {
            return quantity*price;
        }
    }
}