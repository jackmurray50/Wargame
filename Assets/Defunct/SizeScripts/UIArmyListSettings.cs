using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.UI{
public class UIArmyListSettings : UISettings
{


    protected override void SetSettings(){
        float AM_ListBackdrop_width = Screen.width * .18f;

        float MainMenuWidth= Screen.width * .18f;
        float genericOffset = Screen.width * .01f;

        s.Add(new Settings("AM_ListBackdrop", AM_ListBackdrop_width, //Name and width
            Screen.height, MainMenuWidth , //Height and X position
            Screen.height)); //Y position

        s.Add(new Settings("AM_ViewerBackdrop", Screen.width - (genericOffset + MainMenuWidth + AM_ListBackdrop_width), //NAme and width
            Screen.height, MainMenuWidth + AM_ListBackdrop_width + genericOffset, //Height and X
            Screen.height)); //Y pos
        s.Add(new Settings("AM_NewListBtn", MainMenuWidth * .9f,
            Screen.height * 0.05f, MainMenuWidth +  genericOffset,
            0 + (Screen.height * 0.05f)));
    }
}
}