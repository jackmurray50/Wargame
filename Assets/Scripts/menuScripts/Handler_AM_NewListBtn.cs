using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler_AM_NewListBtn : MonoBehaviour
{
    //Enable AM_NewArmyView
    public void OnClick(){
        //This just enables the new army view

        Transform newArmyView = transform.parent.parent.Find("AM_NewArmyView");

        newArmyView.gameObject.SetActive(true);
    }
}
