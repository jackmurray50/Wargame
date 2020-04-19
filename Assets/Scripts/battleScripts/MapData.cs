using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData
{
    int height;
    int width;

    public MapData(int _width, int _height){
        this.height = _height;
        this.width = _width;
    }

    public int getWidth(){
        return width;
    }
    public int getHeight(){
        return height;
    }
}
