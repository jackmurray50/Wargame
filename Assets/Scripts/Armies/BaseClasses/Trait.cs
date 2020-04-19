using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Trait is a base class for any trait. It holds the name and description, and any restrictions (ex: A human cannot gain the 'Tracked' trait)
//Its children are various other traits like ArmourSystemTrait, MovementSystemTrait, and so on.

namespace Books.Traits{
    public class Trait : Book
    {
        public override string getName(){
            if(!hasAssocNumber)
                return name;
            else{
                return name + " " + number;
            }
        }
        private string description;
        public string getDescription(){
            return description;
        }

        private List<string> restrictions;
        public List<string> getRestrictions(){
            return restrictions;
        }

        private int number;
        public int getNumber(){
            return number;
        }
        private bool hasAssocNumber = false;

        //One constructor for if the trait has no number associated (Ex: Reach)
        public Trait(string n, string d, List<string> r) : this(n, d, r, 0){

        }
        //Constructor for if there's a number associated (Ex: Blast 6)
        public Trait(string n, string d, List<string> r, int _num) : base(n){
            description = d;
            restrictions = r;
            number = _num;
            hasAssocNumber = true;
        }

        public bool HasRestriction(string target){
            return restrictions.Contains(target);
        }

        //TODO: Add an icon field

    }
    public class WeaponTrait : Trait
    {
       public WeaponTrait(string _name, string _description, List<string> _restrictions) : this(_name, _description, _restrictions, 0){

       }
       public WeaponTrait(string _name, string _description, List<string> _restrictions, int _num) : base(_name, _description, _restrictions, _num){

        }
    }

    public class ArmourTrait : Trait{
        public ArmourTrait(string _name, string _description, List<string> _restrictions) : this(_name, _description, _restrictions, 0){

        }
        public ArmourTrait(string _name, string _description, List<string> _restrictions, int _num) : base(_name, _description, _restrictions, _num){

        }
    }
    public class MovementTrait : Trait{
        public MovementTrait(string _name, string _description, List<string> _restrictions) : this(_name, _description, _restrictions, 0){

        }
        public MovementTrait(string _name, string _description, List<string> _restrictions, int _num) : base(_name, _description, _restrictions, _num){

        }
    }

    public class UnitTrait : Trait{
        public UnitTrait(string _name, string _description, List<string> _restrictions) : this(_name, _description, _restrictions, 0){

        }
        public UnitTrait(string _name, string _description, List<string> _restrictions, int _num) : base(_name, _description, _restrictions, _num){
        }
    }
}