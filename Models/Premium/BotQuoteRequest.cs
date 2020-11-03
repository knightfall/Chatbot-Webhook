using Newtonsoft.Json;

namespace Chatbot_Webhook.Models.Premium
{
    public class BotQuoteRequest
    {
        [JsonProperty("CoverType")]
        public string CoverType { get; set; }

        [JsonProperty("Duration")]
        public int Duration { get; set; }
    }
}
