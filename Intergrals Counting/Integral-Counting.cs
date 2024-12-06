using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Intergrals_Counting
{
    public class Intergrals_Counting
    {
        

        public double Integration_of_Left_Rectangles(Func<double, double> f, double divisions, double left, double right)
        {
            if (divisions <= 0)
                throw new ArgumentException("Количество подынтервалов должно быть положительным.");
            double sum = 0;
            double lenght = (Math.Abs(right - left) / divisions);
            for(int i = 0; i<divisions; i++)
            {
                double next = left + i * lenght;
                sum += f(next) * lenght;
               
            }
            return sum;
        }
        public double Integration_of_Right_Rectangles(Func<double, double> f, double divisions, double left, double right)
        {
            if (divisions <= 0)
                throw new ArgumentException("Количество подынтервалов должно быть положительным.");
            double sum = 0;
            double lenght = (Math.Abs(right - left) / divisions);
            double right_border= left + lenght;

            for (int i = 0; i < divisions; i++)
            {
                double next = right_border + i * lenght;
                sum += f(next) * lenght;

            }
            return sum;
        }
        public double Calculating_with_Parametr_Right_Rectangles(Func<double, double> f, double Min_diff, double left, double right)
        {
            bool Flag = false;
            double tmp1 = 0;
            double tmp2 = 0;
            double divisions = 0;
            while (Flag == true)
            {
                divisions = 2;
                tmp1 = Integration_of_Right_Rectangles(f, divisions, left, right);
                tmp2 = Integration_of_Right_Rectangles(f, (divisions+1), left, right);
                if (Math.Abs(tmp1-tmp2) < Min_diff)
                {
                    Flag = true;
                    
                }
                divisions++;
            }
            List<double> Tmp_List = new List<double>() { tmp1, tmp2, divisions };
            return tmp2;
            
        }




    }
}
