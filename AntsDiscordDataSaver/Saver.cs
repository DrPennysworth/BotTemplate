using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace AntsDiscordDataSaver
{
    public class Saver : ISave
    {
        private static readonly string DatabasePath = Environment.CurrentDirectory + @"\DB.kek";
        public List<AntsBaseDataModel> Database { get; set; }
        protected BinaryFormatter formatter = new BinaryFormatter();
        protected FileStream Stream ;

        public async Task SaverInit()
        {
            Stream = File.OpenWrite(DatabasePath);
            Database = (List<AntsBaseDataModel>)formatter.Deserialize(Stream) ?? new List<AntsBaseDataModel>();

        }

        public async Task<bool> CacheDatabaseToDisk()
        {
            try
            {
                formatter.Serialize(Stream, Database);
                Stream.Flush();
                return true;
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.Message);
                return false;
            }
        }

        public async Task AddUserToDatabase(AntsBaseDataModel data)
        {
            try
            {
                if (!Database.Exists(x=> x.DiscordId == data.DiscordId))
                {
                    Database.Add(data); 
                }
                else
                {
                    Console.WriteLine("oops");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            
        }

        public async Task UpdateUserData(ulong discordId, AntsBaseDataModel data )
        {
            
            Database[Database.FindIndex(x => x.DiscordId == discordId)] = data ;
        }

        public async Task RemoveUserFromDatabase(ulong discordId)
        {
            Database.RemoveAt(Database.FindIndex(x => x.DiscordId == discordId));
        }

        public async Task<AntsBaseDataModel> GetDataFromDatabase(ulong discordId)
        {
            if (Database.Exists(x=>x.DiscordId == discordId))
            {
                return Database.Find(x => x.DiscordId == discordId);
            }

            return null;
        }

        public async Task<List<AntsBaseDataModel>> GetAllDataFromDatabase()
        {
            return Database;
        }
    }
}