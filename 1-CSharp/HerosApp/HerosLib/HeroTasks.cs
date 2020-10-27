using System;
using System.Threading.Tasks;

namespace HerosLib
{
    public delegate void HeroDel();
    
    public class HeroTasks : IHeroOperations, IHeroSuperPowers
    {
        string path = @"SuperPowers.txt";

        public event HeroDel workDone; // create event
        
        public async void DoWork()
        {
            System.Console.WriteLine("Work started...");
            await Task.Run(new Action(GetSuperPowers));
            System.Console.WriteLine("Saving humanity is my work");
            System.Console.WriteLine("Work finished.");
            OnWorkDone();
        }

        public void OnWorkDone() {
            if (workDone != null) {
                workDone(); // raising the event
            }
        }

        public void ManageLife()
        {
            System.Console.WriteLine("I have a cranky partner to manage");
        }

        public void GetSuperPowers() {
            System.Console.WriteLine("Getting superpowers...");
            System.Threading.Thread.Sleep(1000);
            string superPower = System.IO.File.ReadAllText(path);
            System.Console.WriteLine($"Superpower obtained: {superPower}");
        }
    }
}