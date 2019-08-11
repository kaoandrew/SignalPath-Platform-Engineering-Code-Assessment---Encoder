namespace HexStringToBase64Encoder.Interfaces
{
    /// <summary>
    /// Basic interface for all encoders that take strings as input and return strings
    /// </summary>
    public interface IStringtoStringEncoder
    {
        /// <summary>
        /// Takes input string and returns the string in a different encoding
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        string Encode(string inputString);
    }
}
