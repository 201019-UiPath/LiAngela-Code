using System;
using HerosLib;
using HerosUI.Menus;

namespace HerosUI
{
    class Program
    {
        static void Main(string[] args)
        {
            #region default constructor
            // Hero obj = new Hero();
            // Console.WriteLine($"{obj.id} {obj.name}");
            #endregion

            #region parameterized constructor
            // Hero obj1 = new Hero(2, "Narco");
            // Console.WriteLine($"{obj1.id} {obj1.name}");
            #endregion

            #region access via properties
            // Console.WriteLine($"ID = {obj1.Id}"); // read property value
            // obj1.Id = 3; // write into property
            // Console.WriteLine($"Updated ID = {obj1.Id}");
            #endregion

            // Hero obj = new Hero();
            // Console.Write("Please enter your hero's ID: ");
            // obj.Id = Int32.Parse(Console.ReadLine());
            // Console.Write("Please enter your hero's name: ");
            // obj.Name = Console.ReadLine();
            // Console.Write("Please enter the first superpower: ");
            // obj.superPowers[0] = Console.ReadLine();
            // Console.Write($"{obj.Id} {obj.Name} {obj.superPowers[0]}");

            #region List<T>, Stack<T>
            // Console.WriteLine("Please enter the superpower to be removed: ");
            // string sp = Console.ReadLine();
            // Hero.RemoveSuperPower(sp);
            // Hero.RemoveSuperPower();
            // foreach(var superPower in Hero.GetSuperPowers()) {
            //     Console.WriteLine(superPower);
            // }
            #endregion

            #region Dictionary<key, value>
            // Console.WriteLine("Superhero/Hideout:");
            // foreach(var superhero in Hero.hideOuts) {
            //     // Console.WriteLine($"{superhero.Key} / {superhero.Value}");
            //     Console.WriteLine($"{superhero.Key} / {Hero.hideOuts[superhero.Key]}");
            // }
            #endregion

            #region calling hero menu
            IMenu startMenu = new MainMenu();
            startMenu.Start();
            #endregion

            HeroTasks heroTask = new HeroTasks();
            #region delegates, anonymous methods, lambda functions
            // HeroDel del = new HeroDel(heroTask.GetSuperPowers);
            Action del = new Action(heroTask.GetSuperPowers); // strongly-typed pre-defined delegate
            del += heroTask.DoWork; // subscribe to a method with +=
            del += heroTask.ManageLife;
            del();
            del -= heroTask.ManageLife;  // unsubscribe with -=
            del();

            // anonymous methods
            Action<string> am = delegate(string name) {
                Console.WriteLine("Hello anonymous");
            };
            am("me");

            // lambda expressions => shorthand notations to anonymous methods
            Action result = () => Console.WriteLine("Hello lambda");
            result();
            #endregion

            #region synchronous vs asynchronous programming
            // subscribing to publisher
            heroTask.workDone += EmailService.SendEmail;
            heroTask.workDone += TextMessageService.SendText;
            heroTask.workDone += PushNotificationService.SendPushNotification;
            heroTask.DoWork();
            heroTask.ManageLife();
            // System.Threading.Thread.Sleep(2000);
            Console.Read(); // holds the screen until key is pressed
            #endregion
        }
    }
}
