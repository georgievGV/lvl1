namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar vehicle = new SportCar(250, 22.8);
            vehicle.Drive(55.9);
            System.Console.WriteLine(vehicle.Fuel);
        }
    }
}
