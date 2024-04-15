namespace Home5
{
    internal class Program
    {
        static void Calculator_GetResult(object sendler, EventArgs eventArgs)
        {
            Console.WriteLine($"{((Calculator)sendler).result}");
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            int number = 0;
            string? action = "";

            ICalculator calc = new Calculator();
            calc.GetResult += Calculator_GetResult;

            while (number != null)
            {
                Console.WriteLine("Нажмите Enter если хотите продолжить, Esc если хотите выйти");
                ConsoleKeyInfo btnRead = Console.ReadKey();
               
                
                if (btnRead.Key == ConsoleKey.Escape)
                {
                    break;
                }

                Console.Write("Введите число: ");
                string? input = Console.ReadLine();
                if (input.Equals("q") || input.Equals("")) return;

                number = (int)ReadInt(input);

                Console.Write("Введите арифметическое действие: ");
                action = Console.ReadLine();
                switch (action)
                {
                    case "+":
                        calc.Sum(number);
                        break;
                    case "-":
                        calc.Substract(number);
                        break;
                    case "*":
                        calc.Multiply(number);
                        break;
                    case "/":
                        calc.Divide(number);
                        break;
                    case "q":
                        return;
                    case "":
                        return;
                    default:
                        Console.WriteLine("Неверное действие!");
                        Console.WriteLine("Начните сначала.");
                        Console.WriteLine();
                        break;
                }
            }
        }

        private static double ReadInt(string? input)
        {
            int i;
            while (!int.TryParse(input, out i))
            {
                Console.WriteLine("Это не число!");
                Console.WriteLine("Введите число.");
                input = Console.ReadLine();
            }
            return i;

        }

    }
}
