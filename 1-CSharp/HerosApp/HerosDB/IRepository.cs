using HerosLib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HerosDB
{
    public interface IRepository
    {
        void AddHero(Hero hero);
        
        Task<List<Hero>> GetAllHeroes();
    }
}