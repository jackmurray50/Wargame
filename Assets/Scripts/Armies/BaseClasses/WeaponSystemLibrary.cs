using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Books.Traits;
//A library of base weapon systemst
using Books;

namespace UnitSystems.WeaponSystems{
    public class WeaponSystemLibrary : Library<WeaponSystem>
    {

        WeaponTraitLibrary traitLibrary = new WeaponTraitLibrary();

        public override void load(){
            loadWeaponSystems();
        }

        protected virtual void loadWeaponSystems(){
        }
        
    }


    public class WeaponTraitLibrary : Library<WeaponTrait>
    {

        //Creates the traits and loads them into weaponTraits. They'll be sorted in this way:
        //First all-inclusive, then melee, then ranged. Then divided into each armies, in that order
        private void loadWeaponTraits(){
#region inclusiveTraits

#endregion inclusiveTraits

#region meleeTraits



#endregion meleeTraits

#region rangedTraits

#endregion rangedTraits
        }

        //Checks if the traits have been loaded. IF they haven't, create all traits.
        public override void load(){
            if(!hasLoaded){
                loadWeaponTraits();
            }
        }
    }
}