using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System.Linq;

namespace Datascrub
{
    class Program
    {
        static void Main(string[] args)
        {
            string root = @"C:\Users\mradt\source\repos\Trinity\Machine Learning\machine-learning-final-assignment";
            var listings = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Listing>>(File.ReadAllText(root + @"\listings.json"));
            var reviews = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Review>>(File.ReadAllText(root + @"\reviews.json"));

            var scrubbed = reviews.Select(x => new Scrubbed(x)).ToList();
            //ToJson();
        }

        public static void ToJson()
        {
            string root = @"C:\Users\mradt\source\repos\Trinity\Machine Learning\machine-learning-final-assignment";
            string listings = ConvertCsvFileToJsonObject(root + @"\listings.csv");
            string reviews = ConvertCsvFileToJsonObject(root + @"\reviews.csv");

            File.WriteAllText(root + @"\listings.json", listings);
            File.WriteAllText(root + @"\reviews.json", reviews);
        }

        // https://stackoverflow.com/questions/10824165/converting-a-csv-file-to-json-using-c-sharp
        // https://stackoverflow.com/questions/6542996/how-to-split-csv-whose-columns-may-contain-comma
        public static string ConvertCsvFileToJsonObject(string path)
        {
            var csv = new List<string[]>();

            TextFieldParser parser = new TextFieldParser(path);
            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");
            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                List<string> cleaned = new List<string>();
                foreach (var f in fields)
                {
                    cleaned.Add(f);
                }
                csv.Add(fields);
            }
            parser.Close();

            var properties = csv[0];

            var listObjResult = new List<Dictionary<string, string>>();

            for (int i = 1; i < csv.Count; i++)
            {
                var objResult = new Dictionary<string, string>();
                for (int j = 0; j < properties.Length; j++)
                    objResult.Add(properties[j], csv[i][j]);

                listObjResult.Add(objResult);
            }

            return JsonConvert.SerializeObject(listObjResult);
        }

    }
}