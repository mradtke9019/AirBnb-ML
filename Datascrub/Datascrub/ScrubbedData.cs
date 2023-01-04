using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datascrub
{
    public class ScrubbedData
    {

        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string neighborhood_overview { get; set; }
        public string host_id { get; set; }
        public string host_duration_years { get; set; }
        public string host_about { get; set; }
        public string host_response_rate { get; set; }
        public string host_acceptance_rate { get; set; }
        public string host_is_superhost { get; set; }
        public string host_listings_count { get; set; }
        public string host_total_listings_count { get; set; }
        public string host_phone_verified { get; set; }
        public string host_email_verified { get; set; }
        public string host_work_email_verified { get; set; }
        public string host_has_profile_pic { get; set; }
        public string host_identity_verified { get; set; }
        public string accommodates { get; set; }
        public string bathrooms { get; set; }
        public string bedrooms { get; set; }
        public string beds { get; set; }
        public string amenities { get; set; }
        public string price { get; set; }
        public string minimum_nights { get; set; }
        public string maximum_nights { get; set; }
        public string minimum_minimum_nights { get; set; }
        public string maximum_minimum_nights { get; set; }
        public string minimum_maximum_nights { get; set; }
        public string maximum_maximum_nights { get; set; }
        public string minimum_nights_avg_ntm { get; set; }
        public string maximum_nights_avg_ntm { get; set; }
        public string has_availability { get; set; }
        public string availability_30 { get; set; }
        public string availability_60 { get; set; }
        public string availability_90 { get; set; }
        public string availability_365 { get; set; }
        public string number_of_reviews { get; set; }
        public string number_of_reviews_ltm { get; set; }
        public string number_of_reviews_l30d { get; set; }
        public string years_since_first_review { get; set; }
        public string years_since_last_review { get; set; }
        public string review_scores_rating { get; set; }
        public string review_scores_accuracy { get; set; }
        public string review_scores_cleanliness { get; set; }
        public string review_scores_checkin { get; set; }
        public string review_scores_communication { get; set; }
        public string review_scores_location { get; set; }
        public string review_scores_value { get; set; }
        public string instant_bookable { get; set; }
        public string calculated_host_listings_count { get; set; }
        public string calculated_host_listings_count_entire_homes { get; set; }
        public string calculated_host_listings_count_private_rooms { get; set; }
        public string calculated_host_listings_count_shared_rooms { get; set; }
        public string reviews_per_month { get; set; }
        public string review_sentiment { get; set; }
        public string sentiment_average { get; set; }

    }
}
