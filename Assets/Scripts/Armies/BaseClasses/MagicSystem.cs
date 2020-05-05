using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Books;

namespace UnitSystems.MagicSystems{

    //Holds information about a units magical capabilities. 
    //Each unit will have spell slots and a spell list
    public class MagicSystem : UnitSystem
    {

        List<Spell> spellBook = new List<Spell>();
        List<SpellSlot> spellslots = new List<SpellSlot>();

        public MagicSystem(string _name, List<Spell> _spellbook, params SpellSlot[] _spellSlots) : base(_name){
            spellBook = _spellbook;
            for(int i = 0; i < _spellSlots.Length; i++){   
                spellslots.Add(_spellSlots[i]);
            }
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
    }

    public class SpellSlot {
        int level;
        int amount;

        public SpellSlot(int _amount, int _level){
            level = _level;
            amount = _amount;
        }

    }
}