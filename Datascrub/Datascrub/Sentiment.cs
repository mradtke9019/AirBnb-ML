using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datascrub
{
    public class Sentiment
    {
        public string id { get; set; }
        public double sentiment { get; set; }
        public double sentiment_average { get; set; }
        public Sentiment(string id, string sentiment, string sentiment_average)
        {
            this.id = id;
            this.sentiment = Double.Parse(sentiment);
            this.sentiment_average = Double.Parse(sentiment_average);
        }
    }
}
