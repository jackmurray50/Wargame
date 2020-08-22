using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Books.Traits;
using Books;


//MiscSystem represents any systems that doesnt fit into one of the other categories, ex: Radios
namespace UnitSystems.MiscSystems{
    public class MiscSystem : UnitSystem{
        string description {get;}

        public MiscSystem(string _name, string _desc) : base(_name){
            base.SetType("Misc");
            description = _desc;
        }




    }
}