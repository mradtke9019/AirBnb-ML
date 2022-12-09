using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datascrub
{
    public class Review
    {
        public string listing_id { get; set; }
        public string id { get; set; }
        public string date { get; set; }
        public string reviewer_id { get; set; }
        public string reviewer_name { get; set; }
        public string comments { get; set; }
    }
}
