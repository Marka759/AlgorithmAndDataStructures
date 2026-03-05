namespace prog_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int min = 0;
            int max = 0;
            int count = 0;
            int countGame = 0;

            char answer = 'Y';
            do
            {
                int counter = 0;
                int number = RandomNumber();
                while (true)
                {
                    counter++;
                    Console.WriteLine("Input number from [1;100]");
                    int userNumber = CheckNumberFromUser();
                    if (CmpNumber(userNumber, number))
                    {

                        Console.WriteLine("You won");
                        if (min == 0 || min > counter) min = counter;
                        max = max < counter ? counter : max;
                        countGame++;
                        count += counter;
                        break;
                    }
                }
                Console.WriteLine("Do you want to play again?");
                answer = Convert.ToChar(Console.Read());
            } while (answer == 'Y');
            Console.WriteLine($"min = {min} max={max} avg= {count * 1.0 / countGame}");
        }
        ///<summary>
        /// Генерирует случайное число от 1 до 100
        /// </summary>
        /// <returns> сгенерированное число </returns>
        static int RandomNumber()
        {
            Random rnd = new Random();
            return rnd.Next(1, 101);
        }
        /// <summary>
        /// Статический метод для проверки ввода числа в диапазоне (1,101)
        /// </summary>
        /// <returns>Корректное число или предупреждает о при превышении количества попыток</returns>
        static int CheckNumberFromUser()
        {
            int userNumber = 0;
            for (int i = 0; i < 3; i++)
            {
                if (!int.TryParse(Console.ReadLine(), out userNumber) || userNumber > 100 || userNumber < 1)
                    Console.WriteLine("Input number from [1;100]");
                else break;
                if (i == 2)
                {
                    Console.WriteLine("You are stupid");
                    return 0;

                }
            }
            return userNumber;

        }
        /// <summary>
        /// Сравниваем введенное число с загаданным
        /// </summary>
        /// <returns> угадано ли число</returns>
        static bool CmpNumber(int userNumber, int number)
        {
            if (userNumber > number)
            {
                Console.WriteLine("Your number is greater");
                return false;
            }
            else if (userNumber < number)
            {
                Console.WriteLine("Your number is less");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
