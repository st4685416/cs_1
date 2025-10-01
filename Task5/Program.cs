namespace Task5
{
    public class Program
    {
        public static void Main()
        {
            int[][] groups = new int[4][];
            groups[0] = new int[] { 45, 12, 88, 90, 52, 100, 81, 77, 58, 37, 37, 85 };
            groups[1] = new int[] { 27, 59, 71, 87, 97, 62, 40, 92, 85, 100, 26, 92, 82, 90, 72, 88 };
            groups[2] = new int[] { 71, 57, 79, 62, 15, 95, 95, 93, 44, 12, 42, 60, 68, 66, 61, 27 };
            groups[3] = new int[] { 16, 65, 72, 62, 61, 55, 98, 89, 82, 39 };

            PrintGroupStatistics(groups);
        }

        public static double GetAverage(int[] marks)
        {
            return marks.Average();
        }

        public static int GetMin(int[] marks)
        {
            return marks.Min();
        }

        public static int GetMax(int[] marks)
        {
            return marks.Max();
        }

        public static void PrintGroupStatistics(int[][] groups)
        {
            for (int i = 0; i < groups.Length; i++)
            {
                int[] group = groups[i];

                Console.WriteLine(
                    $"Група {i + 1}: Середній = {Convert.ToInt32(GetAverage(group))}, Мінімальний = {GetMin(group)}, Максимальний = {GetMax(group)}");
            }
        }
    }
}