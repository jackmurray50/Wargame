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
        
        return systems.Count;
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
        /// <summary>
        /// The amount of systems that can be in a socket
        /// </summary>
        /// Ex: if a socket is for WeaponSystems and the unit is a dual-wielder, they'll have a size of two.
        int size;
        public SocketBlock(string _name, int _size, params Socket.SocketType[] _tags) : base(_name){
            size = _size;
            tags = new List<Socket.SocketType>();
            foreach(Socket.SocketType x in _tags){
                tags.Add(x);
            }
        }

        /// <summary>
        /// Add a tag to the socketblock
        /// </summary>
        public void AddTags(params Socket.SocketType[] _tags){
            for(int i = 0; i < _tags.Length; i++){
                tags.Add(_tags[i]);
            }
        }

        /// <summary>
        /// Get a list of tags associated with the socketblock
        /// </summary>
        public List<Socket.SocketType> tags {get;}

        public bool HasTag(Socket.SocketType _tag){
            if(tags.Contains(_tag)){
                return true;
            }
            return false;
        }

        public Socket GetSocket(){
            Socket output = new Socket(getName(), size, tags);
            return output;
        }
    }
}