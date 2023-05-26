using System;
using PTMKTest.BL;
using PTMKTest.ViewModel;
using PTMKTest.Hepler;
using PTMKTest.Controllers;

namespace PTMKTest
{
     class Program
     {
        private static ConsoleController _controller = new ConsoleController();

        public static void Main()
        {
            _controller.EntyMethood();
            Console.ReadKey();
        }
     }
}