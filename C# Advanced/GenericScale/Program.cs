namespace GenericScale
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            EqualityScale<int> name = new EqualityScale<int>(10, 10);
            System.Console.WriteLine(name.AreEqual());
        }
    }
}
