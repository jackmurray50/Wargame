using Books.Units;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Books.Units{

    //A squad is a grouping of soldiers. Ex: The Scav squad may have scavs, scav sergeants, scav mages, and so on. It holds
    //The amount of each unit allowed, and the total point cost for the unit. It also changes the cost of units, if necessary
    public class Squad : Book{
        List<Unit> units = new List<Unit>();

        SquadBlockTombstone tombstone = null;
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
    

    }
    
    //SquadBlockTombstone is used to hold the 'tombstone' information for a squad, like the name and type. This is important to keep track of which squad
    //belongs to which squadblock, and to keep the squadblock and squads separate
    public class SquadBlockTombstone{
        string name;
        SquadBlock.SquadType type;
        public SquadBlockTombstone(string _name, SquadBlock.SquadType _type){
            name = _name;
            type = _type;
        }
    }

    //SquadOptions hold a function which will alter a Unit based on a Unitblock and pass out a boolean (True if it passed). They also hold a name for the function
    //and a description, which will be shown to the player.
    public class SquadOption{
        string name {get;}
        Func<Unit, UnitBlock, bool> doOption {get;}
        Func<Unit, UnitBlock, bool> undoOption {get;}
        string desc {get;}
        public SquadOption(string _name, string _desc, Func<Unit, UnitBlock, bool> _doOption, Func<Unit, UnitBlock, bool> _undoOption){
            name = _name;
            desc = _desc;
            doOption = _doOption;
            undoOption = _undoOption;
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
            
            Squad output = new Squad(this.getName(), this.GetTombstone());
            for(int i = 0; i < units.Count; i++){
                if(units[i].IsDefault){
                    output.AddUnit(units[i].CreateDefaultUnit());
                }
            }

            return output;
        }

    }
}