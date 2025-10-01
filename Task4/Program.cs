namespace Task4
{
    public class Program
    {
        public static void Main()
        {
            double a, b, c;

            Console.Write("Введіть сторону a: ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введіть сторону b: ");
            b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введіть сторону c: ");
            c = Convert.ToDouble(Console.ReadLine());

            if (IsValidTriangle(a, b, c))
            {
                Console.WriteLine($"Периметр: {GetPerimeter(a, b, c)}");
                Console.WriteLine($"Площа: {GetArea(a, b, c)}");
                Console.WriteLine($"Тип трикутника: {GetTriangleType(a, b, c)}");
            }
            else
            {
                Console.WriteLine("\nТрикутник не існує");
            }
        }

        public static bool IsValidTriangle(double a, double b, double c)
        {
            return a > 0 && b > 0 && c > 0 && (a + b > c) && (a + c > b) && (b + c > a);
        }

        public static double GetPerimeter(double a, double b, double c)
        {
            return a + b + c;
        }

        public static double GetArea(double a, double b, double c)
        {
            double p = GetPerimeter(a, b, c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public static string GetTriangleType(double a, double b, double c)
        {
            bool isEquilateral = a == b && a == c;
            bool isIsosceles = a == b || b == c || a == c;
            bool isRight = (a * a + b * b == c * c || a * a + c * c == b * b || b * b + c * c == a * a);

            if (isEquilateral)
            {
                return "рівносторонній";
            }

            if (isRight && isIsosceles)
            {
                return "прямокутний та рівнобедрений";
            }

            if (isRight)
            {
                return "прямокутний";
            }

            if (isIsosceles)
            {
                return "рівнобедрений";
            }

            return "довільний";
        }
    }
}