using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelismExam1.Console
{
    public class AverageCalculator
    {
        private readonly IEnumerable<double> values;
        private static object objeto = new Object();
        double average = 0;
        public AverageCalculator(IEnumerable<double> values)
        {
            this.values = values;
        }

        public  double Execute()
        {
            for (int i = 0; i < 5; i++)
            {
                Task.Run(() => { 
               
                     var tupla = (Load_balance(5, this.values.Count(), i));
                    lock (objeto)
                    {
                        this.average += CalculateAverage(this.values.ToArray(), tupla.Item1, tupla.Item2);
                    }
              
                });
            }
            return this.average / 5;
        }

        public double ExecuteParallel()
        {

            Parallel.For(0, 4, index =>
            {
                var tupla = (Load_balance(5, this.values.Count(), index));
                lock (objeto)
                {
                    this.average += CalculateAverage(this.values.ToArray(), tupla.Item1, tupla.Item2);
                }  
            });

            return this.average /5; 
        }

        private double CalculateAverage(double[] listOfValues, int start, int end)
        {
            double average = 0;
            for (int i = start; i < end; i++)
            {
                average += listOfValues[i];
            }
            return average / (end - start);
        }

        public Tuple<int, int> Load_balance(int threads, int values, int threadToCalculate)
        {
            int count = 0;
            int start = 0;
            int end = 0;
            int quotient = values / threads;
            int remainder = values % threads;
            if (threadToCalculate < remainder)
            {
                count = quotient + 1;
                start = threadToCalculate * count;
            }
            else
            {
                count = quotient;
                start = threadToCalculate * count + remainder;
            }
            end = start + count;
            return new Tuple<int, int>(start, end);
        }

       

    }
}
