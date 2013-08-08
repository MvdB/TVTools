using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace TVTools
{
    class TVOff
    {
                
        static void Main(string[] args)
        {
            char SETID = '1';
            char[] OFF = new char[] { 'k', 'a', ' ', SETID, ' ', '0', '\r' };
            Console.Beep(3500, 250);
            try
            {
                Console.WriteLine("Preparing COM-Port..");
                SerialPort port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
                port.Open();
                port.Write(OFF, 0, OFF.Length);
                Console.Beep(2500, 250);
                char[] readBuffer = new char[OFF.Length];
                port.Read(readBuffer, 0, readBuffer.Length);
                Console.WriteLine("Data received: '" + readBuffer + "'");
                Console.WriteLine("TV Off..");
                Console.Beep(1500, 250);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured: " + e.Message);
                Console.Beep(800, 1000);
            }
            //Console.ReadLine();
        }
    }
}
