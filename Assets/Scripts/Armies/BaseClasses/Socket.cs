using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Books;

namespace UnitSystems.Sockets{
public class Socket : Books.Book{

    public enum SocketType{
        SCALING = 0, //Items that scale with the amount of units
        MAIN
    }

    public List<UnitSystem> systems {get;}
    public List<SocketType> tags {get;}

    public int size {get; set;}

    //Clear the List of systems, and return the amount of systems deleted
    public int Clear(){
        int output = systems.Count;
        systems.RemoveRange(0, systems.Count -1);
        return output;
    }

    public void Add(params UnitSystem[] _systems){
        for(int i = 0; i < _systems.Length; i++){
            systems.Add(_systems[i]);
        }
    }

    //Returns the sum of the amount from each system
    public int GetSystemCount(){
        int output = 0;

        foreach (var item in systems){
            output += item.amount;
        }
        return output;
    }


    public Socket(string _name) : this(_name, 1, new List<SocketType>()){

    }

    //Constructor that gives the Socket a name, a maximum size, and a set of tags.
    public Socket(string _name,  int _size, List<SocketType> _tags) : base (_name){
        systems = new List<UnitSystem>();
        tags = new List<SocketType>();
        for(int i = 0; i < _tags.Count; i++){
            tags.Add(_tags[i]);
        }
        size = _size;
    }


}
    public class SocketBlock : Book{
        int size;
        public SocketBlock(string _name, int _size, params Socket.SocketType[] _tags) : base(_name){
            size = _size;
            tags = new List<Socket.SocketType>();
            foreach(Socket.SocketType x in _tags){
                tags.Add(x);
            }
        }

        public void AddTags(params Socket.SocketType[] _tags){
            for(int i = 0; i < _tags.Length; i++){
                tags.Add(_tags[i]);
            }
        }

        List<Socket.SocketType> tags {get; set;}

        public Socket GetSocket(){
            Socket output = new Socket(getName(), size, tags);
            return output;
        }
    }
}