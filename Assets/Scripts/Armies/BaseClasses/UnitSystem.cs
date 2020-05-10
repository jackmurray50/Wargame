using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitSystems.Sockets;

namespace UnitSystems{
public class UnitSystem : Books.Book
{
    UnitSystemBlock block;
    
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
    public string socket {get;}


    public UnitSystemBlock(string _name, UnitSystem _unitSystem, bool _isDefault, int _cost, string _socket, int _min, int _max ) : base(_name, _cost, _min, _max){
        unitSystem = _unitSystem;
        socket = _socket;
    }
    //Constructor for when the system is a whole-squad system
    public UnitSystemBlock(string _name, UnitSystem _unitSystem, bool _isDefault, int _cost, string _socket) : this(_name, _unitSystem, _isDefault, _cost, _socket, 0,0){
        unitSystem = _unitSystem;
        
    }

    public UnitSystem GetSystem(){
        return unitSystem;
    }

}
}