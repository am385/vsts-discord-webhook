using DiscordWebhookFunctions.Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordWebhookFunctions.Messages
{
    public class PullRequestCreatedMessage : DefaultMessage
    {
        public PullRequestCreatedMessage(IDictionary<string, string> queryParameters, dynamic data) : base(queryParameters, (string)data.message.text, (string)data.detailedMessage.markdown)
        {
            string title = data.resource.title;
            string url = data.resource.url;

            Embeds[0].Fields.Add(new EmbedField
            {
                Name = "Pull Request",
                Value = $"[{title}]({url})"
            });
        }
    }
}
