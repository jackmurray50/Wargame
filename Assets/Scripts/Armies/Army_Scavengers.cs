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
    public class FrontierSquadLibrary : Library<SquadBlock>{
        FrontierUnitLibrary ul = new FrontierUnitLibrary();

        public override void load(){
            SquadBlock newSquad;

            //Create a new squad
            #region Squad_Scavenger
            newSquad = new SquadBlock("Scavengers", SquadBlock.SquadType.GRUNT);
                newSquad.AddUnits(ul.getItem("Scavenger"));
                //Scavenger options:
                    //Armour can be either Kevlar or Dyneema, with Kevlar being the default
                    //Weapons can be either SMG or rifle
                    //Can have 1 flamethrower, anti-material rifle, or mortar
                    //Can add in a scavenger mage and foreman

                //SquadOptions represent modifications that you can do to a unit.
                newSquad.AddSquadOptions(
                    new SquadOption("Scavenger_Dyneema", "Add Dyneema", (s, b) => {
                        //This option adds Dyneema

                        //Get the units that are going to be altered
                        List<Unit> affectedUnits = new List<Unit>();
                        affectedUnits.Add(s.GetUnit("Scavenger"));
                        affectedUnits.Add(s.GetUnit("Scavenger Foreman"));
                        affectedUnits.Add(s.GetUnit("Scavenger Mage"));

                        //go through the units to be altered, remove their current armour and put Dyneema into the slot
                        foreach (Unit x in affectedUnits){
                            x.ClearSocket("Armor");
                            //The 2nd parameter grabs the Dyneema system from the unit, from the squad
                            x.AddSystemToSocket("Armor", b.GetUnitBlock("Scavenger").GetSystemBlock("Dyneema").GetSystem());
                        }
                    },
                    (s, b) =>{
                        //This code reverts the option
                        List<Unit> affectedUnits = new List<Unit>();
                        affectedUnits.Add(s.GetUnit("Scavenger"));
                        affectedUnits.Add(s.GetUnit("Scavenger Foreman"));
                        affectedUnits.Add(s.GetUnit("Scavenger Mage"));

                        //go through the units to be altered, remove their current armour and put Kevlar into the slot
                        foreach (Unit x in affectedUnits){
                            x.ClearSocket("Armor");
                            //The 2nd parameter grabs the Dyneema system from the unit, from the squad
                            x.AddSystemToSocket("Armor", b.GetUnitBlock("Scavenger").GetSystemBlock("Kevlar").GetSystem());
                        }

                    }),
                    
                    new SquadOption("Scavenger_Foreman", "Add a Scavenger Foreman", (s, b) =>{
                        s.AddUnit(b.GetUnitBlock("Scavenger_Foreman").CreateDefaultUnit());
                    },
                    (s, b) =>{
                        s.RemoveUnit("Scavenger_Foreman");
                    }),
                    new SquadOption("Scavenger_Mage", "Add a Scavenger Mage", (s, b) =>
                    {
                        s.AddUnit(b.GetUnitBlock("Scavenger_Mage").CreateDefaultUnit());
                    },
                    (s, b) =>
                    {
                        s.RemoveUnit("Scavenger_Mage");
                    })

                );
                //End of AddSquadOptions
                items.Add(newSquad);
                #endregion Squad_Scavenger


        }
    }

    public class FrontierUnitLibrary : Library<UnitBlock>
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

            newUnit = new UnitBlock("Scavenger", true, 5, 20);
                //First, create the SocketBlocks. These are essentially 'inventory slots'. 
                newUnit.AddSocketBlock(new SocketBlock("Armour", 1, Socket.SocketType.SCALING, Socket.SocketType.MAIN));
                newUnit.AddSocketBlock(new SocketBlock("Movement", 1, Socket.SocketType.SCALING, Socket.SocketType.MAIN));
                newUnit.AddSocketBlock(new SocketBlock("Stats", 1, Socket.SocketType.SCALING, Socket.SocketType.MAIN));
                newUnit.AddSocketBlock(new SocketBlock("Melee Weapon", 1, Socket.SocketType.SCALING, Socket.SocketType.MAIN));
                newUnit.AddSocketBlock(new SocketBlock("Ranged Weapon", 1, Socket.SocketType.SCALING, Socket.SocketType.MAIN));
                newUnit.AddSocketBlock(new SocketBlock("Support Weapon", 1));

                //Add in all the potential systems, making sure to mark the default systems as 'true'
                newUnit.AddSystems(
                    //Armour systems
                    new UnitSystemBlock("Kevlar", asl.getItem("Kevlar"), true, 0, "Armour"),
                    new UnitSystemBlock("Dyneema", asl.getItem("Dyneema"), false, 2, "Armour"),

                    //Movement systems
                    new UnitSystemBlock("Infantry 5", mosl.getItem("Infantry 5"), true, 0, "Movement"),

                    //Stats Systems
                    new UnitSystemBlock("Scavenger", ssl.getItem("Scavenger"), true, 0, "Stats"),

                    //Melee Weapon
                    new UnitSystemBlock("Unarmed", wsl.getItem("Unarmed"), true, 0, "Melee Weapon"),
                    //new UnitSystemBlock("Bayonet", wsl.getItem("Bayonet"), false, 1, "Melee Weapon"),

                    //Ranged Weapon
                    new UnitSystemBlock("Kinetic Rifle", wsl.getItem("Kinetic Rifle"), true, 0, "Ranged Weapon")//,
                    //new UnitSystemBlock("Kinetic SMG", wsl.getItem("Kinetic SMG"), false, 1, "Ranged Weapon"),

                    //Support Weapon
                    //new UnitSystemBlock("Heavy Flamethrower", wsl.getItem("Heavy Flamethrower"), false, 5, "Support Weapon", 0, 1),
                    //new UnitSystemBlock("Knee Mortar", wsl.getItem("Knee Mortar"), false, 5, "Support Weapon", 0, 1),
                    //new UnitSystemBlock("Anti Material Rifle", wsl.getItem("Anti Material Rifle"), false, 2, "Support Weapon", 0, 2)

                );
                //CRUCIAL STEP
                //Adds the unit to the library of units
                items.Add(newUnit);
            #region Scavenger
                
               
            #endregion Scavenger
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

        }

        protected override void loadSpellBooks(){

        }
        protected override void loadSpells(){

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
            items.Add(new WeaponSystemRanged("Kinetic Rifle", smallArms, 1, 30, 10));
            #endregion RangedWeapons

            #region MeleeWeapons
            //Melee Weapons
            //(string _name, Damage _damage, params WeaponTrait[] _traits)
            items.Add(new WeaponSystemMelee("Unarmed", smallArms));



            #endregion MeleeWeapons
        }
    }
}