using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;

namespace Datascrub
{
    class Program
    {
        static void Main(string[] args)
        {
            string root = @"C:\Users\Matthew Radtke\source\repos\machine-learning-final-assignment";
            var scrubbedDatastring = ConvertCsvFileToJsonObject(root + "/scrubbed-data.csv");
            List<ScrubbedData> data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ScrubbedData>>(scrubbedDatastring);
            data = data.Where(x =>
            {
                if (string.IsNullOrEmpty(x.review_scores_accuracy)&&
                string.IsNullOrEmpty(x.review_scores_checkin) &&
                string.IsNullOrEmpty(x.review_scores_cleanliness) &&
                string.IsNullOrEmpty(x.review_scores_communication) &&
                string.IsNullOrEmpty(x.review_scores_location) &&
                string.IsNullOrEmpty(x.review_scores_rating) &&
                string.IsNullOrEmpty(x.review_scores_value))
                    return false;
                return true;
            }).ToList();
            //File.WriteAllText(root + "./scrubbed-data.json", scrubbedDatastring);
            /*var listings = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Listing>>(File.ReadAllText(root + @"\listings.json"));
            //var reviews = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Review>>(File.ReadAllText(root + @"\reviews.json"));


            //var scrubbed = reviews.Select(x => new ScrubbedReview(x)).ToList();
            //ReviewsToCSV(scrubbed, root);

            // Only get listings thathave review data we care about
            //var listingIds = scrubbed.Select(x => x.listing_id).Distinct().ToList();
            //listings = listings.Where(x => listingIds.Contains(x.id)).ToList();


            var sListings = listings.Select(x => new ScrubbedListing(x)).ToList();
            var sentiments = LoadSentiments(root);

            FinalJSON(root, sListings, sentiments);
            //ListingsToCSV(sListings, root, "scrubbed-listings.csv");
            //ToJson();*/
        }

/*        public static void FinalJSON(string root, List<ScrubbedListing> listings, List<Sentiment> sentiments)
        {
            List<ScrubbedData> data = new List<ScrubbedData>();
            foreach (ScrubbedListing listing in listings)
            {
                var sentiment = sentiments.FirstOrDefault(x => x.id == listing.id);
                data.Add(new ScrubbedData(listing, sentiment));
            }

            File.WriteAllText(Path.Join(root,"scrubbed-data.json") , JsonConvert.SerializeObject(data));
        }
*/
        public static List<Sentiment> LoadSentiments(string root)
        {
            List<Sentiment> result = new List<Sentiment>();
            var lines = File.ReadAllLines(Path.Join(root, "sentiments.csv")).ToList();
            lines = lines.Skip(1).ToList();
            foreach(var line in lines)
            {
                var splits = line.Split(",");
                result.Add(new Sentiment(splits[0], splits[1], splits[2]));
            }
            return result;
        }

        public static void ListingsToCSV(List<ScrubbedListing>listings, string filePath, string name)
        {
            StringBuilder str = new StringBuilder();
            // Header line
            string header = ScrubbedListing.GetHeaders();
            str.AppendLine(header);
            foreach (var listing in listings)
            {
                string line = listing.Values();
                str.AppendLine(line);
            }

            File.WriteAllText(Path.Combine(filePath, name), str.ToString());
        }

        public static void ReviewsToCSV(List<ScrubbedReview> reviews, string filePath, string name = "scrubbed-reviews.csv")
        {
            StringBuilder str = new StringBuilder();
            // Header line
            str.AppendLine("listing_id,id,reviewer_id,comments");
            foreach(var review in reviews)
            {
                string line = review.ToString();
                str.AppendLine(line);
            }

            File.WriteAllText(Path.Combine(filePath,name), str.ToString());
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