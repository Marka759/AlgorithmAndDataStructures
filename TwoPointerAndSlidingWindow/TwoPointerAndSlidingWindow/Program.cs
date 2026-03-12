using System.Text;

namespace TwoPointerAndSlidingWindow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = "asd dsa";
            string str2 = "asdsa";
            string str3 = "asd";
            Console.WriteLine(BadSolution1(str1));
            Console.WriteLine(BadSolution1(str2));
            Console.WriteLine(BadSolution1(str3));
            Console.WriteLine();
            Console.WriteLine(GoodSolution1(str1));
            Console.WriteLine(GoodSolution1(str2));
            Console.WriteLine(GoodSolution1(str3));
            Console.WriteLine(FormatPhoneNumber("79991234567"));
            Console.WriteLine("=== Пример с реальными данными ===");
            string csvData = "John Doe, 25, New York, john.doe@email.com";
            string[] userData = ProcessCSVLine(csvData);

            Console.WriteLine($"Имя: {userData[0]}");
            int[] test1 = { };
            Console.WriteLine(GetSum(test1));
            Console.WriteLine(IsPrime(-6));
            int N =int.Parse(Console.ReadLine());
            PrintMultiplicationTable(N);
        }
        public static bool BadSolution1(string str)//O(2*n) - линейная сложность алгоритма
        {
            if (string.IsNullOrWhiteSpace(str)) return false;
            string rev = "";
            foreach(var ch in str) //O(n) - линейная сложность алгоритма
            {
                rev = ch + rev; 
            }
            for (int i = 0; i < str.Length; i++)//O(n) - линейная сложность алгоритма
            {
                if (str[i] != rev[i])
                    return false;
            }
            return true;
        }

        public static bool GoodSolution1(string str)//O(n) - линейная сложность алгоритма
        {
            if (string.IsNullOrWhiteSpace(str)) return false; //проверка строки
            for (int left =0, right=str.Length-1; left < right; left++, right--)//0(n)
            {
                if (str[left] != str[right])
                    return false;
            }
            return true;
        }

        public static int GoodSolution2(int[] arr, int k)
        {
            if (arr is null || arr.Length == 0) return 0;
            int top = 0;
            int bottom = 0;
            int max = 0;
            int sum = 0;

            while (true)
            {
                if (sum + arr[top] <= k && top < arr.Length)
                {
                    sum += arr[top];
                    top++;

                }
                else 
                {
                    max = max > top - bottom? max : top - bottom;
                    sum -= arr[bottom];
                    bottom++;   

                }
                if (top==arr.Length)
                {
                    break;
                }
            }
            while (bottom < arr.Length)
            {
                max = max > top - bottom ? max : top - bottom;
                sum -= arr[bottom];
                bottom++;
            }
            return max; 
        }
        public static string FormatPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Length != 11 || !phoneNumber.All(char.IsDigit))
            {
                throw new ArgumentException("Строка должна содержать ровно 11 цифр");
            }

            StringBuilder formattedNumber = new StringBuilder("+");

            // Добавляем первую цифру (код страны)
            formattedNumber.Append(phoneNumber[0]);

            // Добавляем остальные части с форматированием
            formattedNumber.Append($" ({phoneNumber.Substring(1, 3)}) {phoneNumber.Substring(4, 3)}-{phoneNumber.Substring(7, 2)}-{phoneNumber.Substring(9, 2)}");

            return formattedNumber.ToString();
        }

        public static string[] ProcessCSVLine(string csvLine)
        {
            
            if (string.IsNullOrEmpty(csvLine))
            {
                return new string[0]; 
            }

            
            string[] values = csvLine.Split(',');

      
            string[] result = new string[values.Length];

   
            for (int i = 0; i < values.Length; i++)
            {
                
                result[i] = values[i].Trim().ToLower();
            }

            return result;
        }
        public static int GetSum(int[] test)
        {
            if (test  == null || test.Length == 0)
            {
                return 0;
            }
            int sum = 0;
            for (int i = 0; i < test.Length; i++)
            {
                sum += test[i];
            }
            return sum;
        }
        public static bool IsPrime(int num)
        {
            if (num < 2) return false;
            int count = 0;
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                { count++; }
            }
            if (count == 0) { return true; }
            else return false;
        }
        public static  void PrintMultiplicationTable (int N)
        {
            for (int i = 1;i<11;i++)
            {
                Console.WriteLine($"{N} * {i} = {N*i}");
            }
        }
    }
}
