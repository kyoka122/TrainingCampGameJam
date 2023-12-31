using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.SceneManagement;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    PoolManager poolManager;
    [SerializeField]
    List<GameObject> prefabs;
    [SerializeField]
    List<Transform> pos = new List<Transform>();
    Destroyer destroyer;
    public Dictionary<JumpObjectType, List<Destroyer>> spawnedData;
    [SerializeField] private RandomCardSelect select;
    public int spawnCount;
    [SerializeField] private int speedAndCardUpRate = 5;
    
    private int _jumpedCount=0;
    
    public void Init()
    {
        spawnedData = new Dictionary<JumpObjectType, List<Destroyer>>();
        select.Init(spawnCount);
        for (int i = 0; i < prefabs.Count; i++) Spawn(prefabs[i], (JumpObjectType)Enum.GetValues(typeof(JumpObjectType)).GetValue(i));

        //SetCard();
    }

    public void SetCard()
    {
        select.SelectCards(Math.Min(_jumpedCount/speedAndCardUpRate+2,spawnCount));

        int index = 0;
        foreach (int num in select.compareNum)
        {
            ActiveSwitch((JumpObjectType)Enum.GetValues(typeof(JumpObjectType)).GetValue(num), index);
            index++;
        }

        _jumpedCount++;
    }

    void Spawn(GameObject prefab, JumpObjectType type)
    {
        var destroyers = new List<Destroyer>();
        for (int i = 0; i < spawnCount; i++)
        {
            destroyer = poolManager.GetGameObject(prefab, pos[i].localPosition, Quaternion.identity).GetComponent<Destroyer>();
            destroyer.gameObject.SetActive(false);
            destroyers.Add(destroyer);
        }

        spawnedData.Add(type, destroyers);
    }

    public void ActiveSwitch(JumpObjectType type, int index)
    {
        spawnedData[type][index].gameObject.SetActive(true);
    }

    public class CardData
    {
        public int cardNum;
        public Destroyer destroyer;
    }
}
