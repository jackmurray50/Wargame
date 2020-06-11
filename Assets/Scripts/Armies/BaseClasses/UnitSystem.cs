using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitSystems.Sockets;

namespace UnitSystems{
public class UnitSystem : Books.Book
{
    public UnitSystemBlock block {get; set;}

    public UnitSystem(string _name) : base(_name){
        
    }


    public int GetCost(){
        return block.GetCost();
    }

    public override string ToString(){
        return $"{this.getName()}";
    }

}

//UnitSystemBlocks will be assigned from unit to unit, and will be used to hold a Systems meta-data
public class UnitSystemBlock : Block{
    UnitSystem unitSystem;
    public string socket {get;}


    public UnitSystemBlock(string _name, UnitSystem _unitSystem, bool _isDefault, int _cost, string _socket) : base(_name, _cost, 1, 1, _isDefault){
        unitSystem = _unitSystem;
        socket = _socket;
    }

    public UnitSystem GetSystem(){
        UnitSystem output = unitSystem;
        unitSystem.block = this;
        return output;
    }

}
}