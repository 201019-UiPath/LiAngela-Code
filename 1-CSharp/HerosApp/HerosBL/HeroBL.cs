using HerosLib;
using HerosDB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HerosBL
{
    public class HeroBL
    {
        IRepository repo = new FileRepo();
        
        public void AddHero(Hero newHero) {
            // add business logic to check if hero name is unique for example
            // throw exception otherwise
            List<Hero> heroes = GetAllHeroes();
            newHero.Id = heroes.Count + 1;
            repo.AddHero(newHero);
        }

        public List<Hero> GetAllHeroes() {
            Task<List<Hero>> getHeroes = repo.GetAllHeroes();
            return getHeroes.Result;
        }
    }
}
