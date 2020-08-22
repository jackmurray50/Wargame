using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Books.Units;
public class UnitSelectorManager : MonoBehaviour
{
    private Squad squad;
    public void SetUnit(Squad _squad){
        squad = _squad;
        transform.GetComponentInChildren<TMPro.TextMeshProUGUI>().SetText(_squad.getName());

    }

    public Squad GetUnit(){
        //Returns a copy of the Squad
        return System.ObjectExtensions.Copy(squad);
    }
}
