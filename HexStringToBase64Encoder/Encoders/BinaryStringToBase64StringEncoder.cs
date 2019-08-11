using HexStringToBase64Encoder.Encoders.Constants;
using HexStringToBase64Encoder.Interfaces;
using System;
using System.Linq;

namespace HexStringToBase64Encoder.Encoders
{
    /// <summary>
    /// Converts Binary string into Base64 string
    /// </summary>
    public class BinaryStringToBase64StringEncoder : IStringtoStringEncoder
    {
        string base64String = string.Empty;
        HexStringToBinaryStringEncoder binaryEncoder = new HexStringToBinaryStringEncoder();

        public string Encode(string inputString)
        {
            var binaryString = binaryEncoder.Encode(inputString);
            for (int i = 0; i < binaryString.Length; i += EncoderConstants.cOctetChunkSize)
            {
                // Break the input string into a list of character octets
                var currentOctets = binaryString.Skip(i).Take(EncoderConstants.cOctetChunkSize).ToList();

                for (int j = 0; j < currentOctets.Count(); j += EncoderConstants.cSextetSize)
                {
                    // Break the octets into sextets
                    var currentSextets = currentOctets.Skip(j).Take(EncoderConstants.cSextetSize);

                    // Recombine the sextets into a string, padding if short of full sextets
                    var bitString = currentSextets.Aggregate(string.Empty, (current, currentBit) => current + currentBit)
                        .PadRight(EncoderConstants.cSextetSize, '0');

                    // Convert to int to reference Base64 Table
                    var tableIndex = Convert.ToInt32(bitString, EncoderConstants.cBaseTwo);

                    base64String += Base64Table.Table[tableIndex];
                }
            }

            // Add padding for any leftover octets
            for (int i = 0; i < (binaryString.Length % EncoderConstants.cOctetDivisor); i++)
            {
                base64String += "=";
            }

            return base64String;
        }
    }
}
