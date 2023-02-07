using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Final_assessment
{
    public class Fight
    {
        //Creating properties
        private Game _game;
        public Game game
        {
            get { return _game; }
            set { _game = value;}
        }

        public void setttingGame()
        {
            Game newGame = new Game();
            game = newGame;
        }
        private Hero _hero;
        public Hero Hero
        {
            get { return _hero; }
            set { _hero = value; }
        }

        public void setHero(Hero hero)
        {
            Hero = hero;
        }


        private Monster _monster;
        public Monster Monster
        {
            get { return _monster; }
            set { _monster = value; }
        }
        //method to assign a Monster a Monster property
        public void setMonster(Monster monster)
        {
            Monster = monster;
        }

        bool fightloop = true;

        //Hero turn method
        public void HeroTurn()
        {
            Console.WriteLine("Now its hero turn");
            Console.WriteLine($"Current Health of Monster  is {Monster.CurrentHealth}");
            Monster.CurrentHealth -= Hero.BaseStrength + Hero.EquippedWeapon.Power - Monster.BaseDefense;
        }

        //monster turn method
        public void MonsterTurn()
        {
            Console.WriteLine($"Its {Monster.Name} Monster turn");
            Console.WriteLine($"Current Health of Hero  is {Hero.CurrentHealth}");

            Hero.CurrentHealth -= Monster.BaseStrength - Hero.BaseDefence - Hero.EquippedArmour.Power;
        }

        //if hero wins this method will be called.
        public void win()
        {
            if (Monster.CurrentHealth <= 0)
            {
                Monster.CurrentHealth = 0;
                Console.WriteLine($"Current Health of Monster  is {Monster.CurrentHealth} and Hero's is {Hero.CurrentHealth} and you won the Game:");
                Hero.Win++;
                game.DeleteMonster(Monster);
                fightloop = false;

            }

        }
        //if hero losts this method will be called
        public void lost()
        {
            if (Hero.CurrentHealth <= 0)
            {
                Hero.CurrentHealth = 0;
                Console.WriteLine($"Current Health of {Hero.Name} is {Hero.CurrentHealth}  and monster health is {Monster.CurrentHealth} and you lost the Game:");
                Hero.Lost++;
                Hero.CurrentHealth = Hero.OriginalHealth;
                fightloop = false;

            }

        }

        //in this method the battle begins
        public void ContinueFighting()
        {
            while (fightloop)
            {
              
                HeroTurn();
                win();
                if (fightloop == true)
                {
                    MonsterTurn();
                    lost();
                }

            }

        }


        public Fight(Hero hero, Monster monster)
        {
            setHero(hero);
            setMonster(monster);
            setttingGame();
            ContinueFighting();
        }


    }
}
