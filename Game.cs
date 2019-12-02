using System;
using System.Collections.Generic;
//when using polymorphism, do you need to have the function be in the parent class, then overridden?
static class Game
{
    static List<Character> players= new List<Character>();
    public static void Start()
    {
        //this code will be managed in encounter class
        players.Add(new Player("adil"));
        players.Add(new Player("jarvis"));
        //players[1].hp = 100;
        Encounter.Battle(players, new List<Character>() { new RagingRoach() });
        
    }
}