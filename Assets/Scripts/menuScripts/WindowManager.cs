using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    //this enum will be used to select which state to enter into.
    public enum States{
        ARMYMANAGER_ARMYLISTS,
        ARMYMANAGER_ARMYVIEWER,
        ARMYMANAGER_NEWARMYVIEW,
    }

    //The following variables hold the relevant Transforms from the scene. They're manually drag+dropped from the Editor.
    #region Transforms
    [SerializeField]
    private Transform Canvas_ArmyManager;

    [SerializeField]
    private Transform Canvas_MainMenu;

    [SerializeField]
    private Transform Canvas_GameFinder;

    [SerializeField]
    private Transform AM_NAV;
    [SerializeField]
    private Transform AM_ListBackdrop;
    [SerializeField]
    private Transform AM_ViewerBackdrop;

    #endregion Transforms

    public void SetState(States _state){
        switch(_state){
            case States.ARMYMANAGER_ARMYLISTS: 
                ArmyManager_ArmyLists();
                break;  
            case States.ARMYMANAGER_ARMYVIEWER:
                ArmyManager_ArmyViewer();
                break;
            case States.ARMYMANAGER_NEWARMYVIEW:
                ArmyManager_NewArmyView();
                break;
            default:
                break;

        }
    }

    private void CloseAll(){
        Canvas_GameFinder.gameObject.SetActive(false);
        Canvas_MainMenu.gameObject.SetActive(false);
        Canvas_ArmyManager.gameObject.SetActive(false);
    }

    private void ArmyManager_ArmyLists(){
        CloseAll();
        Canvas_MainMenu.gameObject.SetActive(true);
        Canvas_ArmyManager.gameObject.SetActive(true);

    }

    private void ArmyManager_ArmyViewer(){
        AM_NAV.gameObject.SetActive(false);
        AM_ListBackdrop.gameObject.SetActive(false);
        AM_ViewerBackdrop.gameObject.SetActive(true);

    }

    private void ArmyManager_NewArmyView(){
        AM_NAV.gameObject.SetActive(true);
        
    }
}
