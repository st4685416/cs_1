namespace Task3
{
    public class Program
    {
        public static void Main()
        {
            int age;
            Console.Write("Введіть ваш вік: ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(ClassifyAge(age));
        }

        public static string ClassifyAge(int age)
        {
            switch (age)
            {
                case < 0 or > 120:
                    return "Нереальний вік";
                case > 59:
                    return "Пенсіонер";
                case > 17:
                    return "Дорослий";
                case > 12:
                    return "Підліток";
                default:
                    return "Ви дитина";
            }
        }
    }
}