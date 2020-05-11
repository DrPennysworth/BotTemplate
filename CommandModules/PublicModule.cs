using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace BotTemplate.CommandModules
{
    public class PublicModule : ModuleBase<SocketCommandContext> // if you make a new module file make sure your class/file inherits from ModuleBase<SocketCommandContext> this will let you use the already made command code without rewirting it 
    {

        [Command("ping")] // this is the actual text the command will look for 
        [Alias("pong", "hello")] // you can use this to make the bot look for other names that will also work to be this command like if you have a command that says hi you may want it to also look for Hi HI Hello to be names that run the same command
        public Task PingAsync()  // if you want to use arguments to a command use the argument of the function to use the arguments in the text command so if you put in string name in the function argument it will use the text after the command as a string input the arguments are gathered automatically 
            => ReplyAsync("pong!"); // this weird looking way to run code is called a lambda it just a replacment for needing to make a brakets for one line since the function only does one thing you can also use it if you want ot do something but never really need to do it again you can use    => (input arguments for code){code} this way you dont need make a function that only ever is used once javascript uses this alot
        

        // Get info on a user, or the user who invoked the command if one is not specified
        [Command("userinfo")]
        public async Task UserInfoAsync(IUser user = null)
        {
            user = user ?? Context.User; // the ?? is an operator that does the left first and if the left sire returns null then the right side is used usefull for making sure a null value doesnt crash the program works alot like try catch but doesnt give any info back to you like catch does

            await ReplyAsync(user.ToString());
        }

        // Ban a user
        [Command("ban")]
        [RequireContext(ContextType.Guild)]
        // make sure the user invoking the command can ban
        [RequireUserPermission(GuildPermission.BanMembers)]
        // make sure the bot itself can ban
        [RequireBotPermission(GuildPermission.BanMembers)]
        public async Task BanUserAsync(IGuildUser user, [Remainder] string reason = null)
        {
            await user.Guild.AddBanAsync(user, reason: reason);
            await ReplyAsync("ok!");
        }

        // [Remainder] takes the rest of the command's arguments as one argument, rather than splitting every space
        [Command("echo")]
        public Task EchoAsync([Remainder] string text)
            // Insert a ZWSP before the text to prevent triggering other bots!
            => ReplyAsync('\u200B' + text);

        // 'params' will parse space-separated elements into a list
        [Command("list")]
        public Task ListAsync(params string[] objects)
            => ReplyAsync("You listed: " + string.Join("; ", objects));

        // Setting a custom ErrorMessage property will help clarify the precondition error
        [Command("guild_only")]
        [RequireContext(ContextType.Guild, ErrorMessage = "Sorry, this command must be ran from within a server, not a DM!")]  // this lets you requre the command be said in a spacific context so you can lock commands to only work as a dm to the bot or in certain channels 
        //[RequireUserPermission(ChannelPermission.ViewChannel, ErrorMessage = " you failed", Group = "a role name here")] // you will use this to handle only people with certain permissions can use this command 
        public Task GuildOnlyCommand()
            => ReplyAsync("Nothing to see here!");
    }
}