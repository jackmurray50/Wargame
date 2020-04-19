using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Books.Traits;
//A library of base weapon systemst

namespace Books.WeaponSystems{
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
        
#region traitRestrictions
        private static List<string> restrictionM = new List<string>();
        private static List<string> restrictionR = new List<string>();
        private static List<string> restrictionRM = new List<string>();

        private void loadRestrictions(){
            restrictionM.Add("Melee");

            restrictionR.Add("Ranged");

            restrictionRM.Add("Melee");
            restrictionRM.Add("Ranged");
        }
    #endregion traitRestrictions

        //Creates the traits and loads them into weaponTraits. They'll be sorted in this way:
        //First all-inclusive, then melee, then ranged. Then divided into each armies, in that order
        private void loadWeaponTraits(){
#region inclusiveTraits
            items.Add(new WeaponTrait("Armour Piercing",
                "Increases armour-penetration by 2",
                restrictionRM
            ));
            items.Add(new WeaponTrait("Self Damaging", "When this weapon is used, the unit must make a saving throw or take damage",
            restrictionRM));
            #endregion inclusiveTraits

#region meleeTraits
            items.Add(new WeaponTrait("Reach", 
                "While wielding a weapon with Reach, a unit may attack in melee so long as they're touching the base of an allied unit that is touching an enemies base",
                restrictionM
            ));


            #endregion meleeTraits

#region rangedTraits
            items.Add(new WeaponTrait("Precise",
                "A weapon with Precise can target individual units",
                restrictionR
            ));

            items.Add(new WeaponTrait("Arcing Fire",
                "A weapon with arcing fire can fire over cover, at a penalty",
                restrictionR
            ));
            items.Add(new WeaponTrait("Blast", "A weapon with blast deals damage to everyone within the blasts epicenter",
            restrictionR, 6));

            items.Add(new WeaponTrait("Rapid Fire",
                "Increases number of attacks",
                restrictionR
            ));
            items.Add(new WeaponTrait("CQC Firearm", "Able to be used in melee combat with no penalty", restrictionR
            ));
            items.Add(new WeaponTrait("Heavy", "A weapon with Heavy receives an accuracy penalty if the squad has moved", restrictionR));
#endregion rangedTraits
        }

        //Checks if the traits have been loaded. IF they haven't, create all traits.
        public override void load(){
            if(!hasLoaded){
                loadRestrictions();
                loadWeaponTraits();
            }
        }
    }
}