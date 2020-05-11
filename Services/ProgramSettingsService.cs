using System;
using System.IO;
using System.Threading.Tasks;
using BotTemplate.JsonDataModels;
using Newtonsoft.Json;

namespace BotTemplate.Services
{
    public class ProgramSettingsService
    {
        private ProgramSettings _programSettings;
        public ProgramSettings ProgramSettings { get; private set; }
        public async Task Init()
        {
            if (!File.Exists("ProgramSettings.json"))
            {
                File.Create("ProgramSettings.json");
            }

            try
            {
                
                var file = await File.ReadAllTextAsync(Environment.CurrentDirectory + @"\ProgramSettings.json");
                _programSettings = JsonConvert.DeserializeObject<ProgramSettings>(file);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            ProgramSettings = _programSettings;
        }
    }
}