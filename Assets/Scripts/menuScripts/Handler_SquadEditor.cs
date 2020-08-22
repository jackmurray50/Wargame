using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Books.Units;

//SquadEditor is used to create SquadEditorPrefabs, populate them with data, and in general handle them.
public class Handler_SquadEditor : MonoBehaviour
{
    [SerializeField]
    private Transform SquadEditorPrefab;

    //position does nothing for now, its just setting up for drag+drop functionality in the future.
    public void InstantiateSquad(Squad _squad, int position){
        Instantiate(SquadEditorPrefab, new Vector3(1,1,1) , Quaternion.identity);
    }

}
