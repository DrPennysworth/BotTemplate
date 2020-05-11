using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BotTemplate.JsonDataModels
{
    [Serializable]
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class UsersList
    {
        public List<User> Users { get; set; }
    }
}