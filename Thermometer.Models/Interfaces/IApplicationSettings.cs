namespace Thermometer.Interfaces
{
    public interface IApplicationSettings
    {
        bool LocationConsent { get; set; }

        int Radius { get; set; }
    }
}