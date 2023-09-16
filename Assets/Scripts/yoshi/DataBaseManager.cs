using System.Collections;
using System.Collections.Generic;
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
                Debug.Log(jumpObject.name + " " + jumpObject.id[j]);
            }

        }
    }

    //動作確認
    void Update()
    {
        if(!isRandom)
        {
            Debug.Log(RandomCardsSelect(level));
            isRandom = true;
        }
    }


    int RandomCardsSelect(int level)
    {
        for (int i = 0; i < numberOfCards; i++)
        {
            rd = Random.Range(0, level);
        }
        return rd;
    }
}

