using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Thermometer.Interfaces;

namespace Thermometer.Infrastructure
{
    internal class Md5AlgorithmProvider : IMd5AlgorithmProvider
    {
        public string GetMd5Hash(string str)
        {
            var alg = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);
            var buff = CryptographicBuffer.ConvertStringToBinary(str, BinaryStringEncoding.Utf8);
            var hashed = alg.HashData(buff);
            return CryptographicBuffer.EncodeToHexString(hashed);
        }
    }
}