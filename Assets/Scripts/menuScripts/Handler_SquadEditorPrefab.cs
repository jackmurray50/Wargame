using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SLS.Widgets.Table;
using Books.Units;
using TMPro;

public class Handler_SquadEditorPrefab : MonoBehaviour
{
    //This is the table that'll hold the units stats. HP, AC, dex, int, so on.
    [SerializeField]
    private Table UnitTable;
    
    [SerializeField]
    private Table WeaponTable;


    //Setting this as SerializeField for debugging purposes.
    [SerializeField]
    //squad holds the squad that's currently being edited.
    private Squad squad;

    public void SetSquad(Squad _squad){
        squad = _squad;
        Populate();
    }


    void Start()
    {
    }

    private void Populate(){
        PopulateUnitTable();
        transform.Find("SquadName").GetComponent<TextMeshProUGUI>().SetText(squad.displayName);
        transform.Find("SquadCost").GetComponent<TextMeshProUGUI>().SetText(squad.GetCost().ToString());
    }

    private void PopulateUnitTable(){
        this.UnitTable.ResetTable();

        //Set up the columns
        this.UnitTable.AddTextColumn("Name");

        this.UnitTable.AddTextColumn("HP");
        this.UnitTable.AddTextColumn("Armour");

        this.UnitTable.AddTextColumn("Size");
        this.UnitTable.AddTextColumn("MVMT");

        this.UnitTable.AddTextColumn("STR");
        this.UnitTable.AddTextColumn("DEX");

        
        this.UnitTable.AddTextColumn("INT");
        this.UnitTable.AddTextColumn("DET");
        
        this.UnitTable.AddTextColumn("Amount");

        this.UnitTable.Initialize(this.OnTableSelected);

        //Populate the table with information
        for(int i = 0; i < squad.units.Count; i++){
            //The unit we're working with
            Unit unit = squad.units[i];
            Datum d = Datum.Body(i.ToString());
            d.elements.Add(unit.getName());
            d.elements.Add(unit.GetHP());
            d.elements.Add(unit.GetArmour());
            d.elements.Add(unit.GetSize());
            d.elements.Add(unit.GetMovement());
            d.elements.Add(unit.GetStrength());
            d.elements.Add(unit.GetDexterity());
            d.elements.Add(unit.GetIntelligence());
            d.elements.Add(unit.GetDetermination());
            d.elements.Add(unit.amount);
            
            this.UnitTable.data.Add(d);
        }

        //Draw the table
        this.UnitTable.StartRenderEngine();
    }

    private void OnTableSelected(Datum datum, Column column){

    }

}
