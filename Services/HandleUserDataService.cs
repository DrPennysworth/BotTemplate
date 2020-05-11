using System;
using System.IO;
using System.Threading.Tasks;
using BotTemplate.JsonDataModels;
using Discord;
using Newtonsoft.Json;

namespace BotTemplate.Services
{
    
    public class HandleUserDataService
    {
        private static readonly string UserDataFilePath = Environment.CurrentDirectory + @"\UserData.json";
        private UsersList UserData
        {
            get
            {
                if (!File.Exists(UserDataFilePath))
                {
                    File.Create(UserDataFilePath);
                    return new UsersList();
                }
                return JsonConvert.DeserializeObject<UsersList>(File.ReadAllText(UserDataFilePath));
            }
            set {}
        }
        public void Init()
        {
            if (UserData == null)
            {
                UserData = new UsersList();
            }
        }

        public async Task<User> GetUserByDiscordId(ulong discordId)
        {
            return UserData.Users.Find(x => x.DiscordId == discordId);
        }

        public void AddUser(ulong discordId, User user)
        {
            if (!DoesUserExists(discordId))
            {
                UserData.Users.Add(new User()
                {
                    DiscordId = user.DiscordId,
                    DiscordUserName = user.DiscordUserName
                });
            }
        }

        public void AddUser(User userInfo)
        {
            UserData.Users.Add(userInfo);
        }

        public bool DoesUserExists(ulong discordId)
        {
            if (UserData.Users.Exists(x => x.DiscordId == discordId && UserData != null))
            {
                return true;
            }

            return false;
        }

        public void RemoveUser(ulong discordId)
        {
            UserData.Users.RemoveAt(UserData.Users.FindIndex(x => x.DiscordId == discordId));
        }

        public UsersList GetAllUsers()
        {
            return UserData;
        }
    }
}