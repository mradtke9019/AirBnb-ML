using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Datascrub
{
    public class ScrubbedReview
    {
        public string listing_id { get; set; }
        public string id { get; set; }
       // public string date { get; set; }
        public string reviewer_id { get; set; }
        //public string reviewer_name { get; set; }
        public string comments { get; set; }

        
        public ScrubbedReview(Review r)
        {
            this.listing_id = r.listing_id;
            this.id = r.id;
            this.reviewer_id = r.reviewer_id;
            this.comments = r.comments;
            string noHtml = Cleaning.StripHTML(comments);
           /* if(comments != noHtml)
            {
                Console.WriteLine("Cleaned html");
            }*/
            comments = noHtml;

            string noBadChars = Cleaning.StripInvalidChars(comments);
            /*if (comments != noBadChars)
            {
                Console.WriteLine("Cleaned invalid chars");
            }*/
            comments = noBadChars;
            // remove invalid characters
        }



        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(listing_id);
            result.Append(",");
            result.Append(id);
            result.Append(",");
            result.Append(reviewer_id);
            result.Append(",");
            result.Append("\"" + comments + "\"");
            return result.ToString();
        }
    }
}