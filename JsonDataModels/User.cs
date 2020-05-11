using System;
using Newtonsoft.Json;

namespace BotTemplate.JsonDataModels
{
    [Serializable]
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class User
    {
        public ulong DiscordId { get; set; }
        public string DiscordUserName { get; set; }
    }
}