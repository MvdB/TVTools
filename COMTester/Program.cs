using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace COMTester
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string s in SerialPort.GetPortNames())
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }
    }
}
