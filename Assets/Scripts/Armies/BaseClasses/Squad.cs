using Books.Units;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Books.Units{

    //A squad is a grouping of soldiers. Ex: The Scav squad may have scavs, scav sergeants, scav mages, and so on. It holds
    //The amount of each unit allowed, and the total point cost for the unit. It also changes the cost of units, if necessary
    public class Squad : Book{
        List<Unit> units = new List<Unit>();

        public SquadBlockTombstone tombstone {get;}
        public Squad(string _name, SquadBlockTombstone _tombstone) : base(_name){
            tombstone = _tombstone;
        }

        public int GetCost(){
            int output = 0;
            for(int i = 0; i < units.Count; i++){
                output += units[i].GetCost();
            }
            return output;
        }

        public void AddUnit(Unit _input){
            units.Add(_input);
        }

        public void RemoveUnit(string _name){
            for(int i = 0; i < units.Count; i++){
                if(units[i].getName() == _name){
                    units.RemoveAt(i);
                }
            }
        }

        public Unit GetUnit(string _name){
            for(int i = 0; i < units.Count; i++){
                if(units[i].getName() == _name){
                    return units[i];
                }
            }
            Debug.Log("<color=red>ERROR: Unit not found </color> Target: \'" + _name + "\'");
            return null;
        }

    }
    
    //SquadBlockTombstone is used to hold the 'tombstone' information for a squad, like the name and type. This is important to keep track of which squad
    //belongs to which squadblock, and to keep the squadblock and squads separate
    public class SquadBlockTombstone{
        string name;
        public SquadBlock.SquadType type {get;}
        public SquadBlockTombstone(string _name, SquadBlock.SquadType _type){
            name = _name;
            type = _type;
        }
    }

    //SquadOptions hold a function which will alter a Unit based on a Unitblock and pass out a boolean (True if it passed). They also hold a name for the function
    //and a description, which will be shown to the player.
    public class SquadOption{
        string name {get;}
        
        public delegate void Option(Squad _s, SquadBlock _b);
        public Option implement {get;}
        public Option deimplement {get;}
        string desc {get;}

        bool isActive {get; }
        public SquadOption(string _name, string _desc, Option _implement, Option _deimplement){
            name = _name;
            desc = _desc;
            implement = _implement;
            deimplement = _deimplement;
            isActive = false;
        }
    }

    //SquadBlock holds the possible units, and is used to create a default unit.
    public class SquadBlock : Books.Book
    {
        List<UnitBlock> units = new List<UnitBlock>();
        List<SquadOption> options = new List<SquadOption>();
        public SquadBlock(string _name, SquadType _type) : base(_name){
            type = _type;
        }
        public SquadBlockTombstone GetTombstone(){
            return new SquadBlockTombstone(this.getName(), this.type);
        }

        public void AddUnits(params UnitBlock[] _units){
            for(int i = 0; i < _units.Length; i++){
                units.Add(_units[i]);
            }
        } 

        public UnitBlock GetUnitBlock(string _name){
            for(int i = 0; i < units.Count; i++){
                if(units[i].getName() == _name){
                    return units[i];
                }
            }
            return null;
        }

        public void AddSquadOptions(params SquadOption[] _options){
            for(int i = 0; i < _options.Length; i++){
                options.Add(_options[i]);
            }
        }
        public enum SquadType{
            ARTILLERY,
            ASSAULT,
            COLOSSUS,
            COMMAND,
            ELITE,
            FORTIFICATION,
            GRUNT,
            SUPERHEAVY
        }
        //Creates a squad with the default parameters

        SquadType type;
        public Squad CreateDefaultSquad(){
            Debug.Log("Creating Default \'" + this.getName() + "\' Squad");
            Squad output = new Squad(this.getName(), this.GetTombstone());
            for(int i = 0; i < units.Count; i++){
                Debug.Log(units[i].getName());
                if(units[i].IsDefault){
                    output.AddUnit(units[i].CreateDefaultUnit());
                }
            }

            return output;
        }

    }
}