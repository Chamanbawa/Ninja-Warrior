using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Final_assessment
{
    public class Monster
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


        private int _baseStrength;
        public int BaseStrength
        {
            get { return _baseStrength; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("BaseStrength cannot be negative");
                }
                else
                {
                    _baseStrength = value;
                }
            }
        }

        private int _baseDefense;
        public int BaseDefense
        {
            get { return _baseDefense; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("BaseDefense cannot be negative");
                }
                else
                {
                    _baseDefense = value;
                }
            }
        }

        private int _originalHealth;
        public int OriginalHealth
        {
            get { return _originalHealth; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception("Original Health can be between 0 and 100 only.");
                }
                else
                {
                    _originalHealth = value;
                }
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


        public Monster(string name, int strength, int defense, int originalHealth)
        {
            Name = name;
            BaseStrength = strength;
            BaseDefense = defense;
            OriginalHealth = originalHealth;
            _setCurrentHealth();

        }
    }
}
