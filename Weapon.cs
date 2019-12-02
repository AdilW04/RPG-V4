using System;

class Weapon
{
    public string name;
    public int atk;
    public int value;
    public Weapon(string n, int a, int v)
    {
        this.name = n;
        this.atk = a;
        this.value = v;
    }
    public virtual void Attack(string playerName,Character target)
    {
    }
}

