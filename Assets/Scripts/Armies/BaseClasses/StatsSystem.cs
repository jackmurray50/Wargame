using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Books;

namespace UnitSystems.StatsSystems{
    public class StatsSystem : UnitSystem
    {
        List<Skill> skills = new List<Skill>();
        List<Stat> stats = new List<Stat>();
        //The bonus that having a relevant skill gives
        private int specialization;
        public StatsSystem(string _name, int _specialization, params Stat[] _stats) : base(_name){
            this.specialization = _specialization;
            setStats(_stats);

        }
        
        //Sets the StatsSystems stats, overwriting any identical stats
        public void setStats(Stat[] _stats){
            for(int i = 0; i <_stats.Length; i++){
                for(int j = 0; j < stats.Count; j++){
                    if(stats[j].getName() == _stats[i].getName()){
                        stats.RemoveAt(j);
                    }
                }
                stats.Add(_stats[i]); 
            }
        }

        //Sets the StatsSystems skills, overwriting any identical skills
        public void setSkills(params Skill[] _skills){
            for(int i = 0; i <_skills.Length; i++){
                for(int j = 0; j < skills.Count; j++){
                    if(skills[j].getName() == _skills[i].getName()){
                        skills.RemoveAt(j);
                    }
                }
                skills.Add(_skills[i]); 
            }
        }

        public int getStat(string name){
            for(int i = 0; i < stats.Count; i++){
                if(stats[i].getName() == name){
                    return stats[i].getNumber();
                }
            }
            //Since no number should ever get to maxValue, it'll serve as a stand-in for "This went wrong"
            return int.MaxValue;
        }

        //Get the total skill modifier. So skill + stat
        public int getSkill(string name, string _stat){
            //First, check if the unit has the relevant stat. If they don't, assume the stat is 0.
            int output = getStat(_stat);

            //Second, check if the unit has the skill
            for(int i = 0; i < this.skills.Count; i++){
                if(skills[i].getName() == name){
                    output += specialization;
                }
            }

            return int.MaxValue;
        }
    
        private string SkillsToString(){
            string output = "";
            foreach (Skill entry in skills){
                output += entry.ToString();
                int skillValue = specialization;
                skillValue += this.getStat(entry.getName());
            }
            return output;
        }

        private string StatsToString(){
            string output = "";
            foreach(Stat entry in stats){
                output += entry.ToString();
                output += ", ";
            }

            return output;

        }

        public override string ToString(){
            return $"{this.getName()}, Specialization Bonus = {specialization}, Skills = {SkillsToString()}, Stats = {StatsToString()}";
        }
    }

    public class Stat : Book{
        int number;
        public int getNumber(){
            return number;
        }
        public Stat(string _name, int _number) : base(_name){
            number = _number;
        }

        public override string ToString(){
            return $"{this.getName()} = {number}";
        }
    }

    public class Skill : Book{
        string assocStat;
        public string getAssocStat(){
            return assocStat;
        }
        public Skill(string _name, string _stat) : base(_name){
            assocStat = _stat;
        }

        public override string ToString(){
            return $"{this.getName()}";
        }

    }
}