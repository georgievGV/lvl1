namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            Product product = new Product("plod", 2);

            Beverage beverage = new Beverage("Vodka", 3.5m, 100);

            HotBeverage hotBeverage = new HotBeverage("bulyon", 0.5m, 250);
            Coffee coffee = new Coffee("Lavazza", 70);
            Tea tea = new Tea("Jasmine", 3.5m, 200);

            ColdBeverage coldBeverage = new ColdBeverage("Juice", 2.5m, 250);

            Food food = new Food("pasta", 4.5m, 250);

            MainDish mainDish = new MainDish("Bob", 3, 250);
            Fish fish = new Fish("Cipura", 6);

            Dessert dessert = new Dessert("Kompot", 2, 500, 300);
            Cake cake = new Cake("Nedlya");

            Starter starter = new Starter("Tarator", 3.5m, 300);
            Starter soup = new Starter("Angel", 1.33m, 500);
        }
    }
}