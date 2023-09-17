using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    [SerializeField] CardData cardData;
    [SerializeField] int level;
    [SerializeField] int numberOfCards;
    [SerializeField] bool isRandom;
    private int rd;

    public void AddCardData(JumpObject jumpObject)
    {
        cardData.jumpObjectLists.Add(jumpObject);
    }

    //動作確認
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

    //動作確認
    void Update()
    {
        UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
        if (!isRandom)
        {
            isRandom = true;
        }
    }


    void RandomCardsSelect(int level)
    {
        for (int i = 0; i < numberOfCards; i++)
        {
            rd = Random.Range(0, level);
        }
    }
}

