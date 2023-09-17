using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCardSelect : MonoBehaviour
{
    [SerializeField] bool isRandom;
    private List<JumpObjectType> selectedCards = new List<JumpObjectType>();
    PoolManager poolManager;

    // ÉJÅ[ÉhÇÃéÌóﬁÇê›íË
    private JumpObjectType[] cardTypes = {
        JumpObjectType.Marshmallow,
        JumpObjectType.Hopping,
        JumpObjectType.Trampoline
    };

    void Update()
    {
        if (!isRandom)
        {
            UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);
            isRandom = true;
        }
        else
        {
            SelectCards();
        }
        isRandom = false;
    }

    void SelectCards()
    {
        for (int i = 0; i < cardTypes.Length; i++)
        {
            int rd = Random.Range(0, 6);
        }
    }
}
