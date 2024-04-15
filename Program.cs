/*Доработайте программу калькулятор реализовав выбор 
 * действий и вывод результатов на экран в цикле так 
 * чтобы калькулятор мог работать до тех пор пока 
 * пользователь не нажмет отмена или введёт пустую строку.*/

namespace Home5
{
    internal class Program
    {
        static void Calculator_GetResult(object sendler, EventArgs eventArgs)
        {
            Console.WriteLine($"{((Calculator)sendler).result}");
        }
       
      
        static void Main(string[] args)
        {

            ICalculator calc =  new Calculator();

            calc.GetResult += Calculator_GetResult;

            while (true)
            {
                Console.WriteLine("Нажмите Enter если хотите продолжить, Esc если хотите выйти");

                ConsoleKeyInfo btnRead = Console.ReadKey();
                
                Console.WriteLine("Введите действие или нажмите для завершения \"q\".");
                if (btnRead.Key == ConsoleKey.Escape)
                {
                    break;
                }

                string? userEntered = Console.ReadLine();
                if (userEntered != "q" || userEntered == "") break;
               
                string? newUserEntered = userEntered.Remove(0, 1);

                if (int.TryParse(newUserEntered, out int value))
                {
                    switch (userEntered[0])
                    {
                        case '+':
                            calc.Sum(value);
                            break;

                        case '-':
                            calc.Substract(value);
                            break;

                        case '/':
                            calc.Divide(value);
                            break;

                        case '*':
                            calc.Multiply(value);
                            break;

                        default:
                            Console.WriteLine("Вы не ввели дейсвие!");
                            break;

                    }
                }
                else { Console.WriteLine("Введите знак действия с числом!"); }

            }     
        }
    }
}
