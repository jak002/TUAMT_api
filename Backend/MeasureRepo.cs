namespace TUAMT_api.Backend
{
    public class MeasureRepo : IMeasureRepo
    {

        private List<Measure> measureList = new List<Measure>()
        {
            new Measure() {Name = "Small Boulder", Name_Plural = "Small boulders", Type = "Area", Value = 3.14},
            new Measure() {Name = "Large Boulder", Name_Plural = "Large boulders", Type = "Area", Value = 3.14},
            new Measure() {Name = "Beaver", Name_Plural = "Beavers", Type = "Length", Value = 1.2},
            new Measure() {Name = "Football field", Name_Plural = "Football fields", Type = "Length", Value = 109.8},
            new Measure() {Name = "Fridge", Name_Plural = "Fridges", Type = "Length", Value = 1.62},
        };

        public List<Measure> GetAll()
        {
            return measureList;
        }

        public List<Measure> GetByType(string type)
        {
            return measureList.FindAll(x => x.Type == type);
        }

        public Measure GetByName(string name)
        {
            return measureList.Find(x => x.Name == name);
        }

        public Conversion GetConversion(string input, string output, double amount)
        {
                Measure inputMeasure = GetByName(input);
                Measure outputMeasure = GetByName(output);
                return new Conversion() { InputMeasure = inputMeasure, OutputMeasure = outputMeasure, Amount = Conversion.Convert(inputMeasure, outputMeasure, amount) };

        }
    }
}
