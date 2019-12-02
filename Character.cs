using System;
using System.Collections.Generic;
class Character
{
    public string name;
    public int hp;
    public int mp;
    public bool hasFallen;
    public int key;
    public int amountAttacked;
    public bool isDefending;
    public int defense;
    public Character(string n, int h, int m)
    {
        this.isDefending = false;
        this.name = n;
        this.hp = h;
        this.mp = m;
        this.hasFallen = false;
        this.key = 0;
        this.amountAttacked = 0;
        this.defense = 1;
    }
    public void CancelDefend()
    {
        if (this.isDefending)
        {
            Output.Ln(this.name+" is no longer defending...");
            this.isDefending = false;
        }
    }
    public void Defend()
    {
        Output.Ln(this.name + " is defending");
        this.isDefending = true;
    }
    public virtual void Turn(List<Character> targetable)
    {

    }
    public void LoseHp(int amountLost)
    {
        this.hp = this.hp - amountLost;
    }
    public void LoseMp(int amountLost)
    {
        this.mp = this.mp - amountLost;
    }
    public int GetHp()
    {
        return (this.hp);
    }
    public string GetName()
    {
        return (this.name);
    }
    public void Fall()
    {
        this.hasFallen = true;
    }
    public void Rise()
    {
        this.hasFallen = false;
    }
    public bool GetHasFallen()
    {
        return(this.hasFallen);
    }
    public void SetKey(int key)
    {
        this.key = key;
    }
    public int GetKey()
    {
        return (this.key);
    }
    public void SetName(string newName)
    {
        this.name = newName;
    }

    public virtual int TakeDamage(int amount)//may add calculation with defense amount/armour defense or somett
    {
        LoseHp(amount);
        Output.Ln(this.name + "s hp is now " + this.hp);
        return (amount);
    }
}