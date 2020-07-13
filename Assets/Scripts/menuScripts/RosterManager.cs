using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Armies;
using Armies.Frontier;

public class RosterManager : MonoBehaviour
{

    void Start(){
        LoadArmiesFromFile();
        DisplayArmies(currentPage);
    }
    //The index of the page the player is currently looking at
    int currentPage = 0;
    //The list of armies that have been created
    //Each List will have a maximum size of 14, and they'll represent pages
    public List<List<Roster>> rosters = new List<List<Roster>>();

    [SerializeField]
    private List<Transform> ArmyButtons = new List<Transform>();

    //Load in the already-created armies from local
    public void LoadArmiesFromFile(){
        FrontierSquadLibrary fsl = new FrontierSquadLibrary();
        rosters.Add(new List<Roster>());
        Roster test = new Roster("Test One", 0, Roster.Faction.FRONTIERWORLDS);
        test.AddSquad(System.ObjectExtensions.Copy(fsl.getItem("Frontiersmen")), "Test Frontiersmen");

        Debug.Log(test.GetSquad("Test Frontiersmen"));
        test.GetSquad("Test Frontiersmen").GetOption("Dyneema").implement(test.GetSquad("Test Frontiersmen"));
        Debug.Log(test.GetSquad("Test Frontiersmen"));
        test.AddSquad(System.ObjectExtensions.Copy(fsl.getItem("Frontiersmen")), "Test Frontiersmen 2");
         Debug.Log(test.GetSquad("Test Frontiersmen 2"));

        rosters[0].Add(test);              

    }

    //Load in the already-created armies from the server
    public void LoadArmiesFromServer(){

    }

    private void DisplayArmies(int _page){
        //Check if the page can exist
        if(rosters.Count > _page){ 
            //There's 14 possible slots for armies, so go through Armies
            int i = 0;
            //Go until you've reached the end of the Armies list 
            for(; i < rosters[_page].Count; i++){

                ArmyButtons[rosters[_page][i].GetPosition()].GetComponent<Handler_AM_ListBtn>().SetValues(rosters[_page][i]);
            }
        }else{ 
            //Page doesn't exist, throw an error
        }
        //Set all the remaining armybuttons to the placeholder
        for(int i = 0; i < 15; i++){ //Cycle through all the buttons
            if(!ArmyButtons[i].GetComponent<Handler_AM_ListBtn>().HasArmy()){
                ArmyButtons[i].GetComponent<Handler_AM_ListBtn>().SetPlaceholder();
            }
        }
    }


    //The save button will be in its own handler
}