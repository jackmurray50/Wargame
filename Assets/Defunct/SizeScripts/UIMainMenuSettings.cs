using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.UI{
public class UIMainMenuSettings : UISettings
{

    protected override void SetSettings(){  

        float ListBackdropWidth = Screen.width * .12f;
        float ListBackdropXOffset = Screen.width * .03f;
        s.Add(new Settings("ListBackdrop", ListBackdropWidth, Screen.height, ListBackdropXOffset, 0));
        

        //ListBackdrop's width is Screen.width * .25f, and since the size isn't recalculated until the end of this frame, I
        //replace the Listbackdrop width lookups with screen.width * .25f
        float menuItemWidth = ListBackdropWidth /1.5f;
        float menuItemHeight = Screen.height * 0.05f;        
        Vector2 menuItemOffset = new Vector2(ListBackdropWidth /6 +ListBackdropXOffset, menuItemHeight);
        float starterHeight = Screen.height * .85f;

        s.Add(new Settings("TitleText", ListBackdropWidth, //Name and width
            Screen.height * 0.05f, ListBackdropXOffset, //Height and X position
            Screen.height * .95f)); //Y position
        s.Add(new Settings("FindGameBtn", menuItemWidth,//Name and width
            menuItemHeight,  menuItemOffset.x, //Height and X position
            starterHeight - (menuItemHeight + menuItemOffset.y)*1)); //Y position
         s.Add(new Settings("ArmyListBtn", menuItemWidth,//Name and width
            menuItemHeight,  menuItemOffset.x, //Height and X position
            starterHeight - (menuItemHeight + menuItemOffset.y)*2)); //Y position
        s.Add(new Settings("ShopBtn", menuItemWidth,//Name and width
            menuItemHeight,  menuItemOffset.x, //Height and X position
            starterHeight - (menuItemHeight + menuItemOffset.y)*3)); //Y position
        s.Add(new Settings("SettingsBtn", menuItemWidth,//Name and width
            menuItemHeight,  menuItemOffset.x, //Height and X position
            starterHeight - (menuItemHeight + menuItemOffset.y)*4)); //Y position
        s.Add(new Settings("RulesBtn", menuItemWidth,//Name and width
            menuItemHeight,  menuItemOffset.x, //Height and X position
            starterHeight - (menuItemHeight + menuItemOffset.y)*5)); //Y position
        s.Add(new Settings("QuitBtn", menuItemWidth,//Name and width
            menuItemHeight,  menuItemOffset.x, //Height and X position
            starterHeight - (menuItemHeight + menuItemOffset.y)*6)); //Y position
    }

    
}

}