using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelismExam1.Console
{
    public class Process
    {
        public async Task RunAsync()
        {
            await File.WriteAllTextAsync(@"data\text.txt", "Starting process");
            for (int i = 0; i < 1000000; i++)
            {
                System.Console.WriteLine($"Processing {i} in thread {Thread.CurrentThread.ManagedThreadId}");
                await File.AppendAllTextAsync(@"data\text.txt", $"Processing {i} in thread {Thread.CurrentThread.ManagedThreadId}");
            }
        }
    }
}
