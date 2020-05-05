using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Books;
using Books.Traits;
namespace UnitSystems.MovementSystems{
    public class MovementSystemLibrary : Library<MovementSystem>{

        private MovementTraitLibrary mtl = new MovementTraitLibrary();
        public override void load(){
            loadMovementSystems();
        }

        protected virtual void loadMovementSystems(){
            items.Add(new MovementSystem("Infantry", 6));
            items.Add(new MovementSystem("Flight", 25, 5, MovementSystem.Terrain.SKY));
            items.Add(new MovementSystem("Tank", 10, 1,  MovementSystem.Terrain.LAND, mtl.getItem("Tracked")));
            items.Add(new MovementSystem("Light Transport", 18));
        }
    }
    public class MovementTraitLibrary : Library<MovementTrait>{
        List<string> restrictionVehicle;
        List<string> restrictionInfantry;
        List<string> restrictionInclusive;
        public override void load(){
            
            loadBase();
            loadMovementTraits();
        }

        public void loadBase(){
            this.loadMovementTraits();
        }

        protected virtual void loadMovementTraits(){
            items.Add(new MovementTrait("Hover", "May ignore difficult terrain, and stay out of reach of melee",
                new List<string>(){"Fly"}));
            items.Add(new MovementTrait("Tracked", "May ignore many sources of difficult terrain",
                new List<string>(){"Vehicle"}));
        }
    }
}