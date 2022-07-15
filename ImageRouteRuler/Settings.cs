namespace ImageRouteRuler
{
    public class Settings
    {
        public double Scale { get; set; }
        public double ScaleKm => Scale / 100000;
        public double ScaleCm => Scale;

        public string File { get; set; }
        public double Dpi { get; set; }

        public double Dpc => (Dpi != 0 ? Dpi / 2.54 : 0);

        public bool DrawLabels { get; set; }

        public Settings(double scale = 50000)
        {
            Scale = scale;
        }
    }
}
