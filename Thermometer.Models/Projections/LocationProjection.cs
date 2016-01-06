namespace Thermometer.Projections
{
    public class LocationProjection
    {
        #region Constructors

        public LocationProjection(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Долгота
        /// </summary>
        public double Longitude { get; }

        /// <summary>
        ///     Широта
        /// </summary>
        public double Latitude { get; }

        #endregion
    }
}