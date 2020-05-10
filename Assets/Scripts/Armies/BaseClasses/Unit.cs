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


        public UnitBlock block {get; set;}
        private Dictionary<string, Socket> sockets = new Dictionary<string, Socket>();

        public void ClearSocket(string _Socket){
            sockets[_Socket].Clear();
        }

        public void AddSocket(string _name, Socket _socket){
            sockets.Add(_name, _socket);
        }

        public int GetCost(){
            int output = 0;

            output += block.GetCost();
            return output;
        }

        public Unit(string _name) : base(_name){

        }
    }


    //UnitBlock represents the potential options for a particular unit
    public class UnitBlock : Block
    {
        
        private List<SocketBlock> sockets = new List<SocketBlock>();
        private List<UnitSystemBlock> systems = new List<UnitSystemBlock>();

        #region Creation
        public UnitBlock(string _name, bool _isDefault, int _cost, int _min, int _max) : base(_name, _cost, _min, _max){
            
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
            Unit output = new Unit(this.getName());
            //Make sure the unit knows what block its associated with
            output.block = this;
            //Create the units sockets
            foreach(SocketBlock entry in sockets){
                //Create a new socket
                Socket newSocket = entry.GetSocket();
                foreach (UnitSystemBlock s in systems){
                    //If a system is a Default System, add it to the appropriate socket
                    if(s.socket == entry.getName() && s.IsDefault){
                        newSocket.Add(s.GetSystem());
                    }
                }
                output.AddSocket(entry.getName(),newSocket);
            }


            return output;
        }
    }
   
}