using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Chatbot_Webhook.Handler;
using Chatbot_Webhook.Models;
using Chatbot_Webhook.Models.Premium;

namespace Chatbot_Webhook.Worker
{
    public class FetchPremium
    {
        public async Task<OshcQuote> OshcGetQuote(BotQuoteRequest quoteRequest)
        {
            string Covertype = quoteRequest.CoverType;
            int duration = quoteRequest.Duration;
            var bq = new BaseQuote
            {
                duration = duration
            };

            var op = new OshcQuote
            {
                Date = DateTime.UtcNow.AddHours(10).ToString("f",
                    CultureInfo.CreateSpecificCulture("en-AU")) + " AEST",
                Duration = duration
            };
            // Generating ID using covertype, duration and datetime
            op.Id = Covertype + "-" + duration + "-" + op.Date;
            if (Covertype == "Single")
            {
                bq.Allianzadult = "1";
                bq.Allianzchild = "0";
                bq.NibCoverType = "Single";
                bq.medibankCoverType = "S";
                op.Covertype = "Single";
            }
            else if (Covertype == "Couple")
            {
                bq.Allianzadult = "2";
                bq.Allianzchild = "0";
                bq.NibCoverType = "Couple";
                bq.medibankCoverType = "D";
                op.Covertype = "Couple";
            }
            else if (Covertype == "Family")
            {
                bq.Allianzadult = "2";
                bq.Allianzchild = "1";
                bq.NibCoverType = "Family";
                bq.medibankCoverType = "F";
                op.Covertype = "Family";
            }
            else if (Covertype == "Parent")
            {
                bq.Allianzadult = "1";
                bq.Allianzchild = "1";
                bq.NibCoverType = "Family";
                bq.medibankCoverType = "P";
                op.Covertype = "Single Parent";
            }

            //  Console.WriteLine($"Sending to Handler: {stopwatch.Elapsed.ToString()} has elapsed");

            var oshcApiHandler = new OshcApiHandler();

            //Parallel request to reduce processing time
            //Might not work in linux based installations. Check before deploying
            //Doesn't work in 5 dollar DigitalOcean droplet

            op.Allianz = await oshcApiHandler.AllianzQuoteHandler(bq);
            op.Nib = await oshcApiHandler.AllianzQuoteHandler(bq);
            op.Ahm = await oshcApiHandler.AhmQuoteHandler(bq);
            op.Medibank = await oshcApiHandler.MedibankQuoteHandler(bq);



            //stopwatch.Stop();
            return op;
        }
    }
}
