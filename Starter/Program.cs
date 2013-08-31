using System;
using System.Threading;

namespace AEGIS.Sudoku.Starter
{
    static class Program
    {
        static void StartViewer()
        {
            Console.WriteLine(" --- Viewer started");
            var i = 0;           
            do
            {
                Console.WriteLine(" --- Viewer bizzi (" + i + ")");
                ++i;
                Thread.Sleep(125-i);
            } while (i < 100);

            Console.WriteLine(" --- Viewer ended");
        }

        static void StartSolver()
        {
            Console.WriteLine("Solver started");

            var i = 0;
            do
            {
                Console.WriteLine("solver bizzi (" + i + ")");
                ++i;
                Thread.Sleep(125-i);
            } while (i < 100);

            Console.WriteLine("Solver ended");
        }

        static void Main(string[] args)
        {
            var viewerThread = new Thread(StartViewer);
            var solverThread = new Thread(StartSolver);

            Console.WriteLine("Main starts viewer");
            viewerThread.Start();

            Console.WriteLine("Main starts solver");
            solverThread.Start();

            do
            {

            } while (true);
        }
    }
}
