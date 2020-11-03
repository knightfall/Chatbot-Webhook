using System;

namespace Chatbot_Webhook.Models
{
    public partial class OshcQuote
    {
        public string Id { get; set; }
        public string Date { get; set; }
        public int Duration { get; set; }
        public decimal? Allianz { get; set; }
        public decimal? Nib { get; set; }
        public decimal? Medibank { get; set; }
        public decimal? Ahm { get; set; }
        public decimal? Cbhs { get; set; }
        public decimal? Bupa { get; set; }
        public string Covertype { get; set; }
    }
}
