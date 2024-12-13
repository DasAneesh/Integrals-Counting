using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intergrals_Counting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> Square = (x) => x*x + x + 2;
            Func<double, double> Sin = (x) => Math.Sin(x);
            Intergrals_Counting Sqr_Func = new Intergrals_Counting();
            Console.WriteLine(Environment.ProcessorCount);
            Console.WriteLine($"Обычный Интеграл правый, {Sqr_Func.Integration_of_Right_Rectangles(Square, 100000, 2, 20, 0.01)}");
            Console.WriteLine($"Обычный Интеграл левый, {Sqr_Func.Integration_of_Left_Rectangles(Square, 100000, 2, 20, 0.01)}");
            Console.WriteLine($"Сегментный Интеграл правый, {Sqr_Func.SegIntegration_of_Right_Rectangles(Square, 100, 2, 20, 0.01)}");
            Console.WriteLine($"Сегментный Интеграл левый, {Sqr_Func.SegIntegration_of_Left_Rectangles(Square, 100, 2, 20, 0.01)}");
            Console.WriteLine($"Парралельный Сегментный Интеграл левый, {Sqr_Func.Parallel_SegIntegration_of_Left_Rectangles(Square, 100, 2, 20, 0.01)}");
            Console.WriteLine($"Парралельный Сегментный Интеграл правый, {Sqr_Func.Parallel_SegIntegration_of_Right_Rectangles(Square, 100, 2, 20, 0.01)}");
            Console.ReadLine();
        }
    }
}
