using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Books;
public class Block : Book
{
    private int min;
    private int max;
    private int cost;
    public bool IsDefault {get;}

    //The tag handles 

    public Block(string _name, int _min, int _max, int _cost) : base(_name){
        min = _min;
        max = _max;
        cost = _cost;
    }

    public int GetCost(){
        return cost;
    }

    
}
