using System;

namespace BoxOfT
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            box.Add(4);
            box.Add(12);
            box.Add(32);

            Console.WriteLine(box.Remove() == 32);
            Console.WriteLine(box.Remove() == 12);
            Console.WriteLine(box.Count == 1);
        }
    }
}
