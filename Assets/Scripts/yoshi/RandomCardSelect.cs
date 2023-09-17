using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class RandomCardSelect : MonoBehaviour
{
    public int cardNum;
    public bool isSelect;
    public List<int> compareNum = new List<int>();
    private List<JumpObjectType> selectedCards = new List<JumpObjectType>();
    private bool isSelectStop = false;
    [SerializeField]
    Spawner spawner;

    // ÉJÅ[ÉhÇÃéÌóﬁÇê›íË
    private JumpObjectType[] cardTypes = {
        JumpObjectType.Marshmallow,
        JumpObjectType.Hopping,
        JumpObjectType.Trampoline
    };

    void Start()
    {
        //SelectCards();
    }
    void Update()
    {
        UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);

        //if (isSelect) {
          //  for (int i = 0; i < cardNum; i++)
            //{
              //  spawner.ActiveSwitch(compareNum[i]);
            //}
        //}
        //isSelect = false;
    }

    public void SelectCards()
    {
        for (int i = 0; i < cardNum; i++)
        {
            int rd = Random.Range(0, System.Enum.GetValues(typeof(JumpObjectType)).Length);
            JumpObjectType selectType = (JumpObjectType)rd;
            compareNum.Add(rd);
            Debug.Log(compareNum[i]);
        }

        if (isSameCards())
        {
            ChangeLastCard();
        }
    }

    bool isSameCards()
    {
        for (int i = 1; i< cardNum; i++)
        {
            if (compareNum[i] != compareNum[0]) return false;
        }
        return true;
    }

    void ChangeLastCard()
    {
        int changeNum = Random.Range(1, System.Enum.GetValues(typeof(JumpObjectType)).Length);
        int afterNum = changeNum + (int)compareNum[0];
        if(afterNum > cardNum) 
        {
            afterNum -= cardNum;
        }
        compareNum[0] = afterNum;
        Debug.Log("change" + " " + compareNum[0]);
    }
}

