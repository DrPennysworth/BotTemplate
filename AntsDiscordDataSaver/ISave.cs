using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntsDiscordDataSaver
{
    public interface ISave 
    {
        public List<AntsBaseDataModel> Database { get; set; }
        public Task<bool> CacheDatabaseToDisk();
        public Task AddUserToDatabase(AntsBaseDataModel data);
        public Task UpdateUserData(ulong discordId, AntsBaseDataModel data);
        public Task RemoveUserFromDatabase(ulong discordId);
        public Task<AntsBaseDataModel> GetDataFromDatabase(ulong discordId);
        public Task<List<AntsBaseDataModel>> GetAllDataFromDatabase();
    }
}