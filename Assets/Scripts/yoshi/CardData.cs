using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "CardDataBase", menuName = "CreateCardDataBase")]
public class CardData : ScriptableObject
{
    public List<JumpObject> jumpObjectLists = new List<JumpObject>();

    public List<JumpObject> GetItemLists()
    {
        return jumpObjectLists;
    }
}
