namespace Thermometer.Interfaces
{
    public interface IMd5AlgorithmProvider
    {
        string GetMd5Hash(string str);
    }
}