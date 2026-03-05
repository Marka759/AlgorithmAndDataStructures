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
    }
}
