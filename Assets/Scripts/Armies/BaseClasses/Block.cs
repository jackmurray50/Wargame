using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Books;
public class Block : Book
{
    public int min {get;}
    public int max {get;}
    private int cost = 0;
    public bool IsDefault {get;}

    //The tag handles 

    public Block(string _name, int _min, int _max, int _cost) : base(_name){
        min = _min;
        max = _max;
        cost = _cost;
    }

    public Block(string _name, int _min, int _max, int _cost, bool _isDefault) : this(_name, _min, _max, _cost){
        IsDefault = _isDefault;
    }

    public int GetCost(){
        return cost;
    }

    
}
