using Books.Units;
using System.Collections;
using System.Collections.Generic;

namespace Books.Units{

    //A squad is a grouping of soldiers. Ex: The Scav squad may have scavs, scav sergeants, scav mages, and so on. It holds
    //The amount of each unit allowed, and the total point cost for the unit. It also changes the cost of units, if necessary
    public class Squad : Book{
        //Need a list of allowed units
        List<squadComponent> units = new List<squadComponent>();
        public void addUnits(params squadComponent[] _units){
            for(int i = 0; i < _units.Length; i++){
                units.Add(_units[i]);
            }
        }
        public SquadType GetClassification(){
            return type;
        }
        public enum SquadType{
            COMMAND, //Command-type units.
            ELITE, //Expensive and rare units, mostly vehicles
            SUPERHEAVY, //The largest weapons usually seen on the battlefield
            GRUNT, //The most common types of unit
            ARTILLERY, //Artillery
            ASSAULT, //Fast units
            COLOSSUS, //Super-weapons like massive mechs or godzilla-tier units
            FORTIFICATION //Immovable units, meant to be placed before the battle
            

        }

        private SquadType type;
        int size;

        public Squad(string _name, SquadType _type, int _size) : base(_name){
            type = _type;
            size = _size;
        }
    }

    //SquadComponent holds the metadata for a unit, in relation to the squad
    public class squadComponent : Book{
        public UnitBlock unit;
        public int maxAmount;
        public int minAmount = 0;
        public int cost;

        //Most involved
        public squadComponent(string _name, UnitBlock _unit, int _maxAmount, int _minAmount, int _cost) : base(_name){
            unit = _unit;
            maxAmount = _maxAmount;
            minAmount = _minAmount;
            cost = _cost;
        }
        //Least involved; any number of units
        public squadComponent(string _name, UnitBlock _unit) : this(_name, _unit, int.MaxValue, 0, _unit.getCost()){

        }
    }

}