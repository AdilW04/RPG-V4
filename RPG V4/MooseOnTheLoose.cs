using System;
using System.Collections.Generic;
class MooseOnTheLoose:Monster
{
    int mooseCount;
    bool mooseChargeActive;
    Character mooseChargeFocus;
    public MooseOnTheLoose()
    :base ("Moose On The Loose",25,20,6)
    {

        this.mooseCount = 0;
        this.mooseChargeActive = false;
        this.mooseChargeFocus = null;
    }
    public override void Turn(List<Character> targetable)//should recieve list of all combatants from encounter class
    {
        Output.Ln(this.name + "'s HP: " + this.hp);
        Random RNG = new Random();
        while (true)
        {

            int index = RNG.Next(targetable.Count);
            

            if (targetable[index] is Player)
            {
                Output.Ln("its " + this.name + "'s turn now...");
                if (RNG.Next(100) <= 50 || this.mooseChargeActive == true)
                {
                
                   
                    MooseCharge(targetable[index]);
                   

                    

                }
                else
                {
                    Attack(targetable[index]);
                }

                
                break;
            }
        }

    }
    public void MooseCharge(Character target)
    {
        Random RNG = new Random();
        if (this.mooseChargeActive == false)
        {
            this.mooseChargeFocus = target;
            Output.Ln("The Moose stares at " + this.mooseChargeFocus.GetName() + " dead in the eye");
            Output.Ln("Its getting ready to Charge");
            this.mooseCount = RNG.Next(1, 3);
            this.mooseChargeActive = true;
        }
        else
        {
            if (this.mooseChargeFocus.GetHasFallen() == false)
            {
                if (this.mooseCount == 0)
                {
                    Output.Ln("Moose Charges towards " + this.mooseChargeFocus.GetName()+" dealing "+this.atk*2+" damage!");
                    this.mooseChargeFocus.TakeDamage(this.atk * 2);
                    this.mooseChargeActive = false;
                }
                else
                {
                    Output.Ln("The moose is still getting ready for a dangerous charge towards "+this.mooseChargeFocus.GetName()+"!");
                    mooseCount = mooseCount - 1;
                }
            }
            else
            {
                Output.Ln("The moose is confused for his target has fallen!");
                this.mooseChargeActive = false;
                this.mooseChargeFocus = null;
                this.mooseCount = 0;
            }
        }
        
    }
}