using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Armies{
public class Handler_AM_ListBtn : MonoBehaviour
{

    [SerializeField]
    List<Sprite> armyLogos = new List<Sprite>();

    private bool hasArmy = false;
    public bool HasArmy(){
        return hasArmy;
    }
    private ArmyList army;
    public void SetValues(ArmyList _army){
        transform.GetComponent<Button>().enabled = false;

        transform.Find("Word Backdrop").Find("Name").GetComponent<TMPro.TextMeshProUGUI>().SetText(_army.GetName());
        transform.Find("Word Backdrop").Find("Cost").GetComponent<TMPro.TextMeshProUGUI>().SetText(_army.GetCost().ToString());
        transform.Find("AssaultCounting").Find("Text (TMP)").GetComponent<TMPro.TextMeshProUGUI>().SetText(_army.GetUnitCount(Books.Units.Squad.SquadType.ASSAULT).ToString());
        transform.Find("EliteCounting").Find("Text (TMP)").GetComponent<TMPro.TextMeshProUGUI>().SetText(_army.GetUnitCount(Books.Units.Squad.SquadType.ELITE).ToString());
        transform.Find("CommandCounting").Find("Text (TMP)").GetComponent<TMPro.TextMeshProUGUI>().SetText(_army.GetUnitCount(Books.Units.Squad.SquadType.COMMAND).ToString());
        transform.Find("ColossusCounting").Find("Text (TMP)").GetComponent<TMPro.TextMeshProUGUI>().SetText(_army.GetUnitCount(Books.Units.Squad.SquadType.COLOSSUS).ToString());
        transform.Find("GruntCounting").Find("Text (TMP)").GetComponent<TMPro.TextMeshProUGUI>().SetText(_army.GetUnitCount(Books.Units.Squad.SquadType.GRUNT).ToString());
        transform.Find("ArtilleryCounting").Find("Text (TMP)").GetComponent<TMPro.TextMeshProUGUI>().SetText(_army.GetUnitCount(Books.Units.Squad.SquadType.ARTILLERY).ToString());
        transform.Find("SuperHeavyCounting").Find("Text (TMP)").GetComponent<TMPro.TextMeshProUGUI>().SetText(_army.GetUnitCount(Books.Units.Squad.SquadType.SUPERHEAVY).ToString());
        transform.Find("FortificationCounting").Find("Text (TMP)").GetComponent<TMPro.TextMeshProUGUI>().SetText(_army.GetUnitCount(Books.Units.Squad.SquadType.FORTIFICATION).ToString());

        SetBackground(_army.GetFaction(0));
        army = _army;
        hasArmy = true;

    }


    private void SetBackground(ArmyList.Faction _faction){
        Image background = transform.Find("Background").GetComponent<Image>();
        switch (_faction){
            case ArmyList.Faction.NONE:
                background.sprite = armyLogos[0];
                break;
            case ArmyList.Faction.FRONTIERWORLDS:
                background.sprite = armyLogos[1];
                break;
            case ArmyList.Faction.UNITEDINNERPLANETS:
                background.sprite = armyLogos[2];
                break;
            case ArmyList.Faction.MEDUSAE:
                background.sprite = armyLogos[3];
                break;
            case ArmyList.Faction.CENTAUR:
                background.sprite = armyLogos[4];
                break;

        }
    }
    public void SetPlaceholder(){
        SetBackground(ArmyList.Faction.NONE);
        for(int i = 0; i < transform.childCount; i++){
            Transform t =  transform.GetChild(i);
            if(t.name != "Background"){
                t.gameObject.SetActive(false);
            }
        }

        transform.GetComponent<Button>().enabled = true;
    }
}
}