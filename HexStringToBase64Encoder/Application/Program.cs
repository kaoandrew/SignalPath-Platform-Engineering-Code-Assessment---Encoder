using HexStringToBase64Encoder.Encoders;
using System;

namespace HexStringToBase64Encoder
{
    /// <summary>
    /// Main demo application
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // String provided by prompt
            string demoString = "45766964696e74";
            var base64encoder = new BinaryStringToBase64StringEncoder();

            Console.WriteLine("Demo string is: " + demoString);
            Console.WriteLine("Expected output is: RXZpZGludA==");
            Console.WriteLine("Base64Encoder result is: " + base64encoder.Encode(demoString));
            Console.ReadKey();
        }
    }
}
