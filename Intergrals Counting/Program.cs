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
            Func<double, double> Square = (x) => x * x;
            Intergrals_Counting Sqr_Func = new Intergrals_Counting();
            Console.WriteLine(Sqr_Func.Integration_of_Right_Rectangles(Square, 100, 2, 20));
            Console.WriteLine(Sqr_Func.Integration_of_Left_Rectangles(Square, 100, 2, 20));
            Console.WriteLine(Sqr_Func.Calculating_with_Parametr_Right_Rectangles(Square, 0.01, 2, 20));
            Console.ReadLine();
        }
    }
}
