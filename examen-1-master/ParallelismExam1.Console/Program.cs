using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParallelismExam1.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //ejercicio 1.
            var averageCalculator = new AverageCalculator(new List<double>
            {
                3,5,6,7,7,314,5,67,148,678,1467,932,67
            });
            var result = averageCalculator.ExecuteParallel();
            System.Console.WriteLine(result);

            //ejercicio 2.
            //var process = new Process();
            //await process.RunAsync();

            
        }
    }
}
