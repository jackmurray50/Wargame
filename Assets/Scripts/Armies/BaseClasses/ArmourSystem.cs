using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Books.Traits;
using Books;

namespace UnitSystems.ArmourSystems{
    public abstract class ArmourSystem : UnitSystem
    {
        protected string armourType;

        private int mainArmour {get;}
        protected List<ArmourTrait> traits = new List<ArmourTrait>();
        protected int hp;

        public ArmourSystem(string _name, int _hp, int _mainArmour, params ArmourTrait[] _traits) : base(_name){
            mainArmour = _mainArmour;
            for(int i = 0; i < _traits.Length; i++){
                traits.Add(_traits[i]);
            }
        }

    }

    public class ArmourSystemInfantry : ArmourSystem{
        int dodgeBonus {get;}
        
        public ArmourSystemInfantry(string _name, int _hp, int _armour, int _dodgeBonus, params ArmourTrait[] _traits) : base(_name, _hp, _armour, _traits){
            base.armourType = "Infantry";
            this.dodgeBonus = _dodgeBonus;
        }
    }

    public class ArmourSystemAFV : ArmourSystem{
        int side {get;}
        int rear {get;}
        int top {get;}
        public ArmourSystemAFV(string _name, int _hp, int _front, int _side, int _rear, int _top, params ArmourTrait[] _traits) : base(_name, _hp, _front, _traits){
            base.armourType = "AFV";
            side = _side;
            rear = _rear;
            top = _top;
        }
    }
}