using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    [SerializeField] CardData cardData;
    [SerializeField] int level;
    [SerializeField] int numberOfCards;
    private int rd;

    public void AddCardData(JumpObject jumpObject)
    {
        cardData.jumpObjectLists.Add(jumpObject);
    }

    //ìÆçÏämîF
    void Start()
    {
        int count = cardData.jumpObjectLists.Count;

        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < level; j++)
            {
                JumpObject jumpObject = ScriptableObject.CreateInstance("JumpObject") as JumpObject;
                jumpObject = cardData.jumpObjectLists[i];
                Debug.Log(jumpObject.objectName);
            }

        }
    }
}

