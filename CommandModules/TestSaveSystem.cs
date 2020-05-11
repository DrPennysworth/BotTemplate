using System.Threading.Tasks;
using BotTemplate.JsonDataModels;
using BotTemplate.Services;
using Discord.Commands;

namespace BotTemplate.CommandModules
{
    public class TestSaveSystem : ModuleBase<SocketCommandContext>
    {
        public HandleUserDataService UserService { get; set; }
        
        [Command("addme")]
        public async Task AddMe()
        {
            UserService.AddUser(Context.User.Id, new User
            {
                DiscordId = Context.User.Id,
                DiscordUserName = Context.User.Username
            });
            await ReplyAsync("You are in the system!");
        }

        [Command("findme")]
        public async Task FindMeInDB()
        {
            if (UserService.DoesUserExists(Context.User.Id))
            {
                await ReplyAsync("You are in the data base");
            }
            else
            {
                await ReplyAsync("We cant seem to find you please use the addme command to be put into the databse");
            }
        }
    }
}