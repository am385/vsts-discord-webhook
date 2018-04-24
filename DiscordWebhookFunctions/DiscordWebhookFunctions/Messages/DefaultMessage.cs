using DiscordWebhookFunctions.Discord;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordWebhookFunctions.Messages
{
    public class DefaultMessage : Webhook
    {
        public DefaultMessage(IDictionary<string, string> queryParameters, dynamic data) : this(queryParameters, (string)data.message.text, (string)data.detailedMessage.markdown)
        { }

        public DefaultMessage(IDictionary<string, string> queryParameters, string title, string description)
        {
            queryParameters.TryGetValue("username", out string queryUsername);
            Username = string.IsNullOrWhiteSpace(queryUsername) ? "VSTS" : queryUsername;

            queryParameters.TryGetValue("tts", out string queryTTS);
            if (!string.IsNullOrWhiteSpace(queryTTS))
            {
                bool.TryParse(queryTTS, out var queryTTSBool);
                TTS = queryTTSBool;
            }

            Embeds.Add(new Embed
            {
                Title = title,
                Description = description,
                Footer = new EmbedFooter
                {
                    Text = "VSTS Discord Integration",
                    //IconUrl = "https://cdn.discordapp.com/embed/avatars/0.png"
                }
            });
        }
    }
}
