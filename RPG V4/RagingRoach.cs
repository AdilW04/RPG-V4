using System;
using System.Collections.Generic;
class RagingRoach : Monster
{
    public RagingRoach()
    :base("Raging Roach",20,6,4)
    {

    }
    public override void Turn(List<Character> targetable)
    {
        Output.Ln(this.name + "'s HP: " + this.hp);
        Random RNG = new Random();
        while (true)
        {
            int index = RNG.Next(targetable.Count);
            if (targetable[index] is Player)
            {
                Output.Ln("its " + this.name + "'s turn now...");
                if (RNG.Next(100) <= 50)
                {
                    Attack(targetable[index]);
                }
                else
                {
                    Quiver();
                }
                break;
            }
        }

    }
    public void Quiver()
    {
        if (amountAttacked <1)
        {
            Output.Ln("Raging Roach Quivers Nervously...");
        }
        else
        {
            Output.Ln("Raging Roach apologises profusely for attacking you that one time ");
        }
        

    }


}