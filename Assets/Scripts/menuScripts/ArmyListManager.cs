using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Books;
using Books.Units;

//ArmyListManager is responsible for populating the ArmyUnits UI section with all the possible units, after taking in the armies to be used.
public class ArmyListManager : MonoBehaviour
{
    [SerializeField]
    private GameObject destinationObject;
    [SerializeField]
    private Transform prefab; 

    //The armies being used
    private List<Library<Squad>> ArmyLists = new List<Library<Squad>>();
    public void LoadPage(int _page){
        Transform UnitTab;
        for(int i = 0; i < ArmyLists[_page].getCount(); i++){
            UnitTab = Instantiate(prefab, destinationObject.transform.position - new Vector3(0, 110 * i, 0), Quaternion.identity, destinationObject.transform);
            //Insert code to update the unit tab's info 
            UnitTab.GetComponent<UnitSelectorManager>().SetUnit(ArmyLists[_page].getItems()[i]);
        }
    }

    void Start(){
        //TODO: Remove this bit of code, its just used for testing
        ArmyLists = new List<Library<Squad>>();
        Library<Squad> test = new Armies.Frontier.FrontierSquadLibrary();
        ArmyLists.Add(test);
        LoadPage(0);
    }
    //Constructor that adds Armies to the ArmyList
    public ArmyListManager(params Library<Squad>[] _ArmyLists){
        ArmyLists = new List<Library<Squad>>();
        for(int i = 0; i < _ArmyLists.Length; i++){
            ArmyLists.Add(_ArmyLists[i]);
        }

        //TODO: Remove this bit of code, its just used for testing
        Library<Squad> test = new Armies.Frontier.FrontierSquadLibrary();
        ArmyLists.Add(test);
        Debug.Log(test.ToString());
        LoadPage(0);
        //End todo


    }
}
