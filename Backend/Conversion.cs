namespace TUAMT_api.Backend
{
    public class Conversion
    {
        public Measure InputMeasure { get; set; }
        public Measure OutputMeasure { get; set; }

        public double Amount { get; set; }

        public static double Convert(Measure input, Measure output, double amount)
        {
            double initMeters = input.MeasureToMeter(amount);
            double result = output.MeterToMeasure(initMeters);
            return result;
        }
    }
}
