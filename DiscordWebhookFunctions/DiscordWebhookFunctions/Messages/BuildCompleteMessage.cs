using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordWebhookFunctions.Messages
{
    public class BuildCompleteMessage : DefaultMessage
    {
        public BuildCompleteMessage(IDictionary<string, string> queryParameters, dynamic data) : base(queryParameters, (string)data.message.text, (string)data.detailedMessage.markdown)
        {
            string status = data.resource.status;
            switch (status)
            {
                case "succeeded":
                    Embeds[0].Color = 6618980;
                    break;

                case "partiallySucceeded":
                    Embeds[0].Color = 14548736;
                    break;

                case "failed":
                    Embeds[0].Color = 13127690;
                    break;

                case "stopped":
                    break;

                default:
                    Embeds[0].Color = 13127690;
                    break;
            }
        }
    }
}
