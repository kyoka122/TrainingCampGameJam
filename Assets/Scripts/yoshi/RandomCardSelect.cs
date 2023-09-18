using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class RandomCardSelect : MonoBehaviour
{
    public bool isSelect;
    public List<int> compareNum ;
    private List<JumpObjectType> selectedCards = new List<JumpObjectType>();
    private bool isSelectStop = false;
    [SerializeField]
    Spawner spawner;

    // �J�[�h�̎�ނ�ݒ�
    private JumpObjectType[] cardTypes = {
        JumpObjectType.Marshmallow,
        JumpObjectType.Hopping,
        JumpObjectType.Trampoline,
        JumpObjectType.Dummy 
    };

    public void Init(int maxCardCount)
    {
        Debug.Log($"max:{maxCardCount}");
        compareNum = new List<int>(maxCardCount);
    }
    
    void Update()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
    }

    public void SelectCards(int cardCount)
    {
        for (int i = 0; i < cardCount; i++)
        {
            int rd = Random.Range(0, System.Enum.GetValues(typeof(JumpObjectType)).Length);
            JumpObjectType selectType = (JumpObjectType)rd;
            if (compareNum.Count<=i)
            {
                compareNum.Add(rd);
                continue;
            }
            

            compareNum[i] = rd;
            //compareNum.Add(rd);//Addし続けたら無限増殖。
            Debug.Log(compareNum[i]);
        }

        if (isSameCards(cardCount))
        {
            ChangeLastCard(cardCount);
        }
    }

    bool isSameCards(int cardCount)
    {
        for (int i = 1; i< cardCount; i++)
        {
            if (compareNum[i] != compareNum[0]) return false;
        }
        return true;
    }

    void ChangeLastCard(int cardCount)
    {
        int changeNum = Random.Range(1, System.Enum.GetValues(typeof(JumpObjectType)).Length);
        int afterNum = changeNum + (int)compareNum[0];
        if(afterNum > cardCount) 
        {
            afterNum -= cardCount;
        }
        compareNum[0] = afterNum;
        Debug.Log("change" + " " + compareNum[0]);
    }
}

