namespace TUAMT_api.Backend
{
    public class Conversion
    {
        public Measure InputMeasure { get; set; }
        public Measure OutputMeasure { get; set; }

        public double Amount { get; set; }

        public static double Convert(Measure input, Measure output, double amount)
        {
            if (input == null)
            {
                throw new ArgumentException("Didn't quite catch what you wrote for input");
            }
            if (output == null)
            {
                throw new ArgumentException("I'm... not sure I can output to that measurement. Have you tried 'big mac' instead?");
            }
            double initMeters = input.MeasureToMeter(amount);
            double result = output.MeterToMeasure(initMeters);
            return result;
        }
    }
}
