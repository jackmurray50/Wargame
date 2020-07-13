using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitSystems.Sockets;

namespace UnitSystems{
public class UnitSystem : Books.Book
{

    public UnitSystem(string _name) : base(_name){
        
    }

    public override string ToString(){
        return $"{this.getName()}";
    }

}
}