using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitSystems.Tag;

namespace UnitSystems{
public class UnitSystem : Books.Book
{
    UnitSystemBlock block;

    public UnitSystemTag tag {get; set;}
    
    public int amount {get; set;}

    public UnitSystem(string _name) : base(_name){
    }


    public int GetCost(){
        return block.GetCost();
    }

}

//UnitSystemBlocks will be assigned from unit to unit, and will be used to hold a Systems meta-data
public class UnitSystemBlock : Block{
    UnitSystem unitSystem;
    bool isSquadSystem {get;}
    public UnitSystemBlock(string _name, UnitSystem _unitSystem, UnitSystemTag _tag, bool _isDefault, int _cost, int _min, int _max) : base(_name, _cost, _min, _max){
        unitSystem = _unitSystem;
        isSquadSystem = false;
        unitSystem.tag = _tag;
    }
    //Constructor for when the system is a whole-squad system
    public UnitSystemBlock(string _name, UnitSystem _unitSystem, UnitSystemTag _tag, bool _isDefault, int _cost) : this(_name, _unitSystem, _tag, _isDefault, _cost, 0,0){
        unitSystem = _unitSystem;
        isSquadSystem = true;
        
    }

    public UnitSystem GetSystem(){
        return unitSystem;
    }
    public UnitSystemTag GetTag(){
        return unitSystem.tag;
    }

}
}