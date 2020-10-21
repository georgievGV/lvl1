using System;

namespace Christmas
{
    public class StartUp
    {
        static void Main()
        {
            Bag bag = new Bag("Blue", 20);
            Present present = new Present("Train", 0.4, "Boy");
            Present secondPresent = new Present("Plane", 0.3, "Boy");
            Present thirdPresent = new Present("MakeUp", 0.7, "Girl");
            Present fourthPresent = new Present("Doll", 0.6, "Girl");

            bag.Add(present);

            Console.WriteLine(bag.GetHeaviestPresent());

            Console.WriteLine(bag.Remove("Traine"));
            Console.WriteLine(bag.Count);
            Console.WriteLine(bag.Report());

        }
    }
}
