using System;
using System.Threading;
//melee has combo chains so attack more than once,but ranged has headshots and does more damage in general
    class Melee : Weapon
    {
        int comboChain;
        //int missChance; 
        public Melee(string n, int a, int v, int c,int m)//where c is combo chain
        : base(n, a, v)
        {
            this.comboChain = c;
        }
        public override void Attack(string playerName,Character target)
        {
            Random RNG = new Random();
            int combo = RNG.Next(1, this.comboChain+1);
            Output.Ln(playerName + " attacks "+target.GetName()+ " with " + this.name);
            for (int i = 0; i < combo; i++)
            {
                int damageDealt=target.TakeDamage(this.atk);
                Output.Ln(target.GetName() + " Lost " + damageDealt + " HP!");
                //Thread.Sleep(1000);
            }
        if (combo > 1)
        {
            Output.Ln("A " + combo + "x Combo!");
        }



        }
    }
