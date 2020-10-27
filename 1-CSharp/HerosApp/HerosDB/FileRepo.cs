using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

using HerosLib;

namespace HerosDB
{
    /// <summary>
    /// Repository using files
    /// </summary>
    public class FileRepo : IRepository
    {
        string filePath = "HerosDB/HerosDataPlace/Heroes.txt";

        /// <summary>
        /// Adds hero to file
        /// </summary>
        /// <param name="hero"></param>
        public async void AddHero(Hero hero)
        {
            List<Hero> heroes = await GetAllHeroes();
            heroes.Add(hero);
            using (FileStream fs = File.Create(filePath))
            {
                System.Console.WriteLine("Hero is being written to file...");
                await JsonSerializer.SerializeAsync(fs, heroes);
            }
        }

        /// <summary>
        /// Gets all heros from file
        /// </summary>
        /// <returns></returns>
        public async Task<List<Hero>> GetAllHeroes()
        {
            List<Hero> allHeroes = new List<Hero>();
            if (File.Exists(filePath)) {
                using (FileStream fs = File.OpenRead(filePath))
                {
                    allHeroes = await JsonSerializer.DeserializeAsync<List<Hero>>(fs);
                }
            }
            return allHeroes;
        }
    }
}