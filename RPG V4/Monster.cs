using System;
using System.Collections.Generic;
using System.Threading;
class Monster:Character
{
    public int atk;
    public Monster(string n,int h,int m,int a):base(n,h,m)
    {
        this.atk = a;
    }
    //override may change to virtual if boss
    public override void Turn(List<Character> targetable)//should recieve list of all combatants from encounter class
    {
        Console.WriteLine(this.name + "'s HP: " + this.hp);
        Random RNG= new Random();
        while (true) 
        {
            int index = RNG.Next(targetable.Count);
            if (targetable[index] is Player)
            {
                Output.Ln("its " + this.name + "'s turn now...");
                Attack(targetable[index]);
                break;
            }
        }

    }
    public void ResetAmountAttacked()
    {
        this.amountAttacked = 0;
    }
    public virtual void Attack(Character target)
    {
        Output.Ln(this.name + " attacks "+target.name);
        int damageDealt=target.TakeDamage(this.atk);
        Output.Ln(this.name + " did " + damageDealt + " HP of Damage to "+target.name);
        this.amountAttacked += 1;
    }
    public override int TakeDamage(int amount)//may add calculation with defense amount/armour defense or somett
    {
        Output.Ln("SMASH!");
        LoseHp(amount);
        return (amount);
    }
}