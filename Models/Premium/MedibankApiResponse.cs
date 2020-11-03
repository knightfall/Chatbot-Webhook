using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Chatbot_Webhook.Models.Premium
{
    public partial class MedibankApiResponseJson
    {
        [JsonProperty("quoteId")]
        public string QuoteId { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [JsonProperty("visaEndDate")]
        public string VisaEndDate { get; set; }

        [JsonProperty("product")]
        public string Product { get; set; }

        [JsonProperty("courseCompletionDate")]
        public string CourseCompletionDate { get; set; }

        [JsonProperty("fundId")]
        public long FundId { get; set; }
    }

    public partial class MedibankApiResponseJson
    {
        public static MedibankApiResponseJson FromJson(string json) => JsonConvert.DeserializeObject<MedibankApiResponseJson>(json, MedibankConverter.Settings);
    }

    public static class MedibankSerialize
    {
        public static string ToJson(this MedibankApiResponseJson self) => JsonConvert.SerializeObject(self, MedibankConverter.Settings);
    }

    internal static class MedibankConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
