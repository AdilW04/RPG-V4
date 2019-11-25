using System;
using System.Collections.Generic;

class Player:Character
{
    List<Weapon> equippedWeapons;
    Weapon weapon;
    public Player(string n)
    :base(n,54,30)
    {
        this.equippedWeapons = new List<Weapon>();
        this.equippedWeapons.Add(new Melee("What seems to be a sword", 20, 400,3,10));
        this.weapon = equippedWeapons[0];

    }
    public override void Turn(List<Character> targetable)
    {
        bool a = true;
        while (a == true)
        {

            Console.WriteLine(this.name + "'s HP: " + this.hp);
            Console.WriteLine("You are playing as " + this.name);
            Console.Write("~~ 1) Attack 2) Defend 3) Magic *.¬:");
            string input = Console.ReadLine().ToUpper();
            if (input == "1" || input == "ATTACK")
            {
                //checks how many monsters there are so you dont have to pick if theres only 1
                int y = 0;
                foreach (Character target in targetable)
                {
                    if (target is Monster)
                    {
                        y = y + 1;
                    }
                }
                if (y > 1)
                {
                    ////gives each monster a key and outputs their name
                    //Console.WriteLine("Here are your targets");
                    //int x = 1;
                    //foreach (Character target in targetable)
                    //{
                    //    if (target is Monster)
                    //    {
                    //        target.SetKey(x);
                    //        Console.WriteLine("> " + target.GetKey() + ")" + target.name + " Hp: " + target.hp);
                    //        x = x + 1;
                    //    }
                    //}
                    ////asks you who you wanna pick and checks which monster has the key that you inputted
                    ////is input2 valid?
                    //bool valid = false;
                    //while (valid == false)
                    //{
                    //    try
                    //    {
                    //        Console.Write("Please select your target: ");
                    //        int input2 = Convert.ToInt32(Console.ReadLine());
                    //        foreach (Character target in targetable)
                    //        {
                    //            if (target.GetKey() == input2)
                    //            {
                    //                //replace with return
                    //                this.weapon.Attack(this.name, target);
                    //                valid = true;
                    //                break;

                    //            }

                    //        }
                    //        if (valid == false)
                    //        {
                    //            Console.WriteLine("enter in the right number, its not hard, really, my 6 year old nephew can do it");
                    //        }
                    //    }
                    //    catch
                    //    {
                    //        Console.WriteLine("Enter in a number, moron");                            
                    //    }

                    //}
                    this.weapon.Attack(this.name,ChooseTarget(targetable));
                }
                else
                {
                    
                    foreach (Character i in targetable)
                    {
                        if (i is Monster)
                        {
                            this.weapon.Attack(this.name, i);
                        }
                    }
                    
                }




                a = false;
            }
            else if (input=="instadeath")
            {

                this.LoseHp(this.GetHp());
                
            }
            else
            {
                Console.WriteLine("Its not hard to just type in a number, is it?");

            }
        }

    }
    public Character ChooseTarget(List<Character> targetable)
    {
        Character target = null;
        //gives each monster a key and outputs their name
        Console.WriteLine("Here are your targets");
        int x = 1;
        foreach (Character i in targetable)
        {
            if (i is Monster)
            {
                i.SetKey(x);
                Console.WriteLine("> " + i.GetKey() + ")" + i.name + " Hp: " + i.hp);
                x = x + 1;
            }
        }
        //asks you who you wanna pick and checks which monster has the key that you inputted
        //is input2 valid?
        bool valid = false;
        while (valid == false)
        {
            try
            {
                Console.Write("Please select your target: ");
                int input2 = Convert.ToInt32(Console.ReadLine());
                foreach (Character i in targetable)
                {
                    if (i.GetKey() == input2)
                    {
                        //replace with return
                        target = i;
                        valid = true;
              
                        break;

                    }

                }
                if (valid == false)
                {
                    Console.WriteLine("enter in the right number, its not hard, really, my 6 year old nephew can do it");
                }
            }
            catch
            {
                Console.WriteLine("Enter in a number, moron");
            }
           
        }
        return (target);


    }
    public override int TakeDamage(int amount)//may add calculation with defense amount/armour defense or somett
    {
        Console.WriteLine("OUCH!");
        LoseHp(amount);
        return (amount);
    }
}