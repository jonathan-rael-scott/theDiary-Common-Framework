using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Console
{
    class Program
    {
        private static string testString = "HelloJustinNeilon_HowAreYouDoing69Degrees";
        static void ExecuteTimings(string testId, Action action)
        {
            DateTime startA = DateTime.Now;
            action();
            TimeSpan dif = (DateTime.Now - startA);
            Console.WriteLine();
            Console.WriteLine("Dif {1}: {0}", dif.Ticks, testId);
        }
        static void Main(string[] args)
        {
            
            System.Collections.Generic.Queue<object> a = new Queue<object>();
            System.Collections.Generic.Queue<object> q = new Queue<object>();
            List<object> b = new List<object>();
            SortedSet<object> c = new SortedSet<object>();
            SortedList<int, object> d = new SortedList<int, object>();
            for (int i = 0; i < 50000; i++)
            {
                var z = i;
                a.Enqueue(z);
                b.Add(z);
                c.Add(z);
                d.Add(i, z);
                q.Enqueue(z);
            }

            DateTime startA = DateTime.Now;
            object cd;
            ExecuteTimings("Test A", () =>
            {
                while (a.Count > 0)
                {
                    a.Dequeue();
                    Console.Write(string.Empty);
                }
            });

            ExecuteTimings("Test B", () =>
            {
                int count =q.Count;
                for (int i = 0; i < count; i++)
                {
                    q.Dequeue();
                    Console.Write(string.Empty);

                }
            });

            ExecuteTimings("Test C", () =>
            {
                b.ForEach(z =>
                {
                    Console.Write(string.Empty);
                });
            });

            ExecuteTimings("Test E", () =>
            {
                foreach(var z in b)
                {
                    Console.Write(string.Empty);
                };
            });
            ExecuteTimings("Test F", () => b.ForEachAsParallel(z => Console.Write(string.Empty)));
            ExecuteTimings("Test D", () =>
            {
            b.AsParallel().ForAll(z =>
            {
                Console.Write(string.Empty);
            });
            });
            
            Console.ReadLine();
        }
    }
}
