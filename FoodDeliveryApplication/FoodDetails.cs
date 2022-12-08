using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryApplication
{
    /// <summary>
    /// <see cref="FoodDetails"> Used to food items
    /// </summary>
    public class FoodDetails
    {
        /// <summary>
        /// FoodID field is static  
        /// </summary>
        private static int s_foodID = 100;
        /// <summary>
        /// FoodID property used to assign the values to foodID
        /// </summary>
        /// <value></value>
        public string FoodID { get;}
        /// <summary>
        /// FoodName Property used to store a information of food
        /// </summary>
        /// <value></value>
        public string FoodName { get; set; }
        /// <summary>
        /// Per item food rate
        /// </summary>
        /// <value></value>
        public int PricePerQuantity { get; set; }
        /// <summary>
        /// Available quantity of a food
        /// </summary>
        /// <value></value>
        public int QuantityAvailable { get; set; }

        /// <summary>
        /// Parameterized constructor used for assign a values to specifies property
        /// </summary>
        /// <param name="foodName"></param>
        /// <param name="pricePerQuantity"></param>
        /// <param name="quantityAvailable"></param>
        public FoodDetails(string foodName,int pricePerQuantity,int quantityAvailable)
        {
            s_foodID++;
            FoodID = "FID"+s_foodID;
            FoodName = foodName;
            PricePerQuantity = pricePerQuantity;
            QuantityAvailable = quantityAvailable;
        }
        /// <summary>
        /// Get the values from file read and assigned to specified property
        /// </summary>
        /// <param name="FoodData"></param>
        public FoodDetails(string foodData)
        {
            string[] values = foodData.Split(',');

            s_foodID = int.Parse(values[0].Remove(0,3));
            FoodID = values[0];
            FoodName = values[1];
            PricePerQuantity = int.Parse(values[2]);
            QuantityAvailable = int.Parse(values[3]);
        }
    }
}