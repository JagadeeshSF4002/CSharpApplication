
namespace OnlineMedicalStore
{
    class Program
    {
        public static void Main(string[] args)
        {
            //used to call default data and store into thelist
            Operation.DefaultData();
            //used to call mainmenu for purchase the medical item
            Operation.MainMenu();
        }
    }
}