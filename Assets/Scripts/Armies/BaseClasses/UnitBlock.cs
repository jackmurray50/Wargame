using System.Collections;
using System.Collections.Generic;
using Books.WeaponSystems;
using Books.ArmourSystems;
using Books.MovementSystems;
using Books.StatsSystems;
using Books.MagicSystems;
using Books.Traits;
using Books;

//UnitBlock represents the basic unit, and holds all possible accessories and options that the player can
//purchase.
namespace Books.Units{
    public class UnitBlock : Book
    {

        public enum Weight {
            NONAPPLICABLE = 0, //Size for units that are immaterial or for whom size doesnt matter, EX: Cruise missiles
            TINY, //Size for units about the size of a cat 0 - 25 lbs
            SMALL, //Size for units about the size of a dog 26 - 100 lbs
            MEDIUM, //Size for units about the size of a human 101 - 600 lbs
            LARGE, //Size for units that are significantly larger than a human, ex: 9ft tall people, a horse or motorbike 601 - 2000 lbs
            HUGE, //Units about the size of a large vehicle, 2,001 - 10,000 lbs ex: Universal carrier, lightly armoured transports
            MASSIVE, //Units about the size of a tank, 10,001 - 60,000 lbs ex: Most tanks
            SUPERMASSVE, //Units significantly larger than most tanks, 60,001 - 300,000 lbs ex: Super-heavy tanks, or monstrous creatures the size of a blue whale
            COLOSSAL //Units that are the size of modern-day aircraft carriers, or even larger. 300,001+ lbs
        }

        protected int baseCost;
        protected Weight weight;

        #region systemHandling

        protected List<WeaponSystem> weaponSystems;
        protected List<ArmourSystem> armourSystems;
        protected List<MovementSystem> movementSystems;
        //The default magicSystem will be simply not having one
        protected List<MagicSystem> magicSystems;
        //statsSystem will handle things like the creatures strength and dexterity, with some traits being added or removed
        //if their not applicable. Ex: A car cannot have an intelligence score
        protected List<StatsSystem> statsSystems;


        public void addSystem(params ArmourSystem[] _system){

        }
        public void addSystem(params WeaponSystem[] _system){

        }
        public void addSystem(params MovementSystem[] _system){

        }
        public void addSystem(params StatsSystem[] _system){

        }
        public void addSystem(params MagicSystem[] _system){

        }

        public void addTrait(params UnitTrait[] _traits){

        }

        public bool removeSystem(string _name){
            return false;
        }

        #endregion systemHandling

        //The way defaults are handled is to have a list of strings, corresponding to systems. When GetDefaultSystems
        //is called, have it go through the lists of systems, returning the defaults
        List<string> defaults = new List<string>();

        public List<Book> GetDefaultSystems(){
            List<Book> output = new List<Book>();

            for(int i = 0; i < defaults.Count; i++){
                //Go through the various system Lists, looking for the system that corresponds to the default we're looking for
                bool found = false;
                for(int j = 0; j < weaponSystems.Count && !found; j++){
                    if(weaponSystems[j].getName() == defaults[i]){
                        output.Add(weaponSystems[j]);
                        found = true;
                    }
                }
                for(int j = 0; j < magicSystems.Count && !found; j++){
                    if(weaponSystems[j].getName() == defaults[i]){
                        output.Add(weaponSystems[j]);
                        found = true;
                    }
                }
                for(int j = 0; j < armourSystems.Count && !found; j++){
                    if(weaponSystems[j].getName() == defaults[i]){
                        output.Add(weaponSystems[j]);
                        found = true;
                    }
                }
                for(int j = 0; j < movementSystems.Count && !found; j++){
                    if(weaponSystems[j].getName() == defaults[i]){
                        output.Add(weaponSystems[j]);
                        found = true;
                    }
                }
                for(int j = 0; j < statsSystems.Count && !found; j++){
                    if(weaponSystems[j].getName() == defaults[i]){
                        output.Add(weaponSystems[j]);
                        found = true;
                    }
                }
                
                
            }
            return output;
            
        }

        public void SetDefaultSystems(params string[] _defaults){
            for(int i = 0; i < _defaults.Length; i++){
                defaults.Add(_defaults[i]);
            }

        }

        public int getCost(){
            return baseCost;
        }
        
        //Constructor
        public UnitBlock(string _name, int _cost, Weight _weight) : base(_name){
            this.baseCost = _cost;
            this.weight = _weight;
        }


    }
}