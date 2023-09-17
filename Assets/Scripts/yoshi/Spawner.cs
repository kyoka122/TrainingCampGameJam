using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    PoolManager poolManager;
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    List<Transform> pos = new List<Transform>();
    Destroyer destroyer;
    public List<Destroyer> spawnedData;
    RandomCardSelect randomCardSelect = new RandomCardSelect();
    public int spawnCount;

    void Start()
    {
        spawnedData = new List<Destroyer>(spawnCount);

        Spawn(prefab);
    }

    void Spawn(GameObject prefab)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            destroyer = poolManager.GetGameObject(prefab, pos[i].localPosition, Quaternion.identity).GetComponent<Destroyer>();
            destroyer.gameObject.SetActive(false);
            spawnedData.Add(destroyer);
        }
    }

    public void ActiveSwitch(int cardNum)
    {
        spawnedData[cardNum].gameObject.SetActive(true);
    }

    public class CardData
    {
        public int cardNum;
        public Destroyer destroyer;
    }
}
