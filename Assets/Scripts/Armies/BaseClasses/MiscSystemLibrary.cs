using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Books;
using Books.Traits;
using UnitSystems.MiscSystems;

namespace UnitSystems.MiscSystems{
    public class MiscSystemLibrary : Library<MiscSystem>
    {
        public override void load(){
            LoadMiscSystems();
        }

        protected virtual void LoadMiscSystems(){

        }
    }
}