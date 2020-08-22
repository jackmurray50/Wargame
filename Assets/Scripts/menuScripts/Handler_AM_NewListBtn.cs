using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler_AM_NewListBtn : MonoBehaviour
{
    //Enable AM_NewArmyView
    public int position {get; set;}

    [SerializeField]
    private WindowManager windowManager;
    public void OnClick(){
        //This just enables the new army view

        windowManager.SetState(WindowManager.States.ARMYMANAGER_NEWARMYVIEW);

    }
}
