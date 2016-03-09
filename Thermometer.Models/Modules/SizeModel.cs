namespace Thermometer.Modules
{
    public class SizeModel
    {
        #region Fields

        public static SizeModel Empty = new SizeModel();

        #endregion

        #region Constructors

        public SizeModel()
        {
        }

        public SizeModel(double width, double height)
        {
            Width = width;
            Height = height;
        }

        #endregion

        #region Properties

        public double Height { get; set; }

        public double Width { get; set; }
        
        #endregion
    }
}