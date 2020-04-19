using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Books;



namespace Books{
    public abstract class Library<T> where T : Book
    {
        protected bool hasLoaded = false;
        protected List<T> items = new List<T>();

        public int getCount(){
            return items.Count;
        }
        public List<T> getItems(){
            return items;
        }
        public virtual T getItem(string name){
            if(!hasLoaded){
                //Debug.Log("Loading...." + typeof(T) + " Library");
                load();
                hasLoaded = true;
                }
            for(int i = 0; i < items.Count; i++){
                if(items[i].getName() == name || items[i].getName() == name + " 0"){
                    //Debug.Log("Item Found: " + name + " : " + typeof(T).ToString());
                    return (T)items[i];

                }
            }
            Debug.Log("<color=red>Item not found:</color>"+ name + " : " + typeof(T).ToString());
            return null;
        }
        public abstract void load();

    }
}
