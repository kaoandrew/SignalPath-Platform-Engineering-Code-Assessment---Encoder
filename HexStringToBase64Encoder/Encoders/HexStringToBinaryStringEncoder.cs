using HexStringToBase64Encoder.Encoders.Constants;
using HexStringToBase64Encoder.Interfaces;
using System;
using System.Text;

namespace HexStringToBase64Encoder.Encoders
{
    /// <summary>
    /// Converts Hexadecimal string into Binary string
    /// </summary>
    public class HexStringToBinaryStringEncoder : IStringtoStringEncoder
    {
        public string Encode(string inputString)
        {

            StringBuilder stringBuilder = new StringBuilder();

            // Convert each character in input to hex integer, then to binary string and padding with zeroes to make quartets
            foreach (char c in inputString.ToCharArray())
            {
                stringBuilder.Append(Convert.ToString(Convert.ToInt32(c.ToString(), EncoderConstants.cBaseSixteen), EncoderConstants.cBaseTwo)
                    .PadLeft(EncoderConstants.cQuartetSize, '0'));
            }

            return stringBuilder.ToString();          
        }
    }
}
