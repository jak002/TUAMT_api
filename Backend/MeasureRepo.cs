namespace TUAMT_api.Backend
{
    public class MeasureRepo : IMeasureRepo
    {

        private List<Measure> measureList = new List<Measure>()
        {
            new Measure() {Name = "Small Boulder", NamePlural = "Small boulders", Type = "Area", Value = 3.14},
            new Measure() {Name = "Large Boulder", NamePlural = "Large boulders", Type = "Area", Value = 3.14},
            new Measure() {Name = "Beaver", NamePlural = "Beavers", Type = "Length", Value = 1.2},
            new Measure() {Name = "Football field", NamePlural = "Football fields", Type = "Length", Value = 109.8},
            new Measure() {Name = "Fridge", NamePlural = "Fridges", Type = "Length", Value = 1.62},
        };

        public List<Measure> GetAll()
        {
            return measureList;
        }

        public List<string> GetByType(string type)
        {
            List<Measure> wholestuff = measureList.FindAll(x => x.Type == type);
            List<string> names = new List<string>();
            foreach (Measure measure in wholestuff) {
                names.Add(measure.Name);
            }
            return names;
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
