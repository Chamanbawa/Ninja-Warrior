using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Final_assessment
{
    public class Weapon
    {
        private string _name;
        public string Name { get { return _name; } }
        private void _setName(string name)
        {
            if (name.Length < 3)
            {
                throw new Exception("Weapon name should have at least 3 characters:");
            }
            else
            {
                _name = name;
            }
        }

        private int _power;
        public int Power { get { return _power; } }
        private void _setpower(int power)
        {
            if (power < 0 || power > 100)
            {
                throw new Exception("Weapon Damage cannot be less than 0 and greater then 100");
            }
            else
            {
                _power = power;
            }
        }


        public Weapon(string name, int power)
        {
            _setName(name);
            _setpower(power);

        }

    }
}
