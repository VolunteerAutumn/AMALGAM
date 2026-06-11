using System;

namespace epstein_files_csharp_edition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ===================================================================
            Action showTime = () => Console.WriteLine($"Current time: {DateTime.Now.ToLongTimeString()}");
            Action showDate = () => Console.WriteLine($"Current date: {DateTime.Now.ToShortDateString()}");
            Action showDayOfWeek = () => Console.WriteLine($"Day of week: {DateTime.Now.DayOfWeek}");
            // ===================================================================
            Func<double, double, double> rectangleArea = (length, width) => length * width;
            Func<double, double, double> triangleArea = (baseLength, height) => (baseLength * height) / 2;
            // ===================================================================
            Predicate<double> isPositiveArea = area => area > 0;
            // ===================================================================

            showTime();
            showDate();
            showDayOfWeek();

            Console.WriteLine();

            double rectArea = rectangleArea(5, 4);
            Console.WriteLine($"Rectangle area: {rectArea}");
            Console.WriteLine($"Valid area? {isPositiveArea(rectArea)}");

            Console.WriteLine();

            double triArea = triangleArea(10, 6);
            Console.WriteLine($"Triangle area: {triArea}");
            Console.WriteLine($"Valid area? {isPositiveArea(triArea)}");
        }
    }
}
