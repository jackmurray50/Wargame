using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Books;

namespace UnitSystems.Tag{
public class UnitSystemTag : Books.Book{

    //The tag name
    public string tag{get;}

    //The list of types this tag has.
    List<TagType> tagtypes = new List<TagType>();
    
    public enum TagType{
        EXCLUSIVE, //The squad or unit can only have one of these
        REPLACE, //The squad or unit must lose an amount of base Books, to make room for this one.
            //Ex: If there's a squad of scavs, and someone UPGRADES one to a heavy weapons specialist, they need to lose 1 Scav

    }

    public UnitSystemTag(string _name, params TagType[] _types) : base (_name){
         
    }
}
}