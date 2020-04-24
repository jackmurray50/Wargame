//ArmyList is effectively a list of Squads
//Has a name
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Books;
using Books.Units;
using Books.WeaponSystems;
using Books.ArmourSystems;
using Books.MagicSystems;
using Books.StatsSystems;
using Books.MovementSystems;


namespace Armies{
public class ArmyList{

    private int position = 0;
    private List<Faction> factions = new List<Faction>();

    private int maxCost;
    private string name;
    private List<BuiltSquad> squads = new List<BuiltSquad>();
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

    //TODO: Sort squads by squad type


    //Squads currently in the army

    public string GetName(){
        return name;
    }
    public int GetCost(){
        //TODO: Make this calculate the cost
        return 2000;
    }

    //Should sort squads by squad type


    public void UpdateSquad(int index, BuiltSquad newSquad){
        squads[index] = newSquad;

    }

    public void AddSquad(BuiltSquad newSquad){
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
    List<Unit> units = new List<Unit>();
    //Include a GetCost button

    //Make the 2D array accessible

    Squad.SquadType classification;
    string name; //A custom name the player can set, ex: 181st Infantry
    string squadName; //The name of the squad (Ex: Scav, Frontiersmen, etc...)
    public BuiltSquad(Squad _squad){
        classification = _squad.GetClassification();
    }

    public void SetName(string n){
        name = n;
    }
    public string GetName(){
        return name;
    }

    public Squad.SquadType GetClassification(){
        return this.classification;
    }

    public int GetCost(){
        int cost = 0;
        for(int i = 0; i < units.Count; i++){
            cost += units[i].GetCost();
        }
        return cost;
    }
    
}


//A class that handles a units stats and equipment. UnitBlock holds the possible equipment and systems, this one holds the active ones.
public class Unit{
    
    int amount;
    string name;

    int cost;

    UnitBlock unitBlock;

    //The systems that the Unit has. It can have multiple of some of them, though statssystems and magicsystems will be rare
    List<ArmourSystem> armourSystems = new List<ArmourSystem>();
    List<MagicSystem> magicSystems = new List<MagicSystem>();
    List<MovementSystem> movementSystems = new List<MovementSystem>();
    List<StatsSystem> statsSystems = new List<StatsSystem>();
    List<WeaponSystem> weaponSystems = new List<WeaponSystem>();

    //Don't need default weapons or armour systems. The first magic, movement and stats systems will be considered the default

    public Unit(UnitBlock _unitBlock){
        unitBlock = _unitBlock;
    }
    public int GetCost(){
        int cost = unitBlock.getCost();



        return cost * amount;
    }


    


}
}