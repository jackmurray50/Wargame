using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Books;

namespace UnitSystems.Sockets{
public class Socket : Books.Book{

    public List<UnitSystem> systems {get;}
    //The systems 'tags', such as 'Scaling' which means that the amount of all the systems inside increase with the amount of units.

    //The amount of unique systems that a socket can hold
    public int size {get; set;}

    //Clear the List of systems, and return the amount of systems deleted
    public int Clear(){
        int output = systems.Count;
        systems.RemoveRange(0, systems.Count);
        Debug.Log(systems.Count);
        return output;
    }

    public void Add(params UnitSystem[] _systems){
        for(int i = 0; i < _systems.Length; i++){
            systems.Add(_systems[i]);
        }
    }

    //Returns the sum of the amount from each system
    public int GetSystemCount(){
        
        return systems.Count;
    }


    public Socket(string _name) : this(_name, 1){

    }

    //Constructor that gives the Socket a name, a maximum size, and a set of tags.
    public Socket(string _name,  int _size) : base (_name){
        systems = new List<UnitSystem>();
        size = _size;
    }


}
}