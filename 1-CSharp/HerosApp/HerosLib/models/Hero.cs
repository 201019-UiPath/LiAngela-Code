using System;
using System.Collections.Generic;

namespace HerosLib
{
    #region old way of creating class members
    // public class Hero
    // {
    //     public int id; // value type => System.Int32
        
    //     public string name; // reference type => string class

    //     // properties
    //     public int Id {
    //         get {
    //             return id;
    //         }
    //         set {
    //             id = value;
    //         }
    //     }

    //     // default constructor
    //     public Hero() {
    //         id = 1;
    //         name = "Bombasto";
    //     }

    //     // parameterized constructor
    //     public Hero(int id, string name)
    //     {
    //         // this.id = id;
    //         Id = id;
    //         this.name = name;
    //     }
    // }
    #endregion

    #region modern way of creating class members
    public class Hero
    {
        public int Id { get; set; } // value type => System.Int32
        
        public string Name { get; set; } // reference type => string class

        // public string[] superPowers = new string[10];

        // public static List<string> superPowers = new List<string>();
        
        public static Stack<string> superPowers = new Stack<string>(); // LIFO
        
        public static Dictionary<string, string> hideOuts = new Dictionary<string, string>();

        // public Hero() {
        //     superPowers.Add("Strength");
        //     superPowers.Add("Invisibility");
        //     superPowers.Add("Flying");
        //     superPowers.Add("Seeing through walls");
        // }

        public Hero() {
            superPowers.Push("Strength");
            superPowers.Push("Invisibility");
            superPowers.Push("Flying");
            superPowers.Push("Seeing through walls");
            // hideOuts.Add("Thor", "Asgard");
            // hideOuts.Add("Batman", "Batcave");
            // hideOuts.Add("Superman", "Fortress of Solitude");
        }

        // public static List<string> GetSuperPowers() {
        //     return superPowers;
        // }

        public static Stack<string> GetSuperPowers() {
            return superPowers;
        }

        // public void RemoveSuperPower(string superPower) {
        //     if (superPowers.Contains(superPower)) {
        //         superPowers.Remove(superPower);
        //     }
        // }

        public void RemoveSuperPower() {
            superPowers.Pop();
        }

        public void AddSuperPower(string superPower) {
            if (superPower != null && superPower != "") {
                // superPowers.Add(superPower);
                superPowers.Push(superPower);
            } else {
                throw new ArgumentException("Superpower should not be null or empty");
            }
        }
    }
    #endregion
}
