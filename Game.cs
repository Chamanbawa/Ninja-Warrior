using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_Final_assessment
{
    public class Game
    {
        private string _name = "cha,an";
        public string Name
        {
            get { return _name; }
            set
            {

                _name = value;

            }
        }
        //Creating properties and fields.
        private Hero _hero;
        public Hero Hero
        {
            get { return _hero; }
            set { _hero = value; }
        }
        private Monster _monster;
        public Monster Monster
        {
            get { return _monster; }
            set { _monster = value; }
        }
        private Fight _fight;
        public Fight Fight
        {
            get { return _fight; }
            set { _fight = value; }
        }

        //Creating collections
        private HashSet<Weapon> _weapons { get; set; } = new HashSet<Weapon>();
        private HashSet<Armour> _armours { get; set; } = new HashSet<Armour>();
        private HashSet<Monster> _monsters { get; set; } = new HashSet<Monster>();

        //loop booleans
        bool checkingName = true;
        bool inventoryloop = true;
        bool ContinueSwitch = true;
        bool weaponsloop = true;
        bool armoursloop = true;
        string heroNamebyUser = "";

        //some methods to create,delete and get classes,weapons,armours etc.
        private void GetHeroName()
        {
            while (checkingName)
            {
                Console.Write("Enter Hero Name:");
                heroNamebyUser = Console.ReadLine();
                Hero hero = new Hero(heroNamebyUser);
                Hero = hero;
                if (Hero.Name == heroNamebyUser)
                {
                    checkingName = false;
                }
            }


        }
        public void CreateWeapon(string name, int power)
        {

            Weapon newWeapon = new Weapon(name, power);
            _weapons.Add(newWeapon);

        }

        public void CreateArmour(string name, int power)
        {
            Armour newArmour = new Armour(name, power);
            _armours.Add(newArmour);

        }

        public void CreateMonster(string name, int strength, int defense, int originalhealth)
        {

            Monster newMonster = new Monster(name, strength, defense, originalhealth);
            _monsters.Add(newMonster);


        }
        public void DeleteMonster(Monster monster)
        {
          
            _monsters.Remove(monster);
        }
        public void RandomMonster()
        {
            // I found this great method from stack overflow. to get randome numbers and I user element at get specific element at particluar place.
            int randomNumber = new Random().Next(_monsters.Count);
            Monster randomMonster = _monsters.ElementAt(randomNumber);
            Monster = randomMonster;
        }

        public void CreateFight(Hero hero, Monster monster)
        {
            Fight newFight = new Fight(hero, monster);

            Fight = newFight;
        }

        //printing all the available weapons and armours in the game.
        private void _getWeaponsList()
        {
            int i = 1;
            foreach (Weapon w in _weapons)
            {

                Console.WriteLine($"{i}: {w.Name} : {w.Power} Damage per shot");
                i++;
            }
            Console.WriteLine($"{_weapons.Count + 1}. To Go back to the Main Menu ");

        }
        private void _getArmoursList()
        {
            int i = 1;
            foreach (Armour a in _armours)
            {
                Console.WriteLine($"{i}. {a.Name} : {a.Power} BaseDefense per shot");
                i++;
            }
            Console.WriteLine($"{_armours.Count + 1}. To Go back to the Main Menu ");

        }

        private void MainMenu()
        {


            Console.WriteLine("Press a for Statistics");
            Console.WriteLine("Press b for Inventory");
            Console.WriteLine("Press c for Fight");
            Console.WriteLine("Press d for EXIT");
            string userSelection = Console.ReadLine().ToUpper().Trim();

            // if userseleciton is not valid 
            while (userSelection != "A" && userSelection != "B" && userSelection != "C" && userSelection != "D")
            {
                Console.WriteLine("Please enter  a-d:");
                Console.WriteLine("Press a for Statistics");
                Console.WriteLine("Press b for Inventory");
                Console.WriteLine("Press c for Fight");
                Console.WriteLine("Press d for EXIT");


                userSelection = Console.ReadLine().ToUpper().Trim();
            }


            while (userSelection != "D")
            {
                //if user gets inside this loop by enterinng corrrect input and try to enter wrong input again this is for that.
                while (userSelection != "A" && userSelection != "B" && userSelection != "C" && userSelection != "D")

                {
                    Console.WriteLine("Please enter  a-d:");
                    Console.WriteLine("Press a for Statistics");
                    Console.WriteLine("Press b for Inventory");
                    Console.WriteLine("Press c for Fight");
                    Console.WriteLine("Press d for EXIT");
                    userSelection = Console.ReadLine().ToUpper().Trim();
                }
                while (ContinueSwitch)
                {
                    //selecting option from main menu.
                    switch (userSelection)
                    {
                        case "A":
                            //Statistics are here.
                            Console.WriteLine($"Total games played {Hero.Win + Hero.Lost}," +
                                $" Total wins {Hero.Win}, Total" +
                                $" losts {Hero.Lost}");
                            ContinueSwitch = false;
                            break;


                        case "B":
                            //inside the inventory case.

                            while (inventoryloop)
                            {
                                //here weapons , armours to get changed.
                                Console.WriteLine("a. To change the Weapon ");
                                Console.WriteLine("b. To change the Armour ");
                                Console.WriteLine("c. To Go back to the Main Menu ");
                                string inventoryoptions = Console.ReadLine().ToUpper().Trim();
                                while (inventoryoptions != "A" && inventoryoptions != "B" && inventoryoptions != "C")
                                {
                                    Console.WriteLine("a. To change the Weapon ");
                                    Console.WriteLine("b. To change the Armour ");
                                    Console.WriteLine("c. To Go back to the Main Menu ");
                                    inventoryoptions = Console.ReadLine();
                                }

                                switch (inventoryoptions)
                                {
                                    case "A":
                                        //case 1 for weapons change.
                                        while (weaponsloop)
                                        {


                                            _getWeaponsList();
                                            Console.Write($"Enter a number which weapon you want to equip with. Currently you have {Hero.EquippedWeapon.Name} : ");
                                            int weaponselection = Int32.Parse(Console.ReadLine());

                                            while (weaponselection > _weapons.Count + 1 || weaponselection <= 0)
                                            {
                                                _getWeaponsList();
                                                Console.WriteLine("Please enter the valid value ");
                                                Console.Write($"Enter a number which weapon you want to equip with. Currently you have {Hero.EquippedWeapon.Name} : ");
                                                weaponselection = Int32.Parse(Console.ReadLine());
                                            }


                                            //this is to exit the loop 
                                            if (weaponselection == _weapons.Count + 1)
                                            {
                                                weaponsloop = false;
                                            }
                                            else
                                            {
                                                Hero.Equipweapon(_weapons.ElementAt(weaponselection - 1));

                                            }


                                        }

                                        weaponsloop = true;
                                        break;
                                    case "B":
                                        //this case to change armours 
                                        while (armoursloop)
                                        {


                                            _getArmoursList();

                                            Console.Write($"Enter a number which Armour you want to equip with. Currently you have {Hero.EquippedArmour.Name} : ");
                                            int armourselection = Int32.Parse(Console.ReadLine());

                                            while (armourselection > _armours.Count + 1 || armourselection <= 0)
                                            {
                                                _getArmoursList();
                                                Console.WriteLine("Please enter the valid value ");
                                                Console.Write($"Enter a number which Armour you want to equip with. Currently you have {Hero.EquippedArmour.Name} : ");
                                                armourselection = Int32.Parse(Console.ReadLine());
                                            }


                                            //this is to get exit from armours loop.
                                            if (armourselection == _armours.Count + 1)
                                            {
                                                armoursloop = false;
                                            }
                                            else
                                            {
                                                Hero.EquipArmour(_armours.ElementAt(armourselection - 1));

                                            }
                                        }
                                        armoursloop = true;

                                        break;

                                    case "C":
                                        //this case is to get out of the inventory.
                                        inventoryloop = false;
                                        break;

                                }
                            }
                            inventoryloop = true;
                            ContinueSwitch = false;

                            break;
                        case "C":
                            //this is to do a fight.
                            //new fight is get created.
                            RandomMonster();
                            CreateFight(Hero, Monster);
                            Fight.ContinueFighting();

                            ContinueSwitch = false;
                            break;
                    }
                }
                ContinueSwitch = true;
                Console.WriteLine("Please enter  a-d:");
                Console.WriteLine("Press a for Statistics");
                Console.WriteLine("Press b for Inventory");
                Console.WriteLine("Press c for Fight");
                Console.WriteLine("Press d for EXIT");
                userSelection = Console.ReadLine().ToUpper().Trim();

            }
        }

        public void CreatingInstances()
        {
            CreateWeapon("AWM", 50);
            CreateWeapon("AKM", 10);
            CreateWeapon("M416", 13);
            CreateWeapon("M249", 17);
            CreateWeapon("Kr98k", 20);
            CreateArmour("level 1", 7);
            CreateArmour("level 2", 25);
            CreateArmour("level 3", 30);
            CreateMonster("sara", 20, 3, 100);
            CreateMonster("Victor", 15, 5, 100);
            CreateMonster("Carlo", 25, 3, 100);
            Hero.Equipweapon(_weapons.First());
            Hero.EquipArmour(_armours.First());
        }
        public void Start()
        {
            GetHeroName();
            CreatingInstances();
            MainMenu();

        }




    }
}
