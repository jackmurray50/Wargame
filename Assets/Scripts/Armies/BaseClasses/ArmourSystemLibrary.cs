using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Books;
using Books.Traits;
using UnitSystems.ArmourSystems;

namespace UnitSystems.ArmourSystems{
    public class ArmourSystemLibrary : Library<ArmourSystem>
    {
        protected ArmourTraitLibrary atl = new ArmourTraitLibrary();
        public override void load(){
            loadArmourSystems();

        }

        protected virtual void loadArmourSystems(){
   
        }



    }

    public class ArmourTraitLibrary : Library<ArmourTrait>{

        List<string> restrictionVehicle = new List<string>();
        List<string> restrictionInfantry = new List<string>();
        List<string> restrictionInclusive = new List<string>();
        public override void load(){
            
            loadRestrictions();
            //Ensure that global traits are included in all armies trait lists
            this.loadArmourTraits();
        }

        private void loadRestrictions(){
            restrictionVehicle.Add("Vehicle");
            restrictionInclusive.Add("Vehicle");
            restrictionInclusive.Add("Infantry");
            restrictionInfantry.Add("Infantry");
        }
        private void loadArmourTraits(){

    #region inclusiveArmourTraits
            items.Add(new ArmourTrait("Energetic Resistant", "Halves damage from Energetic sources",
                restrictionInclusive));
            items.Add(new ArmourTrait("Sloped Armour", "Increases front, side and rear armour at the cost of top armour", 
                restrictionVehicle));
            items.Add(new ArmourTrait("Power Armour", "Increases Strength", 
                restrictionInfantry));
            items.Add(new ArmourTrait("Ridden", "Provides no protection to the crew", restrictionVehicle));
            items.Add(new ArmourTrait("Open Topped", "Provides less protection to the crew", restrictionVehicle));
    #endregion exclusiveArmourTraits
        }


    }
}