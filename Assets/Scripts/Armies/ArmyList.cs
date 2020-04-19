//ArmyList is effectively a list of Squads
//Has a name
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Books;
using Books.Units;

public class ArmyList{

    private int position = 0;

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

    private List<Faction> factions = new List<Faction>();

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

    //TODO: Sort squads by squad type


    //Squads currently in the army

    private string name;
    public string GetName(){
        return name;
    }
    public int GetCost(){
        //TODO: Make this calculate the cost
        return 2000;
    }
    private int maxCost;

    //Should sort squads by squad type
    private List<Squad> squads = new List<Squad>();

    public void UpdateSquad(int index, Squad newSquad){
        squads[index] = newSquad;

    }

    public void AddSquad(Squad newSquad){
        squads.Add(newSquad);

    }
    //Will remove a squad
    public void RemoveSquad(){
        
    }

    //Returns the amount of units of a specific type in the army
    public int GetUnitCount(Squad.SquadType _type){
        int count = 0;
        switch (_type){
            case Squad.SquadType.ARTILLERY:
                for(int i = 0; i < squads.Count; i++){
                    if(squads[i].GetClassification() == Squad.SquadType.ARTILLERY){
                        count++;
                    }
                }
                break;
            case Squad.SquadType.ASSAULT:
            for(int i = 0; i < squads.Count; i++){
                    if(squads[i].GetClassification() == Squad.SquadType.ASSAULT){
                        count++;
                    }
                }
                break;
            case Squad.SquadType.COLOSSUS:
            for(int i = 0; i < squads.Count; i++){
                    if(squads[i].GetClassification() == Squad.SquadType.COLOSSUS){
                        count++;
                    }
                }
                break;
            case Squad.SquadType.COMMAND:
            for(int i = 0; i < squads.Count; i++){
                    if(squads[i].GetClassification() == Squad.SquadType.COMMAND){
                        count++;
                    }
                }
                break;
            case Squad.SquadType.ELITE:
            for(int i = 0; i < squads.Count; i++){
                    if(squads[i].GetClassification() == Squad.SquadType.ELITE){
                        count++;
                    }
                }
                break;
            case Squad.SquadType.FORTIFICATION:
            for(int i = 0; i < squads.Count; i++){
                    if(squads[i].GetClassification() == Squad.SquadType.FORTIFICATION){
                        count++;
                    }
                }
                break;
            case Squad.SquadType.GRUNT:
            for(int i = 0; i < squads.Count; i++){
                    if(squads[i].GetClassification() == Squad.SquadType.GRUNT){
                        count++;
                    }
                }
                break;
            case Squad.SquadType.SUPERHEAVY:
            for(int i = 0; i < squads.Count; i++){
                    if(squads[i].GetClassification() == Squad.SquadType.SUPERHEAVY){
                        count++;
                    }
                }
                break;
            

        }
        return count;
    }

    //returns the amount of units in the army
    public int GetUnitCount(){
        return squads.Count;
    }


    //TODO: Make a class that takes in all the data of a Squad, once it's been built (Cost, amount of units, purchased items, etc....)

}

public class BuiltSquad{
    //MAke a 2D array. List of unit blocks, and amount of each unit block.

    //Include a GetCost button

    //Make the 2D array accessible
    
}