﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Books.Traits;

namespace Books.WeaponSystems{
    public abstract class WeaponSystem : Book
    {
        protected string systemType = "Any";
        protected int baseCost;
        protected Damage damage;
        
        public List<WeaponTrait> traits = new List<WeaponTrait>();
        protected WeaponSystem(string n, int c, Damage d, params WeaponTrait[] _traits) : base(n){
            baseCost = c;
            damage = d;
            for(int i = 0; i < _traits.Length; i++){
                traits.Add(_traits[0]);
            }
        }
        public class Damage{
            public enum DamageType{
                ENERGETIC = 0, //Damage dealt through energy. Fire, lightning, etc... are types of this.
                KINETIC, //Damage dealt by hitting someone with something
                PSYCHIC, //Damage dealt to the soul or psyche through magic or tech
                POTENT //Unavoidable damage
            }
            public enum DamageArea{
                SINGLE = 0, //Single target
                CONE,
                SPHERE
            }
            public int deviation;
            public int aoe; //Area of effect
            public int min;
            public int max;
            public DamageType dt;
            public DamageArea da;
            public int armourPenetration;
            //Single target damage
            public Damage(int _min, int _max, DamageType _dt, int _ap) : this(_min, _max, _dt, _ap, DamageArea.SINGLE, 0){
            }
            public Damage(int _min, int _max, DamageType _dt, int _ap, DamageArea _da, int deviation){
                this.min = _min;
                this.max = _max;
                this.dt = _dt;
                this.armourPenetration = _ap;
                this.da = _da;
                this.deviation = deviation;

            }
        }

    }

    public abstract class WeaponSystemHandheld : WeaponSystem
    {
     protected int weight;
        public WeaponSystemHandheld(string _name, int _cost, Damage _damage, int _weight, params WeaponTrait[] _traits) : base(_name, _cost, _damage, _traits){
            this.weight = _weight;
        }
    }
    //The base class for all melee weapons. Range is implied to be 0.
    public class WeaponSystemMelee : WeaponSystemHandheld
    {
        public WeaponSystemMelee(string _name, int _cost, Damage _damage, int _weight, params WeaponTrait[] _traits) : base(_name, _cost, _damage,  _weight, _traits){
            base.systemType = "Melee";
        }
    }
    public class WeaponSystemRanged : WeaponSystemHandheld
    {

        protected int optimalRange;
        protected int maxRange;
        public WeaponSystemRanged(string _name, int _cost, Damage _damage, int _weight, int _optimalRange, int _maxRange, params WeaponTrait[] _traits) : base(_name, _cost, _damage, _weight, _traits ){
            base.systemType = "Ranged";

    }

}

}