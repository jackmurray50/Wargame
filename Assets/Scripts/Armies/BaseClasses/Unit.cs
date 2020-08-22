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

        //All the GetStat methods will go through the units sockets and find systems that have
        //the right state. Then it'll add them together, and return the number.
        //TODO: Current issue is there's no way for the game to understand if there's no stat for a certain
        //unit
        public int GetHP(){
            int output = 0;
            foreach(var x in sockets){
                foreach(UnitSystem y in x.Value.systems){
                    if(y.type == "ArmourInfantry"){
                        ArmourSystemInfantry asi = (ArmourSystemInfantry)y;
                        output += asi.hp;
                    }
                    if(y.type == "ArmourAFV"){
                        ArmourSystemAFV asv = (ArmourSystemAFV)y;
                        output += asv.hp;
                    }
                }
            }
            return output;
        }

        public string GetArmour(){
            string output = "";
            foreach(var x in sockets){
                foreach(UnitSystem y in x.Value.systems){
                    if(y.type == "ArmourInfantry"){
                        ArmourSystemInfantry asi = (ArmourSystemInfantry)y;
                        output += asi.mainArmour;
                    }
                    if(y.type == "ArmourAFV"){
                        ArmourSystemAFV asv = (ArmourSystemAFV)y;
                        output += $"F: {asv.mainArmour} S: {asv.side} B: {asv.rear} T: {asv.top}";
                    }
                }
            }
            
            return output;
        }

        public int GetSize(){
            return 0;
        }

        public int GetStrength(){
            int output = 0;
            foreach(var x in sockets){
                foreach(UnitSystem y in x.Value.systems){
                    if(y.type == "Stats"){
                        StatsSystem ss = (StatsSystem)y;
                        output += ss.GetStat("Strength");
                    }
                }
            }
            return output;
        }

        public int GetDexterity(){
                        int output = 0;
            foreach(var x in sockets){
                foreach(UnitSystem y in x.Value.systems){
                    if(y.type == "Stats"){
                        StatsSystem ss = (StatsSystem)y;
                        output += ss.GetStat("Dexterity");
                    }
                }
            }
            return output;
        }

        public int GetIntelligence(){
            int output = 0;
            foreach(var x in sockets){
                foreach(UnitSystem y in x.Value.systems){
                    if(y.type == "Stats"){
                        StatsSystem ss = (StatsSystem)y;
                        output += ss.GetStat("Intelligence");
                    }
                }
            }
            return output;
        }

        public int GetDetermination(){
            int output = 0;
            foreach(var x in sockets){
                foreach(UnitSystem y in x.Value.systems){
                    if(y.type == "Stats"){
                        StatsSystem ss = (StatsSystem)y;
                        output += ss.GetStat("Determination");
                    }
                }
            }
            return output;
        }

        public int GetMovement(){
            return 6;
        }

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