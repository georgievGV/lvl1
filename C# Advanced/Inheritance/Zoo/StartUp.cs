namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Bear bear = new Bear("Chi");

            System.Console.WriteLine(bear.Name);
        }
    }
}