using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Handler_AM_NAV : MonoBehaviour
{
    private int position;

    [SerializeField]
    WindowManager windowManager;
    public void OnClickFinishBtn(){
        //Create a new ArmyList and send it to the Roster Viewer


        //Open the Roster panel
        //Hide the new army background
        //transform.parent.gameObject.SetActive(false);
        //Hide the roster list
        //transform.parent.parent.Find("AM_ListBackdrop").gameObject.SetActive(false);
        
        //Show the Roster Viewer
        //transform.parent.parent.Find("AM_ViewerBackdrop").gameObject.SetActive(true); 

        windowManager.SetState(WindowManager.States.ARMYMANAGER_ARMYVIEWER);
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
    
    //Sets the position of the roster in the armylist, so that when/if a roster is saved it'll be saved to the right position.
    public void OnSetActive(int _position){
        position = _position;
    }

    //Since there'll be multiple types of Rosters, depending on which armies it is composed of, there will be more than one
    //roster subclass. The CreateRoster method selects the subclass and returns a new roster will all the proper information
    private Armies.Roster CreateRoster(){
        //TODO: Properly implement
        return new Armies.Roster("", position);

    }
}
