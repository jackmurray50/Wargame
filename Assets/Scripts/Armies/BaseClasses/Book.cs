using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Books{
    public abstract class Book
    {
        protected string name;
        public virtual string getName(){
            return name;
        }
        public Book(string n){
            name = n;
        }
    }
}
