using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI{
public class UIFindGameSettings : UISettings
{
    protected override void SetSettings(){
        float MainMenuWidth= Screen.width * .18f;
        float genericOffset = Screen.width * .01f;

        s.Add(new Settings("GF_Backdrop", Screen.width - MainMenuWidth, Screen.height, MainMenuWidth, Screen.height));
        
    }
}
}