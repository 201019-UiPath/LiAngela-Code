using HerosLib;
using HerosBL;
using System.Collections.Generic;

namespace HerosUI.Menus
{
    /// <summary>
    /// Main menu
    /// </summary>
    public class MainMenu : IMenu
    {
        HeroBL heroBL = new HeroBL();
        
        public void Start() {
            string userInput;
            do {
                System.Console.WriteLine("Welcome friend! What would you like to do today?");
                System.Console.WriteLine("[0] Create a hero\n[1] Get all heroes\n[x] Exit");
                userInput = System.Console.ReadLine();
                switch (userInput) {
                    case "0":
                        Hero newHero = GetHeroDetails();
                        heroBL.AddHero(newHero);
                        System.Console.WriteLine($"Hero {newHero.Name} was created with superpower of {Hero.superPowers.Pop()}!");
                        break;
                    case "1":
                        List<Hero> allHeroes = heroBL.GetAllHeroes();
                        foreach(var hero in allHeroes) {
                            System.Console.WriteLine($"Hero {hero.Id}: {hero.Name}");
                        }
                        break;
                    case "x":
                        System.Console.WriteLine("Have a great day!");
                        break;
                }
            } while (!userInput.Equals("x"));
        }

        public Hero GetHeroDetails() {
            Hero hero = new Hero();
            System.Console.WriteLine("Please enter your hero's name: ");
            hero.Name = System.Console.ReadLine();
            System.Console.WriteLine("Please add your hero's superpower: ");
            hero.AddSuperPower(System.Console.ReadLine());
            System.Console.WriteLine("Hero created!");
            // use logging software to log this
            // add step that sends the hero's details to the BL and then to the DL
            return hero;
        }
    }
}