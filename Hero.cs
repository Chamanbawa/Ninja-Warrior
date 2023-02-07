using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OOP_Final_assessment
{
    public class Hero
    {

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length < 2 || value.Length > 15 || value.All(e => !Char.IsLetter(e)))
                {
                    Console.WriteLine("Name should be between 2 and 15 characters:");
                }
                else
                {
                    _name = value;
                }
            }
        }

        private int _baseStrength = 5;
        public int BaseStrength
        {
            get { return _baseStrength; }
            set
            {

                if (value < 0 || value > 100)
                {
                    throw new Exception("Base Defense should be between 0 and 100");
                }
                else
                {
                    _baseStrength = value;
                }

            }
        }

        private int _baseDefence = 3;
        public int BaseDefence
        {
            get { return _baseDefence; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception("Base Defense should be between 0 and 100");
                }
                else
                {
                    _baseDefence = value;
                }
            }
        }

        private int _originalHealth = 100;
        public int OriginalHealth
        {
            get { return _originalHealth; }
            set
            {
                _originalHealth = value;
            }
        }
        private int _currentHealth;
        public int CurrentHealth
        {

            get { return _currentHealth; }
            set
            {
                if (_currentHealth > OriginalHealth)
                {
                    throw new Exception("currentHealth cannot be greater than original health:");
                }
                else
                {
                    _currentHealth = value;
                }
            }
        }
        private void _setCurrentHealth()
        {
            _currentHealth = OriginalHealth;
        }

        private Weapon? _equippedWeapon;

        public Weapon EquippedWeapon
        {
            get { return _equippedWeapon; }
            set { _equippedWeapon = value; }

        }
        private Armour _equippedArmour;
        public Armour EquippedArmour
        {
            get { return _equippedArmour; }
            set { _equippedArmour = value; }
        }

        private int _win = 0;
        public int Win
        {
            get { return _win; }
            set { _win = value; }
        }

        private int _lost = 0;
        public int Lost
        {
            get { return _lost; }
            set { _lost = value; }
        }

        //GetStats (to get the things that hero currently has)

        public string GetStats()
        {
            Console.WriteLine($"Hero Name is {Name}, whose BaseStrength and BaseDefense is {_baseStrength} and {_baseDefence} respecitvley. Original health is {_originalHealth} and CurrentHealth is {CurrentHealth}.");
            return "hey";
        }

        //GetInventory(Returns what items the Hero is Equipped with)

        public string GetInventory()
        {
            Console.WriteLine($"Hero currently has {EquippedWeapon} in his hands and {EquippedArmour} on the body:");
            return "inventory";
        }


        //EquipWeapon(Change the EquippedWeapon)
        public void Equipweapon(Weapon weapon)
        {
            _equippedWeapon = weapon;
        }

        //EquipArmour(Change the EquippedArmour)
        public void EquipArmour(Armour armour)
        {
            _equippedArmour = armour;
        }

        public Hero(string name)
        {
            Name = name;
            _setCurrentHealth();
        }

        public void Game()
        {

        }

    }
}
