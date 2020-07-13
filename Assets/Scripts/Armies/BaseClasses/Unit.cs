using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitSystems;
using UnitSystems.ArmourSystems;
using UnitSystems.MagicSystems;
using UnitSystems.MovementSystems;
using UnitSystems.StatsSystems;
using UnitSystems.WeaponSystems;
using UnitSystems.Sockets;
namespace Books.Units{
//Unit represents a constructed unit
    public class Unit : Book
    {   
        //The systems that the Unit has.
        private Dictionary<string, Socket> sockets = new Dictionary<string, Socket>();

        public int amount {get; set;}

        public void ClearSocket(string _Socket){
            sockets[_Socket].Clear();
        }

        public void AddSystemToSocket(string _socket, params UnitSystem[] _systems){
            foreach(UnitSystem x in _systems){
                sockets[_socket].Add(_systems);
            }
        }

        public void AddSocket(string _name, Socket _socket){
            sockets.Add(_name, _socket);
        }

        public Unit(string _name) : base(_name){
            amount = 0;
        }

        public override string ToString(){
            string output = "";
            output += $"Name: {this.getName()}\n{sockets.Count}, Amount: {this.amount}, Sockets:\n";

            foreach(KeyValuePair<string, Socket> entry in sockets){
                output += "\t";
                output += entry.Key + $" Socket, {entry.Value.systems.Count}/{entry.Value.size}\n";
                foreach(var x in entry.Value.systems){
                    output += "\t\t";
                    output += x.ToString();
                    output += "\n";
                }
            }
            return output;
        }
    }
}