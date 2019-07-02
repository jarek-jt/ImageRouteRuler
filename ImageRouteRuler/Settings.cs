namespace ImageRouteRuler
{
    public class Settings
    {
        public double Scale { get; set; }
        public double ScaleKm
        {
            get
            {
                return Scale/ 100000;
            }
        }

        public double ScaleCm
        {
            get
            {
                return Scale;
            }
        }

        public string File { get; set; }
        public double Dpi { get; set; }

        public double Dpc
        {
            get
            {
                return (Dpi != 0 ? Dpi / 2.54 : 0);
            }
        }

        public Settings(double scale = 50000)
        {
            Scale = scale;
        }
    }
}
