//ArmyList is effectively a list of Squads
//Has a name
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Books;
using Books.Units;


namespace Armies{
public class ArmyList{

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



    public Faction GetFaction(int i){
        return factions[i];
    }
    //Remember, first faction is always the primary
    public ArmyList(string _name, int _position, params Faction[] _factions){
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

}

}