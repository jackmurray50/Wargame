using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Books.Traits;

namespace UnitSystems.MovementSystems{
    public class MovementSystem : UnitSystem
    {

        protected int primarySpeed;
        //How many movement points (Amount shown in primaryspeed) it costs to turn 360 degrees
        protected float rotationCost;
        protected List<MovementTrait> traits = new List<MovementTrait>();
        public void addTrait(MovementTrait _trait){
            traits.Add(_trait);
        }
        public List<MovementTrait> getTraits(){
            return traits;
        }


        public enum Terrain{
            LAND,
            SKY,
            WATER,
            AMPHIBIOUS,
            ROADABLE,
            ALLTERRAIN
        }
        protected Terrain terrain;
        public MovementSystem(string _name, int _speed, params MovementTrait[] _traits) : this(_name, _speed, 0f, Terrain.LAND, _traits){

        }

        public MovementSystem(string _name, int _speed, float _rotationCost, Terrain _terrain, params MovementTrait[] _traits) : base(_name){
            this.primarySpeed = _speed;
            this.rotationCost = _rotationCost;
            this.terrain = _terrain;

            for(int i = 0; i < _traits.Length; i++){
                addTrait(_traits[i]);
            }
        }

    }
}