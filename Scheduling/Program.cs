using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    public class Program
    {
        public static void Main()
        {
            List<int> tasks = Array.ConvertAll(Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries), int.Parse).ToList();
            List<int> threads = Array.ConvertAll(Console.ReadLine().Split(), int.Parse).ToList();
            int taskToBeKilled = int.Parse(Console.ReadLine());

            while (taskToBeKilled != tasks[tasks.Count - 1])
            {
                if(threads[0] >= tasks[tasks.Count - 1])
                {
                    tasks.RemoveAt(tasks.Count - 1);
                }
                threads.RemoveAt(0);
            }
            Console.WriteLine($"Thread with value {threads[0]} killed task {taskToBeKilled}");
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
