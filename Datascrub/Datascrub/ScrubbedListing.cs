using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datascrub
{
    public class ScrubbedListing
    {

        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string neighborhood_overview { get; set; }
        public string host_id { get; set; }
        //public string host_since { get; set; }
        
        // new calculated field
        public double host_duration_years { get; set; }
        public string host_location { get; set; }
        public string host_about { get; set; }
        public string host_response_time { get; set; }
        public double host_response_rate { get; set; }
        public double host_acceptance_rate { get; set; }
        public int host_is_superhost { get; set; }
        
        public string host_neighbourhood { get; set; }
        public int host_listings_count { get; set; }
        public int host_total_listings_count { get; set; }
        public int host_phone_verified{ get; set; }
        public int host_email_verified { get; set; }
        public int host_work_email_verified { get; set; }
        //public string host_verifications { get; set; }
        public int host_has_profile_pic { get; set; }
        public int host_identity_verified { get; set; }
        public string neighbourhood { get; set; }
        public string neighbourhood_cleansed { get; set; }
        //public string neighbourhood_group_cleansed { get; set; }
        //public string latitude { get; set; }
        //public string longitude { get; set; }
        public string property_type { get; set; }
        public string room_type { get; set; }
        public int accommodates { get; set; }
        //public string bathrooms { get; set; }
        public double bathrooms { get; set; }
        //public string bathrooms_text { get; set; }
        public int bedrooms { get; set; }
        public int beds { get; set; }
        public string amenities { get; set; }
        public double price { get; set; }
        public string minimum_nights { get; set; }
        public string maximum_nights { get; set; }
        public string minimum_minimum_nights { get; set; }
        public string maximum_minimum_nights { get; set; }
        public string minimum_maximum_nights { get; set; }
        public string maximum_maximum_nights { get; set; }
        public string minimum_nights_avg_ntm { get; set; }
        public string maximum_nights_avg_ntm { get; set; }
        //public string calendar_updated { get; set; }
        public int has_availability { get; set; }
        public string availability_30 { get; set; }
        public string availability_60 { get; set; }
        public string availability_90 { get; set; }
        public string availability_365 { get; set; }
        //public string calendar_last_scraped { get; set; }
        public string number_of_reviews { get; set; }
        public string number_of_reviews_ltm { get; set; }
        public string number_of_reviews_l30d { get; set; }
        public double years_since_first_review { get; set; }
        public double years_since_last_review { get; set; }
//        public string first_review { get; set; }
        //public string last_review { get; set; }
        public string review_scores_rating { get; set; }
        public string review_scores_accuracy { get; set; }
        public string review_scores_cleanliness { get; set; }
        public string review_scores_checkin { get; set; }
        public string review_scores_communication { get; set; }
        public string review_scores_location { get; set; }
        public string review_scores_value { get; set; }
        //public string license { get; set; }
        public int instant_bookable { get; set; }
        public string calculated_host_listings_count { get; set; }
        public string calculated_host_listings_count_entire_homes { get; set; }
        public string calculated_host_listings_count_private_rooms { get; set; }
        public string calculated_host_listings_count_shared_rooms { get; set; }
        public string reviews_per_month { get; set; }
        public ScrubbedListing(Listing l)
        {
            id = l.id;
            name = l.name;
            description = Cleaning.StripInvalidChars(Cleaning.StripHTML(l.description));
            neighborhood_overview = Cleaning.StripInvalidChars(Cleaning.StripHTML(l.neighborhood_overview));
            host_id = l.host_id;
            host_duration_years = (DateTime.Now - DateTime.Parse(l.host_since)).Days / 365.0;
            host_location = l.host_location;
            host_about = Cleaning.StripInvalidChars(Cleaning.StripHTML(l.host_about));
            host_response_time = l.host_response_time; // Make into ints
            host_response_rate = PercentageToDouble(l.host_response_rate);
            host_acceptance_rate = PercentageToDouble(l.host_acceptance_rate);
            host_is_superhost = BoolToInt(l.host_is_superhost);
            host_neighbourhood = l.host_neighbourhood;
            host_listings_count = int.Parse(l.host_listings_count);
            host_total_listings_count = int.Parse(l.host_total_listings_count);

            host_phone_verified = l.host_verifications.Contains("phone") ? 1 : -1;
            host_email_verified = l.host_verifications.Contains("'email'") ? 1 : -1;
            host_work_email_verified = l.host_verifications.Contains("work_email") ? 1 : -1;
            host_identity_verified = BoolToInt(l.host_identity_verified);
            host_has_profile_pic = BoolToInt(l.host_has_profile_pic);


            neighbourhood = l.neighbourhood;
            neighbourhood_cleansed = l.neighbourhood_cleansed;
            property_type = l.property_type;
            room_type = l.room_type;
            accommodates = int.Parse(l.accommodates);
            bathrooms = ParseBathrooms(l.bathrooms_text);
            bedrooms = !string.IsNullOrEmpty(l.bedrooms) ? int.Parse(l.bedrooms) : 0;
            beds = !string.IsNullOrEmpty(l.beds) ? int.Parse(l.beds) : 0;
            // amenities Get these sorted
            amenities = "";
            price = Double.Parse(l.price.Trim('$'));

            minimum_nights = l.minimum_nights;
            maximum_nights = l.maximum_nights;
            minimum_minimum_nights = l.minimum_minimum_nights;
            maximum_minimum_nights = l.maximum_minimum_nights;
            minimum_maximum_nights = l.minimum_maximum_nights;
            maximum_maximum_nights = l.maximum_maximum_nights;
            minimum_nights_avg_ntm = l.minimum_nights_avg_ntm;
            maximum_nights_avg_ntm = l.maximum_nights_avg_ntm;
            has_availability = BoolToInt(l.has_availability);

            availability_30 = l.availability_30;
            availability_60 = l.availability_60;
            availability_90 = l.availability_90;
            availability_365 = l.availability_365;
            number_of_reviews = l.number_of_reviews;
            number_of_reviews_l30d = l.number_of_reviews_l30d;
            number_of_reviews_ltm = l.number_of_reviews_ltm;

            if (l.first_review != "")
                years_since_first_review = (DateTime.Now - DateTime.Parse(l.first_review)).Days / 365.0;
            else
                years_since_first_review = 0;
            if (l.last_review != "")
                years_since_last_review = (DateTime.Now - DateTime.Parse(l.last_review)).Days / 365.0;
            else
                years_since_last_review = 0;
            review_scores_rating = l.review_scores_rating;
            review_scores_accuracy = l.review_scores_accuracy;
            review_scores_cleanliness = l.review_scores_cleanliness;
            review_scores_checkin = l.review_scores_checkin;
            review_scores_communication = l.review_scores_communication;
            review_scores_location = l.review_scores_location;
            review_scores_value = l.review_scores_value;
            instant_bookable = BoolToInt(l.instant_bookable);

            calculated_host_listings_count = l.calculated_host_listings_count;
            calculated_host_listings_count_entire_homes = l.calculated_host_listings_count_entire_homes;
            calculated_host_listings_count_private_rooms = l.calculated_host_listings_count_private_rooms;
            calculated_host_listings_count_shared_rooms = l.calculated_host_listings_count_shared_rooms;

            reviews_per_month = l.reviews_per_month;
        }

        public double ParseBathrooms(string str)
        {
            str = str.ToLower();
            if(string.IsNullOrEmpty(str))
            {
                return 0;
            }
            if (str.ToLower().Contains(""))
            {
                return 0.5;
            }
            double result = 0;

            result = Double.Parse(str.Split(" ").First());

            return result;
        }

        public double PercentageToDouble(string str)
        {
            if (str.Contains("N/A"))
                return 0;
            double r = Double.Parse(str.Split("%")[0]);
            return r / 100.0;
        }

        public int BoolToInt(string input)
        {
            if(input.ToLower() == "f")
            {
                return -1;
            }
            if (input.ToLower() == "t")
            {
                return 1;
            }
            return -1;
        }

        public static string GetHeaders()
        {
            string header = "";
            var properties = typeof(ScrubbedListing).GetProperties();

            header = string.Join(",", properties.Select(x => x.Name));

/*            foreach(var property in properties)
            {
                property.Name
            }*/

            return header;
        }


        public string Values()
        {
            List<string> values = new List<string>();
            string value;
            foreach (var prop in this.GetType().GetProperties())
            {
                string v = prop.GetValue(this, null).ToString();
                v = v.Replace("\"", ""); // This will mess with the csv format
                if (v.Contains(","))
                    v = "\"" + v + "\"";
                values.Add(v);
            }
            return string.Join(",", values);
        }
    }
}
