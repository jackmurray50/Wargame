using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Armies;

//A class used to handle the various buttons and details in the Unit panel.
//Each unit that has been added to the panel will create its own Unit gameobject. 
//It'll look at all the squads members, and display the posibilities. It'll need to
//Create 3 sets of views: Compact, Detailed, and Normal. It'll also need to be able to switch between them
//The majority of the information'll be held in the squad that is assigned to it when the  ArmyUnits or RosterUnits class creates this.
//The other information will be this objects current view state, which gameobjects need to be enabled/disabled/moved, so on.
//Finally, it'll need a 'Commit' button.
public class Handler_AM_Unit : MonoBehaviour
{

    private BuiltSquad squad;
    private enum View{
        DETAILED,
        COMPACT,
        NORMAL
    }

    public void SetSquad(BuiltSquad _squad){
        //TODO: Maybe make sure this can only be set once?
        squad = _squad;
    }
    void Start()
    {

        //First, load all the various GameObjects we'll need.
        //INSERT BIG GetComponent<T>() list here
        
        //Then load all the required information into them coming from the Squad class

        //If we're making a new squad, no need to do anything; a new BuiltSquad is already initialized.
        //If we're altering an existing one, use SetSquad()

        //Then, link all the buttons that add or reduce units and systems to this class, while keeping track of which unit/system they're handling
        //Probably do it index-based

        //Set the view to the default one (Usually normal) which'll get rid of all the unnecessary information

        //Double-check that the magic system isn't 
        SetView(View.NORMAL);
    }

    //Either increment or decrement a value. Useful if someone hits a plus or minus button (Or scrolls?)
    public void ChangeValue(int _index, bool _posOrNeg){

    }
    //Set a squads value to something
    public void Changevalue(int _index, int _amount){

    }


    private void SetView(View _view){
        switch (_view){
            case View.DETAILED:
                break;
            case View.COMPACT:
                break;
            case View.NORMAL:
                break;  
        
        }
    }


}
