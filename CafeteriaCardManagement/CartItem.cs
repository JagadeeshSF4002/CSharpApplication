

namespace CafeteriaCardManagement
{
    public class CartItem
    {
        private static int s_itemID;
        public string ItemID { get;}
        public string OrderID { get; set; }
        public string FoodID { get; set; }
        public long OrderPrice { get; set; }
        public int OrderQuantity { get; set; }

        public CartItem(string orderID,string foodID,long orderPrice,int orderQuantity)
        {
            s_itemID++;
            ItemID = "ITID"+s_itemID;
            OrderID = orderID;
            FoodID = foodID;
            OrderPrice = orderPrice;
            OrderQuantity = orderQuantity;
        }
        public CartItem(string data)
        {
            string[] values = data.Split(',');

            s_itemID = int.Parse(values[0].Remove(0,4));
            ItemID = values[0];
            OrderID = values[1];
            FoodID = values[2];
            OrderPrice = long.Parse(values[3]);
            OrderQuantity = int.Parse(values[4]);
        }
    }
}