using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Intergrals_Counting
{
    public class Intergrals_Counting
    {
        

        public double Integration_of_Left_Rectangles(Func<double, double> f, double divisions, double left, double right, double tollerance)
        {
            double prearea = 0;
            double currarea = 0;
 
            while(true)
            {
                double sum = 0;
                if (divisions <= 0)
                    throw new ArgumentException("Количество подынтервалов должно быть положительным.");
                
                double lenght = (Math.Abs(right - left) / divisions);
                for (int i = 0; i < divisions; i++)
                {
                    double next = left + i * lenght;
                    sum += f(next) * lenght;

                }
                currarea = sum;
                if (currarea != prearea)
                {
                    if ((currarea - prearea) < tollerance)
                    {
                        break;
                    }
                }
                divisions *= 2;
                prearea = currarea;
            }
            return currarea;


        }
        public double Integration_of_Right_Rectangles(Func<double, double> f, double divisions, double left, double right, double tollerance)
        {
            double prearea = 0;
            double currarea = 0;

            while (true)
            {
                double sum = 0;
                if (divisions <= 0)
                    throw new ArgumentException("Количество подынтервалов должно быть положительным.");

                double lenght = (Math.Abs(right - left) / divisions);
                for (int i = 0; i < divisions; i++)
                {
                    double next = left + (i+1) * lenght;
                    sum += f(next) * lenght;

                }
                currarea = sum;
                if (currarea != prearea)
                {
                    if ((currarea - prearea) < tollerance)
                    {
                        break;
                    }
                }
                divisions *= 2;
                prearea = currarea;
            }
            return currarea;
        }
       
        public double SegIntegration_of_Right_Rectangles(Func<double, double> f, double divisions, double left, double right, double tollerance)
        {
            if (divisions <= 0)
                throw new ArgumentException("Количество подынтервалов должно быть положительным.");
            const int segments = 10;
            double lenght = (Math.Abs(right - left) / segments);
            double sum = 0;
            for (int i = 0; i < segments; i++)
            {
                if (i == segments - 1)
                {
                    sum += Integration_of_Right_Rectangles(f, divisions, left + lenght * i, right, tollerance);
                    break;
                }
                sum += Integration_of_Right_Rectangles(f, divisions, left + lenght * i, left + lenght * (i + 1), tollerance);

               
            }
            return sum;
        }


        public double SegIntegration_of_Left_Rectangles(Func<double, double> f, double divisions, double left, double right, double tollerance)
        {
            if (divisions <= 0)
                throw new ArgumentException("Количество подынтервалов должно быть положительным.");
            int segments = 10;
            double lenght = (Math.Abs(right - left) / segments);
            double sum = 0;
            for (int i = 0; i < segments; i++)
            {
                if (i == segments - 1)
                {
                    sum += Integration_of_Left_Rectangles(f, divisions, left + lenght * i, right, tollerance);
                    break;
                }
                sum += Integration_of_Left_Rectangles(f, divisions, left + lenght * i, left + lenght * (i + 1), tollerance);

            }
            return sum;
        }


        public double Parallel_SegIntegration_of_Left_Rectangles(Func<double, double> f, double divisions, double left, double right, double tollerance)
        {
            const int threads = 4;
            double lenght = (Math.Abs(right - left) / threads);
            double areaSum = 0;
            object locker = new object();
            List<Thread> threads_ = new List<Thread>();

            for (int i = 0; i < threads; i++)
            {
                int tempIndex = i;
                Thread thread = new Thread(() =>
                {
                    double tempSum = Integration_of_Left_Rectangles(f, divisions, tempIndex * lenght, (tempIndex+1) * lenght, tollerance);
                    lock (locker)
                    {
                        areaSum += tempSum;
                    }
                });
                threads_.Add(thread);
                thread.Start();
            }

            foreach (Thread thread in threads_)
            {
                thread.Join();
            }

            return areaSum;
        }


        public double Parallel_SegIntegration_of_Right_Rectangles(Func<double, double> f, double divisions, double left, double right, double tollerance)
        {
            const int threads = 4;
            double lenght = (Math.Abs(right - left) / threads);
            double areaSum = 0;
            object locker = new object();
            List<Thread> threads_ = new List<Thread>();

            for (int i = 0; i < threads; i++)
            {
                int tempIndex = i;
                Thread thread = new Thread(() =>
                {
                    double tempSum = Integration_of_Right_Rectangles(f, divisions, tempIndex * lenght, (tempIndex + 1) * lenght, tollerance);
                    lock (locker)
                    {
                        areaSum += tempSum;
                    }
                });
                threads_.Add(thread);
                thread.Start();
            }

            foreach (Thread thread in threads_)
            {
                thread.Join();
            }

            return areaSum;
        }

        //public double Calculating_with_Parametr_Right_Rectangles(Func<double, double> f, double Min_diff, double left, double right)
        //{
        //    bool Flag = false;
        //    double tmp1 = 0;
        //    double tmp2 = 0;
        //    double divisions = 0;
        //    while (Flag == true)
        //    {
        //        divisions = 2;
        //        tmp1 = Integration_of_Right_Rectangles(f, divisions, left, right);
        //        tmp2 = Integration_of_Right_Rectangles(f, (divisions + 1), left, right);
        //        if (Math.Abs(tmp1 - tmp2) < Min_diff)
        //        {
        //            Flag = true;
        //        }
        //        divisions++;
        //    }
        //    List<double> Tmp_List = new List<double>() { tmp1, tmp2, divisions };
        //    return tmp2;

        //}

    }
}
