using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    private MapData map;


    //Constructor for gamesettings.
    public GameSettings(MapData map){
        this.map = map;
    }

    public int getWidth(){
        return map.getWidth();
    }

    void Start()
    {
        
    }
}
