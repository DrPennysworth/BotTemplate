using System;
using Newtonsoft.Json;

namespace AntsDiscordDataSaver
{
    [Serializable]
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class AntsBaseDataModel
    {
        public ulong DiscordId { get; set; }
    }
}