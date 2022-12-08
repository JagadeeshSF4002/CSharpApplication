namespace  ECommerceApplicationWithFile
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Operation.DefaultData();
            Files.Create();
            Files.ReadLines();
            Operation.DisplayMainMenu();
            Files.WriteFiles();
        }
    }
}
