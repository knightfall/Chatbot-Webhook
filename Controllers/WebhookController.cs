﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Chatbot_Webhook.Models.Premium;
using Chatbot_Webhook.Worker;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Chatbot_Webhook.Controllers
{
    [Route("api")]
    [ApiController]
    public class WebhookController : ControllerBase
    {
        // GET: api/<WebhookController>
        [HttpGet("test")]
        public JsonResult Get([FromBody] BotQuoteRequest quoteRequest)
        {
            var returned = new FetchPremium().OshcGetQuote(quoteRequest);
            return new JsonResult(returned);
        }


    }
}
