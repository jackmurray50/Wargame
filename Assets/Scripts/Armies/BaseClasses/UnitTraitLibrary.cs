using System.Collections;
using Books.Traits;
using Books.Units;
using System.Collections.Generic;
using UnityEngine;
using Books;


namespace Books.Units{

    public class UnitTraitLibrary : Library<UnitTrait>{
        List<string> restrictionVehicle = new List<string>(){"Vehicle"};
        List<string> restrictionInfantry = new List<string>(){"Infantry"};
        public override void load(){
            loadTraits();
        }

        //Function used so the child of a traitlibrary can load the base traits, which allows for global traits
        protected void loadBaseTraits(){
            this.load();
        }

        public void loadTraits(){
            //Any global traits go here
            items.Add(new UnitTrait("Crewed", "Has a necessary crew size", restrictionVehicle, 3));
        }
    }

}