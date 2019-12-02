using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
static class Encounter
{
    public static void Battle(List<Character> players, List<Character> options)
    {
        
        List<Character> monsters = MonsterMaker(options);
        List<Character> combatants = players.Concat(monsters).ToList();
        if (monsters.Count > 1)
        {
            Output.Ln("OH NO! " + monsters[0].GetName() + " And Cohorts Attack!");
        }
        else
        {
            Output.Ln("OH NO! " + monsters[0].GetName() + " Strikes!");
        }


        
        bool battleEnd = false;
        while (battleEnd==false)
        {
            foreach (Character combatant in combatants)
            {
                //Console.ReadKey();
                if (battleEnd==true)
                {
                    break;
                }
                if (combatant.GetHasFallen() == false)
                {
                    Console.WriteLine(Constants.divider);
                    List<Character> active = new List<Character>();
                    foreach(Character i in combatants)
                    {
                        if (i.GetHasFallen() == false)
                        {
                            active.Add(i);
                        }
                    }
                    combatant.Turn(active);//player takes in both
                }
                
                
                
                foreach(Character fighter in combatants)
                {
                    if (fighter.GetHp()<=0&& fighter.GetHasFallen()==false)
                    {
                        Output.Ln(fighter.GetName()+" has Fallen...",60,5);
                        fighter.Fall();
                        int activePlayers = 0;
                        int activeMonsters = 0;
                        //checks if this monster who has died is the last one
                        foreach (Character i in combatants)
                        {
                            if (i is Player && i.GetHasFallen()==false) 
                            {
                                activePlayers = activePlayers + 1;
                            }
                            if (i is Monster && i.GetHasFallen() == false)
                            {
                                activeMonsters = activeMonsters + 1;
                            }
                        }
                        if (activePlayers == 0)
                        {
                            battleEnd= true;
                            break;
                            //GameOver();
                        }
                        if (activeMonsters==0)
                        {
                            battleEnd = true;
                            break;
                            //Victory();
                        }
                        break;
                    }
                }
                

            }
        }
    }
    public static List<Character> MonsterMaker(List<Character> options)
    {
        //temp, will expand upon, put in algorithim that creates random monster from base objects and adds letters to their names using ascii eg ragingroach A, raging roach B
        //Monster ragingRoach = new RagingRoach();
        List<Character> monsters = new List<Character>();
        Random RNG = new Random();
        for (int i=1;i<=RNG.Next(2,4);i++)
        {
            monsters.Add((Monster)Activator.CreateInstance(options[RNG.Next(options.Count)].GetType()));
        }
        int x = 0;
        List<String> letters = new List<String> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K" };
        foreach (Character i in monsters)
        {
            i.SetName(i.GetName() + " ["+letters[x]+"]");
            x += 1;
        }

        return (monsters);
    }
}