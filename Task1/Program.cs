namespace Task1
{
    public class Program
    {
        public static void Main()
        {
            int number;
            Console.Write("Введіть число: ");
            number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(GetMessage(number));
        }

        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        public static string GetMessage(int number)
        {
            if (IsEven(number))
            {
                return "Двері відкриваються!";
            }

            return "Двері зачинені...";
        }
    }
}