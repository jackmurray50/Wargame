using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.UI{
public abstract class UISettings : MonoBehaviour
{
    protected List<Settings> s = new List<Settings>();

    protected abstract void SetSettings();

    void Start(){
        //Set the scale of objects
        SetSettings();
        Rescale(s);
    }

    
    float screenWidth = Screen.width;
    float screenHeight = Screen.height;
    void update(){
        //If the screens width or height has changed
        if(screenWidth != Screen.width || screenHeight != Screen.height){
            Rescale(s);
            screenWidth = Screen.width;
            screenHeight = Screen.height;
        }
        
    }

    public void Rescale(List<Settings> _settings){
        foreach (Settings i in _settings){
            Transform UIElement = FindChildInHierarchy(transform, i.getName());
            UIElement.GetComponent<RectTransform>().sizeDelta = new Vector2(i.getWidth(), i.getHeight());
            UIElement.GetComponent<RectTransform>().position = new Vector3(i.getX(), i.getY(), 0);
        }
        
    }
    private Transform FindChildInHierarchy(Transform parent, string s){
        Transform[] children = GetComponentsInChildren<Transform>();
        foreach (Transform child in children){
            if(child.name == s){
                return child;
            }
        }
        return null;
    }
}

public class Settings
{
    private float width;
    private float height;
    private float xCoord;
    private float yCoord;
    private string name;
    public Settings(string n, float w, float h, float x, float y){
        name = n;
        width = w;
        height = h;
        xCoord = x;
        yCoord = y;
    }
    public string getName(){
        return name;
    }
    public float getWidth(){
        return width;
    }
    public float getHeight(){
        return height;
    }
    public float getX(){
        return xCoord;
    }
    public float getY(){
        return yCoord;
    }
}
}