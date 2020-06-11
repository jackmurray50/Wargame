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
        public int amount {get; set;}

        public UnitBlock block {get; set;}
        //The systems that the Unit has.
        private Dictionary<string, Socket> sockets = new Dictionary<string, Socket>();

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

        public int GetCost(){
            int output = 0;
            foreach(KeyValuePair<string, Socket> entry in sockets){
                for(int i = 0; i < entry.Value.systems.Count; i++){
                    output += entry.Value.systems[i].GetCost();
                }
            }
            return output;
        }

        public Unit(string _name, UnitBlock _block) : base(_name){
            this.block = _block;
            amount = _block.min;
        }

        public override string ToString(){
            string output = "";
            output += $"Name: {this.getName()}\nAmount: {this.amount}\nSockets:\n";

            foreach(KeyValuePair<string, Socket> entry in sockets){
                output += "\t";
                output += entry.Key + " Socket\n";
                foreach(var x in entry.Value.systems){
                    output += "\t\t";
                    output += x.ToString();
                    output += "\n";
                }
            }
            return output;
        }
    }


    //UnitBlock represents the potential options for a particular unit
    public class UnitBlock : Block
    {
        
        private List<SocketBlock> sockets = new List<SocketBlock>();
        private List<UnitSystemBlock> systems = new List<UnitSystemBlock>();

        #region Creation
        public UnitBlock(string _name, bool _isDefault, int _min, int _max) : base(_name, _min, _max, 0, _isDefault){

        }

        //Creates a Unit based on the defaults provided.
        public void AddSocketBlock(params SocketBlock[] _block){
            foreach(SocketBlock x in _block){
                sockets.Add(x);
            }
        }

        public void AddSystems(params UnitSystemBlock[] _block){
            foreach(UnitSystemBlock x in _block){
                systems.Add(x);
            }
        }

    
        #endregion Creation

        #region GetSystem
        public UnitSystemBlock GetSystemBlock(string _name){
            for(int i = 0; i < systems.Count; i++){
                if(systems[i].getName() == _name){
                    return systems[i];
                }
             }
            Debug.Log("<color=red>ERROR:</color> UnitSystemBlock " + _name + " not found in UnitBlock " + getName());
            return null;
        }
        #endregion GetSystem
        
        public Unit CreateDefaultUnit(){
            //Initialize the unit
            Unit output = new Unit(this.getName(), this);
            //Make sure the unit knows what block its associated with
            output.block = this;
            //Create the units sockets
            foreach(SocketBlock entry in sockets){
                //Create a new socket
                Socket newSocket = entry.GetSocket();
                foreach (UnitSystemBlock s in systems){
                    //If a system is a Default System, add it to the appropriate socket
                        //Debug.Log($"system: {s.getName()} searching for Socket {s.socket}");
                        //Debug.Log($"Socket: {entry.getName()}");
                    if(s.socket == entry.getName() && s.IsDefault){
                        //Add the system types
                        UnitSystem newSystem = s.GetSystem();
                            //Room here for non-constructor system refinement
                        newSocket.Add(newSystem);
                    }
                }
                output.AddSocket(entry.getName(),newSocket);
            }
            //Set the amount of each unit the the proper amount
            Debug.Log("Creating new Unit: " + this.getName());
            output.amount = this.min;
            Debug.Log(this.min);

            Debug.Log(output.ToString());

            return output;
        }
    }
   
}