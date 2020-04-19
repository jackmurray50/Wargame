using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler_MainMenuBtn : MonoBehaviour
{
    //This is the menu element that'll be enabled and disabled on click.
    //The idea is to have all elements disabled by default.
    [SerializeField]
    private List<GameObject> menuElement = new List<GameObject>();
    [SerializeField]
    private int element;
    public void onClick(){
        //Enable the menu element GameObject
        menuElement[element].SetActive(true);
        for(int i = 0; i < menuElement.Count; i++){
            if(i != element){
                menuElement [i].SetActive(false);
            }
        }
    }
}