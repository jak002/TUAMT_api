
namespace TUAMT_api.Backend
{
    public interface IMeasureRepo
    {
        List<Measure> GetAll();
        Measure GetByName(string name);
        List<string> GetByType(string type);
        Conversion GetConversion(string input, string output, double amount);
    }
}