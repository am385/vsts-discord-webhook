using DiscordWebhookFunctions.Discord;
using DiscordWebhookFunctions.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace DiscordWebhookFunctions
{
    public static class VstsWebhookInterceptor
    {
        private const string DISCORD_WEBHOOK_API = "https://discordapp.com/api/webhooks";

        [FunctionName("VstsWebhookInterceptor")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // Get Discord URL values from Query Parameters
            string discordWebhookId = req.Query["id"];
            string discordWebhookToken = req.Query["token"];

            if (discordWebhookId == null || discordWebhookToken == null)
                return new BadRequestObjectResult("Please pass the discord webhook 'id' and 'token' in the query string");

            string requestBody = new StreamReader(req.Body).ReadToEnd();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            if (data == null)
                return new BadRequestObjectResult("The body can't be null");

            DefaultMessage discordMessage;
            try
            {
                discordMessage = GenerateDiscordMessage(req.GetQueryParameterDictionary(), data);
            }
            catch (Exception)
            {
                return new BadRequestObjectResult("The body does not conform to VSTS generic 'Web Hook'");
            }

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            using (var client = new HttpClient())
            {
                var uri = $"{DISCORD_WEBHOOK_API}/{discordWebhookId}/{discordWebhookToken}";
                HttpResponseMessage result = client.PostAsJsonAsync(uri, discordMessage).Result;

                var json = JsonConvert.SerializeObject(discordMessage);

                return new StatusCodeResult((int)result.StatusCode);
            }
        }

        private static DefaultMessage GenerateDiscordMessage(IDictionary<string, string> queryParameters, dynamic data)
        {
            DefaultMessage discordMessage = null;

            string eventType = data.eventType;
            switch (eventType)
            {
                case "build.complete":
                    discordMessage = new BuildCompleteMessage(queryParameters, data);
                    break;

                case "git.push":
                    discordMessage = new DefaultMessage(queryParameters, data);
                    break;

                case "git.pullrequest.created":
                    discordMessage = new PullRequestCreatedMessage(queryParameters, data);
                    break;
                case "git.pullrequest.updated":
                    discordMessage = new DefaultMessage(queryParameters, data);
                    break;
                case "git.pullrequest.merged":
                    discordMessage = new DefaultMessage(queryParameters, data);
                    break;

                case "tfvc.checkin":
                    discordMessage = new DefaultMessage(queryParameters, data);
                    break;

                case "workitem.created":
                    discordMessage = new DefaultMessage(queryParameters, data);
                    break;
                case "workitem.commented":
                    discordMessage = new DefaultMessage(queryParameters, data);
                    break;
                case "workitem.updated":
                    discordMessage = new DefaultMessage(queryParameters, data);
                    break;
                case "workitem.deleted":
                    discordMessage = new DefaultMessage(queryParameters, data);
                    break;
                case "workitem.restored":
                    discordMessage = new DefaultMessage(queryParameters, data);
                    break;

                case "ms.vss-release.release-created-event":
                    discordMessage = new DefaultMessage(queryParameters, data);
                    break;
                case "ms.vss-release.release-abandoned-event":
                    discordMessage = new DefaultMessage(queryParameters, data);
                    break;

                case "ms.vss-release.deployment-approval-completed-event":
                    discordMessage = new DefaultMessage(queryParameters, data);
                    break;
                case "ms.vss-release.deployment-approval-pending-event":
                    discordMessage = new DefaultMessage(queryParameters, data);
                    break;
                case "ms.vss-release.deployment-started-event":
                    discordMessage = new DefaultMessage(queryParameters, data);
                    break;
                case "ms.vss-release.deployment-completed-event":
                    discordMessage = new DefaultMessage(queryParameters, data);
                    break;

                default:
                    discordMessage = new DefaultMessage(queryParameters, data);
                    break;
            }

            return discordMessage;
        }
    }
}
