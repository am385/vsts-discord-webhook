using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordWebhookFunctions.Discord
{
    public class Embed
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("timestamp")]
        public DateTime? TimeStamp { get; set; }

        [JsonProperty("color")]
        public int? Color { get; set; }

        [JsonProperty("footer")]
        public EmbedFooter Footer { get; set; }

        [JsonProperty("image")]
        public EmbedImage Image { get; set; }

        [JsonProperty("thumbnail")]
        public EmbedThumbnail Thumbnail { get; set; }

        [JsonProperty("author")]
        public EmbedAuthor Author { get; set; }

        [JsonProperty("fields")]
        public List<EmbedField> Fields { get; set; } = new List<EmbedField>();
    }
}
