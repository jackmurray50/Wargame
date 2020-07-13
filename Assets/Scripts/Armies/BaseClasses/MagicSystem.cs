using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Books;

namespace UnitSystems.MagicSystems{

    //Holds information about a units magical capabilities. 
    //Each unit will have spell slots and a spell list
    public class MagicSystem : UnitSystem
    {

        MagicSystemLibrary.SpellBook spellBook;
        List<SpellSlot> spellslots = new List<SpellSlot>();

        public MagicSystem(string _name, MagicSystemLibrary.SpellBook _spellbook, params SpellSlot[] _spellSlots) : base(_name){
            spellBook = _spellbook;
            for(int i = 0; i < _spellSlots.Length; i++){   
                spellslots.Add(_spellSlots[i]);
            }
        }

        private string SpellBookToString(){
            string output = "";
            foreach(Spell entry in spellBook.getSpells()){
                output += entry.ToString();
                output += ", ";
            }
            return output;
        }

        private string SpellSlotsToString(){
            string output = "";
            foreach (SpellSlot entry in spellslots){
                output += entry.ToString();
                output += ", ";
            }
            return output;
        }

        public override string ToString(){
            return $"MagicSystem {this.getName()}, Spell slots = {this.SpellSlotsToString()}, Spellbook = {this.SpellBookToString()}";
        }
    }

    public class Spell : Book{
        string description;
        int minLevel;
        public string getDescription(){
            return description;
        }
        public int getMinLevel(){
            return minLevel;
        }
        public Spell(string _name, string _description, int _minLevel) : base(_name){
            description = _description;
            minLevel = _minLevel;

        }

        public override string ToString(){
            return $"{this.getName()}, lvl {this.minLevel}, {description}";
        }
    }

    public class SpellSlot {
        int level;
        int amount;

        public SpellSlot(int _amount, int _level){
            level = _level;
            amount = _amount;
        }

        public override string ToString(){
            return $"{amount} slots of lvl {level}";
        }

    }
}