using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Books;
using Books.Units;
using UnitSystems;
using UnitSystems.ArmourSystems;
using UnitSystems.MagicSystems;
using UnitSystems.MovementSystems;
using UnitSystems.StatsSystems;
using UnitSystems.WeaponSystems;
using UnitSystems.Tag;

namespace Armies.Scavengers{

    //Squad_Scavengers holds a list of all the squads an army has access to
    public class Squad_Scavengers : Library<SquadBlock>{
        Unit_Scavengers ul = new Unit_Scavengers();

        public override void load(){
            SquadBlock newSquad;

            newSquad = new SquadBlock("Scavengers", SquadBlock.SquadType.GRUNT);
            newSquad.AddUnits(ul.getItem("Scavengers"));
            newSquad.AddSquadOptions(new SquadOption("Scavenger Flame thrower", "Swap one basic weapon for one Flame Thrower", 
            (unit, block) => this.test(unit, block)));



            items.Add(newSquad);

        }

        public bool test(Unit _one, UnitBlock _two){
            return true;
        }
    }

    public class Unit_Scavengers : Library<UnitBlock>
    {

        #region libraries
        ArmourSystemLibrary_Scav asl = new ArmourSystemLibrary_Scav();
        MagicSystemLibrary_Scav masl = new MagicSystemLibrary_Scav();
        MovementSystemLibrary_Scav mosl = new MovementSystemLibrary_Scav();
        StatsSystemLibrary_Scav ssl = new StatsSystemLibrary_Scav();
        WeaponSystemLibrary_Scav wsl = new WeaponSystemLibrary_Scav();

        #endregion libraries
        public override void load(){

            //Unit information will almost always be dependant on which squad they're from, so consider
            //the units created here to be 'Defaults', with specific implementation able to be changed
            //in the squad declaration


            //Reminder
            //(string _name, UnitSystem _unitSystem, UnitSystemTag _tag, bool _isDefault, int _cost)
            UnitBlock newUnit;

            //TODO:
            //Having multiple systems in one System (ex: 2 pistols, or a pistol and a sword)
            //Having multiple systems linked to each other (Ex: Make sure that the sergeant gets the sergeant weapons and the sergeant stat system)
            //Make the game understand which system to remove when an option is chosen. Ex: If a heavy weapon is chosen, remove the Kinetic Rifle
            newUnit = new UnitBlock("Scavenger", true, 8, 5, 20);
            #region Scavenger
                
                //Armour
                UnitSystemTag tag = new UnitSystemTag("Armour", UnitSystemTag.TagType.EXCLUSIVE);
                newUnit.AddArmourSystems(new UnitSystemBlock("Kevlar", asl.getItem("Kevlar"), tag, true, 0));
                newUnit.AddArmourSystems(new UnitSystemBlock("Dyneema", asl.getItem("Dyneema"), tag, false, 1));


                //Magic Systems
                tag = new UnitSystemTag("Magic", UnitSystemTag.TagType.REPLACE);
                newUnit.AddMagicSystems(new UnitSystemBlock("Mundane", masl.getItem("Mundane"), tag, true, 0));
                newUnit.AddMagicSystems(new UnitSystemBlock("Mage", masl.getItem("Scav Mage"), tag, false, 10, 0, 1));

                //Misc Systems

                //Movement Systems
                tag = new UnitSystemTag("Movement", UnitSystemTag.TagType.EXCLUSIVE);
                newUnit.AddMovementSystems(new UnitSystemBlock("Scavenger Movement", mosl.getItem("Infantry 5"), tag, true, 0));

                //StatsSystems
                tag = new UnitSystemTag("Stats", UnitSystemTag.TagType.REPLACE);
                newUnit.AddStatsSystems(new UnitSystemBlock("Scavenger", ssl.getItem("Scavenger"), tag, true, 0));
                newUnit.AddStatsSystems(new UnitSystemBlock("Foreman", ssl.getItem("Scavenger Foreman"), tag, false, 4, 0, 1));
                newUnit.AddStatsSystems(new UnitSystemBlock("Mage", ssl.getItem("Scavenger Mage"), tag, false, 8, 0, 1));

                //Weapons
                tag = new UnitSystemTag("Ranged Weapon", UnitSystemTag.TagType.EXCLUSIVE);
                newUnit.AddWeaponSystems(new UnitSystemBlock("Kinetic Rifle", ssl.getItem("Kinetic Rifle"), tag, true, 0));
                newUnit.AddWeaponSystems(new UnitSystemBlock("Kinetic Pistol", ssl.getItem("Akimbo Kinetic Pistol"), tag, false, 1));
                    
                tag = new UnitSystemTag("Melee Weapon", UnitSystemTag.TagType.EXCLUSIVE);
                newUnit.AddWeaponSystems(new UnitSystemBlock("Bayonet", ssl.getItem("Bayonet"), tag, true, 0));

                tag = new UnitSystemTag("Support Weapon", UnitSystemTag.TagType.EXCLUSIVE);
                newUnit.AddWeaponSystems(new UnitSystemBlock("Heavy Flamethrower", ssl.getItem("Heavy Flamethrower"), tag, false, 5, 0, 1));
                newUnit.AddWeaponSystems(new UnitSystemBlock("Kinetic Anti-Tank Rifle", ssl.getItem("Kinetic Anti-Tank Rifle"), tag, false, 2, 0, 1));
                newUnit.AddWeaponSystems(new UnitSystemBlock("Kinetic HMG", ssl.getItem("Kinetic HMG"), tag, false, 5, 0, 1));
                newUnit.AddWeaponSystems(new UnitSystemBlock("Kinetic Mortar", ssl.getItem("Kinetic Mortar"), tag, false, 5, 0, 1));
            #endregion Scavenger
        }

        

    }

    public class ArmourSystemLibrary_Scav : ArmourSystemLibrary{
        protected override void loadArmourSystems(){
            items.Add(new ArmourSystemInfantry("Kevlar", 1, 6, 2));
            items.Add(new ArmourSystemInfantry("Dyneema", 1, 7, 2));

        }
    }

    public class MagicSystemLibrary_Scav : MagicSystemLibrary{
        protected override void loadMagicSystems(){
            base.loadMagicSystems(); //The base loadMagicSystem has a magic system that represents no spellcasting ability

        }

        protected override void loadSpellBooks(){

        }
        protected override void loadSpells(){

        }
    }

    public class MovementSystemLibrary_Scav : MovementSystemLibrary{

        private MovementTraitLibrary mtl = new MovementTraitLibrary();
        protected override void loadMovementSystems(){
            //Plenty of movement traits that are necessary, so make sure to load the base items
            mtl.loadBase();

            items.Add(new MovementSystem("Infantry 5", 5));

        }
    }

    public class StatsSystemLibrary_Scav : StatsSystemLibrary{
        protected override void loadStatsSystems(){
            //(string _name, int _specialization, params Stat[] _stats)
            StatsSystem ss;

            ss = new StatsSystem("Scavenger", 1, 
                createStat(AvailableStatistics.ATTACKS, 1),
                createStat(AvailableStatistics.DETERMINATION, -1),
                createStat(AvailableStatistics.DEXTERITY, 2),
                createStat(AvailableStatistics.INTELLIGENCE, 1),
                createStat(AvailableStatistics.STRENGTH, 1)
            );
            ss.setSkills(
                createSkill(AvailableSkills.AIM)
            );

            items.Add(ss);

        }
    }  

    public class WeaponSystemLibrary_Scav : WeaponSystemLibrary{

        WeaponTraitLibrary wtl = new WeaponTraitLibrary();
        protected override void loadWeaponSystems(){
            #region DamageType
            //(int _minDamage, int _maxDamage, DamageType _dt, int _ArmourPenetration, OPTIONAL: DamageArea _da, int deviation)
            WeaponSystem.Damage smallArms = new WeaponSystem.Damage(1, 1, WeaponSystem.Damage.DamageType.KINETIC, 0);


            #endregion DamageType

            #region RangedWeapons
            //Ranged weapons
            //(string _name, Damage _damage, int _attacks, int _optimalRange, int _falloff, params WeaponTrait[] _traits)
            items.Add(new WeaponSystemRanged("Frontier Blowback", smallArms, 1, 30, 10));
            #endregion RangedWeapons

            #region MeleeWeapons
            //Melee Weapons
            //(string _name, Damage _damage, params WeaponTrait[] _traits)
            items.Add(new WeaponSystemMelee("Unarmed", smallArms));



            #endregion MeleeWeapons
        }
    }
}