using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitSystems;
using UnitSystems.ArmourSystems;
using UnitSystems.MagicSystems;
using UnitSystems.MovementSystems;
using UnitSystems.StatsSystems;
using UnitSystems.WeaponSystems;
using UnitSystems.Tag;
namespace Books.Units{
//Unit represents a constructed unit
    public class Unit
    {   
        //The systems that the Unit has.

        UnitSystemBlock block;
        private List<List<UnitSystem>> systems = new List<List<UnitSystem>>();
        public enum SystemType{
            ARMOURSYSTEMS = 0,
            MAGICSYSTEMS,
            MISCSYSTEMS,
            MOVEMENTSYSTEMS,
            STATSSYSTEMS,
            WEAPONSYSTEMS
        }
        //Index 0 = ArmourSystems
        //Index 1 = MagicSystems
        //Index 2 = MiscSystems
        //Index 3 = MovementSystems
        //Index 4 = StatsSystems
        //Index 5 = WeaponSystems

        public void AddSystem(int _systemtype, UnitSystem _input){
            systems[_systemtype].Add(_input);
        }
        public void AddSystem(SystemType _systemtype, UnitSystem _input){
            int _type = 0;
            switch (_systemtype){
                case SystemType.ARMOURSYSTEMS:
                    _type = 0;
                    break;
                case SystemType.MAGICSYSTEMS:
                    _type = 1;
                    break;
                case SystemType.MISCSYSTEMS:
                    _type = 2;
                    break;
                case SystemType.MOVEMENTSYSTEMS:
                    _type = 3;
                    break;
                case SystemType.STATSSYSTEMS:
                    _type = 4;
                    break;
                case SystemType.WEAPONSYSTEMS:
                    _type = 5;
                    break;
            }
            systems[_type].Add(_input);
        }

        public void RemoveSystemsByTag(UnitSystemTag _tag){
            for(int i = 0; i < systems.Count; i++){
                for(int j = 0; j < systems[i].Count; j++){
                    if(systems[i][j].tag.getName() == _tag.getName()){
                        systems[i].RemoveAt(j);
                    }
                }
            }
        }

        public int GetCost(){
            int output = 0;
            for(int i = 0; i < systems.Count; i++){
                for(int j = 0; j < systems[i].Count; i++){
                    output += systems[i][j].GetCost();
                }
            }
            output += block.GetCost();
            return output;
        }

        public void ModifySystemAmount(UnitSystem _system, int _amount){
        }

        public UnitSystem GetMainSystem(SystemType _type, string _tagname){
            for(int i = 0; i < systems[(int)_type].Count; i++){
                if(systems[(int)_type][i].tag.getName() == _tagname){
                    return systems[(int)_type][i];
                }
            }
            Debug.Log("<color=red>Couldn't find the main " + _type + " with tag " + _tagname + " in unit created by " + block.getName());
            return null;
        }
    }


    //UnitBlock represents the potential options for a particular unit
    public class UnitBlock : Block
    {
        
        private List<List<UnitSystemBlock>> systems = new List<List<UnitSystemBlock>>(); //A list of lists of UnitSystemBlocks.
        //Index 0 = ArmourSystems
        //Index 1 = MagicSystems
        //Index 2 = MiscSystems
        //Index 3 = MovementSystems
        //Index 4 = StatsSystems
        //Index 5 = WeaponSystems



        public UnitBlock(string _name, bool _isDefault, int _cost, int _min, int _max) : base(_name, _cost, _min, _max){
            //Initialize all 6 lists of UnitSystemBlocks
            for(int i = 0; i < 6; i++){
                systems.Add(new List<UnitSystemBlock>());
            }
        }

        //Creates a Unit based on the defaults provided.
        public Unit CreateDefaultUnit(){
            Unit output = new Unit();
            for(int i = 0; i < systems.Count; i++){
                for(int j = 0; j < systems[i].Count; j++){
                    if(systems[i][j].IsDefault){
                        output.AddSystem(i, systems[i][j].GetSystem());
                    }
                }
            }
            return output;
        }

        
        #region AddSystem
        //These methods take in any amount of system blocks and add them to the proper
        public void AddArmourSystems(params UnitSystemBlock[] _systems){
            for(int i = 0; i < _systems.Length; i++){
                systems[0].Add(_systems[i]);
            }
        }
        public void AddMagicSystems(params UnitSystemBlock[] _systems){
            for(int i = 0; i < _systems.Length; i++){
                systems[1].Add(_systems[i]);
            }
        }
        public void AddMiscSystems(params UnitSystemBlock[] _systems){
            for(int i = 0; i < _systems.Length; i++){
                systems[2].Add(_systems[i]);
            }
        }
        public void AddMovementSystems(params UnitSystemBlock[] _systems){
            for(int i = 0; i < _systems.Length; i++){
                systems[3].Add(_systems[i]);
            }
        }
        public void AddStatsSystems(params UnitSystemBlock[] _systems){
            for(int i = 0; i < _systems.Length; i++){
                systems[4].Add(_systems[i]);
            }
        }
        public void AddWeaponSystems(params UnitSystemBlock[] _systems){
            for(int i = 0; i < _systems.Length; i++){
                systems[5].Add(_systems[i]);
            }
        }

        #endregion AddSystem
    
        #region GetSystem
        public UnitSystemBlock GetSystemBlock(Unit.SystemType _type, string _name){
            int index = (int)_type;
            for(int i = 0; i < systems[index].Count; i++){
                if(systems[index][i].getName() == _name){
                    return systems[index][i];
                }
            }
            Debug.Log("<color=red>ERROR: Couldn't find \'</color>" + _name + "\' of type \'" + _type + "\' in UnitSystemBlock \'" + this.getName() + "\'");
            return null;
        }
        #endregion GetSystem
    }
}