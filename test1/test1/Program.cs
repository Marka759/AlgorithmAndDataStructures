namespace test1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] num_array1 = {1,2,3,2,5 };
            Console.WriteLine(IsAscending(num_array1));
            int[] num_array2 = { 1, 2, 2, 3, 4 };
            Console.WriteLine(IsAscending(num_array2));
            int[] num_array3 = { 5,4,3,2,1};
            Console.WriteLine(IsAscending(num_array3));
            int[] num_array4 = { 10 };
            Console.WriteLine(IsAscending(num_array4));
            int[] num_array5 = { };
            Console.WriteLine(IsAscending(num_array5));
            int[] num_array6 = null;
            Console.WriteLine(IsAscending(num_array6));
            Console.WriteLine(GetFibonacci(5));
        }

        public static bool IsAscending(int[] num_array)
        {
            if (num_array == null || num_array.Length == 0)
            {
                return false;
            }
            
            int num= num_array[0];

            bool result = false;

            if (num_array.Length == 1)
                return true;
            for (int i = 1; i < num_array.Length; i++)
            {
                if (num_array[i] >= num)
                { 
                    result = true;
                    num = num_array[i]; 
                }
                
                else
                {
                    result = false;
                    break;
                }
                
            }
            return result;
        }
        public static int GetFibonacci(int n)
        {
            if (n < 0) return -1;
            int[] Fib = new int[n+1];
            Fib[0] = 0;
            Fib[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                Fib[i] = Fib[i - 1] + Fib[i - 2];
            }
            return Fib[n];
        }
    }
}
