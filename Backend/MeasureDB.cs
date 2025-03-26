
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace TUAMT_api.Backend
{
    public class MeasureDB : IMeasureRepo
    {
        private readonly string _connectionString = secret.ConnectionString;
        public List<Measure> GetAll()
        {
            List<Measure> list = new List<Measure>();
            string SqlCommand = "SELECT * FROM TUAMTMeasures";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlCommand command = new(SqlCommand, conn);
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Measure measure = new Measure();
                        measure.Name = reader.GetString("Name");
                        measure.NamePlural = reader.GetString("Name_plural");
                        measure.Value = reader.GetDouble("Value");
                        measure.Type = reader.GetString("Type");
                        list.Add(measure);
                    }
                    return list;
                }
                catch (Exception ex)
                {
                    throw new Exception("Couldn't get database. Please contact admin, something may have gone haywire.");
                }
            }
        }

        public Measure GetByName(string name)
        {
            Measure measure = null;
            string SqlCommand = "SELECT * FROM TUAMTMeasures WHERE Name = @NAME";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlCommand command = new(SqlCommand, conn);
                    command.Parameters.AddWithValue("@NAME", name);
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        measure = new Measure();
                        measure.Name = reader.GetString("Name");
                        measure.NamePlural = reader.GetString("Name_plural");
                        measure.Value = reader.GetDouble("Value");
                        measure.Type = reader.GetString("Type");
                    }
                    return measure;
                }
                catch (Exception ex)
                {
                    throw new Exception("Couldn't get database. Please contact admin, something may have gone haywire.");
                }
            }
        }

        public List<string> GetByType(string type)
        {
            List<string> list = new List<string>();
            string SqlCommand = "SELECT * FROM TUAMTMeasures WHERE Type = @TYPE";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlCommand command = new(SqlCommand, conn);
                    command.Parameters.AddWithValue("@TYPE", type);
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string name = reader.GetString("Name");
                        list.Add(name);
                    }
                    return list;
                }
                catch (Exception ex)
                {
                    throw new Exception("Couldn't get database. Please contact admin, something may have gone haywire.");
                }
            }
        }

        public Conversion GetConversion(string input, string output, double amount)
        {
            try { 
            Measure inputMeasure = GetByName(input);
            Measure outputMeasure = GetByName(output);
            return new Conversion() { InputMeasure = inputMeasure, OutputMeasure = outputMeasure, Amount = Conversion.Convert(inputMeasure, outputMeasure, amount) };
        }
            catch (Exception ex)
            {
                throw;
            }
}
    }
}
