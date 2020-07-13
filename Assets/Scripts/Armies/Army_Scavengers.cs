using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Books;
using Books.Units;
using UnitSystems;
using UnitSystems.ArmourSystems;
using UnitSystems.MagicSystems;
using UnitSystems.MiscSystems;
using UnitSystems.MovementSystems;
using UnitSystems.StatsSystems;
using UnitSystems.WeaponSystems;
using UnitSystems.Sockets;

namespace Armies.Frontier{

    //FrontierSquadLibrary holds a list of all the squads an army has access to
    public class FrontierSquadLibrary : Library<Squad>{
        FrontierUnitLibrary ul = new FrontierUnitLibrary();

        public override void load(){
            Squad newSquad;
            //First squad, mostly doing this to double-check the systems.
            //It'll be a squad of standard infantry that have a rifle by default, but choose to have a mage and/or a sergeant,
            //and they can choose between rifles (Medium range medium ROF) and SMGs (Low range high ROF)

            #region Frontiersmen
            //First, create the squad. Give it a name and a type.
            newSquad = new Squad("Frontiersmen", Squad.SquadType.GRUNT);
            //Second, add the units. In this case there'll be the Sergeant, the Mage, the Heavy Gunner, and the standard infantryman
                newSquad.AddUnits(ul.getItem("Frontiersman Default"));
                newSquad.GetUnit("Frontiersman Default").amount = 5;
                newSquad.AddUnits(ul.getItem("Frontiersman Sergeant"));
                newSquad.AddUnits(ul.getItem("Frontiersman Mage"));
                newSquad.AddUnits(ul.getItem("Frontiersman Gunner"));

            //Third, create the squad options. The squad options available to the Frontiersmen are going to be:
            //1.  Increase/Decrease their size from 5 to 25. 
            newSquad.AddOption(new SquadOption(
                "Squad Size",
                "Increase or decrease the squads size",
                8,
                20,
                new SquadOption.Option( e => {
                    e.GetUnit("Frontiersman Default").amount++;
                    e.GetOption("Squad Size").optionNum++;
                }),
                new SquadOption.Option( e => {
                    e.GetUnit("Frontiersman Default").amount--;
                    e.GetOption("Squad Size").optionNum--;
                }),
                new SquadOption.CostCalculator( e => {
                    return e.optionNum * e.baseCost;
                })
            ));
            //TODO: Create a 'base' amount of units in a squad
            //2.  Change the armour of each unit to Dyneema, or back to Kevlar
            //SquadOption(string _name, string _desc, int _cost, int _optionLimit, Option _implement, Option _deimplement
            newSquad.AddOption(new SquadOption(
                "Dyneema", 
                "Swap between Kevlar (base) and Dyneema", 
                2, //This option'll cost 2 per unit in the squad
                1, //This option is binary, it can be on or off
                new SquadOption.Option( e => {
                    //Implement the option, so turn the squads armour into Dyneema
                        Debug.Log("Adding Dyneema to squad" + e.getName());
                    //First, make a list of units that'll be affected
                    List<Unit> units = new List<Unit>();
                    units.Add(e.GetUnit("Frontiersman Default"));
                    units.Add(e.GetUnit("Frontiersman Sergeant"));
                    units.Add(e.GetUnit("Frontiersman Mage"));
                    units.Add(e.GetUnit("Frontiersman Gunner"));

                    //Second, iterate through the List, performing the operation. In this case, clearing the Armour socket and filling it with Dyneema
                    foreach(Unit entry in units){
                        entry.ClearSocket("Armour");
                        entry.AddSystemToSocket("Armour", ul.asl.getItem("Dyneema"));
                    }

                    e.GetOption("Dyneema").optionNum++;
                }),
                new SquadOption.Option( e => {
                    //Deimplement the option, so turn the squads armour into Kevlar

                    //First, make a list of units that'll be affected
                    List<Unit> units = new List<Unit>();
                    units.Add(e.GetUnit("Frontiersman Default"));
                    units.Add(e.GetUnit("Frontiersman Sergeant"));
                    units.Add(e.GetUnit("Frontiersman Mage"));
                    units.Add(e.GetUnit("Frontiersman Gunner"));

                    //Second, iterate through the List, performing the operation. In this case, clearing the Armour socket and filling it with Kevlar
                    foreach(Unit entry in units){
                        entry.ClearSocket("Armour");
                        entry.AddSystemToSocket("Armour", ul.asl.getItem("Kevlar"));
                    }
                }),
                new SquadOption.CostCalculator( e => {
                    int TotalSquadSize = 0;
                    TotalSquadSize += e.squad.GetOption("Squad Size").optionNum;
                    //TODO: Uncomment this
                    /*
                    TotalSquadSize += e.squad.GetOption("Add Sergeant").optionNum;
                    TotalSquadSize += e.squad.GetOption("Add Gunner").optionNum;
                    TotalSquadSize += e.squad.GetOption("Add Mage").optionNum;
                    */
                    if(e.optionNum == 1){
                        return TotalSquadSize * e.baseCost;
                    }else{
                        return 0;
                    }
                })
            ));
            //3.  Change the weapon of all default frontiersmen to an SMG, or back to a rifle
            newSquad.AddOption(new SquadOption("Frontiersmen SMG",
            "On implement, give the frontiersmen SMGs",
            0,
            1,
                new SquadOption.Option(e => {
                    e.GetUnit("Frontiserman Default").ClearSocket("Weapon");
                }),
                new SquadOption.Option(e => {

                }),
                new SquadOption.CostCalculator( e => {
                    return 0;
                })
            ));
            //4.  Add in a Sergeant
            //5.  Add in a Mage
            //6.  Add in a Heavy Gunner (Max 10% of force, uses 2 crew members)
            //    All Heavy Gunner weapons are mutually exclusive
            //7.  Change the Heavy Gunners weapon to a Flamethrower
            //8.  Change the Heavy Gunners weapon to an HMG
            //9.  Change the Heavy Gunners weapon to an anti-material rifle
            //10. Give the squad a radio


            //Set the options default state, if its different from optionNum = 0;
            newSquad.GetOption("Squad Size").optionNum = 5;

            //Set options parent squads, if needed
            newSquad.GetOption("Dyneema").squad = newSquad;
            items.Add(newSquad);
            #endregion Frontiersmen
        }
    }

    //The units created in this library will include their default configuration and the sockets they need. The objects created can be
    //modified under the FrontierSquadLibrary class.
    public class FrontierUnitLibrary : Library<Unit>
    {

        public FrontierUnitLibrary(){
            asl = new ArmourSystemLibrary_Scav();
            masl = new MagicSystemLibrary_Scav();
            mosl = new MovementSystemLibrary_Scav();
            ssl = new StatsSystemLibrary_Scav();
            wsl = new WeaponSystemLibrary_Scav();
        }

        #region libraries
        public ArmourSystemLibrary_Scav asl {get;}
        public MagicSystemLibrary_Scav masl {get;}
        public MovementSystemLibrary_Scav mosl {get;}
        public StatsSystemLibrary_Scav ssl {get;}
        public WeaponSystemLibrary_Scav wsl {get;}

        #endregion libraries
        public override void load(){
            Unit newUnit;

            //Creating the Frontiersmen units
            #region Frontiersmen
            newUnit = new Unit("Frontiersman Default");
                newUnit.AddSocket("Armour", new Socket("Armour", 1));
                newUnit.AddSocket("Ranged Weapon", new Socket("Ranged Weapon", 1));
                newUnit.AddSocket("Melee Weapon", new Socket("Melee Weapon", 1));
                newUnit.AddSocket("Stats", new Socket("Stats", 1));
                newUnit.AddSocket("Movement", new Socket("Movement", 1));
                newUnit.AddSocket("Misc", new Socket("Misc", int.MaxValue));
                
                //Set kevlar as the default item
                newUnit.AddSystemToSocket("Armour", asl.getItem("Kevlar"));
                newUnit.AddSystemToSocket("Ranged Weapon", wsl.getItem("Kinetic Rifle"));
                newUnit.AddSystemToSocket("Melee Weapon", wsl.getItem("Unarmed"));
                newUnit.AddSystemToSocket("Stats", ssl.getItem("Frontiersmen"));
                newUnit.AddSystemToSocket("Movement", mosl.getItem("Infantry 5"));

            items.Add(newUnit);

            newUnit = new Unit("Frontiersman Gunner");
                newUnit.AddSocket("Armour", new Socket("Armour", 1));
                newUnit.AddSocket("Heavy Weapon", new Socket("Heavy Weapon", 1));
                newUnit.AddSocket("Personal Defense Weapon", new Socket("Personal Defense Weapon", 2));
                newUnit.AddSocket("Melee Weapon", new Socket("Melee Weapon", 1));
                newUnit.AddSocket("Stats", new Socket("Stats", 1));
                newUnit.AddSocket("Movement", new Socket("Movement", 1));
                newUnit.AddSocket("Misc", new Socket("Misc", int.MaxValue));

                newUnit.AddSystemToSocket("Armour", asl.getItem("Kevlar"));
                newUnit.AddSystemToSocket("Heavy Weapon", wsl.getItem("Kinetic HMG"));
                newUnit.AddSystemToSocket("Personal Defense Weapon", wsl.getItem("Kinetic PDW"));
                newUnit.AddSystemToSocket("Melee Weapon", wsl.getItem("Unarmed"));
                newUnit.AddSystemToSocket("Stats", ssl.getItem("Frontiersmen"));
                newUnit.AddSystemToSocket("Movement", mosl.getItem("Infantry 5"));

            items.Add(newUnit);

            newUnit = new Unit("Frontiersman Sergeant");
                newUnit.AddSocket("Armour", new Socket("Armour", 1));
                newUnit.AddSocket("Ranged Weapon", new Socket("Ranged Weapon", 1));
                newUnit.AddSocket("Melee Weapon", new Socket("Melee Weapon", 1));
                newUnit.AddSocket("Stats", new Socket("Stats", 1));
                newUnit.AddSocket("Movement", new Socket("Movement", 1));
                newUnit.AddSocket("Misc", new Socket("Misc", int.MaxValue));
                
                //Set kevlar as the default item
                newUnit.AddSystemToSocket("Armour", asl.getItem("Kevlar"));
                newUnit.AddSystemToSocket("Ranged Weapon", wsl.getItem("Kinetic Rifle"));
                newUnit.AddSystemToSocket("Melee Weapon", wsl.getItem("Standard Sword"));
                newUnit.AddSystemToSocket("Stats", ssl.getItem("Frontiersmen"));
                newUnit.AddSystemToSocket("Movement", mosl.getItem("Infantry 5"));

            items.Add(newUnit);

            //the Frontiersmen mage will use unlimited-use spells as their weaponry
            newUnit = new Unit("Frontiersman Mage");
                newUnit.AddSocket("Armour", new Socket("Armour", 1));
                newUnit.AddSocket("Stats", new Socket("Stats", 1));
                newUnit.AddSocket("Movement", new Socket("Movement", 1));
                newUnit.AddSocket("Magic", new Socket("Magic", 1));
                newUnit.AddSocket("Misc", new Socket("Misc", int.MaxValue));
                
                //Set kevlar as the default item
                newUnit.AddSystemToSocket("Armour", asl.getItem("Kevlar"));
                newUnit.AddSystemToSocket("Magic", masl.getItem("Frontiersmen Mage"));
                newUnit.AddSystemToSocket("Stats", ssl.getItem("Frontiersmen"));
                newUnit.AddSystemToSocket("Movement", mosl.getItem("Infantry 5"));

            items.Add(newUnit);

            #endregion Frontiersmen
        }

        

    }


//Army-specific libraries of weapons, magic systems, etc...
//Create any new systems inside the Load functions
    public class ArmourSystemLibrary_Scav : ArmourSystemLibrary{
        protected override void loadArmourSystems(){
            items.Add(new ArmourSystemInfantry("Kevlar", 1, 6, 2));
            items.Add(new ArmourSystemInfantry("Dyneema", 1, 7, 2));

        }
    }

    public class MagicSystemLibrary_Scav : MagicSystemLibrary{
        protected override void loadMagicSystems(){
            base.loadMagicSystems(); //The base loadMagicSystem has a magic system that represents no spellcasting ability

            items.Add(new MagicSystem("Frontiersmen Mage",
                spellBooks.Find(e => e.getName() == "Scrapper_L1"),
                new SpellSlot(int.MaxValue, 0),
                new SpellSlot(2, 2)
            ));

        }

        protected override void loadSpellBooks(){
            spellBooks.Add(new SpellBook("Scrapper_L1", 
                spells.Find(e => e.getName() == "Propel Scrap"),
                spells.Find(e => e.getName() == "Earth Tremor"),

                spells.Find(e => e.getName() == "Shift Earth"),
                spells.Find(e => e.getName() == "Minor Dispel"),
                spells.Find(e => e.getName() == "Minor Shield")
                ));
        }
        protected override void loadSpells(){
            #region L0
            spells.Add(new Spell("Propel Scrap", "Fire a bolt of scrap that automatically hits, and deals 1 damage with 0 AP. Range 40", 0));
            spells.Add(new Spell("Earth Tremor", "Shake the earth before you, attacking 3 times in melee. Uses your Magic ability.", 0));
            #endregion L0


            #region L1
            spells.Add(new Spell("Shift Earth", "Create minor cover", 1));
            spells.Add(new Spell("Minor Dispel", "Dispel a magical effect created by a spell of L1", 1));
            spells.Add(new Spell("Minor Shield", "Reactively give the unit an additional Armour Layer with an AC of 8", 1));
            #endregion L1
        }
    }

    public class MiscSystemLibrary_Scav : MiscSystemLibrary{
        protected override void LoadMiscSystems(){
            items.Add(new MiscSystem("Example System", "Description goes here"));
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

            #region Frontiersmen
            ss = new StatsSystem("Frontiersmen", 1, 
                createStat(AvailableStatistics.ATTACKS, 1),
                createStat(AvailableStatistics.DETERMINATION, 0),
                createStat(AvailableStatistics.DEXTERITY, 2),
                createStat(AvailableStatistics.INTELLIGENCE, 1),
                createStat(AvailableStatistics.STRENGTH, 1)
            );
            ss.setSkills(
                createSkill(AvailableSkills.AIM),
                createSkill(AvailableSkills.BRAVERY)
            );

            items.Add(ss);

            ss = new StatsSystem("Frontiersman Sergeant", 2, 
                createStat(AvailableStatistics.ATTACKS, 2),
                createStat(AvailableStatistics.DETERMINATION, 1),
                createStat(AvailableStatistics.DEXTERITY, 2),
                createStat(AvailableStatistics.INTELLIGENCE, 1),
                createStat(AvailableStatistics.STRENGTH, 1)
            );
            ss.setSkills(
                createSkill(AvailableSkills.AIM),
                createSkill(AvailableSkills.BRAVERY),
                createSkill(AvailableSkills.MELEE),
                createSkill(AvailableSkills.LEADERSHIP)
            );

            items.Add(ss);

            ss = new StatsSystem("Frontiersman Mage", 2, 
                createStat(AvailableStatistics.ATTACKS, 1),
                createStat(AvailableStatistics.DETERMINATION, 1),
                createStat(AvailableStatistics.DEXTERITY, 2),
                createStat(AvailableStatistics.INTELLIGENCE, 2),
                createStat(AvailableStatistics.STRENGTH, 0)
            );
            ss.setSkills(
                createSkill(AvailableSkills.AIM),
                createSkill(AvailableSkills.BRAVERY),
                createSkill(AvailableSkills.MAGIC)
            );

            items.Add(ss);
            #endregion Frontiersmen

        }
    }  

    public class WeaponSystemLibrary_Scav : WeaponSystemLibrary{

        WeaponTraitLibrary wtl = new WeaponTraitLibrary();
        protected override void loadWeaponSystems(){
            #region DamageType
            //(int _minDamage, int _maxDamage, DamageType _dt, int _ArmourPenetration, OPTIONAL: DamageArea _da, int deviation)
            WeaponSystem.Damage smallArms = new WeaponSystem.Damage(1, 1, WeaponSystem.Damage.DamageType.KINETIC, 0);
            WeaponSystem.Damage smallArms_APOne = new WeaponSystem.Damage(1, 1, WeaponSystem.Damage.DamageType.KINETIC, 1);


            #endregion DamageType

            #region RangedWeapons
            //Ranged weapons
            //(string _name, Damage _damage, int _attacks, int _optimalRange, int _falloff, params WeaponTrait[] _traits)
            items.Add(new WeaponSystemRanged("Kinetic Rifle", smallArms, 1, 30, 10));
            items.Add(new WeaponSystemRanged("Kinetic PDW", smallArms, 1, 15, 5));

            items.Add(new WeaponSystemRanged("Kinetic HMG", smallArms, 6, 30, 10, wtl.getItem("Heavy")));
            #endregion RangedWeapons

            #region MeleeWeapons
            //Melee Weapons
            //(string _name, Damage _damage, params WeaponTrait[] _traits)
            items.Add(new WeaponSystemMelee("Unarmed", smallArms));
            items.Add(new WeaponSystemMelee("Standard Sword", smallArms_APOne));



            #endregion MeleeWeapons
        }
    }
}