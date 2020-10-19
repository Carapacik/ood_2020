using System;

namespace Coffee
{
    internal static class Program
    {
        private static IBeverage MakeCappuccino()
        {
            Console.WriteLine("0 - Standard Cappuccino, 1 - Double Cappuccino");
            var choice = Convert.ToInt32(Console.ReadLine());
            if (CheckChoice(choice)) throw new Exception("Argument is out of range!");

            return new Cappuccino((CoffeeSize)choice);
        }

        private static IBeverage MakeMilkShake()
        {
            Console.WriteLine("0 - small MilkShake, 1 - medium MilkShake, 2 - large MilkShake");
            var choice = Convert.ToInt32(Console.ReadLine());
            if (CheckChoice(choice) && choice != 2) throw new Exception("Argument is out of range!");

            return new MilkShake((MilkShakeSize) choice);
        }

        private static IBeverage MakeLatte()
        {
            Console.WriteLine("0 - Standard Latte, 1 - Double Latte");
            var choice = Convert.ToInt32(Console.ReadLine());
            if (CheckChoice(choice)) throw new Exception("Argument is out of range!");

            return new Latte((CoffeeSize)choice);
        }

        private static IBeverage MakeTea()
        {
            Console.WriteLine("0 - Black Tea, 1 - Green Tea, 2 - White Tea, 3 - Herbal Tea");
            var choice = Convert.ToInt32(Console.ReadLine());

            return new Tea((TeaType) choice);
        }

        private static IBeverage AddChocolateCrumbs(IBeverage beverage)
        {
            Console.WriteLine("Enter ChocolateCrumbs mass");
            var mass = Convert.ToUInt32(Console.ReadLine());

            return new ChocolateCrumbs(beverage, mass);
        }

        private static IBeverage AddChocolate(IBeverage beverage)
        {
            Console.WriteLine("Enter the number of chocolate slices");
            var slices = Convert.ToUInt32(Console.ReadLine());
            if (slices > 5) throw new Exception("You can't order more than 5 slices of chocolate");

            return new CoconutFlakes(beverage, slices);
        }

        private static IBeverage AddCoconutFlakes(IBeverage beverage)
        {
            Console.WriteLine("Enter CoconutFlakes mass");
            var mass = Convert.ToUInt32(Console.ReadLine());

            return new ChocolateCrumbs(beverage, mass);
        }

        private static IBeverage AddIceCubes(IBeverage beverage)
        {
            Console.WriteLine("Enter the number of ice cubes");
            var iceCubes = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("Enter the type of ice\n0 - Dry, 1 - Water");
            var choice = Convert.ToInt32(Console.ReadLine());
            if (CheckChoice(choice)) throw new Exception("Argument is out of range!");
            
            var iceType = (IceCubeType) choice;
            return new IceCubes(beverage, iceCubes, iceType);
        }

        private static IBeverage AddLiquor(IBeverage beverage)
        {
            Console.WriteLine("Enter the type of liquor\n0 - nut, 1 - chocolate");
            var choice = Convert.ToInt32(Console.ReadLine());
            if (CheckChoice(choice)) throw new Exception("Argument is out of range!");

            var liquorType = (LiquorType) choice;
            return new Liquor(beverage, liquorType);
        }

        private static IBeverage AddSyrup(IBeverage beverage)
        {
            Console.WriteLine("Enter the type of syrup\n0 - chocolate, 1 - maple");
            var choice = Convert.ToInt32(Console.ReadLine());
            if (CheckChoice(choice)) throw new Exception("Argument is out of range!");

            var syrupType = (SyrupType) choice;
            return new Syrup(beverage, syrupType);
        }

        private static bool CheckChoice(int choice)
        {
            return choice != 0 && choice != 1;
        }

        private static IBeverage AddCondiments(IBeverage beverage)
        {
            for (;;)
                try
                {
                    Console.WriteLine(
                        "Condiments\n1 - ChocolateCrumbs, 2 - Chocolate, 3 - CoconutFlakes, 4 - IceCubes," +
                        " 5 - Liquor, 6 - Syrup, 7 - Cinnamon, 8 - Cream, 9 - Lemon, 0 - Checkout ");
                    var choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 0)
                        break;
                    beverage = choice switch
                    {
                        1 => AddChocolateCrumbs(beverage),
                        2 => AddChocolate(beverage),
                        3 => AddCoconutFlakes(beverage),
                        4 => AddIceCubes(beverage),
                        5 => AddLiquor(beverage),
                        6 => AddSyrup(beverage),
                        7 => new Cinnamon(beverage),
                        8 => new Cream(beverage),
                        9 => new Lemon(beverage),
                        _ => throw new Exception("Incorrect condiment")
                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }

            return beverage;
        }

        private static void DialogWithUser()
        {
            IBeverage beverage;
            for (;;)
                try
                {
                    Console.WriteLine("Beverages\n1 - Coffee, 2 - Cappuccino, 3 - MilkShake, 4 - Latte, 5 - Tea");
                    var choice = Convert.ToInt32(Console.ReadLine());

                    beverage = choice switch
                    {
                        1 => new Coffee(),
                        2 => MakeCappuccino(),
                        3 => MakeMilkShake(),
                        4 => MakeLatte(),
                        5 => MakeTea(),
                        _ => throw new Exception("Argument is out of range!")
                    };

                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }

            Console.WriteLine($"Your beverage before condiments: {beverage.GetDescription()}, " +
                              $"||| Cost {beverage.GetCost()} |||");
            beverage = AddCondiments(beverage);
            Console.WriteLine($"Your beverage after condiments: {beverage.GetDescription()}, " +
                              $"||| Cost {beverage.GetCost()} |||");
        }

        private static void Main()
        {
            DialogWithUser();
        }
    }
}