using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitSystems.Sockets;

namespace UnitSystems{
public class UnitSystem : Books.Book
{

    public UnitSystem(string _name) : base(_name){
        type = "Base";
    }

    public override string ToString(){
        return $"{this.getName()}";
    }

    public virtual string type {get; private set;}

    protected void SetType(string _type){
        type = _type;
    }

}
}