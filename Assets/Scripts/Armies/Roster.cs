//A Roster is a list of squads and their respective settings. 
//When a game is found, the Roster will be pushed to the server. The army will then be assembled, using this Roster to gather information.

using System.Collections;
using System.Collections.Generic;
using Books;
using UnityEngine;
using Books.Units;

namespace Armies{
public class Roster{

    private int position = 0;
    private List<Faction> factions = new List<Faction>();
    private List<Squad> squads = new List<Squad>();

    private int maxCost;
    private string name;
    public int GetPosition(){
        return position;
    }
    //Useful for swapping positions
    public void SetPosition(int _position){
        position = _position;
    }
     public enum Faction{
        NONE,
        UNITEDINNERPLANETS,
        FRONTIERWORLDS,
        CENTAUR,
        MEDUSAE
    }

    public void AddSquad(Squad _squad, string _name){
        _squad.displayName = _name;
        squads.Add(_squad);
    }

    public Squad GetSquad(string _key){
        return squads.Find(e => e.displayName == _key);
    }

    public Faction GetFaction(int i){
        return factions[i];
    }
    //Remember, first faction is always the primary
    public Roster(string _name, int _position, params Faction[] _factions){
        this.name = _name;
        this.position = _position;
        for(int i = 0; i < _factions.Length; i++){
            factions.Add(_factions[i]);
        }
    }

    public string GetName(){
        return name;
    }
    public int GetCost(){
        int output = 0;
        for(int i = 0; i < squads.Count; i++){
            output += squads[i].GetCost();
        }
        return output;
    }

    public int GetUnitCount(Squad.SquadType _type){
        int amount = 0;
        foreach(Squad x in squads){
            if(x.squadType == _type)
                amount++;
        }
        return amount;
    }

    
}

}