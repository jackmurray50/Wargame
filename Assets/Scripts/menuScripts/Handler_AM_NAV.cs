using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Handler_AM_NAV : MonoBehaviour
{
    public void OnClickFinishBtn(){
        gameObject.transform.parent.gameObject.SetActive(false);
        //Create a new ArmyList

        //Open the Roster panel
    }

    public void OnChangeFactionSelectorDropdown(){
        Transform dropdown = transform.Find("FactionSelectorDropdown");
        Debug.Log("Faction is now " + dropdown.Find("Label").GetComponent<TextMeshProUGUI>().text);

        Transform traitBox = transform.Find("FactionTraitLbl");
        if(dropdown.GetComponent<TMP_Dropdown>().value == 0){
            traitBox.GetComponent<TextMeshProUGUI>().text = "A Thousand Planets, A Single Army: \nGain a reduction in cost when purchasing multiple units of the same type";
        }else if(dropdown.GetComponent<TMP_Dropdown>().value == 1){
            traitBox.GetComponent<TextMeshProUGUI>().text = "Melting Pot: An Outer Frontier army can select two secondary factions, and their army can be up to 25% auxiliaries";
            //TODO: Let the Scavenger faction pick a 2nd auxiliary
        }
    }
}
