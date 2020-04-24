using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Books;
using Books.StatsSystems;

namespace Books.StatsSystems{
    public class StatsSystemLibrary : Library<StatsSystem>{
        public override void load(){
            loadStatsSystems();
        }

        //(string _name, int _specialization, params Stat[] _stats)
        protected virtual void loadStatsSystems(){
            
        }
#region attributeRetrieval

        //Using enums to ensure that all stats and skills fall under already created categories
        public enum AvailableStatistics{
            STRENGTH,
            DEXTERITY,
            INTELLIGENCE,
            DETERMINATION,
            ATTACKS,
            NOSKILL
        }
        public enum AvailableSkills{
            AIM, //Ability to aim personal weapon, dex-based
            DODGE, //Ability to dodge, dex-based
            MELEE, //Ability to attack in melee, str-based
            CREW, //Ability to work as a team, int-based
            MAGIC, //Ability to cast spells, int-based
            BRAVERY, //Ability to stand fast during fear, determination-based
            MAGICRESISTANCE, //Ability to resist magic. Stat is based on magic source
            STEALTH, //Ability to go undetected, dex-based
            DETECTION, //Ability to spot those in stealth. Useful for removing cover bonus. int-based


        }
        //Method to retrieve a new Stat, or create it if it's not already.
        public Stat createStat(AvailableStatistics _s, int num){
            switch(_s){  
                case AvailableStatistics.STRENGTH:
                    return new Stat("Strength", num);
                case AvailableStatistics.DEXTERITY:
                    return new Stat("Dexterity", num);
                case AvailableStatistics.DETERMINATION:
                    return new Stat("Determination", num);
                case AvailableStatistics.INTELLIGENCE:
                    return new Stat("Intelligence", num);
                case AvailableStatistics.ATTACKS:
                    return new Stat("Attacks", num);
                }
            return null;

        }


        //Implementation that leads to skills using their default statistic
        public Skill createSkill(AvailableSkills _s){
            switch (_s){
                case AvailableSkills.AIM:
                    return createSkill("Aim", AvailableStatistics.DEXTERITY);
                case AvailableSkills.BRAVERY:
                    return createSkill("Bravery", AvailableStatistics.DETERMINATION);
                case AvailableSkills.CREW:
                    return createSkill("Crew", AvailableStatistics.INTELLIGENCE);
                case AvailableSkills.DETECTION:
                    return createSkill("Detection", AvailableStatistics.INTELLIGENCE);
                case AvailableSkills.DODGE:
                    return createSkill("Dodge", AvailableStatistics.DEXTERITY);
                case AvailableSkills.MAGIC:
                    return createSkill("Magic", AvailableStatistics.INTELLIGENCE);
                case AvailableSkills.MAGICRESISTANCE:
                    return createSkill("Magic Resistance", AvailableStatistics.NOSKILL);
                case AvailableSkills.MELEE:
                    return createSkill("Melee", AvailableStatistics.STRENGTH);
                case AvailableSkills.STEALTH:
                    return createSkill("Stealth", AvailableStatistics.DEXTERITY);
            }
            Debug.Log("StatsSystemLibrary: Skill not found");
            return null;
        }
        //Implementation that allows overriding the default statistic, ex: intelligence-based weapons
        public Skill createSkill(string _s, AvailableStatistics _stat){
            string temp = "Null";
            switch (_stat){
                case AvailableStatistics.DEXTERITY:
                    temp = "Dexterity";
                    break;
                case AvailableStatistics.STRENGTH:
                    temp = "Strength";
                    break;
                case AvailableStatistics.INTELLIGENCE:
                    temp = "Intelligence";
                    break;
                case AvailableStatistics.DETERMINATION:
                    temp = "Determination";
                    break;
            }
            return new Skill(_s, temp);
        }

#endregion attributeRetrieval
    }
}