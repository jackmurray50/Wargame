using Books.Units;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Books.Units{

    //A squad is a grouping of soldiers. Ex: The Scav squad may have scavs, scav sergeants, scav mages, and so on. It holds
    //The amount of each unit allowed, and the total point cost for the unit. It also changes the cost of units, if necessary
    public class Squad : Book{

        //The list of units this squad can access
        public List<Unit> units {get;}

        //The list of options this squad has
        private List<SquadOption> options = new List<SquadOption>();
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
        public SquadType squadType {get;}

        public string displayName {get; set;}
        public Squad(string _name, SquadType _type) : base(_name){
            units = new List<Unit>();
            squadType = _type;
            displayName = _name;
        }

        public int GetCost(){
            int output = 0;
            for(int i = 0; i < options.Count; i++){
                output += options[i].GetTotalCost();
            }
            return output;
        }

        public void AddUnits(params Unit[] _input){
            for(int i = 0; i < _input.Length; i++){
                units.Add(_input[0]);
            }
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

        public void AddOption(SquadOption _option){
            options.Add(_option);
        }
        public SquadOption GetOption(string _name){
            for(int i = 0; i < options.Count; i++){
                if(_name == options[i].name){
                    return options[i];
                }
            }
            return null;
        }

        public override string ToString(){
            string output = $"{this.getName()}({this.displayName}), Total cost == {this.GetCost()} \n{options.Count} options: ";
            foreach (var entry in options){
                output += $"\n{entry.ToString()}";
            }
            output += "\n";
            foreach (var entry in units){
                output += $"\n{entry.ToString()}";
            }

            return output;
        }

    }

    //SquadOptions hold a function which will alter a Unit based on a Unitblock and pass out a boolean (True if it passed). They also hold a name for the function
    //and a description, which will be shown to the player.
    public class SquadOption{
        public string name {get;}
        
        //Represents the amount of states for the option. Ex:
        //One squad option could be binary, in which case optionLimit would be 1. That would be something like "Substitute Kevlar for Dyneema"
        //Another option could have up to 20 states, if it were the amount of units in the squad.
        public int optionLimit {get;}

        //Represents the current option state
        public int optionNum {get; set;}

        //Represents the various 'tags' an option can have, used for 
        public enum Tag{
            //An option that dictates the size of the squad
            SQUADSIZE
        }

        public List<Tag> tags {get;}

        public bool HasTag(Tag _key){
            return tags.Contains(_key);
        }


        public delegate void Option(Squad _s);

        public delegate int CostCalculator(SquadOption _s);
        public Option implement {get;}
        public Option deimplement {get;}
        private CostCalculator costCalculator;
        string desc {get;}

        //Represents if the option should be displayed
        public bool isActive {get; set;}

        //Return the base cost of the option. 
        public int baseCost {get;}
        public Squad squad {get; set;}

        public int GetTotalCost(){
            return costCalculator(this);
        }
        public SquadOption(string _name, string _desc, int _cost, int _optionLimit, Option _implement, Option _deimplement, CostCalculator _ccalc, params Tag[] _tags){
            name = _name;
            desc = _desc;
            implement = _implement;
            deimplement = _deimplement;
            isActive = false;
            baseCost = _cost;
            optionLimit = _optionLimit;
            optionNum = 0;
            costCalculator = _ccalc;
            tags = new List<Tag>();
            foreach(var entry in _tags){
                tags.Add(entry);
            }
        }




        public override string ToString(){
            string output = "";
            output += $"{name}, {desc}, ";
            if(optionLimit == 1){
                output += "Boolean option";
                if(optionNum == 0){
                    output += "(Off)";
                }else{
                    output += "(On)";
                }
            }else{
                output += $"Limit is {optionLimit} ({optionNum}/{optionLimit})";
            }
            output += $", Cost: {baseCost}/{this.GetTotalCost()}";
            return output;
        }


    }
}