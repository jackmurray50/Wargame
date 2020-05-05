using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Books;
using Books.Traits;
using UnitSystems.MagicSystems;

namespace UnitSystems.MagicSystems{
    public class MagicSystemLibrary : Library<MagicSystem>{

        protected List<SpellBook> spellBooks = new List<SpellBook>();
        protected List<Spell> spells = new List<Spell>();

        public Spell getSpell(string _name){
            for(int i = 0; i < spells.Count; i++){
                if(spells[i].getName() == _name){
                    return spells[i];
                }
            }
            return null;
        }

        protected SpellBook getSpellBook(string _name){
            for (int i = 0; i < spellBooks.Count; i++){
                if(spellBooks[i].getName() == _name){
                    return spellBooks[i];
                }
            }
            return null;
        }
        public override void load(){
            loadSpells();
            loadSpellBooks();
            loadMagicSystems();
        }



        protected virtual void loadMagicSystems(){
            //Most units will be Mundane, so no magic
            items.Add(new MagicSystem("Mundane", null));
            
        }

                //Spellbooks are a simple way of compiling lists of spells, so it's not necessary to constantly make lists for
        //two magic systems with identical allowable spells
        protected virtual void loadSpellBooks(){
            spellBooks.Add(new SpellBook("Artillerist", getSpell("Fling Fire"), getSpell("Scry"), getSpell("Imbue Spirit")));
            spellBooks.Add(new SpellBook("Mage", getSpell("Mind Spike"), getSpell("Explosion"), getSpell("Conjure Weapon")));
            
        }

        protected virtual void loadSpells(){
            //L1 spells -- Infinite use, basically just new weaponsystem
            spells.Add(new Spell("Mind Spike", "Makes an attack against an enemy's determination", 1));
            spells.Add(new Spell("Fling Fire", "Makes an attack against an opponent for 1 damage", 1));
            //L2 spells -- 
            spells.Add(new Spell("Conjure Weapon", "Conjures an advanced melee weapon", 2));
            spells.Add(new Spell("Scry", "Allows for indirect fire in an area", 2));

            //L3 spells
            spells.Add(new Spell("Imbue Spirit", "Allows you to take control over an enemy vehicle, or amplify your own", 3));
            spells.Add(new Spell("Explosion", "Creates a massive detonation that harms a whole squad",3));
            
            //L4 spells
            spells.Add(new Spell("Fire Bolt", "Send a targeted bolt at a single creature, dealing 1d6 energetic damage", 4));
            spells.Add(new Spell("Berserk", "Cause an enemy unit to start infighting, dealing melee attacks against itself and being stunned for a turn", 4));


            //L5 spells -- At most one per battle, meant to be devastatic attacks
            spells.Add(new Spell("Raise Fortress", "Creates a fortress of your choosing at the location you choose", 5));
            spells.Add(new Spell("Cataclysm", "Creates a huge blast around a target", 5));
            spells.Add(new Spell("Mass Raise Dead", "Resurrect a squadron that has been deceased", 5));
            
        }

        
        protected class SpellBook{
            string name;
            private List<Spell> spellbook = new List<Spell>();
            public List<Spell> getSpells(){
                return spellbook;
            }
            public string getName(){
                return name;
            }
            public SpellBook(string _name, params Spell[] _spellbook){
                name = _name;
                for(int i = 0; i < _spellbook.Length; i++){
                    spellbook.Add(_spellbook[i]);
                }

            }
        }

    }
}