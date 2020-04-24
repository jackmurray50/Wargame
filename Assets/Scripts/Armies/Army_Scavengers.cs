using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Books;
using Books.Units;
using Books.ArmourSystems;
using Books.MagicSystems;
using Books.MovementSystems;
using Books.StatsSystems;
using Books.WeaponSystems;

namespace Armies.Scavengers{

    //Army_Scavengers_Squad holds a list of all the squads an army has access to
    public class Army_Scavengers_Squad : Library<Squad>{
        Army_Scavengers_Unit ul = new Army_Scavengers_Unit();
        public override void load(){

            //Scavs
            items.Add(new Squad("Scavs", Squad.SquadType.GRUNT, 25));
            items[items.Count -1].addUnits(
                new squadComponent("Scav", ul.getItem("Scav")),
                new squadComponent("Scav Foreman", ul.getItem("Scav Foreman"), 1, 0, 6),    
                new squadComponent("Scav Mage", ul.getItem("Scav Mage"), 1, 0, 12)
            );
            

            //Conversion tank
            items.Add(new Squad("Conversion Tank", Squad.SquadType.GRUNT, 5));
            items[items.Count -1].addUnits(
                new squadComponent("Conversion Tank", ul.getItem("Conversion Tank"), 5, 0, 35),
                new squadComponent("Crew", ul.getItem("Scav crew"), 20, 4, 0)
            );

            //Figure out the defaults
        }
    }

    public class Army_Scavengers_Unit : Library<UnitBlock>
    {

        #region libraries
        ArmourSystemLibrary_Scav asl = new ArmourSystemLibrary_Scav();
        MagicSystemLibrary_Scav masl = new MagicSystemLibrary_Scav();
        MovementSystemLibrary_Scav mosl = new MovementSystemLibrary_Scav();
        StatsSystemLibrary_Scav ssl = new StatsSystemLibrary_Scav();
        WeaponSystemLibrary_Scav wsl = new WeaponSystemLibrary_Scav();

        #endregion libraries
        public override void load(){
            loadInfantry();
            loadVehicles();
            loadFortifications();
        }

        private void loadInfantry(){
            
            #region Scav
            items.Add(new UnitBlock("Scav", 4, UnitBlock.Weight.MEDIUM)); //Average soldier
                //Armour
                items[items.Count -1].addSystem(asl.getItem("Kevlar"));
                items[items.Count -1].addSystem(asl.getItem("Dyneema"));
                //Magic systems
                items[items.Count -1].addSystem(masl.getItem("Mundane"));
                //Movement systems
                items[items.Count -1].addSystem(mosl.getItem("Infantry"));
                //Stats systems
                items[items.Count -1].addSystem(ssl.getItem("Scav Trooper"));
                //Weapon Systems
                items[items.Count -1].addSystem(wsl.getItem("Frontier Rifle K2"));
                items[items.Count -1].addSystem(wsl.getItem("K15 Submachine Gun"));
                items[items.Count -1].addSystem(wsl.getItem("E-Tool"));
                items[items.Count -1].addSystem(wsl.getItem("H15 Pistol"));


                //Set defaults
                items[items.Count -1].SetDefaultSystems("Kevlar", "Mundane", "Infantry", "Scav Trooper", "Frontier Rifle K 2", "E-Tool");
            #endregion Scav
            #region Scav_Foreman
            items.Add(new UnitBlock("Scav Foreman", 6, UnitBlock.Weight.MEDIUM)); //Troop leader for scavs
                //Armour
                items[items.Count -1].addSystem(asl.getItem("Kevlar"));
                items[items.Count -1].addSystem(asl.getItem("Dyneema"));
                //Magic systems
                items[items.Count -1].addSystem(masl.getItem("Mundane"));
                //Movement systems
                items[items.Count -1].addSystem(mosl.getItem("Infantry"));
                //Stats systems
                items[items.Count -1].addSystem(ssl.getItem("Scav Foreman"));
                //Weapon Systems
                items[items.Count -1].addSystem(wsl.getItem("Frontier Rifle K2"));
                items[items.Count -1].addSystem(wsl.getItem("K15 Submachine Gun"));
                items[items.Count -1].addSystem(wsl.getItem("E-Tool"));
                items[items.Count -1].addSystem(wsl.getItem("H15 Pistol"));
            #endregion Scav_Foreman
            #region Scav_Mage
            items.Add(new UnitBlock("Scav Mage", 6, UnitBlock.Weight.MEDIUM)); //Troop leader for scavs
                //Armour
                items[items.Count -1].addSystem(asl.getItem("Kevlar"));
                items[items.Count -1].addSystem(asl.getItem("Dyneema"));
                //Magic systems
                items[items.Count -1].addSystem(masl.getItem("Scav Mage"));
                //Movement systems
                items[items.Count -1].addSystem(mosl.getItem("Infantry"));
                //Stats systems
                items[items.Count -1].addSystem(ssl.getItem("Scav Mage"));
                //Weapon Systems
                items[items.Count -1].addSystem(wsl.getItem("Frontier Rifle K2"));
                items[items.Count -1].addSystem(wsl.getItem("K15 Submachine Gun"));
                items[items.Count -1].addSystem(wsl.getItem("E-Tool"));
                items[items.Count -1].addSystem(wsl.getItem("H15 Pistol"));    
            #endregion Scav_Mage
            #region Frontiersman
            //items.Add(new UnitBlock("Frontiersman", 8, UnitBlock.Weight.MEDIUM)); //Elite soldiers
            #endregion Frontiersman
            #region Scav_Crew
            items.Add(new UnitBlock("Scav crew", 3, UnitBlock.Weight.MEDIUM)); //Default crew
                //Armour
                items[items.Count -1].addSystem(asl.getItem("Kevlar"));
                items[items.Count -1].addSystem(asl.getItem("Dyneema"));
                //Magic systems
                items[items.Count -1].addSystem(masl.getItem("Mundane"));
                //Movement systems
                items[items.Count -1].addSystem(mosl.getItem("Infantry"));
                //Stats systems
                items[items.Count -1].addSystem(ssl.getItem("Scav Crew"));
                //Weapon Systems
                items[items.Count -1].addSystem(wsl.getItem("K15 Submachine Gun"));
                items[items.Count -1].addSystem(wsl.getItem("H15 Pistol"));
            #endregion Scav_Crew
        }

        private void loadVehicles(){
            #region Universal_Carrier
            items.Add(new UnitBlock("Universal Carrier", 10, UnitBlock.Weight.HUGE)); //Simple 4-man open-topped car with light armour
                //Armour Systems
                items[items.Count -1].addSystem(asl.getItem("Universal Carrier"));
                //Magic System
                items[items.Count -1].addSystem(masl.getItem("Mundane"));
                //Movement Systems
                items[items.Count -1].addSystem(mosl.getItem("Universal Carrier"));
                //Stats Systems
                items[items.Count -1].addSystem(ssl.getItem("Medium Vehicle"));
                //Weapon Systems
                items[items.Count -1].addSystem(wsl.getItem("Duboit Machine Gun"));
                items[items.Count -1].addSystem(wsl.getItem("Ramming"));
            #endregion Universal_Carrier

            #region Conversion_Tank
            items.Add(new UnitBlock("Conversion Tank", 32, UnitBlock.Weight.MASSIVE)); //Effectively just a Bob Semple Tank
                items[items.Count -1].addSystem(asl.getItem("Conversion Tank"));
                items[items.Count -1].addSystem(masl.getItem("Mundane"));
                items[items.Count -1].addSystem(mosl.getItem("Medium Tank"));
                items[items.Count -1].addSystem(ssl.getItem("Heavy Vehicle"));
                //Weapon System
                items[items.Count -1].addSystem(wsl.getItem("Duboit Machine Gun"), wsl.getItem("Duboit Machine Gun"), wsl.getItem("Duboit Machine Gun"),
                wsl.getItem("Duboit Machine Gun"), wsl.getItem("Duboit Anti Tank Rifle"), wsl.getItem("Duboit Anti Tank Rifle"));
            #endregion Conversion_Tank
        }

        private void loadFortifications(){
            //items.Add(new UnitBlock("Trench", 40, UnitBlock.Weight.NONAPPLICABLE)); //A trench. Duh.
        }

    }

    public class ArmourSystemLibrary_Scav : ArmourSystemLibrary{
        protected override void loadArmourSystems(){

            
            //Reminder: 
            // Infantry: (string _name, int _hp, int _cost, int _armour, int _weight, int _dodgeBonus, params ArmourTrait[] _traits)
            // Vehicle: (string _name, int _hp, int _cost, List<ArmourTrait> _traits, int _front, int _side, int _rear, int _top, int _weight)
            items.Add(new ArmourSystemInfantry("Kevlar", 1, 0, 3, 1));
            items.Add(new ArmourSystemInfantry("Dyneema", 1, 1, 4, 1));

            items.Add(new ArmourSystemAFV("Universal Carrier", 4, 12, 10, 8, 8, 4, atl.getItem("Open Topped")));
            items.Add(new ArmourSystemAFV("Conversion Tank", 8, 0, 15, 12, 10, 10 ));

        }
    }

    public class MagicSystemLibrary_Scav : MagicSystemLibrary{
        protected override void loadMagicSystems(){
            base.loadMagicSystems(); //The base loadMagicSystem has a magic system that represents no spellcasting ability

            //Reminder: (string _name, List<Spell> _spellbook, params SpellSlot[] _spellSlots)
            //items.Add(new MagicSystem("Magic system name", getSpellBook("spellbook name").getSpells(), new SpellSlot(6, 1), new SpellSlot(2, 2), new SpellSlot(1, 3)));
            items.Add(new MagicSystem("Scav Mage", getSpellBook("Scav Mage").getSpells (), new SpellSlot(6, 1), new SpellSlot(1, 2)));
        }

        protected override void loadSpellBooks(){
            //Reminder: (string _name, params Spell[] _spellbook)
            //spellBooks.Add(new SpellBook("Name", getSpell("Spell name 1"), getSpell("Spell name 2)));
            spellBooks.Add(new SpellBook("Scav Mage", getSpell("Propel Bullet"), getSpell("Hex")));
        }
        protected override void loadSpells(){
            //Reminder: (string _name, string _description, int _minLevel)
            //spells.Add(new Spell("name", "description", 3));
            spells.Add(new Spell("Propel Bullet", "Makes a standard weapon attack with whichever weapon the caster has, doubling the range", 0));

            spells.Add(new Spell("Hex", "Stuns a vehicles weapons or movement for one round", 2));
        }
    }

    public class MovementSystemLibrary_Scav : MovementSystemLibrary{

        private MovementTraitLibrary mtl = new MovementTraitLibrary();
        protected override void loadMovementSystems(){
            //Plenty of movement traits that are necessary, so make sure to load the base items
            mtl.loadBase();

            //Reminder: (string _name, int _speed, params MovementTrait[] _traits)
            //items.Add(new MovementSystem("Name", 6));
            //Reminder: (string _name, int _speed, float _rotationCost, Terrain _terrain, params MovementTrait[] _traits)
            //Rotation cost is how much movement it takes to turn 360 degrees.
            //items.Add(new MovementSystem("Name", 6, 18, MovementSystem.Terrain.SKY))

            items.Add(new MovementSystem("Infantry", 6));//Basic scav infantry will move at 6 speed per turn

            items.Add(new MovementSystem("Universal Carrier", 12, 12, MovementSystem.Terrain.LAND, mtl.getItem("Tracked")));

            items.Add(new MovementSystem("Medium Tank", 10, 10, MovementSystem.Terrain.LAND, mtl.getItem("Tracked")));
        }
    }

    public class StatsSystemLibrary_Scav : StatsSystemLibrary{
        protected override void loadStatsSystems(){

            /* Reminder
            StatsSystem temp;
            temp = new StatsSystem("Basic Infantry",
                1,
                createStat(AvailableStatistics.STRENGTH, 2),
                createStat(AvailableStatistics.DEXTERITY, 2),
                createStat(AvailableStatistics.DETERMINATION, 0),
                createStat(AvailableStatistics.INTELLIGENCE, 0),
                createStat(AvailableStatistics.ATTACKS, 1)
                );
            temp.setSkills(
                createSkill(AvailableSkills.AIM)
                );
            items.Add(temp);*/
            StatsSystem temp;

            #region infantry
            #region Scavs
            temp = new StatsSystem("Scav Trooper",
                1,
                createStat(AvailableStatistics.STRENGTH, 1),
                createStat(AvailableStatistics.DEXTERITY, 2),
                createStat(AvailableStatistics.DETERMINATION, -1),
                createStat(AvailableStatistics.INTELLIGENCE, 1)
                );
            temp.setSkills(
                createSkill(AvailableSkills.AIM)
                );
            items.Add(temp);

            temp = new StatsSystem("Scav Foreman",
                1,
                createStat(AvailableStatistics.STRENGTH, 1),
                createStat(AvailableStatistics.DEXTERITY, 2),
                createStat(AvailableStatistics.DETERMINATION, 1),
                createStat(AvailableStatistics.INTELLIGENCE, 1)
                );
            temp.setSkills(
                createSkill(AvailableSkills.AIM),
                createSkill(AvailableSkills.BRAVERY)
                );
            items.Add(temp);


            temp = new StatsSystem("Scav Mage",
                1,
                createStat(AvailableStatistics.STRENGTH, 1),
                createStat(AvailableStatistics.DEXTERITY, 2),
                createStat(AvailableStatistics.DETERMINATION, 0),
                createStat(AvailableStatistics.INTELLIGENCE, 2)
                );
            temp.setSkills(
                createSkill(AvailableSkills.AIM),
                createSkill(AvailableSkills.BRAVERY)
                );
            items.Add(temp);

            temp = new StatsSystem("Scav",
                1,
                createStat(AvailableStatistics.STRENGTH, 1),
                createStat(AvailableStatistics.DEXTERITY, 2),
                createStat(AvailableStatistics.DETERMINATION, 0),
                createStat(AvailableStatistics.INTELLIGENCE, 2)
                );
            temp.setSkills(
                createSkill(AvailableSkills.AIM),
                createSkill(AvailableSkills.MAGIC)
                );
            items.Add(temp);

            temp = new StatsSystem("Scav Crew",
                1,
                createStat(AvailableStatistics.STRENGTH, 0),
                createStat(AvailableStatistics.DEXTERITY, 2),
                createStat(AvailableStatistics.DETERMINATION, -1),
                createStat(AvailableStatistics.INTELLIGENCE, 2)
                );
            temp.setSkills(
                createSkill(AvailableSkills.CREW)
                );
            items.Add(temp);
            #endregion Scavs
        
            #endregion infantry

            #region vehicles
            #region Universal_Carrier
            temp = new StatsSystem("Medium Vehicle",
                0,
                createStat(AvailableStatistics.STRENGTH, 4)
                );
            items.Add(temp);
            #endregion Universal_Carrier
            #region Conversion_Tank
            temp = new StatsSystem("Heavy Vehicle",
                0,
                createStat(AvailableStatistics.STRENGTH, 6)
                );
            items.Add(temp);
            #endregion Conversion_Tank
            #endregion vehicles


        }
    }  

    public class WeaponSystemLibrary_Scav : WeaponSystemLibrary{

        WeaponTraitLibrary wtl = new WeaponTraitLibrary();
        protected override void loadWeaponSystems(){
            //Reminder:
            //Damage: (int minDamage, int maxDamage, DamageType _dt, int ArmourPenetration)
            //Damage: (int minDamage, int maxDamage, DamageType _dt, int ArmourPenetration, DamageArea _da, int deviation))

            //WeaponSystemRanged: (string _name, int _cost, Damage _damage, int _weight, 
            //  int _optimalRange, int _maxRange, params WeaponTrait[] _traits)

            //WeaponSystemMelee: (string _name, int _cost, Damage _damage, int _weight, params WeaponTrait[] _traits)

            #region DamageTypes
            //Infantry weapon damage
            WeaponSystem.Damage stdInfantryDamage = new WeaponSystem.Damage(1,1,WeaponSystem.Damage.DamageType.KINETIC, 0);

            //Cannon damage
            WeaponSystem.Damage stdHEDamage = new WeaponSystem.Damage(1,3, WeaponSystem.Damage.DamageType.ENERGETIC, 1, WeaponSystem.Damage.DamageArea.SPHERE, 0);
            WeaponSystem.Damage stdAPDamage = new WeaponSystem.Damage(1,6, WeaponSystem.Damage.DamageType.KINETIC, 3);
            WeaponSystem.Damage rammingDamage = new WeaponSystem.Damage(2, 2, WeaponSystem.Damage.DamageType.KINETIC, 0, WeaponSystem.Damage.DamageArea.CONE, 0); //Damage amount will be multiplied by size
            #endregion DamageTypes

            //Handheld
            items.Add(new WeaponSystemRanged("Frontier Rifle K2", 0, stdInfantryDamage, 1,  40, 80, wtl.getItem("Armour Piercing")));
            items.Add(new WeaponSystemRanged("K15 Submachine Gun", 0, stdInfantryDamage, 1, 20, 40, wtl.getItem("Rapid Fire")));
            items.Add(new WeaponSystemRanged("H15 Pistol", 1, stdInfantryDamage, 1, 10, 20, wtl.getItem("CQC Firearm")));

            items.Add(new WeaponSystemMelee("E-Tool", 0, stdInfantryDamage));
            

            //Supported weapons (LMGs and such)
            items.Add(new WeaponSystemRanged("Duboit Machine Gun", 4, stdInfantryDamage, 2, 50, 100, wtl.getItem("Heavy"), wtl.getItem("Rapid Fire")));
            items.Add(new WeaponSystemRanged("Duboit Anti Tank Rifle", 8, stdAPDamage, 1, 100, 200, wtl.getItem("Heavy")));

            //Vehicle weapons

            items.Add(new WeaponSystemMelee("Ramming", 0, rammingDamage, wtl.getItem("Self Damaging")));
        }
    }
}