using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace TVTools
{
    class TVOn
    {
        static void Main(string[] args)
        {
            char SETID = '1';
            char[] ON = new char[] { 'k', 'a', ' ', SETID, ' ', '1', '\r' };
            //byte[] INPUT = new byte[] { 0x78, 0x62, 0x20, 0x31, 0x20, 0x10, 0x0D }; // ` = 0x60
            char[] INPUT = new char[] { 'x', 'b', ' ', SETID, ' ', '6', '0', '\r' }; // ` = 0x60
            Console.Beep(1500, 250);
            try
            {
                Console.WriteLine("Preparing COM-Port..");
                SerialPort port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
                port.Open();
                port.Write(ON, 0, ON.Length);
                Console.Beep(2500, 250);
                char[] readBuffer = new char[ON.Length];
                port.Read(readBuffer, 0, readBuffer.Length);
                Console.WriteLine("Data received: '" + readBuffer + "'");
                Console.WriteLine("TV On..");
                Console.Beep(3500, 250);
                port.Write(INPUT, 0, INPUT.Length);
                Console.Beep(4500, 250);
                readBuffer = new char[INPUT.Length];
                port.Read(readBuffer, 0, readBuffer.Length);
                Console.WriteLine("Data received: '" + readBuffer + "'"); 
                Console.WriteLine("Input switched..");
                Console.Beep(5500, 250);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured: " + e.Message);
                Console.Beep(5000, 1000);
            }
            //Console.ReadLine();
        }
    }
}
