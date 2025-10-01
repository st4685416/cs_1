namespace Task2
{
    public class Program
    {
        public static void Main()
        {
            int[] arr = GenerateRandomArray(10, 1, 100);
            Console.Write("Array: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + ";");
            }

            Console.WriteLine($"\nСума: {GetSum(arr)}");
            Console.WriteLine($"Середнє: {GetAverage(arr)}");
            Console.WriteLine($"Мінімальне: {GetMin(arr)}");
            Console.WriteLine($"Максимальне: {GetMax(arr)}");
        }

        public static int[] GenerateRandomArray(int size, int min, int max)
        {
            Random random = new Random();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(min, max);
            }

            return array;
        }

        public static int GetSum(int[] numbers)
        {
            return numbers.Sum();
        }

        public static double GetAverage(int[] numbers)
        {
            return numbers.Average();
        }

        public static int GetMin(int[] numbers)
        {
            return numbers.Min();
        }

        public static int GetMax(int[] numbers)
        {
            return numbers.Max();
        }
    }
}