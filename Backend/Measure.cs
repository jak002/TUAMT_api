namespace TUAMT_api.Backend
{
    public class Measure
    {
        public string Name { get; set; }
        public string NamePlural { get; set; }
        public string Type { get; set; }
        public double Value { get; set; }

        public double MeasureToMeter(double amount)
        {
            return amount * Value;
        }

        public double MeterToMeasure(double amount)
        {
            return amount / Value;
        }
    }
}
